class Country
{
    public string Name { get; set; }
}
class Program
{
    static void Main()
    {
        var countries = new[]
        {
            new Country { Name = "Argentina" },
            new Country { Name = "Australia" },
            new Country { Name = "Brazil" }
        };

        var grouped = from country in countries
                      group country by country.Name[0];

        foreach (var g in grouped)
        {
            Console.WriteLine("Group: " + g.Key);
            foreach (var c in g)
                Console.WriteLine(" " + c.Name);
        }
    }
}
