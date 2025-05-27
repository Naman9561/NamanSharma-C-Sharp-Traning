using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceChallengeOfDataType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] values = { "12.3", "45", "ABC", "11", "DEF" };

            decimal total = 0m;
            string message = "";

            foreach (var value in values)
            {
                decimal number; // stores the TryParse "out" value
                if (decimal.TryParse(value, out number))
                {
                    total += number;
                }
                else
                {
                    message += value;
                }
            }

            Console.WriteLine($"Message: {message}");
            Console.WriteLine($"Total: {total}");
            Console.ReadLine();
        }
    }
}
