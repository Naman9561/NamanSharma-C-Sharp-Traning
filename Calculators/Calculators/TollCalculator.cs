using System;

namespace Calculators
{
    internal class TollCalculator
    {
        public decimal CalculateToll(object vehicle, DateTime timeOfToll, bool inbound)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            decimal baseToll;

            if (vehicle is Car car)
            {
                if (car.Passengers == 0)
                    baseToll = 2.00m + 0.50m;
                else if (car.Passengers == 1)
                    baseToll = 2.00m;
                else if (car.Passengers == 2)
                    baseToll = 2.00m - 0.50m;
                else
                    baseToll = 2.00m - 1.00m;
            }
            else if (vehicle is Taxi taxi)
            {
                if (taxi.Fares == 0)
                    baseToll = 3.50m + 1.00m;
                else if (taxi.Fares == 1)
                    baseToll = 3.50m;
                else if (taxi.Fares == 2)
                    baseToll = 3.50m - 0.50m;
                else
                    baseToll = 3.50m - 1.00m;
            }
            else if (vehicle is Bus bus)
            {
                double occupancyRate = (double)bus.Riders / bus.Capacity;
                if (occupancyRate < 0.5)
                    baseToll = 5.00m + 2.00m;
                else if (occupancyRate > 0.9)
                    baseToll = 5.00m - 1.00m;
                else
                    baseToll = 5.00m;
            }
            else if (vehicle is DeliveryTruck truck)
            {
                if (truck.GrossWeightClass > 5000)
                    baseToll = 10.00m + 5.00m;
                else if (truck.GrossWeightClass < 3000)
                    baseToll = 10.00m - 2.00m;
                else
                    baseToll = 10.00m;
            }
            else
            {
                throw new ArgumentException("Not a known vehicle type", nameof(vehicle));
            }

            decimal premium = GetPeakTimePremium(timeOfToll, inbound);
            return baseToll * premium;
        }

        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        private bool IsWeekDay(DateTime time)
        {
            return !(time.DayOfWeek == DayOfWeek.Saturday || time.DayOfWeek == DayOfWeek.Sunday);
        }

        private TimeBand GetTimeBand(DateTime time)
        {
            int hour = time.Hour;

            if (hour < 6 || hour > 19)
                return TimeBand.Overnight;
            else if (hour < 10)
                return TimeBand.MorningRush;
            else if (hour < 16)
                return TimeBand.Daytime;
            else
                return TimeBand.EveningRush;
        }

        public decimal GetPeakTimePremium(DateTime time, bool inbound)
        {
            bool isWeekday = IsWeekDay(time);
            TimeBand band = GetTimeBand(time);

            if (!isWeekday)
                return 1.0m;

            switch (band)
            {
                case TimeBand.Overnight:
                    return 0.75m;
                case TimeBand.Daytime:
                    return 1.5m;
                case TimeBand.MorningRush:
                    return inbound ? 2.0m : 1.0m;
                case TimeBand.EveningRush:
                    return inbound ? 1.0m : 2.0m;
                default:
                    return 1.0m;
            }
        }
    }
}
