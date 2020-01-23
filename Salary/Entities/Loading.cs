using System;
using System.Threading;



namespace Salary.Entities
{
    class Loading
    {
        public static void Load()
        {
            Console.WriteLine("\n\n");
            Random rand = new Random();
            Console.WriteLine("==========================Loading===========================");
            for (int i = 0; i < 60; i++)
            {
                Console.Write("=");
                Thread.Sleep(rand.Next(10, 300));

            }

            Console.WriteLine("\n\n");
        }
    }
}
