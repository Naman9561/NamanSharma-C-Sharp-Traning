using System.Collections.Generic;

namespace CustomCodeFirstConventionsDemo.Models
{
    public class ProductCategory
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
