using System.Threading.Channels;

internal class Program
{
    static void SomeMethod()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine('y');
            Thread.Sleep(100);
        }
        Console.WriteLine();
    }

    static void SomeMethod1()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} {Thread.CurrentThread.ManagedThreadId}");

        Console.WriteLine("Thread Started");
        Thread.Sleep(3000);
        Console.WriteLine("Thread Finished");
    }

    static void Foo(object? obj)
    {
        Console.WriteLine(obj);
    }

    static void Foo1(int i)
    {
        Console.WriteLine(i);
    }

    private static void Main(string[] args)
    {
        #region FirstExample

        //Thread thread = new(SomeMethod);
        //thread.Name = "Kamil";
        ////thread.Priority = ThreadPriority.Highest;
        ////thread.Priority = ThreadPriority.Lowest;

        //Thread.CurrentThread.Name = "Main";

        //thread.Start();

        //for (int i = 0; i < 1000; i++)
        //{
        //    Console.WriteLine('x');
        //    Thread.Sleep(100);
        //}

        #endregion

        #region Foreground vs Background

        //Console.WriteLine($"{Thread.CurrentThread.Name} {Thread.CurrentThread.ManagedThreadId}");

        //var thread = new Thread(SomeMethod1);
        //thread.IsBackground = true;
        //thread.Name = "KamilThread";
        //thread.Start();

        //Console.WriteLine("Main ended");
        //Console.ReadKey();

        #endregion

        //var th = new Thread(() =>
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Console.Write('y');
        //        Thread.Sleep(100);
        //    }

        //});

        //th.IsBackground = true;

        //th.Start();


        #region ParametrizedThreadStart

        //var th = new Thread(Foo);

        //th.Start(2);

        //int a = 542;

        //var th = new Thread(() => { Foo1(a); });
        //th.Start();

        #endregion

        for (int i = 0; i < 10; i++)
        {
            var j = i;
            Thread t = new(() => { Console.WriteLine(j); });
            t.Start();
        }

        //var str = "Fero";
        //var th = new Thread(() => Console.WriteLine(str));
        //str = "Abo";

        //var th1 = new Thread(() => Console.WriteLine(str));

        //th.Start();
        //th1.Start();

        //Thread t = new(() =>
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Console.WriteLine('x');
        //        Thread.Sleep(100);
        //    }
        //});

        //t.Start();

        //Console.WriteLine("0000000000000000000000000");

        //t.Join();

        //Console.WriteLine("hello");

        //var from = @"C:\Users\namiqrasullu\Desktop\Untitled.png";
        //var to = @"C:\Users\namiqrasullu\Desktop\name.ext";
        //FileInfo fileInfo = new FileInfo(from);

        //Console.WriteLine(fileInfo.FullName);
        //Console.WriteLine(fileInfo.Name);
        //Console.WriteLine(fileInfo.Extension);
    }
}