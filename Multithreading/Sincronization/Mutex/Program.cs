using System.Diagnostics;

class Program
{
    static Mutex mutex = new Mutex();
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {            
            Thread thread = new Thread(AcquireMutex);
            thread.Name = $"Thread {i}";
            thread.Start();
        }
    }

    private static void AcquireMutex(object? obj)
    {
        if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}");
            return;
        }
        //mutex.WaitOne();
        DoSomething();
        mutex.ReleaseMutex();
        Console.WriteLine($"Mutex release by {Thread.CurrentThread.Name}");
    }

    private static void DoSomething()
    {
        Thread.Sleep(3000);
        //Console.WriteLine($"Mutex aquired by {Thread.CurrentThread.Name}");
    }
}