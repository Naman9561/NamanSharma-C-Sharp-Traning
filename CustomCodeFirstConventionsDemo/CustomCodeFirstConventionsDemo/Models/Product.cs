using System;
using CustomCodeFirstConventionsDemo.Attributes;

namespace CustomCodeFirstConventionsDemo.Models
{
    public class Product
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public ProductCategory Category { get; set; }

        [IsUnicode(false)]
        public string Description { get; set; }
    }
}
