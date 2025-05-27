using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayChallange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] fraudulentOrderID = {"B123","C234","A345","C15","B177","G3003","C235","B179"};
            foreach (String fraudulent in fraudulentOrderID) { 
            if (fraudulent.StartsWith("B")) {
                Console.WriteLine(fraudulent);
            }
            }
            Console.ReadLine();
        }
    }
}
