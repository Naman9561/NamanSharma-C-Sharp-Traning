class Program
{
    public class Student
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
    }
    public class Teacher
    {
        public required string First { get; init; }
        public required string Last { get; init; }
    }
    static void Main()
    {
        string[] words1 = { "the", "quick", "brown", "fox" };
        string[] words2 = { "jumped", "over", "the", "lazy", "dog" };

        var query = words1.Union(words2);

        foreach (var word in query)
        {
            Console.WriteLine(word);
        }

        //*********************UnionBy*********************
        var students = new List<Student>
        {
            new() { FirstName = "John", LastName = "Smith" },
            new() { FirstName = "Anna", LastName = "Brown" }
        };

        var teachers = new List<Teacher>
        {
            new() { First = "Sara", Last = "Jones" },
            new() { First = "John", Last = "Smith" }
        };

        var result = students
            .Select(s => (s.FirstName, s.LastName))
            .UnionBy(
                teachers.Select(t => (FirstName: t.First, LastName: t.Last)),
                x => (x.FirstName, x.LastName)
            );

        foreach (var person in result)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }
}
