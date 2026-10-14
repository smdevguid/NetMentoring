namespace LocalMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Worker Thread
            new Thread(PointOneToThirty).Start();

            //Main Thread
            PointOneToThirty();
        }

        private static void PointOneToThirty()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write(i + 1 + " ");                
            }
        }
    }
}