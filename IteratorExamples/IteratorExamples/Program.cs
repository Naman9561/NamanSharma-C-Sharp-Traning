using System;
using System.Collections.Generic;

namespace IteratorExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Simple foreach loop over a List
            Console.WriteLine("foreach over List:");
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            foreach (var item in numbers)
                Console.WriteLine(item);

            // Using a method that uses multiple yield return statements
            Console.WriteLine("\nIterator Method:");
            foreach (var num in GetSingleDigitNumbers())
                Console.WriteLine(num);

            // Using a loop-based iterator method
            Console.WriteLine("\nIterator with Loop:");
            foreach (var num in GetSingleDigitNumbersLoop())
                Console.WriteLine(num);

            // Iterator that returns multiple number sets
            Console.WriteLine("\nIterator with Sets:");
            foreach (var num in GetSetsOfNumbers())
                Console.WriteLine(num);

            // Using an extension method to sample every 2nd item
            Console.WriteLine("\nSample Every 2nd Element:");
            foreach (var num in numbers.Sample(2))
                Console.WriteLine(num);

            // More complex iterator logic with mixed yield blocks
            Console.WriteLine("\nFirst Decile:");
            foreach (var num in GetFirstDecile())
                Console.WriteLine(num);

            // Demonstrate conditional iterator method with bool flag
            Console.WriteLine("\nSingle Digit Odds (true):");
            foreach (var num in GetSingleDigitOddNumbers(true))
                Console.WriteLine(num);

            Console.WriteLine("\nSingle Digit Odds (false):");
            foreach (var num in GetSingleDigitOddNumbers(false))
                Console.WriteLine(num);
        }

        // Manually yielding single-digit numbers
        public static IEnumerable<int> GetSingleDigitNumbers()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
        }

        // Looping approach to generate single-digit numbers
        public static IEnumerable<int> GetSingleDigitNumbersLoop()
        {
            int index = 0;
            while (index < 10)
                yield return index++;
        }
// Multiple blocks of yielded values (0–9, 50, 100–109)
        public static IEnumerable<int> GetSetsOfNumbers()
        {
            int index = 0;
            while (index < 10)
                yield return index++;
            yield return 50;
            index = 100;
            while (index < 110)
                yield return index++;
        }
// Yielding numbers using multiple strategies in one method
        public static IEnumerable<int> GetFirstDecile()
        {
            int index = 0;
            while (index < 10)
                yield return index++;
            yield return 50;
            // Instead of returning an array, yield from it
            var items = new int[] { 100, 101, 102, 103, 104, 105, 106, 107, 108, 109 };
            foreach (var item in items)
                yield return item;
        }
        // Wrapper method: decides between returning an empty collection or using an iterator
        public static IEnumerable<int> GetSingleDigitOddNumbers(bool getCollection)
        {
            if (!getCollection)     
                return new int[0]; // return empty collection
            else
                return IteratorMethod(); // delegate to iterator method
        }

        // Actual iterator logic: yields only odd single-digit numbers
        private static IEnumerable<int> IteratorMethod()
        {
            int index = 0;
            while (index < 10)
            {
                if (index % 2 == 1) // c
                                    // heck for odd
                    yield return index;
                index++;
            }
        }
    }
    // Extension methods for sampling sequences
    public static class EnumerableExtensions
    {
        // Sample every nth item from an IEnumerable<T>
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> sourceSequence, int interval)
        {
            int index = 0;
            foreach (T item in sourceSequence)
            {
                if (index++ % interval == 0)
                    yield return item;
            }
        }
    }
}
