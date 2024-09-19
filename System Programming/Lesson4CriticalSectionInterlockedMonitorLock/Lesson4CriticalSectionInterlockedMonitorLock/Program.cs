using Bogus;
using Lesson4CriticalSectionInterlockedMonitorLock.Models;
using System.Text.Json;

namespace Lesson4CriticalSectionInterlockedMonitorLock;

class Counter
{
    public static int count;
}

class Singleton
{
    private static Singleton? _obj;
    private Singleton() { }
    private static object _sync = new();

    public static Singleton GetSingleton()
    {
        lock (_sync)
        {
            _obj ??= new Singleton();
            return _obj;
        }
    }
}

class Program
{
    static object _sync = new object();
    static List<User> _users = [];

    private static void Main(string[] args)
    {

        //var threads = new Thread[5];

        //// problem
        ////for (int i = 0; i < threads.Length; i++)
        ////{
        ////    threads[i] = new Thread(() =>
        ////    {
        ////        for (int j = 0; j < 1_000; j++)
        ////        {
        ////            Counter.count++; // count = count + 1
        ////            //Console.WriteLine(Counter.count);
        ////        }
        ////    });
        ////}

        //// Interlocked
        ////for (int i = 0; i < threads.Length; i++)
        ////{
        ////    threads[i] = new Thread(() =>
        ////    {
        ////        for (int j = 0; j < 1_000_000; j++)
        ////        {
        ////           Interlocked.Increment(ref Counter.count);
        ////        }
        ////    });
        ////}

        //// Monitor
        ////for (int i = 0; i < threads.Length; i++)
        ////{
        ////    threads[i] = new Thread(() =>
        ////    {
        ////        for (int j = 0; j < 1_000; j++)
        ////        {
        ////            Monitor.Enter(_sync);
        ////            try
        ////            {
        ////                Counter.count++;
        ////                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
        ////            }
        ////            finally
        ////            {
        ////                Monitor.Exit(_sync);
        ////            }
        ////        }
        ////    });
        ////}

        //// lock
        //for (int i = 0; i < threads.Length; i++)
        //{
        //    threads[i] = new Thread(() =>
        //    {
        //        for (int j = 0; j < 1_000_000; j++)
        //        {
        //            lock (_sync)
        //            {
        //                Counter.count++;
        //            }               
        //        }
        //    });
        //}


        //for (int i = 0; i < threads.Length; i++)
        //    threads[i].Start();

        //for (int i = 0; i < threads.Length; i++)
        //    threads[i].Join();



        //Console.WriteLine(Counter.count);

        //  <ItemGroup> 
        //    <PackageReference Include="Bogus" Version="35.6.1" /> 
        //  </ItemGroup>

        //var faker = new Faker<User>();
        //var users = faker.RuleFor(u => u.Name, f => f.Person.FirstName)
        //    .RuleFor(u => u.Surname, f => f.Person.LastName)
        //    .RuleFor(u => u.Email, f => f.Internet.Email())
        //    .RuleFor(u => u.DateOfBirth, f => f.Person.DateOfBirth)
        //    .Generate(50);

        //var json = JsonSerializer.Serialize(users);
        //File.WriteAllText("5.json", json);

        //var listOfCar = new List<User>();

        // 5 json filedan melumati oxuyub eyni liste yigmaq lazimdir.
        // istifadechi birinci single ve ya multiple thread ishletmeyini sechir.
        // eger single sechibse 1 thread uzerinden file'lardan oxuyub umumi liste elave edir.
        // eger multiple sechilibse her bir file uchun 1 thread yaradib. onun uzerinden umumi liste elave edir
        // ThreadPool'dan istifade etmelisiz!

        var from = @"C:\Users\namiqrasullu\Desktop\Инструкция_File_Server.pdf";
        var to = @$"C:\Users\namiqrasullu\Desktop\Books\{Guid.NewGuid()}{Path.GetExtension(from)}";
        using (var rfs = new FileStream(from, FileMode.Open, FileAccess.Read))
        {
            using (var wfs = new FileStream(to, FileMode.OpenOrCreate, FileAccess.Write))
            {
                int len = 0;
                do
                {
                    var bytes = new byte[30];
                    len = rfs.Read(bytes, 0, bytes.Length);
                    wfs.Write(bytes, 0, bytes.Length);
                    
                } while (len != 0);
               
            }
        }

    }
}
