class Program
{
    public class Teacher
    {
        public required string First { get; init; }
        public required string Last { get; init; }
        public required int ID { get; init; }
        public required string City { get; init; }
    }
    static void Main()
    {
        string[] words1 = { "the", "quick", "brown", "fox" };
        string[] words2 = { "jumped", "over", "the", "lazy", "dog" };

        var query = words1.Except(words2);

        foreach (var word in query)
        {
            Console.WriteLine(word);
        }

        //************************ExceptBy*************************************

        var teachers = new List<Teacher>
        {
            new() { First = "John", Last = "Smith", ID = 901, City = "NY" },
            new() { First = "Sara", Last = "Jones", ID = 950, City = "LA" },
            new() { First = "Mike", Last = "Brown", ID = 987, City = "Chicago" }
        };

        int[] teachersToExclude = { 901, 965, 932, 945, 987 };

        var result = teachers.ExceptBy(teachersToExclude, t => t.ID);

        foreach (var t in result)
        {
            Console.WriteLine($"{t.First} {t.Last}");
        }
    }
}
