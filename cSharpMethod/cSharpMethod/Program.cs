using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = {1,2,3,4,5,6};

            void arrayLoop() {
                foreach (int i in a) {
                    Console.WriteLine(i);
                }
            }
            arrayLoop();

            void dispalyRandomNumbers() {
                Random random = new Random();
                for (int i = 0; i <= 5; i++) {
                    Console.WriteLine($"{random.Next(1,200)}");
                }
            }
            dispalyRandomNumbers();
            Console.ReadLine();
        }
    }
}
