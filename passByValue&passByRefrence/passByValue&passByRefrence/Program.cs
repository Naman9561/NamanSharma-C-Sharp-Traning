using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passByValue_passByRefrence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test Pass By Value

            int a = 3;
            int b = 4;
            int c = 0;

            Console.WriteLine($"global statement: {a} x {b} = {c}");
            Multiply(a, b, c);
            void Multiply(int d, int e, int f)
            {
                f = d * e;
                Console.WriteLine($"inside Multiply method: {d} x {e} = {f}");
            }

            Console.WriteLine("************************");
            //Test Pass By Refrence

            int[] array = { 1, 2, 3, 4, 5 };

            PrintArray(array);
            Clear(array);
            PrintArray(array);

            void PrintArray(int[] arrays)
            {
                foreach (int x in arrays)
                {
                    Console.Write($"{x} ");
                }
                Console.WriteLine();
            }

            void Clear(int[] arrays)
            {
                for (int i = 0; i < arrays.Length; i++)
                {
                    arrays[i] = 0;
                }
            }

            Console.ReadLine();
        }
    }
}
