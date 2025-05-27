using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstValue = 500;
            int secondValue = 600;
            int largerValue;

            largerValue= System.Math.Max(firstValue,secondValue);

            Console.WriteLine(largerValue);
            Console.ReadLine();
        }
    }
}
