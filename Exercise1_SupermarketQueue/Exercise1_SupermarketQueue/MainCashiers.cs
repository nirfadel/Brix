using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_SupermarketQueue
{
    public class MainCashiers
    {
        Cashier[] cashiers;
        public MainCashiers()
        {
            for (int i = 0; i < cashiers.Length; i++)
            {
                cashiers[i] = new Cashier();
                cashiers[i].NumOfCashier = i;
            }
        }
    }
}
