using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingIsStatment
{
    class Animal
    {
        public void Eat() { Console.WriteLine("Eating."); }
        public override string ToString()
        {
            return "I am an animal.";
        }
    }
    class Mammal : Animal { }
    class Giraffe : Mammal { }

    class SuperNova { }
    internal class Program
    {
        static void Main(string[] args)
        {
            var g = new Giraffe();
            var a = new Animal();
            FeedMammals(g);
            FeedMammals(a);
            SuperNova sn = new SuperNova();
            TestForMammals(g);
            TestForMammals(sn);

            void FeedMammals(Animal b)
            {
                if (b is Mammal m)
                {
                    m.Eat();
                }
                else
                {
                    Console.WriteLine($"{b.GetType().Name} is not a Mammal");
                }
            }

            void TestForMammals(object o)
            {
                var m = o as Mammal;
                if (m != null)
                {
                    Console.WriteLine(m.ToString());
                }
                else
                {
                    Console.WriteLine($"{o.GetType().Name} is not a Mammal");
                }
            }
            Console.ReadLine();
        }
    }
}
