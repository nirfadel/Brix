using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise1_SupermarketQueue
{
    public class BlockingCollectionQueue
    {
        public delegate void dg_AddPerson(object CollectionQueue, Person p);
        public event dg_AddPerson ev_AddPerson;
        int id = 0;
        private static BlockingCollection<Person> _personQueue = new BlockingCollection<Person>();
        private Cashier[] cashiers;

        public BlockingCollectionQueue(int numOfCashiers)
        {
            cashiers = new Cashier[numOfCashiers];
            for (int i = 0; i < cashiers.Length; i++)
            {
                cashiers[i] = new Cashier();
                cashiers[i].NumOfCashier = i;
            }
            var thread = new Thread(new ThreadStart(OnStart));
            thread.Start();
            //AddPersonToCashier();
        }

        public void Enqueue(Person p)
        {
            _personQueue.Add(p);
        }

        public Person Dequeue()
        {
            return _personQueue.Take();
        }

        public void AddToQueue()
        {

            while (true)
            {
                id++;
                Enqueue(new Person { Id = id, Name = "Person" + id });
                var emptyCashier = from c in cashiers
                                   where c.CurrPerson == null
                                   select c;
                Cashier cash = emptyCashier.FirstOrDefault();
                if (cash != null)
                {
                    Person p = Dequeue();
                    // Call the Event
                    ev_AddPerson?.Invoke(this, p);
                    //cash.AddCurrPerson(p);
                }
                Thread.Sleep(1000);
            }


        }

        private void OnStart()
        {
            while (true)
            {
                id++;
                Enqueue(new Person { Id = id, Name = "Person" + id });
                Thread.Sleep(1000);
                var emptyCashier = from c in cashiers
                                   where c.CurrPerson == null
                                   select c;
                Cashier cash = emptyCashier.FirstOrDefault();
                if (cash != null)
                {
                    Person p = Dequeue();
                    // Call the Event
                    //ev_AddPerson?.Invoke(this, p);
                    cash.AddCurrPerson(p);
                }

            }

        }

        static void Consume()
        {
            foreach (var i in _personQueue.GetConsumingEnumerable())
            {
                Console.WriteLine(String.Format("Thread {0} Consuming: {1}", Thread.CurrentThread.ManagedThreadId, i));
                Thread.Sleep(1000);
            }
        }


        internal void AddPersonToCashier(Person p)
        {
            for (; ; )
            {
                var emptyCashier = from c in cashiers
                                   where c.CurrPerson == null
                                   select c;
                Cashier cash = emptyCashier.FirstOrDefault();
                Console.WriteLine("number of occupied cashiers: {0}", cashiers.Length - emptyCashier.Count());
                if (cash != null)
                {

                    cash.AddCurrPerson(p);

                }
            }

        }

    }
}
