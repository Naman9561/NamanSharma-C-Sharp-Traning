class Program
{
    static void Main()
    {
        var numbers = Enumerable.Range(0, 8);

        Console.WriteLine("Take the first 3 elements:");
        foreach (int number in numbers.Take(3))
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nSkip the first 3 elements:");
        foreach (int number in numbers.Skip(3))
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nTakeWhile number < 5:");
        foreach (int number in numbers.TakeWhile(n => n < 5))
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nSkipWhile number < 5:");
        foreach (int number in numbers.SkipWhile(n => n < 5))
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nChunk into size of 3:");
        int chunkNumber = 1;
        foreach (int[] chunk in numbers.Chunk(3))
        {
            Console.WriteLine($"Chunk {chunkNumber++}:");
            foreach (int item in chunk)
            {
                Console.WriteLine($"    {item}");
            }
            Console.WriteLine();
        }
    }
}
