using System;
using System.Collections.Generic;
using System.Linq;
class Country
{
    public string Name { get; set; }
    public double Area { get; set; }
}
class Program
{
    static void Main()
    {
        List<Country> countries = new()
        {
            new Country { Name = "India", Area = 3287 },
            new Country { Name = "Nepal", Area = 147 },
            new Country { Name = "Bhutan", Area = 38 }
        };

        var result = from country in countries where country.Area > 100 select country;

        foreach (var c in result)
            Console.WriteLine(c.Name);
    }
}
