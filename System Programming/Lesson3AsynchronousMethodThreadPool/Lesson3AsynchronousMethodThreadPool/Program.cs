using System.Text;

internal class Program
{
    #region .net framework code example

    //private delegate void SomeDelegate();

    //private static void SomeMethod()
    //{
    //    Console.WriteLine($"SomeMethod: {Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread:{Thread.CurrentThread.IsThreadPoolThread}");
    //    Thread.Sleep(10000);
    //    Console.WriteLine("DoSomething");
    //}

    //private static void SomeMethod1()
    //{
    //    for (int i = 0; i < 100; i++)
    //    {
    //        Console.WriteLine("Salam");
    //        Thread.Sleep(100);
    //    }
    //}

    //private static void Main(string[] args)
    //{
    //    //Console.WriteLine($"Main: {Thread.CurrentThread.ManagedThreadId}");
    //    //SomeDelegate del = SomeMethod;
    //    //IAsyncResult result = del.BeginInvoke(null, null);
    //    //del.EndInvoke(result);

    //    //Thread thread = new Thread(SomeMethod1);
    //    //thread.Start();

    //    //Console.ReadKey();

    //    ////thread.Abort();
    //    //thread.Suspend();

    //    //Console.ReadKey();
    //    //thread.Resume();
    //}
    #endregion

    #region ThreadPool

    //private static void AsyncMethod(object? state)
    //{
    //    Console.WriteLine(state?.ToString());
    //    var thread = Thread.CurrentThread;
    //    Console.WriteLine($"Worker Thread Id: {thread.ManagedThreadId} IsThreadPoolThread: {thread.IsThreadPoolThread} IsBackground: {thread.IsBackground}");
    //}

    //private static void Main(string[] args)
    //{
    //    //Thread thread = new(AsyncMethod);
    //    //thread.Start("Salam");

    //    ThreadPool.QueueUserWorkItem(AsyncMethod, "salam");
    //    // background thread olduguna gore main ishini bitiren kimi ishini sona chatdirir.
    //    Console.ReadKey(); // Main bitmesin deye gozletdik
    //}

    #endregion

    #region Thread Vs ThreadPool

    //private static void UseThread(int operation)
    //{
    //    for (int i = 0; i < operation; i++)
    //    {
    //        var thread = new Thread(() =>
    //        {
    //            Console.Write($"{Thread.CurrentThread.ManagedThreadId} ");
    //            Thread.Sleep(100);
    //        });
    //        thread.Start();
    //    }
    //    Console.WriteLine();
    //}

    //private static void UseThreadPool(int operation)
    //{
    //    for (int i = 0; i < operation; i++)
    //    {
    //        ThreadPool.QueueUserWorkItem(o =>
    //        {
    //            Console.Write($"{Thread.CurrentThread.ManagedThreadId} ");
    //            Thread.Sleep(100);
    //        });
    //    }
    //    Console.WriteLine();
    //}

    //private static void Main(string[] args)
    //{
    //    //UseThread(500);
    //    //UseThreadPool(500);
    //    //Console.ReadKey();
    //    // ref out in
    //    ThreadPool.GetMaxThreads(out int worker, out int comp);
    //    Console.WriteLine(worker);
    //    Console.WriteLine(comp);
    //}

    #endregion

    #region CancellationToken
    private static string Download(CancellationToken cancellationToken)
    {
        Console.WriteLine("Downloading...");
        for (int i = 5; 0 < i; i--)
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"Downloading... Please wait {i} second(s)");
            //if (cancellationToken.IsCancellationRequested)
            //{

            //}
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
            }
            catch
            {
                Console.WriteLine("Download canceled");
                throw;
            }
        }
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"Download completed successufuly");
        return "salam.txt";
    }

    private static void DoSomething(CancellationToken cancellationToken) // 2-ci thread'in main
    {
        try
        {
            Download(cancellationToken);
        }
        catch
        {
            Console.WriteLine("Work canceled");
        }
    }


    private static void Main(string[] args)
    {

        //using (var cts = new CancellationTokenSource())
        //{
        //    ThreadPool.QueueUserWorkItem((o) => { DoSomething(cts.Token); });
        //    Console.ReadKey();
        //    cts.Cancel();
        //    Console.ReadKey();

        //}

        // AutoResetEvent
        // ManualResetEvent


        // fromPath
        // destPath
                     // 010101 -(n + 1)
        //int a = 42;  // 101010
        //int b = 54;  // 110110
        //             // 011100
        //             // 101010

        //int result = (a ^ b);

        //Console.WriteLine((a & b));
        //Console.WriteLine((a | b));
        //Console.WriteLine((a ^ b));
        //Console.WriteLine((result ^ b));
        //Console.WriteLine((~a));
        //string str = "s";
        //Console.WriteLine((str[0] ^ 32));

     
    }



    #endregion

}