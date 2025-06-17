class Program
{
    static void Main()
    {
        string[] words = { "the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog" };

        var query = words.Distinct();

        foreach (var word in query)
        {
            Console.WriteLine(word);
        }

        var query1 = words.DistinctBy(w => w.Length);

        foreach (var word1 in query1)
        {
            Console.WriteLine(word1);
        }
    }
}
