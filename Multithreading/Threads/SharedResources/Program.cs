class Program
{
    private static bool isCompleted = false;
    static readonly object lookComplete = new object();
    static void Main(string[] args)
    {
        //HelloWorldTest();
        HelloWorldTestAsync();
    }

    private static void HelloWorldTestAsync()
    {
        Thread thread = new Thread(HelloWorldAsync);
        thread.Start();
        HelloWorldAsync();
    }

    private static void HelloWorldAsync()
    {
        lock (lookComplete)
        {
            if (!isCompleted)
            {
                Console.WriteLine("Solo debe imprimirse una sola vez");
                isCompleted = true;
            }
        }
         
    }

    private static void HelloWorldTest()
    {
        Thread thread = new Thread(HelloWorld);
        thread.Start();
        HelloWorld();
    }

    private static void HelloWorld()
    {
        if (!isCompleted)
        {
            Console.WriteLine("Solo debe imprimirse una sola vez");
            isCompleted = true;
        }
    }
}