using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise1_SupermarketQueue
{
    public class PCQueue
    {
        readonly object _locker = new object();
        Thread[] cashiers;
        Cashier[] _cashiers;
        Queue<Action> _itemQ = new Queue<Action>();
        Queue<Person> _itemQ2 = new Queue<Person>();

        public PCQueue(int workerCount)
        {
            cashiers = new Thread[workerCount];
            _cashiers = new Cashier[workerCount];
            // Create and start a separate thread for each cashier
            for (int i = 0; i < workerCount; i++)
            {
                (cashiers[i] = new Thread(Consume)).Start();
                _cashiers[i] = new Cashier { NumOfCashier = i };
            }

        }

        public void Shutdown(bool waitForWorkers)
        {
            // Enqueue one null item per worker to make each exit.
            foreach (Thread worker in cashiers)
                EnqueueItem(null);

            // Wait for workers to finish
            if (waitForWorkers)
                foreach (Thread worker in cashiers)
                    worker.Join();
        }

        public void EnqueueItem(Action item)
        {
            lock (_locker)
            {
                _itemQ.Enqueue(item); // We must pulse because we're
                Monitor.Pulse(_locker); // changing a blocking condition.
            }
        }

        void Consume()
        {
            while (true) // Keep consuming until
            { // told otherwise.
                Person item;
                lock (_locker)
                {
                    while (_itemQ.Count == 0) Monitor.Wait(_locker);
                    //item = _itemQ.Dequeue();
                    //AddPersonToCashier(item);
                }
                // if (item == null) return; // This signals our exit.
                //item(); // Execute item.
            }
        }
    }
}
