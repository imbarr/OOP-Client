using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OOP_Client
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var data = Console.ReadLine();
                if (data == null)
                    continue;
                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(IPAddress.Parse("127.0.0.1"), 40000);
                socket.Send(Encoding.UTF8.GetBytes(data.Length + " " + data));
                var response = new byte[1024];
                socket.Receive(response);
                socket.Close();
                Console.WriteLine(Encoding.UTF8.GetString(response));
            }
        }
    }
}