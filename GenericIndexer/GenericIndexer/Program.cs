using System;
namespace GenericIndexer
{
    internal class Program
    {
        class GenericIndexer<T>
        {
            private T[] arr = new T[10];

            public T this[int idx]
            {
                get => arr[idx];
                set => arr[idx] = value;
            }
        }
        static void Main(string[] args)
        {
            var intCol = new GenericIndexer<int>();
            intCol[1] = 100;
            Console.WriteLine(intCol[1]); 

            var strCol = new GenericIndexer<string>();
            strCol[2] = "Indexers";
            Console.WriteLine(strCol[2]); 
        }
    }
}
