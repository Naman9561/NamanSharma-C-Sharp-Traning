using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EF6CustomConventionExample.Models;
using EF6CustomConventionExample.Conventions;

namespace EF6CustomConventionExample.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogContext() : base("name=BlogContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.AddBefore<IdKeyDiscoveryConvention>(new CustomKeyDiscoveryConvention());
            modelBuilder.Conventions.Remove<IdKeyDiscoveryConvention>();
        }
    }
}
