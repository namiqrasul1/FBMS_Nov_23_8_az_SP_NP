using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

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


        var str = context.Request.RawUrl; // [,asdasd,contact] //a.jpg

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
    private static async Task Main(string[] args)
    {
        //new WebHost(27001).Run();

        var client = new HttpClient();
        //var result = await client.GetAsync("https://jsonplaceholder.typicode.com/posts"); // HttpResponseMessage lazim olacaqsa
        //var json = await result.Content.ReadAsStringAsync();
        //var posts = JsonSerializer.Deserialize<List<Post>>(json);
        //var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/234165465");
        //var posts = JsonSerializer.Deserialize<Post>(result);
        //var stream = await client.GetStreamAsync("https://jsonplaceholder.typicode.com/posts");

        //var json = JsonSerializer.Serialize(new Post { UserId = 1, Body = "Hakuna Matata", Title = "John Doe" });

        //var content = new StringContent(json);

        //var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);
        //if (response.IsSuccessStatusCode)
        //{
        //    await Console.Out.WriteLineAsync("element ugurla elave olundu");
        //    var result = await response.Content.ReadAsStringAsync();
        //    await Console.Out.WriteLineAsync(result);
        //}

        //var response = await client.DeleteAsync("https://jsonplaceholder.typicode.com/posts/2");
        //if (response.IsSuccessStatusCode)
        //{
        //    await Console.Out.WriteLineAsync("element silindi");
        //    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
        //}

        //client.PutAsync();
    }
}


class Post
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; } // userId

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }
}