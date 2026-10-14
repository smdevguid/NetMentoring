
/**
* En este ejemplo podemos apreciar que cuando envolvemos un subproceso con try catch, en realidad
la excepcin se generara y no capturarara el error, debido que la excepcion se genera en otro proceso (hilo)

*/

class Program
{
    public static void  Main(string[] args)
    {
       Demo();
    }

    private static void Demo()
    {
        try
        {
            //Worker Thread
            //new Thread(Execute).Start(); // No camptura el error
            new Thread(ExecuteErrorHandeOK).Start(); // Si capturar el error
        }
        //Main Thread
        catch (System.Exception ex
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void Execute()
    {
        throw null;
    }
    private static void ExecuteErrorHandeOK()
    {
        try
        {
            throw null;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
