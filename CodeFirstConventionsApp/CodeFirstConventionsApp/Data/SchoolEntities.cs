using CodeFirstConventionsApp.Models;
using MySql.Data.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeFirstConventionsApp.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SchoolEntities : DbContext
    {
        public SchoolEntities() : base("name=SchoolDBConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SchoolEntities>());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Course>().Map<OnsiteCourse>(m => m.Requires("Discriminator").HasValue("OnsiteCourse"));
            modelBuilder.Entity<Course>().Map<OnlineCourse>(m => m.Requires("Discriminator").HasValue("OnlineCourse"));
        }
    }
}