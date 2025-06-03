using System;

namespace Calculators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tollCalc = new TollCalculator();
            var now = DateTime.Now;
            bool inbound = true;

            var car = new Car { Passengers = 3 };
            var taxi = new Taxi { Fares = 1 };
            var bus = new Bus { Riders = 45, Capacity = 50 };
            var truck = new DeliveryTruck { GrossWeightClass = 5500 };

            Console.WriteLine($"The toll for a car is {tollCalc.CalculateToll(car, now, inbound):C}");
            Console.WriteLine($"The toll for a taxi is {tollCalc.CalculateToll(taxi, now, inbound):C}");
            Console.WriteLine($"The toll for a bus is {tollCalc.CalculateToll(bus, now, inbound):C}");
            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(truck, now, inbound):C}");

            try
            {
                tollCalc.CalculateToll("this will fail", now, inbound);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }

            try
            {
                tollCalc.CalculateToll(null, now, inbound);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }
        }
    }
}
