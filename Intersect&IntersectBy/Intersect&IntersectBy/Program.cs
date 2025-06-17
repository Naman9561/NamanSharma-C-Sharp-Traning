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

        var query = words1.Intersect(words2);

        foreach (var word in query)
        {
            Console.WriteLine(word);
        }

        //*********************InersectBy*********************

        var students = new List<Student>
        {
            new() { FirstName = "John", LastName = "Smith" },
            new() { FirstName = "Anna", LastName = "Brown" },
            new() { FirstName = "Sara", LastName = "Jones" }
        };

        var teachers = new List<Teacher>
        {
            new() { First = "John", Last = "Smith" },
            new() { First = "Michael", Last = "Green" }
        };

        var result = students.IntersectBy(
            teachers.Select(t => (t.First, t.Last)),
            s => (s.FirstName, s.LastName)
        );

        foreach (var person in result)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }
}
