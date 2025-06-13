using System;

namespace DayCollection
{
    internal class Program
    {
        string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
        // Indexer with only a get accessor with the expression-bodied definition:
        public int this[string day] => FindDayIndex(day);
        private int FindDayIndex(string day)
        {
            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == day)
                {
                    return j;
                }
            }
            throw new ArgumentOutOfRangeException(
                nameof(day),
                $"Day {day} is not supported.\nDay input must be in the form \"Sun\", \"Mon\", etc");
        }
        static void Main(string[] args)
        {
            var week = new Program();
            Console.WriteLine(week["Fri"]);
            try
            {
                Console.WriteLine(week["Made-up day"]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Not supported input: {e.Message}");
            }
        }
    }
}
