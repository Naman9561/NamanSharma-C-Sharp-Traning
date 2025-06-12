using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CustomCodeFirstConventionsDemo.Models;
using CustomCodeFirstConventionsDemo.Data;

namespace CustomCodeFirstConventionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProductContext())
            {
                db.Database.Initialize(force: true); // Ensure DB creation.

                var category = new ProductCategory
                {
                    Name = "Electronics",
                    Products = new List<Product>
                        {
                            new Product
                            {
                                Name = "Smartphone",
                                Price = 699.99m,
                                ReleaseDate = DateTime.Now, // Fixed: Removed 'new' keyword
                                Description = "Latest model"
                            },
                            new Product
                            {
                                Name = "SmartTV",
                                Price = 99.99m,
                                ReleaseDate = new DateTime(2024, 1, 1, 10, 30, 20),
                                Description = "Latest model of TV"
                            },
                            new Product
                            {
                                Name = "SmartWatch",
                                Price = 9.99m,
                                ReleaseDate = new DateTime(2024, 1, 1),
                                Description = "Latest model of Watch"
                            }
                        }
                };
                db.Set<ProductCategory>().Add(category);
                db.Products.AddRange(category.Products);
                db.SaveChanges();

                var products = db.Products.Include(p => p.Category).ToList();
                products.ForEach(p => Console.WriteLine($"Product: {p.Name}, Category: {p.Category?.Name}"));
            }
        }
    }
}
