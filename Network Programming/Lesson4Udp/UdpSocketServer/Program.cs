using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Server");

var ip = IPAddress.Parse("10.1.18.1");
var port = 27001;

var endPoint = new IPEndPoint(ip, port);

using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

socket.Bind(endPoint);

var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0); // 0.0.0.0

var bytes = new byte[socket.ReceiveBufferSize];

var segment = new ArraySegment<byte>(bytes);

while (true)
{
    var response = await socket.ReceiveFromAsync(segment, SocketFlags.None, remoteEndPoint);
    var rep = response.RemoteEndPoint;
    var len = response.ReceivedBytes;
    var msg = Encoding.UTF8.GetString(bytes, 0, len);
    Console.WriteLine($"{rep}: {msg}");
}


