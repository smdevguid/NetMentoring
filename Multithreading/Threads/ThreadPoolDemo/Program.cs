class Program
{
    public static void  Main(string[] args)
    {
        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
        Employee employee = new Employee();
        employee.Name="Chander";
        employee.CompanyName="Cazton";      
        
        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

        ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee);

        var processorCount = Environment.ProcessorCount;

        //Establecer maximo de hilos
        ThreadPool.SetMaxThreads(processorCount *2, processorCount*2);        
        //establecer minimo hilos
        int workerThreads = 0;
        int completionPortThreads = 0;
        ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
        
        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
        Console.ReadKey();
    }

    private static void DisplayEmployeeInfo(object? employee)
    {
        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
        Employee? emp = employee as Employee;
        Console.WriteLine(emp);
        
    }
}
public class Employee
{
    public string? Name { get; set; }
    public string? CompanyName { get; set; }

    public override string ToString()
    {
        return $"Employee[Name = {Name}, CompanyName = ${CompanyName} ]";
    }
}