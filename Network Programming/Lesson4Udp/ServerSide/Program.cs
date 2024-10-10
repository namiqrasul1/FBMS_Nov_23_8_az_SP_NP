using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("server");

//var endPoint = new IPEndPoint(IPAddress.Parse("10.1.18.1"), 27001);

var server = new UdpClient(27001); // IPAddress.Loopback => 127.0.0.1
//var server = new UdpClient(endPoint); 
var remoteEp = new IPEndPoint(IPAddress.Any, 0); // 0.0.0.0

while (true)
{
    var bytes = server.Receive(ref remoteEp);
    var str = Encoding.UTF8.GetString(bytes);
    Console.WriteLine($"{remoteEp}: {str}");
}