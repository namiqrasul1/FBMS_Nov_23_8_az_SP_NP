internal class Program
{
    #region Lock

    //private static int _count = 0;
    //private static object _sync = new object();

    //private static void Increment()
    //{
    //    lock (_sync)
    //    {
    //        _count = 0;
    //        for (int i = 0; i < 10; i++)
    //        {
    //            Console.WriteLine($"{Thread.CurrentThread.Name}: {++_count}");
    //        }
    //    }
    //}

    //private static void Main(string[] args)
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        var thread = new Thread(Increment);
    //        thread.Name = $"Thread{i}";
    //        thread.Start();
    //    }
    //}

    #endregion

    #region Mutex (Internal Thread)

    //private static int _count = 0;
    //private static object _sync = new();
    //private static Mutex _mutexObj = new();
    //private static void Increment()
    //{
    //    _mutexObj.WaitOne();

    //    _count = 0;
    //    for (int i = 0; i < 10; i++)
    //    {
    //        Console.WriteLine($"{Thread.CurrentThread.Name}: {++_count}");
    //    }

    //    _mutexObj.ReleaseMutex();
    //}

    //private static void Main(string[] args)
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        var thread = new Thread(Increment);
    //        thread.Name = $"Thread{i}";
    //        thread.Start();
    //    }
    //}

    #endregion

    #region Mutex (External Thread)

    //private static int _count = 0;
    //private static object _sync = new();
    //private static Mutex _mutexObj = new(false, "Tahir");
    //private static void Increment()
    //{
    //    _mutexObj.WaitOne();

    //    _count = 0;
    //    for (int i = 0; i < 10; i++)
    //    {
    //        Console.WriteLine($"{Thread.CurrentThread.Name}: {++_count}");
    //        Thread.Sleep(500);
    //    }

    //    _mutexObj.ReleaseMutex();
    //}

    //private static void Main(string[] args)
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        var thread = new Thread(Increment);
    //        thread.Name = $"Thread{i}";
    //        thread.Start();
    //    }
    //}

    #endregion

    #region Mutex 1 process

    //private static void Main(string[] args)
    //{
    //    using(var mutex = new Mutex(false, "Fazil"))
    //    {
    //        if (mutex.WaitOne(1))
    //        {
    //            Console.WriteLine("Running precess");
    //            Console.WriteLine("Press enter for exit");
    //            Console.ReadLine();

    //            mutex.ReleaseMutex();
    //        }
    //        else
    //        {
    //            Console.WriteLine("Another precess is running...");
    //            Environment.Exit(0);
    //        }
    //    }
    //}

    #endregion

    #region Semaphore (Internal Thread)

    //private static void SomeMethod(object? state)
    //{
    //    var s = state as Semaphore;

    //    var st = false;
    //    if (s is not null)
    //    {
    //        while (!st)
    //        {
    //            if (s.WaitOne(1000))
    //            {
    //                try
    //                {
    //                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} got the key");
    //                    Thread.Sleep(3000);
    //                }
    //                finally
    //                {
    //                    st = true;
    //                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} returned the key");
    //                    s.Release();
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine($"Mister Thread {Thread.CurrentThread.ManagedThreadId}, we dont have enough key. Please wait...");
    //            }
    //        }
    //    }

    //}

    //private static void Main(string[] args)
    //{
    //    var semaphore = new Semaphore(3, 3);

    //    for (int i = 0; i < 10; i++)
    //    {
    //        ThreadPool.QueueUserWorkItem(SomeMethod, semaphore);
    //    }
    //    Console.ReadKey();
    //}

    #endregion

    #region Semaphore (Extarnal Thread)

    //private static void SomeMethod(object? state)
    //{
    //    var s = state as Semaphore;

    //    var st = false;
    //    if (s is not null)
    //    {
    //        while (!st)
    //        {
    //            if (s.WaitOne(1000))
    //            {
    //                try
    //                {
    //                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} got the key");
    //                    Thread.Sleep(3000);
    //                }
    //                finally
    //                {
    //                    st = true;
    //                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} returned the key");
    //                    s.Release();
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine($"Mister Thread {Thread.CurrentThread.ManagedThreadId}, we dont have enough key. Please wait...");
    //            }
    //        }
    //    }

    //}

    //private static void Main(string[] args)
    //{
    //    using var semaphore = new Semaphore(3, 3, "hakuna");

    //    for (int i = 0; i < 10; i++)
    //    {
    //        ThreadPool.QueueUserWorkItem(SomeMethod, semaphore);
    //    }
    //    Console.ReadKey();
    //}

    #endregion

    #region SemaphoreSlim


    private static void Main(string[] args)
    {
        var semaphoreSlim = new SemaphoreSlim(3);
        for (int i = 0; i < 10; i++)
        {
            var name = $"Thread{i}";
            var second = TimeSpan.FromSeconds(2 + 2 * i);

            new Thread( () =>
            {
                Console.WriteLine($"{name} waits for access");

                semaphoreSlim.Wait(second);

                Console.WriteLine($"{name} is working");
                Thread.Sleep(second);
                Console.WriteLine($"{name} completed");

                semaphoreSlim.Release();

            }).Start();

        }
    }

    #endregion

}