using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringConcat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Bob";
            string message = "Hello " + firstName;
            Console.WriteLine(message);

            string first = "Bob";
            string greeting = "Hello";
            string messag = greeting + " " + first + "!";
            Console.WriteLine(message);

            string firstNames = "Bob";
            string greetings = "Hello";
            Console.WriteLine(greetings + " " + firstNames + "!");

            Console.ReadLine();
        }
    }
}
