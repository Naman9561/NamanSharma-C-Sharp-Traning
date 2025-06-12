using EF6CustomConventionExample.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CustomConventionExample
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BlogContext>());
            using (var context = new BlogContext())
            {
                Console.WriteLine("Successfully queried Posts using custom convention.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
