using System;

namespace IndexerOnAnInterface
{
    public interface IIndexInterface
    {
        // Indexer declaration:
        int this[int index]
        {
            get;
            set;
        }
    }
    class IndexerClass : IIndexInterface
    {
        private int[] arr = new int[100];
        public int this[int index]   // Indexer implementation
        {
            get => arr[index];
            set => arr[index] = value;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IndexerClass test = new IndexerClass();
            Random rand = new Random();
            // Initialize elements using indexer
            for (int i = 0; i < 10; i++)
            {
                test[i] = rand.Next();
            }
            // Print elements using indexer
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Element #{i} = {test[i]}");
            }
        }
    }
}