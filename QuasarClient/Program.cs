using System.Net.Sockets;

namespace QuasarClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 3000);

            while(true)
            {
                NetworkStream outStream = client.GetStream();

                BinaryWriter writer = new BinaryWriter(outStream);
                BinaryReader reader = new BinaryReader(outStream);

                Console.Write("Mensagem: ");
                string message = Console.ReadLine();

                writer.Write(message);
            }

            client.Close();
        }
    }
}