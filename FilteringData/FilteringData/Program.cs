class Program
{
    static void Main()
    {
        string[] words = { "the", "quick", "brown", "fox", "jumps" };

        // Query syntax
        IEnumerable<string> query1 = from word in words
                                     where word.Length == 3
                                     select word;

        Console.WriteLine("Query Syntax Result:");
        foreach (string str in query1)
        {
            Console.WriteLine(str);
        }

        // Method syntax
        IEnumerable<string> query2 = words.Where(word => word.Length == 3);

        Console.WriteLine("\nMethod Syntax Result:");
        foreach (string str in query2)
        {
            Console.WriteLine(str);
        }
    }
}