using CodeFirstConventionsApp.Data;
using CodeFirstConventionsApp.Models;
using System;

namespace CodeFirstConventionsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    context.Database.CreateIfNotExists();

                    var department = new Department { Name = "Mathematics" };
                    context.Departments.Add(department);
                    context.SaveChanges();

                    var onsiteCourse = new OnsiteCourse
                    {
                        Title = "Calculus",
                        Credits = 4,
                        DepartmentID = department.DepartmentID,
                        Details = new Details
                        {
                            Time = DateTime.Now,
                            Location = "Room 101",
                            Days = "Monday, Wednesday, Friday"
                        }
                    };

                    var onsiteCourse1 = new OnsiteCourse
                    {
                        Title = "Naman",
                        Credits = 5,
                        DepartmentID = department.DepartmentID,
                        Details = new Details
                        {
                            Time = DateTime.Now,
                            Location = "Room 103",
                            Days = "Monday, Wednesday, Friday, Sunday"
                        }


                    };
                    context.Courses.Add(onsiteCourse);
                    context.Courses.Add(onsiteCourse1);

                    var onlineCourse = new OnlineCourse
                    {
                        Title = "Linear Algebra",
                        Credits = 3,
                        DepartmentID = department.DepartmentID,
                        URL = "https://example.com/linear-algebra"
                    };
                    context.Courses.Add(onlineCourse);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}