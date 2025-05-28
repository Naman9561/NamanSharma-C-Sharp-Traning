using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryCatchBlock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process1();
            }
            catch
            {
                Console.WriteLine("An exception has occurred");
            }

            Console.WriteLine("Exit program");

            void Process1()
            {
                try
                {
                    WriteMessage();
                }
                catch
                {
                    Console.WriteLine("Exception caught in Process1");
                }

            }

            void WriteMessage()
            {
                double float1 = 3000.0;
                double float2 = 0.0;
                int number1 = 3000;
                int number2 = 0;

                Console.WriteLine(float1 / float2);
                Console.WriteLine(number1 / number2);
            }
            Console.ReadLine();
        }
    }
}
