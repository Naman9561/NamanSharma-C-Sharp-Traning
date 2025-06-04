using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationalPatterns
{
    internal class Program
    {
        static string WaterState(int tempInFahrenheit)
        {
            if (tempInFahrenheit < 32)
                return "solid";
            else if (tempInFahrenheit == 32)
                return "solid/liquid transition";
            else if (tempInFahrenheit > 32 && tempInFahrenheit < 212)
                return "liquid";
            else if (tempInFahrenheit == 212)
                return "liquid / gas transition";
            else // tempInFahrenheit > 212
                return "gas";
        }
        static void Main(string[] args)
        {
            int[] testTemperatures = { 20, 32, 50, 100, 212, 250 };

            Console.WriteLine("Using WaterState:");
            foreach (var temp in testTemperatures)
            {
                Console.WriteLine($"{temp}°F => {WaterState(temp)}");
            }
        }
    }
}
