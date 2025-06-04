using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullCheck
{
    internal class Program
    {
        // Type Test
        public static T MidPoint<T>(IEnumerable<T> sequence)
        {
            if (sequence is IList<T> list)
            {
                return list[list.Count / 2];
            }
            else if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence), "Sequence can't be null.");
            }
            else
            {
                int halfLength = sequence.Count() / 2 - 1;
                if (halfLength < 0) halfLength = 0;
                return sequence.Skip(halfLength).First();
            }
        }
        static void Main(string[] args)
        {

            // Null Check
            int? maybe = null;

            if (maybe is int number)
            {
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            }
            else
            {
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }

            List<int> numbers = new List<int> {1,2,3,4,5};
            int middle = MidPoint(numbers);
            
            Console.ReadLine();
        }
    }
}
