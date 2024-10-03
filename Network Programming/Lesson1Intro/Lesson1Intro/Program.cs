using System.Net;
using System.Net.Sockets;
using System.Text;


//var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
//var ipAddress = IPAddress.Parse("172.217.17.142");
//var port = 80;
//var endPoint = new IPEndPoint(ipAddress, port);
//try
//{
//    socket.Connect(endPoint);
//    if(socket.Connected)
//    {
//        var str = "GET\r\n\r\n";
//        var bytes = Encoding.ASCII.GetBytes(str);
//        socket.Send(bytes);

//        var length = 0;
//        var buffer = new byte[1024];
//        do
//        {
//            length = socket.Receive(buffer);
//            var response = Encoding.ASCII.GetString(buffer);
//            Console.WriteLine(response);
//            Thread.Sleep(200);

//        } while (0 < length);

//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//var client = new HttpClient();

//var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
//await Console.Out.WriteLineAsync(result);
