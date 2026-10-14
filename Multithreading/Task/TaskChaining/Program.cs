namespace TaskChaining
{
    class Program
    {
        static void Main()
        {
            Task<string> antecedent = Task.Run(()=>
            {
                Task.Delay(2000);
                 return DateTime.Today.ToShortDateString();
            });
            Task<string> continuation = antecedent.ContinueWith(x =>
            {
                return "Today is "+antecedent.Result;
            });
            Console.WriteLine("Imprimira antes que result");
            Console.WriteLine(continuation.Result);
        }
    }
}