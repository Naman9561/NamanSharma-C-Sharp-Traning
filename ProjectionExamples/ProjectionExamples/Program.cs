class Program
{
    class Bouquet
    {
        public required List<string> Flowers { get; init; }
    }

    static void Main()
    {
        SelectExample();
        SelectManyExample();
        SelectManyCombinationsExample();
        ZipTwoSequences();
        ZipThreeSequences();
        ZipWithSelector();
        SelectVsSelectMany();
    }

    static void SelectExample()
    {
        Console.WriteLine("\n--- Select (project first letter) ---");
        List<string> words = new() { "an", "apple", "a", "day" };

        // Query syntax
        var query = from word in words
                    select word.Substring(0, 1);

        foreach (var s in query)
            Console.WriteLine(s);
    }

    static void SelectManyExample()
    {
        Console.WriteLine("\n--- SelectMany (split phrases to words) ---");
        List<string> phrases = new() { "an apple a day", "the quick brown fox" };


        // Query syntax
        var query = from phrase in phrases
                    from word in phrase.Split(' ')
                    select word;

        foreach (var s in query)
            Console.WriteLine(s);
    }

    static void SelectManyCombinationsExample()
    {
        Console.WriteLine("\n--- SelectMany (all combinations of numbers and letters) ---");
        IEnumerable<int> numbers = new[] { 1, 2, 3 };
        IEnumerable<char> letters = new[] { 'A', 'B' };

        // Query syntax
        var query = from number in numbers
                    from letter in letters
                    select (number, letter);

        foreach (var item in query)
            Console.WriteLine(item);
    }

    static void ZipTwoSequences()
    {
        Console.WriteLine("\n--- Zip two sequences ---");
        IEnumerable<int> numbers = new[] { 1, 2, 3, 4, 5, 6, 7 };
        IEnumerable<char> letters = new[] { 'A', 'B', 'C', 'D', 'E', 'F' };

        foreach ((int number, char letter) in numbers.Zip(letters))
        {
            Console.WriteLine($"Number: {number} zipped with letter: '{letter}'");
        }
    }

    static void ZipThreeSequences()
    {
        Console.WriteLine("\n--- Zip three sequences ---");
        IEnumerable<int> numbers = new[] { 1, 2, 3, 4, 5, 6, 7 };
        IEnumerable<char> letters = new[] { 'A', 'B', 'C', 'D', 'E', 'F' };
        IEnumerable<string> emoji = new[] { "🤓", "🔥", "🎉", "👀", "⭐", "💜", "✔", "💯" };

        foreach ((int number, char letter, string em) in numbers.Zip(letters, emoji))
        {
            Console.WriteLine($"Number: {number} is zipped with letter: '{letter}' and emoji: {em}");
        }
    }

    static void ZipWithSelector()
    {
        Console.WriteLine("\n--- Zip with result selector ---");
        IEnumerable<int> numbers = new[] { 1, 2, 3, 4, 5, 6 };
        IEnumerable<char> letters = new[] { 'A', 'B', 'C', 'D', 'E', 'F' };

        var result = numbers.Zip(letters, (number, letter) => $"{number} = {letter} ({(int)letter})");

        foreach (var str in result)
            Console.WriteLine(str);
    }

    static void SelectVsSelectMany()
    {
        Console.WriteLine("\n--- Select vs SelectMany ---");

        List<Bouquet> bouquets = new()
        {
            new Bouquet { Flowers = new() { "sunflower", "daisy", "daffodil", "larkspur" } },
            new Bouquet { Flowers = new() { "tulip", "rose", "orchid" } },
            new Bouquet { Flowers = new() { "gladiolis", "lily", "snapdragon", "aster", "protea" } },
            new Bouquet { Flowers = new() { "larkspur", "lilac", "iris", "dahlia" } }
        };

        var query1 = bouquets.Select(bq => bq.Flowers);
        var query2 = bouquets.SelectMany(bq => bq.Flowers);

        Console.WriteLine("Results by using Select():");
        foreach (IEnumerable<string> collection in query1)
        {
            foreach (string item in collection)
                Console.WriteLine(item);
        }

        Console.WriteLine("\nResults by using SelectMany():");
        foreach (string item in query2)
            Console.WriteLine(item);
    }
}
