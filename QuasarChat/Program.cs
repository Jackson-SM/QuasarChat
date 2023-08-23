using System.Net.Sockets;

namespace QuasarChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(3000);
            server.Start();

            while(true)
            {
                Console.WriteLine("Observando Conexões...");
                Socket connection = server.AcceptSocket();
            }
        }
    }
}