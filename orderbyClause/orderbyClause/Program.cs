class Country
{
    public string? Name { get; set; }
    public double Area { get; set; }
    public double Population { get; set; }
}
class Program
{
    static void Main()
    {
        var countries = new[]
        {
            new Country { Name = "X", Area = 500, Population = 3000 },
            new Country { Name = "Y", Area = 500, Population = 1000 },
            new Country { Name = "Z", Area = 300, Population = 2000 }
        };

        var sorted = from c in countries orderby c.Area, c.Population descending select c;

        foreach (var c in sorted)
            Console.WriteLine($"{c.Name} - {c.Area} - {c.Population}");
    }
}
