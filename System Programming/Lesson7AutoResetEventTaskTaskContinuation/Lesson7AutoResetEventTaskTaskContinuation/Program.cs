﻿//internal class Program
//{
//    private static AutoResetEvent blok = new(false);
//    private static AutoResetEvent blok1 = new(false);
//    private static void Main(string[] args)
//    {
//        //Thread thread = new(SomeProc);
//        //thread.Start();

//        ThreadPool.QueueUserWorkItem(o => { SomeProc(); });


//        Console.WriteLine("Starting Main");
//        blok1.WaitOne();

//        for (int i = 0; i< 10; i++)
//        {
//            Console.WriteLine($"Main: {i}");
//            Thread.Sleep(100);
//        }

//        blok.Set();

//        Console.ReadKey();
//    }

//    private static void SomeProc()
//    {
//        Console.WriteLine("Starting SomeProc");
//        Thread.Sleep(5000);
//        blok1.Set();

//        blok.WaitOne();

//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine($"Process: {i}");
//            Thread.Sleep(100);
//        }
//    }
//}

// Thread
// ThreadPool
// Task (Task Parallel Library)

using System.Linq.Expressions;
using System.Threading.Channels;
using System.Xml.Linq;

internal class Program
{
    #region Create Task

    //private static void TaskMethod(string name)
    //{
    //    Console.WriteLine($"{name} is running. Id: {Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    //}

    //private static void Main(string[] args)
    //{
    //    var task = new Task(() => { TaskMethod("task"); });
    //    task.Start();

    //    new Task(() => { TaskMethod("task 1"); }).Start();

    //    var t1 = Task.Run(() => { TaskMethod("task 2"); });

    //    var t2 = Task.Factory.StartNew(() => { TaskMethod("task 3"); });
    //    var t3 = Task.Factory.StartNew(() => { TaskMethod("task 4"); }, TaskCreationOptions.LongRunning);

    //    var t4 = new Task<int>(() => { TaskMethod("Task<int>"); Thread.Sleep(4000);  return 5; });
    //    t4.Start();

    //    Console.WriteLine(t4.Result);
    //    Console.WriteLine("salam");
    //    Console.ReadKey();
    //}

    #endregion

    #region Working

    //private static int TaskMethod(string name, int n)
    //{
    //    Console.WriteLine($"{name} is running. Id: {Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");

    //    Thread.Sleep(3000);

    //    return n * 2;
    //}

    //private static void Main(string[] args)
    //{
    //    //var t1 = new Task<int>(() => TaskMethod("Task 1", 21));
    //    //t1.Start();
    //    //var result = t1.Result;
    //    //Console.WriteLine(result);
    //    //Console.WriteLine("continue");

    //    //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");

    //    //var t2 = new Task<int>(() => TaskMethod("Task 2", 21));
    //    //t2.RunSynchronously();


    //    //Console.WriteLine("Main");


    //    var t3 = new Task<int>(() => TaskMethod("Task 3", 21));
    //    t3.Start();

    //    t3.ContinueWith(t =>
    //    {
    //        Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    //        Console.WriteLine(t.Result);
    //    });

    //    Console.WriteLine("Main");

    //    //Func<int> func = () => 5 * 2; ;
    //    //Expression<Func<int>> expr = () =>  5 * 2; ;

    //    Console.ReadKey();
    //}


    #endregion

    #region Continuation

    private static int TaskMethod(string name, int n)
    {
        Console.WriteLine($"{name} is running. Id: {Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");

        throw new Exception();
        Thread.Sleep(TimeSpan.FromSeconds(n));

        Console.WriteLine($"{name} completed");

        return n * 2;
    }

    private static void SomeMethod()
    {
        Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    }

    private static void Main(string[] args)
    {

        //var task1 = new Task<int>(() => TaskMethod("Task 1", 2));
        //var task2 = new Task<int>(() => TaskMethod("Task 2", 5));
        //task1.Start();
        //task2.Start();

        //var task2 = task1.ContinueWith(t => { TaskMethod("Continuation Task", 4); });

        //await Task.WhenAny(task1, task2);

        //await Task.WhenAll(task1, task2);

        //Console.WriteLine("salam");

        //var task1 = new Task<string>(() =>
        //{
        //    Console.WriteLine("Task Started");
        //    Thread.Sleep(TimeSpan.FromSeconds(3));
        //    //throw new Exception();
        //    return "salam";
        //});

        //var task2 = task1.ContinueWith(t =>
        //{
        //    // t.Result serialize
        //    Console.WriteLine("Her shey zordu");
        //}, TaskContinuationOptions.OnlyOnRanToCompletion);

        //var task3 = task1.ContinueWith(t =>
        //{
        //    // t.Result serialize
        //    Console.WriteLine("Hech de zor deyil. ishde problem var");
        //}, TaskContinuationOptions.OnlyOnFaulted);

        //var task4 = task1.ContinueWith(t =>
        //{
        //    // t.Result serialize
        //    Console.WriteLine("Ishi dayandirdilar");
        //}, TaskContinuationOptions.OnlyOnCanceled);

        //task1.Start();


        //var task1 = new Task(SomeMethod);
        ////var task2 = task1.ContinueWith(t => SomeMethod(), TaskContinuationOptions.LongRunning);
        ////var task2 = task1.ContinueWith(t => SomeMethod(), (TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously));
        //var task2 = task1.ContinueWith(t => SomeMethod(), (TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.LongRunning));


        //task1.Start();

        //var task1 = new Task<int>(() => TaskMethod("Task 1", 2));
        //var task2 = new Task<int>(() => TaskMethod("Task 2", 5));

        //_ = Task.Factory.ContinueWhenAll([task1, task2], tasks =>
        //   {
        //       Console.WriteLine("Continuation");
        //   });

        //_ = Task.Factory.ContinueWhenAny([task1, task2], tasks =>
        //{
        //    Console.WriteLine("Continuation");
        //});

        //_ = task1.ContinueWith(t => { Console.WriteLine("Continuation"); }, TaskContinuationOptions.NotOnRanToCompletion);

        //task1.Start();
        //task2.Start();


        /*
         
            OnlyOnRanToCompletion = NotOnFaulted | NotOnCanceled,
            OnlyOnFaulted = NotOnRanToCompletion | NotOnCanceled,
            OnlyOnCanceled = NotOnRanToCompletion | NotOnFaulted 

         */

        //dynamic obj = null;
        //obj.Salam = "salam";

        //List<int> list = [];
        //string[] strings = [];
        //LinkedList<int> l = [];
        Console.ReadKey();
    }


    #endregion
}