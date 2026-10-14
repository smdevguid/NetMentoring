using LoksAndMonitor;

class Program
{
    static void Main()
    {
        Account account = new Account(200000);
        Task task = Task.Factory.StartNew(()=>account.WitdrawRandom());
        Task task2 = Task.Factory.StartNew(()=>account.WitdrawRandom());
        Task task3 = Task.Factory.StartNew(()=>account.WitdrawRandom());
        Task.WaitAll(task, task2, task3);
        Console.WriteLine("All task completed");
    }
}