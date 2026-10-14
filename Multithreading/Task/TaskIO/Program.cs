class Program
{
    static void Main()
    {
        Task<string> task = Task
        .Factory.StartNew<string>(()=>GetPosts("https://jsonplaceholder.typicode.com/posts"));

        SomethingElse();
        task.Wait();
        try
        {
            Console.WriteLine(task.Result);    
        }
        catch (AggregateException ex)
        {            
            Console.WriteLine(ex.Message);
        }

        
    }

    private static void SomethingElse()
    {
        
    }

    private static string GetPosts(string url)
    {
        using(var client = new System.Net.WebClient())
        {
            return client.DownloadString(url);
        }
    }
}