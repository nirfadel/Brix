using Exercise1_SupermarketQueue.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise1_SupermarketQueue
{
    public class SuperMarketQueue
    {
        Node front;
        Node rear;
        Cashier[] cashiers;

        public SuperMarketQueue(int numOfCashiers)
        {
            
            front = rear = null;
            cashiers = new Cashier[numOfCashiers];
            for (int i = 0; i < cashiers.Length; i++)
            {
                cashiers[i] = new Cashier();
                cashiers[i].NumOfCashier = i;
            }
        }

        internal void Enqueue(Person p)
        {
            Node newNode = new Node(p);
            if (rear == null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
            Console.WriteLine("{0} inserted into Queue", p.Name);
            AddPersonToCashier();

        }

        internal void Dequeue()
        {
            // If queue is empty, return NULL.  
            if (this.front == null)
            {
                Console.WriteLine("The Queue is empty");
                return;
            }

            // Store previous front and move front one node ahead  
            Node temp = front;
            front = front.next;

            // If front becomes NULL, then change rear also as NULL  
            if (front == null)
            {
                rear = null;
            }
           
            Console.WriteLine("{0} removed from queue", temp.data.Name);
        }

        internal void AddPersonToCashier()
        {
            var emptyCashier = from c in cashiers
                               where c.CurrPerson == null
                               select c;
            Cashier cash = emptyCashier.FirstOrDefault();
            Console.WriteLine("number of occupied cashiers: {0}", cashiers.Length - emptyCashier.Count());
            if (cash != null)
            {
                cash.AddCurrPerson(front.data);
                Dequeue();
            }
               
        }

        internal void AddRemoveToCashier()
        {

        }

    }
}
