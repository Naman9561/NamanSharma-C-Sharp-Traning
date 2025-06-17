public class Student
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required List<int> Scores { get; init; }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new()
        {
            new Student { FirstName = "Cesar", LastName = "Garcia", Scores = new List<int> { 71, 86, 77, 97 } },
            new Student { FirstName = "Nancy", LastName = "Engström", Scores = new List<int> { 75, 73, 78, 83 } },
            new Student { FirstName = "Ifunanya", LastName = "Ugomma", Scores = new List<int> { 84, 82, 96, 80 } },
            new Student { FirstName = "Svetlana", LastName = "Omelchenko", Scores = new List<int> { 88, 92, 97, 74 } },
            new Student { FirstName = "Debra", LastName = "Garcia", Scores = new List<int> { 96, 85, 91, 60 } },
            new Student { FirstName = "Ifeanacho", LastName = "Jamuike", Scores = new List<int> { 78, 88, 98, 70 } },
            new Student { FirstName = "Martina", LastName = "Mattsson", Scores = new List<int> { 82, 96, 79, 85 } }
        };

        // 1. ALL scores above 70
        Console.WriteLine("Students who scored above 70 in all exams:");
        var allAbove70 = students
            .Where(s => s.Scores.All(score => score > 70))
            .Select(s => $"{s.FirstName} {s.LastName}: {string.Join(", ", s.Scores)}");

        foreach (var student in allAbove70)
            Console.WriteLine(student);

        Console.WriteLine("\n-------------------------------");

        // 2. ANY score above 95
        Console.WriteLine("Students who scored above 95 in any exam:");
        var anyAbove95 = students
            .Where(s => s.Scores.Any(score => score > 95))
            .Select(s => $"{s.FirstName} {s.LastName}: Max Score = {s.Scores.Max()}");

        foreach (var student in anyAbove95)
            Console.WriteLine(student);

        Console.WriteLine("\n-------------------------------");

        // 3. CONTAINS a score of exactly 95
        Console.WriteLine("Students who scored exactly 95 in any exam:");
        var contains95 = students
            .Where(s => s.Scores.Contains(95))
            .Select(s => $"{s.FirstName} {s.LastName}: {string.Join(", ", s.Scores)}");

        foreach (var student in contains95)
            Console.WriteLine(student);
    }
}
