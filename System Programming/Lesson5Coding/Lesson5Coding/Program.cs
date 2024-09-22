using System;

//Directory.CreateDirectory(@"C:\Users\namiqrasullu\Desktop\Kamil");

//var directories = Directory.GetDirectories(@"C:\Users\namiqrasullu\Desktop");

//foreach (var directory in directories)
//    Console.WriteLine(directory);

//var files = Directory.GetFiles(@"C:\Users\namiqrasullu\Desktop");

//foreach (var file in files)
//    Console.WriteLine(file);

// C:\Users\namiqrasullu\Desktop\homework.png
// C:\Users\namiqrasullu\Desktop\Kamil

void copyFile(string source, string destination)
{
    if (File.Exists(source))
    {
        try
        {
            using (var sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
            {

                if (!Path.HasExtension(destination)) // C:\Users\namiqrasullu\Desktop
                {
                    destination = $@"{destination}\{Path.GetFileNameWithoutExtension(source)}Copy{Path.GetExtension(source)}";
                }

                if (Path.GetExtension(source) == Path.GetExtension(destination))
                {
                    using (var destStream = new FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        var len = 200;
                        var bytes = new byte[len];
                        do
                        {
                            len = sourceStream.Read(bytes, 0, len);
                            destStream.Write(bytes, 0, len);
                            Thread.Sleep(10);

                        } while (0 < len);

                    }
                }
                else
                {
                    Console.WriteLine("Choose correct file extension");
                    Console.ReadKey();
                   
                }


            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong");
            // ex.Message log
        }
    }
    else
    {
        Console.WriteLine("File not found");
        Console.WriteLine("Press any key for continue");
        Console.ReadKey();
    }
}

while (true)
{
    Console.Write("Source path: ");
    var source = Console.ReadLine()!;
    Console.Write("Destination Path: ");
    var destination = Console.ReadLine()!;

    //copyFile(source, destination); // single thread

    var thread = new Thread(() =>
    {
        copyFile(source, destination);
    });
    thread.Start();

}