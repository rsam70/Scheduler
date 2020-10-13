using Rsam70.Concurrency.Schedulers;
using System;

namespace Rsam70.Concurrency.GCD
{
    class Program
    {
        public static void Main()
        {
            var scheduler = Scheduler.CreateExclusiveScheduler();

            for (int i = 0; i < 101; i++)
            {
                scheduler.Schedule(() => Console.WriteLine(i));
            }

            Console.WriteLine("press key");
            Console.ReadKey();

            for (int i = 0; i < 100; i++)
            {
                scheduler.Schedule((k) => Console.WriteLine(k), i);
            }

            Console.WriteLine($"Finished");
            Console.ReadKey();
        }
    }
}
