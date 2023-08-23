using System.Net;
using System.Net.Sockets;

namespace QuasarChat
{
    internal class Program
    {

        static List<BinaryWriter> clients = new List<BinaryWriter>();
        static void Main(string[] args)
        {
            string ipAddress = "127.0.0.1";
            int port = 3000;
            TcpListener server = new TcpListener(IPAddress.Parse(ipAddress), port);
            server.Start();

            Console.WriteLine("Aceitando Conexões...");

            while (true)
            {

                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Novo cliente conectado.");

                NetworkStream clientStream = client.GetStream();
                BinaryWriter writer = new BinaryWriter(clientStream);

                clients.Add(writer);

                HandleClientMessages(clientStream);
            }

            server.Stop();

        }

        static void HandleClientMessages(NetworkStream clientStream)
        {
            BinaryReader reader = new BinaryReader(clientStream);
            while(true)
            {
                try
                {
                    string message = reader.ReadString();
                    Console.WriteLine($"Mensagem Recebida: {message}");

                    foreach(var client in clients)
                    {
                        try
                        {
                            client.Write(message);
                            client.Flush();
                        } 
                        catch (Exception e)
                        {
                            client.Write("Não foi possível carregar a mensagem.");
                        }
                    }
                } 
                catch(Exception e)
                {
                    break;
                }
            }

            BinaryWriter writerToRemove = clients.Find(writer => writer.BaseStream == clientStream);
            if(writerToRemove != null)
            {
                clients.Remove(writerToRemove);
            }
            clientStream.Close();
        }
    }
}