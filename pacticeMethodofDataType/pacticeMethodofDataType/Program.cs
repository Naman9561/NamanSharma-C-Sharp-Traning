using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacticeMethodofDataType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string value = "102";
            int result = 0;
            if (int.TryParse(value, out result))
            {
                Console.WriteLine($"Measurement: {result}");
            }
            else
            {
                Console.WriteLine("Unable to report the measurement.");
            }

            string value1 = "bad";
            int result1 = 0;
            if (int.TryParse(value1, out result1))
            {
                Console.WriteLine($"Measurement: {result1}");
            }
            else
            {
                Console.WriteLine("Unable to report the measurement.");
            }

            if (result1 > 0)
                Console.WriteLine($"Measurement (w/ offset): {50 + result1}");
            Console.ReadLine();
        }
    }
}
