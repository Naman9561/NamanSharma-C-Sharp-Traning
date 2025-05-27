using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicProgramm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine is use to print the Message on the console
            Console.WriteLine("Hello World");

            // It Will give the error because using single quotes in which we only write a single character 
            //Console.WriteLine('Hello World');
     
            Console.WriteLine("Hello World");
            // you write this line to end the first line and wirte the second message in second line or this is known as line feed
            Console.WriteLine("");
            Console.WriteLine("You Wrote your first line of code");

            // we use Console.Write(""); to skip the line feed part Hello world is prindent in same line
            Console.Write("Hello");
            Console.Write("World");


            Console.ReadLine();
        }
    }
}
