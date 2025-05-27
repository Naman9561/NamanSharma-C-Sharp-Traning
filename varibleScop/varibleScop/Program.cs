using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varibleScop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 4, 8, 15, 16, 23, 42 };
            int total = 0;


            foreach (int number in numbers)
            {
                total += number;
                if (number == 42)
                {
                    bool found = true;

                    if (found)
                    {
                        Console.WriteLine("Set contains 42");

                    }
                }

            }
            
            Console.WriteLine($"Total: {total}");
            Console.ReadLine();
        }
    }
}
