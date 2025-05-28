using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testVariableScope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] students = { "Jenna", "Ayesha", "Carlos", "Viktor" };

            DisplayStudents(students);
            DisplayStudents(new string[] { "Robert", "Vanya" });

            void DisplayStudents(string[] studentss)
            {
                foreach (string student in studentss)
                {
                    Console.Write($"{student}, ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("*************************");
            PrintCircleArea(12);
            PrintCircleCircumference(12);
            void PrintCircleArea(int radius)
            {
                double pi = 3.14159;
                double area = pi * (radius * radius);
                Console.WriteLine($"Area = {area}");
            }
            void PrintCircleCircumference(int radius)
            {
                double pi = 3.14159;
                double circumference = 2 * pi * radius;
                Console.WriteLine($"Circumference = {circumference}");
            }
            Console.ReadLine();
        }
    }
}
