using System.Net.Sockets;

namespace QuasarClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 3000);

            NetworkStream outStream = client.GetStream();

            BinaryWriter writer = new BinaryWriter(outStream);
            BinaryReader reader = new BinaryReader(outStream);

            client.Close();
        }
    }
}