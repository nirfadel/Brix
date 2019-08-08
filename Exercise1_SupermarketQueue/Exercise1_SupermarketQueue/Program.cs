using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Timers;

namespace Exercise1_SupermarketQueue
{
    class Program
    {
        static int id = 0;
        static SuperMarketQueue superMarketQueue;
        static SuperMarket supermMarket;
        static void Main(string[] args)
        {

            SuperQueue();

        }

        private static void SuperQueue()
        {
            //PCQueue q = new PCQueue(5);

            //for (int i = 0; i < 10; i++)
            //{
            //    int itemNumber = i;      // To avoid the captured variable trap
            //    q.EnqueueItem(() =>
            //    {
            //        Thread.Sleep(1000);          // Simulate time-consuming work
            //        Console.Write(" Task" + itemNumber);
            //    });
            //}

            //Console.WriteLine();



            //BlockingCollectionQueue blockingCollectionQueue = new BlockingCollectionQueue(5);

            //Cashier c = new Cashier();
            //c.Subscribe(blockingCollectionQueue);

            //supermMarket = new SupermMarket();

            superMarketQueue = new SuperMarketQueue(5);
            System.Timers.Timer timer = new System.Timers.Timer(1000)
            {
                AutoReset = true
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.WriteLine("Press any key to stop.");
            Console.Read();
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            id++;
            superMarketQueue.Enqueue(new Person { Id = id, Name = "Nir" + id });



        }
    }
}
