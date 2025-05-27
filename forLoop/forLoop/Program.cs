using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine(i);
                if (i == 7) break;
            }

            string[] names = { "Alex", "Eddie", "David", "Michael" };
            for (int i = 0; i < names.Length; i++) {
                if (names[i] == "David")
                {
                    names[i] = "Sammy";
                }
            }
            foreach (var name in names) Console.WriteLine(name);

            Console.ReadLine();
        }
    }
}
