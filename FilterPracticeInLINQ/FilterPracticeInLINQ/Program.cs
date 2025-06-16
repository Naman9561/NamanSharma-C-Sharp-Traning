enum GradeLevel { FirstYear, SecondYear, ThirdYear, FourthYear }

class Student
{
    public string? LastName { get; set; }
    public int ID { get; set; }
    public GradeLevel Year { get; set; }
}
class Program
{
    static List<Student> students = new()
    {
        new Student { LastName = "Adams", ID = 120, Year = GradeLevel.SecondYear },
        new Student { LastName = "Fakhouri", ID = 116, Year = GradeLevel.FirstYear },
        new Student { LastName = "Feng", ID = 117, Year = GradeLevel.FirstYear },
        new Student { LastName = "Garcia", ID = 115, Year = GradeLevel.ThirdYear },
        new Student { LastName = "Garcia", ID = 114, Year = GradeLevel.FourthYear },
        new Student { LastName = "Garcia", ID = 118, Year = GradeLevel.SecondYear },
        new Student { LastName = "Mortensen", ID = 113, Year = GradeLevel.FirstYear },
        new Student { LastName = "O'Donnell", ID = 112, Year = GradeLevel.FourthYear },
        new Student { LastName = "Omelchenko", ID = 111, Year = GradeLevel.FourthYear },
        new Student { LastName = "Tucker", ID = 119, Year = GradeLevel.ThirdYear },
        new Student { LastName = "Tucker", ID = 122, Year = GradeLevel.ThirdYear },
        new Student { LastName = "Zabokritski", ID = 121, Year = GradeLevel.FourthYear }
    };
   static void FilterByYearType(bool oddYear)
    {
        IEnumerable<Student> studentQuery = oddYear
            ? from student in students
              where student.Year is GradeLevel.FirstYear or GradeLevel.ThirdYear
              select student
            : from student in students
              where student.Year is GradeLevel.SecondYear or GradeLevel.FourthYear
              select student;

        var descr = oddYear ? "odd" : "even";
        Console.WriteLine($"Students in an {descr} year level:");
        foreach (Student s in studentQuery)
            Console.WriteLine($"{s.LastName}: {s.ID}");
    }
    static void Main()
    {
        FilterByYearType(true);
        Console.WriteLine();
        FilterByYearType(false);
    }
}
