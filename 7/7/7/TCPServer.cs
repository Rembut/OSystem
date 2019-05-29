using System;
using System.Text;
using System.Net.Sockets;
using System.Net;


namespace TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] message_Read = new byte[256];
            string data = null;

            try
            {
                IPAddress localAddress = IPAddress.Parse("127.0.0.1");
                TcpListener listener = new TcpListener(localAddress, 7777);

                listener.Start(1);

                while (true)
                {
                    Console.WriteLine("Server waiting {0}", listener.LocalEndpoint);
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream io = client.GetStream();

                    Console.WriteLine("Accepted connection from {0}", client.Client.RemoteEndPoint);

                    int i = io.Read(message_Read, 0, message_Read.Length);
                    data = System.Text.Encoding.UTF8.GetString(message_Read, 0, i);
                    Console.WriteLine("Accepted message from {0}: {1}", client.Client.RemoteEndPoint, data);
                    Console.WriteLine();

                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка {0}", e.Message);
            }
        }
    }
}
