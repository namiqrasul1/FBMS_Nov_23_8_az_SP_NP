using System.Net;

namespace Lesson5Http;

class WebHost
{
    private int _port;
    private HttpListener _listener;

    public WebHost(int port)
    {
        _port = port;
    }

    public void Run()
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://localhost:{_port}/"); // 127.0.0.1
        _listener.Start();

        Console.WriteLine($"Http server started on {_port}");

        while (true)
        {
            var context = _listener.GetContext();
            Task.Run(() => { HandleRuquest(context); });
        }
    }

    private void HandleRuquest(HttpListenerContext context)
    {
        Console.WriteLine(context.Request.RawUrl);
        //Console.WriteLine(context.Request.RemoteEndPoint);
        //Console.WriteLine(context.Request.ContentType);
        //Console.WriteLine(context.Request.AcceptTypes);
        //Console.WriteLine(context.Request.HttpMethod);


        var queryStrings = context.Request.QueryString;

        foreach (string key in queryStrings)
        {
            Console.WriteLine(queryStrings[key]);
        }


        var str = context.Request.RawUrl; // [,asdasd,contact]

        var path = string.Empty;

        if (!string.IsNullOrWhiteSpace(str) && str.EndsWith(".png"))

            path = $@"C:\Users\namiqrasullu\Desktop\FBMS_Nov_23_8_az_SP_NP\Network Programming\Lesson5Http\Lesson5Http\Images\{str?.Split('/').Last()}";
        else
            path = $@"C:\Users\namiqrasullu\Desktop\FBMS_Nov_23_8_az_SP_NP\Network Programming\Lesson5Http\Lesson5Http\Views\{str?.Split('/').Last()}.html";

        var response = context.Response;

        var stream = response.OutputStream;

        try
        {

            response.ContentType = Path.GetExtension(path) == ".png" ? "image/png" : "text/html";
            var bytes = File.ReadAllBytes(path);
            stream.Write(bytes);
        }
        catch
        {
            var bytes = File.ReadAllBytes($@"C:\Users\namiqrasullu\Desktop\FBMS_Nov_23_8_az_SP_NP\Network Programming\Lesson5Http\Lesson5Http\Views\Error.html");
            stream.Write(bytes);
        }
        finally
        {
            stream.Close();
        }

    }
}

class Program
{
    private static void Main(string[] args)
    {
        new WebHost(27001).Run();
    }
}