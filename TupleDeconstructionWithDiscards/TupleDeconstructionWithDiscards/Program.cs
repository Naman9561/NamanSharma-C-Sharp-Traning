using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleDeconstructionWithDiscards
{
    internal class Program
    {
        static (string, int, double) GetCityInformation(string cityName)
        {
            if (cityName == "New York")
                return ("New York", 8_000_000, 783.8);

            return ("Unknown", 0, 0);
        }
        static void Main(string[] args)
        {
            // Deconstruct tuple, discard first two values, keep 'area'
            var (_, _, area) = GetCityInformation("New York");

            Console.WriteLine($"City area: {area} sq km");
        }
    }
}
