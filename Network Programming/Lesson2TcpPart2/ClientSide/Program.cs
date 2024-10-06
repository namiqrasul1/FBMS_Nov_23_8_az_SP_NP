using System.Net;
using System.Net.Sockets;

var port = 27001;
var ipAddress = IPAddress.Parse("10.1.18.1");
var ep = new IPEndPoint(ipAddress, port);

var client = new TcpClient();

try
{
    client.Connect(ep);
    if (client.Connected)
    {
        var sw = new StreamWriter(client.GetStream())
        {
            AutoFlush = true
        };
        while (true)
        {
            var msg = Console.ReadLine();
            sw.WriteLine(msg);
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}