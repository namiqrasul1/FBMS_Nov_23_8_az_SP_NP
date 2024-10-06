﻿using System.Net.Sockets;
using System.Net;
using System.Text;

using var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

var ipAddress = IPAddress.Parse("10.1.18.1");
var port = 27001;

var endPoint = new IPEndPoint(ipAddress, port);


try
{
    server.Connect(endPoint);
    if (server.Connected)
    {
        _ = Task.Run(() =>
        {
            var bytes = new byte[1024];
            var len = 0;
            var msg = string.Empty;

            do
            {
                
                len = server.Receive(bytes);
                msg = Encoding.UTF8.GetString(bytes, 0, len);
                Console.WriteLine($"{server.RemoteEndPoint}: {msg}");
                

            } while (0 < len);
        });

        while (true)
        {
            var msg = Console.ReadLine();
            var bytes = Encoding.UTF8.GetBytes(msg!);
            server.Send(bytes);

        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}