using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDeconstructionWithDiscards
{
    class Person
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string City { get; }
        public string State { get; }

        public Person(string firstName, string middleName, string lastName, string city, string state)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            City = city;
            State = state;
        }

        // Deconstruct method with 4 out parameters
        public void Deconstruct(out string firstName, out string lastName, out string city, out string state)
        {
            firstName = FirstName;
            lastName = LastName;
            city = City;
            state = State;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                var person = new Person("John", "Quincy", "Adams", "Boston", "MA");

                // Deconstruct person, discard lastName and state
                var (firstName, _, city, _) = person;

                Console.WriteLine($"Hello {firstName} of {city}!");
            }
        }
    }
}
