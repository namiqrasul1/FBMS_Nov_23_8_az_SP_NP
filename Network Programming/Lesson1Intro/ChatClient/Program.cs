using System.Net;
using System.Net.Sockets;
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

		while (true)
		{
			var msg = Console.ReadLine();
			var bytes = Encoding.UTF8.GetBytes(msg!);
			server.Send(bytes);
		}
	}
	else Console.WriteLine("Cannot connect");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}