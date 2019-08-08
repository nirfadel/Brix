using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise1_SupermarketQueue
{
    public class SuperMarket
    {
        BlockingCollectionQueue blockingCollection;
        Cashier[] cashiers;
        public SuperMarket(int numOfCashiers)
        {
            blockingCollection = new BlockingCollectionQueue(numOfCashiers);
            cashiers = new Cashier[numOfCashiers];
            for (int i = 0; i < cashiers.Length; i++)
            {
                cashiers[i] = new Cashier();
                cashiers[i].NumOfCashier = i;
            }
        }
        

    }
}
