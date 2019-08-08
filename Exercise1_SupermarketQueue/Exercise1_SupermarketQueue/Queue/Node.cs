using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_SupermarketQueue.Queue
{
    internal class Node
    {
        internal Person data;
        internal Node next;

        public Node(Person p)
        {
            data = p;
            next = null;
        }
    }
}
