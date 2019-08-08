using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2_SearchText
{
    class Program
    {
        static void Main(string[] args)
        {
            string val;
            Console.Write("Please Enter 5 characters long alphanumerical string: ");
            val = Console.ReadLine();
            if(val.Length != 5)
            {
                Console.WriteLine("the input need to be 5 characters long alphanumerical string!");
                Console.Read();
                return;
            }
                
            ReadAndSearchInput search = new ReadAndSearchInput(val);
            string[] output = search.GetSearchResult();
            Console.WriteLine(String.Format("Input: {0} Output: {1}", val, string.Join(", ", output)));
            Console.Read();
        }
    }
}
