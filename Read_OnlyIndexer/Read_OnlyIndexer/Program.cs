using System;

namespace Read_OnlyIndexer
{
    internal class Program
    {
        private readonly string[] words;

        public Program(string text) => words = text.Split(' ');

        public string this[int i] => words[i];

        static void Main(string[] args)
        {
            var s = new Program("C# is awesome");
            Console.WriteLine(s[0]); 
        }
    }
}
