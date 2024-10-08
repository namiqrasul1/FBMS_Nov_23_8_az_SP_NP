using ServerSide.Example;
using System.Net;
using System.Net.Sockets;

Console.WriteLine("server");

var ip = IPAddress.Parse("10.1.18.1");
var port = 27001;
var ep = new IPEndPoint(ip, port);

var listener = new TcpListener(ep);

try
{
    listener.Start();
    while (true)
    {
        var client = listener.AcceptTcpClient();
        _ = Task.Run(() =>
        {
            var stream = client.GetStream();
            var path = "someImage.png";

            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                int len = 0;
                var bytes = new byte[1024];
                while ((len = stream.Read(bytes, 0, bytes.Length)) > 0)
                {
                    fs.Write(bytes, 0, len);
                }
            }
            Console.WriteLine("File Recieved!");
            client.Close();
        });

    }
}
catch (Exception ex)
{
    // logger
    Console.WriteLine(ex.Message);
}

//using FileStreamWriteAdapter adapter = new("text.txt");

//adapter.Write("salam");
//adapter.Write(42);