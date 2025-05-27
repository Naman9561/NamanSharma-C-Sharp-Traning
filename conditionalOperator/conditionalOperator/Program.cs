using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conditionalOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int saleAmount = 100;
            int discount = saleAmount > 1000 ? 100 : 50;
            Console.WriteLine($"Discount: {discount}");
            Console.ReadLine();
        }
    }
}
