using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // \n is used to write in new line
            Console.WriteLine("Hello\nWorld!");

            // \t to give a tab spacing
            Console.WriteLine("Hello\tWorld!");

            // \ \ use to give "" to wordes
            Console.WriteLine("Hello \"World\"!");

            // \\ use double backslash for file directory
            Console.WriteLine("c:\\source\\repos");

            Console.WriteLine("Generating invoices for customer \"Contoso Corp\" ... \n");
            Console.WriteLine("Invoice: 1021\t\tComplete!");
            Console.WriteLine("Invoice: 1022\t\tComplete!");
            Console.WriteLine("\nOutput Directory:\t");

            // @ is use let the \ : with the message
            Console.Write(@"c:\invoices");

            // use /u for Japanese
            Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!");
            Console.ReadLine();
        }
    }
}
