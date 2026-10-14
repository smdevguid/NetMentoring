
class Program
{
    public static void  Main(string[] args)
    {
        Thread thread = new Thread(PrintHelloWorld);
        thread.Start();
        thread.IsBackground = true;
        thread.Join();

        Console.WriteLine("Helo world printed");
    }

    private static void PrintHelloWorld(object? obj)
    {
        Console.WriteLine("Whello wolrd");
        Thread.Sleep(5000);   
    }
}
