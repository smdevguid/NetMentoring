using System.Runtime.CompilerServices;

Thread thread = new Thread(WriteUsingNewThread);
thread.Name="Caztom Worker";
//Worker Trhead
thread.Start();
//Main Thread
Thread.CurrentThread.Name="Caztom main";
for(int i = 0; i< 1000; i++)
{
    Console.Write("A "+i+" ");
}

void WriteUsingNewThread(object? obj)
{
    for(int i = 0; i< 1000; i++)
    {
        Console.Write("Z "+i+" ");
    }
}