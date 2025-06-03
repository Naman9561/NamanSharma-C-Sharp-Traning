using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> actionExample1 = x => Console.WriteLine($"x is: {x}");

            Action<string, string> actionExample2 = (x, y) =>
                Console.WriteLine($"x is: {x}, y is {y}");

            Func<string, int> funcExample1 = x => Convert.ToInt32(x);

            Func<int, int, int> funcExample2 = (x, y) => x + y;

            actionExample1("string for x");

            actionExample2("string for x", "string for y");

            Console.WriteLine($"The value is {funcExample1("1")}");

            Console.WriteLine($"The sum is {funcExample2(1, 2)}");

            Console.ReadLine();
        }
    }
}
