using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPractice
{
    internal class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            // Other properties, methods, events...
        }
        static void Main(string[] args)
        {
            Person person1 = new Person("Leopold", 6);
            Console.WriteLine($"person1 Name = {person1.Name} Age = {person1.Age}");

            // Declare new person, assign person1 to it.
            Person person2 = person1;

            // Change the name of person2, and person1 also changes.
            person2.Name = "Molly";
            person2.Age = 16;

            Console.WriteLine($"person2 Name = {person2.Name} Age = {person2.Age}");
            Console.WriteLine($"person1 Name = {person1.Name} Age = {person1.Age}");

            Person person3 = new Person("Naman",23);
            Console.WriteLine($"person3 Name = {person3.Name} Age = {person3.Age}");

            Console.ReadLine();
        }
    }
}
