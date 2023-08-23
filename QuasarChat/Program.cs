using System.Net.Sockets;

namespace QuasarChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(3000);
            server.Start();


            Console.WriteLine("Aceitando Conexões...");
            Socket connection = server.AcceptSocket();

            NetworkStream socketStream = new NetworkStream(connection);

            BinaryWriter write = new BinaryWriter(socketStream);
            BinaryReader reader = new BinaryReader(socketStream);

            server.Stop();

        }
    }
}