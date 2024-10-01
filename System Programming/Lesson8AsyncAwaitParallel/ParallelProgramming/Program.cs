using ParallelProgramming.Fakers;

var students = InitalizeStudents.GenerateStudents(2000);

//foreach (var student in students)
//{
//    student.Surname = "Kamilzade";
//    await Task.Delay(10);
//}
//Console.WriteLine("end");
//Console.ReadKey();


//Task t = new(async () =>
//{
//    for (int i = 0; i < students.Count / 2; i++)
//    {
//        students[i].Surname = "Kamilzade";
//        await Task.Delay(10);
//    }
//});

//Task t1 = new(async () =>
//{
//    for (int i = students.Count / 2; i < students.Count; i++)
//    {
//        students[i].Surname = "Kamilzade";
//        await Task.Delay(10);
//    }
//});

//t.Start();
//t1.Start();

//await Task.WhenAll(t,  t1);

//Console.WriteLine("End");

//Parallel.ForEach(students, async (st) =>
//{
//    await Console.Out.WriteLineAsync($"{Thread.CurrentThread.ManagedThreadId}");
//    st.Surname = "Kamilzade";
//    await Task.Delay(10);
//});

//Parallel.For(0, students.Count, async i =>
//{
//    await Console.Out.WriteLineAsync($"{Thread.CurrentThread.ManagedThreadId}");
//    students[i].Surname = "Kamilzade";
//    await Task.Delay(10);
//});


//Console.WriteLine("end");

//Parallel.Invoke(
//    () => { Console.WriteLine("Salam 1"); },
//    () => { Console.WriteLine("Salam 2"); },
//    () => { Console.WriteLine("Salam 3"); },
//    () => { Console.WriteLine("Salam 4"); },
//    () => { Console.WriteLine("Salam 5"); },
//    () => { Console.WriteLine("Salam 6"); },
//    () => { Console.WriteLine("Salam 7"); },
//    () => { Console.WriteLine("Salam 8"); }
//);