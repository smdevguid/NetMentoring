class Program
{
    static object customLoock = new object();
    static void Main(){
        lock(customLoock)
        {
            DoSomething();
        }
    }

    private static void DoSomething()
    {
        lock (customLoock)
        {
            Task.Delay(2000);
            AnotherMethod();
        }
    }

    private static void AnotherMethod()
    {
        lock (customLoock)
        {
            
        }
    }
}