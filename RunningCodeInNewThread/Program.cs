using System;
using System.Threading;

namespace RunningCodeInNewThread
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(CountToTen).Start();  //create and start an anonymous thread
            var thread1 = new Thread(new ParameterizedThreadStart(CountToTenNamed));    //create (but don't start) a new thread
            var thread2 = new Thread(new ParameterizedThreadStart(CountToTenNamed));    //create (but don't start) a new thread
            var thread3 = new Thread(new ParameterizedThreadStart   (CountToTenNamed));     //create (but don't start) a new thread

            thread1.Start("My first thread");       //start thread1
            thread2.Start("My second thread");      //start thread2
            thread3.Start("My third thread");       //start thread3

            thread1.Join();     //wait for thread1 to join the executing thread
            thread2.Join();     //wait for thread2 to join the executing thread
            thread3.Join();     //wait for thread3 to join the executing thread

            Console.WriteLine("Done!");     
        }


        private static void CountToTen()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
        private static void CountToTenNamed(object threadName)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Thread {threadName}: {i}");
                Thread.Sleep(100);
            }
        }
    }
}