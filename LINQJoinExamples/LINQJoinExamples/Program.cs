class Program
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int DepartmentID { get; set; }
    }

    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public int TeacherID { get; set; }
    }

    public class Teacher
    {
        public int ID { get; set; }
        public string First { get; set; } = "";
        public string Last { get; set; } = "";
    }

    static void Main(string[] args)
    {
        var students = new List<Student>
{
    new Student { ID = 1, FirstName = "Alice", LastName = "Smith", DepartmentID = 1 },
    new Student { ID = 2, FirstName = "Bob", LastName = "Brown", DepartmentID = 2 },
    new Student { ID = 3, FirstName = "Charlie", LastName = "Davis", DepartmentID = 3 }
};

        var departments = new List<Department>
{
    new Department { ID = 1, Name = "Computer Science", TeacherID = 1 },
    new Department { ID = 2, Name = "Mathematics", TeacherID = 2 },
    new Department { ID = 3, Name = "Physics", TeacherID = 3 }
};

        var teachers = new List<Teacher>
{
    new Teacher { ID = 1, First = "Grace", Last = "Hopper" },
    new Teacher { ID = 2, First = "Alan", Last = "Turing" },
    new Teacher { ID = 3, First = "Marie", Last = "Curie" }
};

        // **************************Multiple Join (Query Syntax)***************************
        var multiJoinQuery = from student in students
                             join department in departments on student.DepartmentID equals department.ID
                             join teacher in teachers on department.TeacherID equals teacher.ID
                             select new
                             {
                                 StudentName = $"{student.FirstName} {student.LastName}",
                                 DepartmentName = department.Name,
                                 TeacherName = $"{teacher.First} {teacher.Last}"
                             };

        foreach (var item in multiJoinQuery)
        {
            Console.WriteLine($"The student \"{item.StudentName}\" studies in the department run by \"{item.TeacherName}\".");
        }

        // **************************Inner Join (Query Syntax)***************************

        var innerJoinGroup = from department in departments
                             join student in students on department.ID equals student.DepartmentID into gj
                             from subStudent in gj
                             select new
                             {
                                 DepartmentName = department.Name,
                                 StudentName = $"{subStudent.FirstName} {subStudent.LastName}"
                             };

        Console.WriteLine("Inner join using GroupJoin():");
        foreach (var v in innerJoinGroup)
        {
            Console.WriteLine($"{v.DepartmentName} - {v.StudentName}");
        }

        //**************************Group Join (Query Syntax)***************************

        var groupedQuery = from department in departments
                           join student in students on department.ID equals student.DepartmentID into studentGroup
                           select new
                           {
                               DepartmentName = department.Name,
                               Students = studentGroup
                           };

        foreach (var group in groupedQuery)
        {
            Console.WriteLine($"{group.DepartmentName}:");
            foreach (var student in group.Students)
            {
                Console.WriteLine($"  {student.FirstName} {student.LastName}");
            }
        }

        // **************************Left Outer Join (Query Syntax)***************************

        var leftOuterJoin = from department in departments
                            join student in students on department.ID equals student.DepartmentID into gj
                            from sub in gj.DefaultIfEmpty()
                            select new
                            {
                                Department = department.Name,
                                StudentName = sub != null ? $"{sub.FirstName} {sub.LastName}" : "No Student"
                            };

        Console.WriteLine("Left outer join:");
        foreach (var v in leftOuterJoin)
        {
            Console.WriteLine($"{v.Department}: {v.StudentName}");
        }


    }
}