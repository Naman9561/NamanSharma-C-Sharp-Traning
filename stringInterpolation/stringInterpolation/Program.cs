using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringInterpolation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Bob";
            string message = $"Hello {firstName}!";
            Console.WriteLine(message);

            int version = 11;
            string updateText = "Update to Windows";
            string messages = $"{updateText} {version}";
            Console.WriteLine(messages);

            Console.ReadLine();
        }
    }
}
