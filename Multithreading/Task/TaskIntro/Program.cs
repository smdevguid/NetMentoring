/**
* La diferencia de los Task y Thread, es que para las Task
* es posible retornar un resultado
*/
class Program
{
    static void Main(string[] args)
    {
        Task task = new Task(SimpleMethod);
        task.Start();
        
        Task<string> taskReturns = new Task<string>(MethodReturns);
        taskReturns.Start();
        taskReturns.Wait();
        Console.WriteLine(taskReturns.Result);

    }

    private static string MethodReturns()
    {
        Thread.Sleep(2000);
        return "Hello";
    }

    private static void SimpleMethod()
    {
        Console.WriteLine("Hello World");
    }
}