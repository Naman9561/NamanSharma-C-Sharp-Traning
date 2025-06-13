class Product
{
    public string? Color { get; set; }
    public decimal Price { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public string? Size { get; set; }
}
class Program
{
    static void Main()
    {
        List<Product> products = new()
        {
            new Product { Color = "Red", Price = 9.99m },
            new Product { Color = "Blue", Price = 14.99m }
        };

        var productQuery = from prod in products
                           select new { prod.Color, prod.Price };

        foreach (var v in productQuery)
        {
            Console.WriteLine($"Color={v.Color}, Price={v.Price}");
        }
    }
}
