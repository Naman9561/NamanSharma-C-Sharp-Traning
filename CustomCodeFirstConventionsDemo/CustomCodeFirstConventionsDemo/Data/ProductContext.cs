using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Linq;
using System.Text.RegularExpressions;
using CustomCodeFirstConventionsDemo.Models;
using CustomCodeFirstConventionsDemo.Conventions;
using CustomCodeFirstConventionsDemo.Attributes;

namespace CustomCodeFirstConventionsDemo.Data
{
    public class ProductContext : DbContext
    {
        static ProductContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductContext>());
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new DateTime2Convention());

            modelBuilder.Properties<int>()
                        .Where(p => p.Name == "Key")
                        .Configure(p => p.IsKey().HasColumnOrder(1));

            modelBuilder.Properties()
                        .Where(p => p.Name == "Name")
                        .Configure(p => p.HasColumnOrder(2));

            modelBuilder.Properties()
                        .Having(p => p.GetCustomAttributes(false).OfType<IsUnicodeAttribute>().FirstOrDefault())
                        .Configure((c, att) => c.IsUnicode(att.Unicode));

            modelBuilder.Properties<string>()
                        .Configure(c => c.HasMaxLength(500));

            modelBuilder.Properties<string>()
                        .Where(p => p.Name == "Name")
                        .Configure(c => c.HasMaxLength(250));

            modelBuilder.Types()
                        .Configure(c => c.ToTable(GetTableName(c.ClrType)));
        }

        private string GetTableName(Type type)
        {
            var pluralizationService = DbConfiguration
                .DependencyResolver
                .GetService<IPluralizationService>();

            var pluralized = pluralizationService?.Pluralize(type.Name) ?? type.Name;
            var result = Regex.Replace(pluralized, "([a-z])([A-Z])", "$1_$2");

            return result.ToLower();
        }
    }
}
