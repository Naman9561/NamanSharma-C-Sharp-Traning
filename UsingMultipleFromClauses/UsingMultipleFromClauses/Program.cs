class City
{
    public string Name { get; set; }
    public int Population { get; set; }
}
class Country
{
    public string Name { get; set; }
    public List<City> Cities { get; set; }
}
class Program
{
    static void Main()
    {
        var countries = new List<Country>
        {
            new Country {
                Name = "CountryA",
                Cities = new List<City> {
                    new City { Name = "City1", Population = 15000 },
                    new City { Name = "City2", Population = 9000 }
                }
            }
        };
        var bigCities = from country in countries from city in country.Cities where city.Population > 10000 select city;
        foreach (var city in bigCities)
            Console.WriteLine(city.Name);
    }
}
