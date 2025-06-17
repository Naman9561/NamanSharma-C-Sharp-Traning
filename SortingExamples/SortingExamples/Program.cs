public enum GradeLevel
{
    FirstYear = 1,
    SecondYear,
    ThirdYear,
    FourthYear
}

public class Student
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int ID { get; init; }
    public required GradeLevel Year { get; init; }
    public required List<int> Scores { get; init; }
    public required int DepartmentID { get; init; }
}

public class Teacher
{
    public required string First { get; init; }
    public required string Last { get; init; }
    public required int ID { get; init; }
    public required string City { get; init; }
}

public class Department
{
    public required string Name { get; init; }
    public int ID { get; init; }
    public required int TeacherID { get; init; }
}

class Program
{
    static void Main()
    {
        var teachers = new List<Teacher>
        {
            new() { First = "Alice", Last = "Smith", ID = 1, City = "Seattle" },
            new() { First = "Bob", Last = "Johnson", ID = 2, City = "New York" },
            new() { First = "Charlie", Last = "Brown", ID = 3, City = "Seattle" },
            new() { First = "Diana", Last = "White", ID = 4, City = "Chicago" },
            new() { First = "Eve", Last = "Black", ID = 5, City = "New York" }
        };

        Console.WriteLine("=== Primary Sort: Last Name Ascending ===");
        var query1 = teachers.OrderBy(t => t.Last).Select(t => t.Last);
        foreach (var last in query1)
            Console.WriteLine(last);

        Console.WriteLine("\n=== Primary Sort: Last Name Descending ===");
        var query2 = teachers.OrderByDescending(t => t.Last).Select(t => t.Last);
        foreach (var last in query2)
            Console.WriteLine(last);

        Console.WriteLine("\n=== Secondary Sort: City, Then Last Name Ascending ===");
        var query3 = teachers.OrderBy(t => t.City).ThenBy(t => t.Last).Select(t => (t.Last, t.City));
        foreach (var item in query3)
            Console.WriteLine($"City: {item.City}, Last Name: {item.Last}");

        Console.WriteLine("\n=== Secondary Sort: City Ascending, Then Last Name Descending ===");
        var query4 = teachers.OrderBy(t => t.City).ThenByDescending(t => t.Last).Select(t => (t.Last, t.City));
        foreach (var item in query4)
            Console.WriteLine($"City: {item.City}, Last Name: {item.Last}");
    }
}
