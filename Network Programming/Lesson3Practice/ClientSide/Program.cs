using System.Net;
using System.Net.Sockets;

Console.WriteLine("Client");

var port = 27001;
var ip = IPAddress.Parse("10.1.18.1");
var ep = new IPEndPoint(ip, port);

var client = new TcpClient();

try
{
    client.Connect(ep);
    if (client.Connected)
    {
        //var path = @"C:\Users\namiqrasullu\Desktop\homework.png";
        var path = @"C:\Users\namiqrasullu\Desktop\Инструкция_Teams.pdf";
        var networkStream = client.GetStream();
        using (var readFs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            var buffer = new byte[1024];
            var len = 0;

            while ((len = readFs.Read(buffer, 0, buffer.Length)) > 0)
            {
                networkStream.Write(buffer, 0, len);
            }
        }
        networkStream.Close();
        client.Close();
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

