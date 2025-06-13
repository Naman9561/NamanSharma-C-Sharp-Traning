using System;

namespace BasicIndexer
{
    internal class Program
    {
        string[] data = new string[5];
        public string this[int index] //this[int index] Provides Indexer Signature
        {
            get => data[index];
            set => data[index] = value;
        }
        static void Main(string[] args)
        {
            var coll = new Program();
            coll[0] = "Hello";
            Console.WriteLine(coll[0]); 
        }
    }
    }

