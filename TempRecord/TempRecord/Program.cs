using System;

// Use indexers for encapsulating internal collections
// and providing a more natural syntax for accessing elements.

namespace TempRecord {
    internal class Program {
        // Array of temperature values
        float[] temps =
        {56.2F, 56.7F, 56.5F, 56.9F, 58.8F,61.3F, 65.9F, 62.1F, 59.2F, 57.5F};
        // To enable client code to validate input
        // when accessing your indexer.
        public int Length => temps.Length;
        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public float this[int index]
        {
            get => temps[index];
            set => temps[index] = value;
        }
        static void Main(string[] args)
        {
            var tempRecord = new Program();
            // Use the indexer's set accessor
            tempRecord[3] = 58.3F;
            tempRecord[5] = 60.1F;
            // Use the indexer's get accessor
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Element #{i} = {tempRecord[i]}");
            }
        }
    }
}