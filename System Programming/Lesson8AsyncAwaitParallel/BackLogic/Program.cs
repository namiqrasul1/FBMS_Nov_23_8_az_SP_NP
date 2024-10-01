using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace BackLogic
{
    class SomeClass
    {
        public void Operation()
        {
            Console.WriteLine($"Operation: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Begin");
            Thread.Sleep(10000);
            Console.WriteLine("End");
        }

        public void OperationAsync()
        {
            AsyncStateMachine stateMachine = new AsyncStateMachine();
            stateMachine.outer = this;
            stateMachine.state = -1;
            stateMachine.builder = AsyncVoidMethodBuilder.Create();
            stateMachine.builder.Start(ref stateMachine);
        }
    }


    internal struct AsyncStateMachine : IAsyncStateMachine
    {
        public int state;
        public SomeClass outer;
        private TaskAwaiter awaiter;
        public AsyncVoidMethodBuilder builder;

        int counter;

        public void MoveNext()
        {
            Console.WriteLine($"Move next colled {++counter} time(s): {Thread.CurrentThread.ManagedThreadId}");
            if(state == -1)
            {
                Console.WriteLine($"OperationAsync Part 1: {Thread.CurrentThread.ManagedThreadId}");

                Task task = Task.Factory.StartNew(outer.Operation);
                awaiter = task.GetAwaiter();
                
                state = 0;

                builder.AwaitOnCompleted(ref awaiter, ref this);
            }
            else
            {
                Console.WriteLine($"OperationAsync Part 2: {Thread.CurrentThread.ManagedThreadId}");
            }

        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            Console.WriteLine($"SetStateMachine: {Thread.CurrentThread.ManagedThreadId}");

            builder.SetStateMachine(stateMachine);
        }
    }

    internal class Program
    {
       
        private static void Main(string[] args)
        {
            Console.WriteLine($"Main: {Thread.CurrentThread.ManagedThreadId}");
            SomeClass someClass = new SomeClass();
            someClass.OperationAsync();
            Console.ReadKey();
        }
    }
}
