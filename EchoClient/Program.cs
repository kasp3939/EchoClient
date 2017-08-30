using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;


namespace EchoClient
{
    class Program
    {

        Thread newClient;
        static void Main(string[] args)
        {
            Program C = new Program();
            C.Client();
        }

        public void Client()
        {
            Console.WriteLine("Client ready");


            TcpClient client = new TcpClient("localhost", 11000);
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

            while (true)
            {

                Console.WriteLine("Enter to send: ");
                string LineToSend = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Sending an Echo " + LineToSend);
                writer.WriteLine(LineToSend);
                Console.WriteLine("");
                string lineReceived = reader.ReadLine();
                Console.WriteLine("Received an " + lineReceived);
                Console.WriteLine("");

            }

        }
    }
}
