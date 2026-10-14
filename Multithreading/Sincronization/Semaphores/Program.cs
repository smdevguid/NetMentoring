class Program
{
    static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            new Thread(EnterSemafore).Start(i+1);
        }
    }

    private static void EnterSemafore(object id)
    {
        Console.WriteLine($"{id} is waiting to be part of the club");
        semaphoreSlim.Wait();
        Console.WriteLine($"{id} part of the club");
        Thread.Sleep(1000/(int)id);
        Console.WriteLine($"{id} left the club");
    }
}