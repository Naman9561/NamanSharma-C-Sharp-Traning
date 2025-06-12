using EF6CustomConventionExample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CustomConventionExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogContext())
            {
                var posts = context.Posts.ToList();
                Console.WriteLine("Successfully queried Posts using custom convention.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
