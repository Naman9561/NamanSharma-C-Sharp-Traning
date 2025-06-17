
public enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear }

public class Student
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int ID { get; set; }
    public GradeLevel Year { get; set; }
    public List<int>? Scores { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new()
        {
            new Student { FirstName = "Alice", LastName = "Anderson", ID = 1, Year = GradeLevel.FirstYear, Scores = new List<int> { 90, 85, 88 } },
            new Student { FirstName = "Bob", LastName = "Brown", ID = 2, Year = GradeLevel.FirstYear, Scores = new List<int> { 70, 75, 72 } },
            new Student { FirstName = "Charlie", LastName = "Clark", ID = 3, Year = GradeLevel.SecondYear, Scores = new List<int> { 95, 91, 89 } },
            new Student { FirstName = "Diana", LastName = "Davis", ID = 4, Year = GradeLevel.ThirdYear, Scores = new List<int> { 60, 65, 58 } },
            new Student { FirstName = "Eve", LastName = "Evans", ID = 5, Year = GradeLevel.SecondYear, Scores = new List<int> { 82, 87, 84 } }
        };

        // Group by Year
        Console.WriteLine("Group by Year:");
        var groupByYear = students.GroupBy(s => s.Year);
        foreach (var group in groupByYear)
        {
            Console.WriteLine($"Year: {group.Key}");
            foreach (var student in group)
            {
                Console.WriteLine($"\t{student.FirstName} {student.LastName}");
            }
        }

        // Group by First Letter of Last Name
        Console.WriteLine("\nGroup by First Letter of Last Name:");
        var groupByFirstLetter = students.GroupBy(s => s.LastName[0]);
        foreach (var group in groupByFirstLetter)
        {
            Console.WriteLine($"Starts with: {group.Key}");
            foreach (var student in group)
            {
                Console.WriteLine($"\t{student.FirstName} {student.LastName}");
            }
        }

        // Group by Percentile
        Console.WriteLine("\nGroup by Percentile:");
        var groupByPercentile = students
            .Select(s => new { Student = s, Percentile = GetPercentile(s) })
            .GroupBy(s => s.Percentile);
        foreach (var group in groupByPercentile)
        {
            Console.WriteLine($"Percentile: {group.Key * 10}");
            foreach (var s in group)
            {
                Console.WriteLine($"\t{s.Student.FirstName} {s.Student.LastName}");
            }
        }
    }

    static int GetPercentile(Student s)
    {
        double avg = s.Scores.Average();
        return avg > 0 ? (int)(avg / 10) : 0;
    }
}
