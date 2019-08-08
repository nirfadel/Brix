using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise1_SupermarketQueue
{
    public class Cashier
    {

        public void Subscribe(BlockingCollectionQueue collectionQueue)
        {
            collectionQueue.ev_AddPerson += new BlockingCollectionQueue.dg_AddPerson(CollectionQueue_ev_AddPerson);
        }

        private void CollectionQueue_ev_AddPerson(object CollectionQueue, Person p)
        {
            Console.WriteLine("{0} Enter into Cashier {1}", p.Name, NumOfCashier);
            CurrPerson = p;
            Random rnd = new Random();
            int number = rnd.Next(1, 5);
            var sw = new Stopwatch();
            sw.Start();
            Thread.Sleep(number * 1000);
            RemoveCurrPerson(p);
            Console.WriteLine("{0} Exit from Cashier {1} after {2} seconds", p.Name, NumOfCashier, sw.Elapsed.TotalSeconds);
        }

        public Cashier()
        {

        }
        public int NumOfCashier { get; set; }

        public Person CurrPerson { get; set; }

        public void AddCurrPerson()
        {


        }
        public void AddCurrPerson(Person p)
        {
            Console.WriteLine("{0} Enter into Cashier {1}", p.Name, NumOfCashier);
            CurrPerson = p;
            Random rnd = new Random();
            int number = rnd.Next(1, 5);
            var sw = new Stopwatch();
            sw.Start();
            Thread.Sleep(number * 1000);
            RemoveCurrPerson(p);
            Console.WriteLine("{0} Exit from Cashier {1} after {2} seconds", p.Name, NumOfCashier, sw.Elapsed.TotalSeconds);
        }

        public void RemoveCurrPerson(Person p)
        {
            CurrPerson = null;
        }

    }
}
