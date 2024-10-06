using System.Net;
using System.Net.Sockets;

var port = 27001;
var ipAddress = IPAddress.Parse("10.1.18.1");
var ep = new IPEndPoint(ipAddress, port);

using var listener = new TcpListener(ep);
try
{
    listener.Start();
    while (true)
    {
        var client = listener.AcceptTcpClient();
        _ = Task.Run(() =>
        {
            Console.WriteLine($"{client.Client.RemoteEndPoint} connected");
            var stream = client.GetStream();
            var sr = new StreamReader(stream);
            while (true)
            {
                var message = sr.ReadLine();
                Console.WriteLine($"{client.Client.RemoteEndPoint}: {message}");
            }

        });
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

