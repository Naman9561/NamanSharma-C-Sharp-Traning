using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting async practice...\n");

            // Call async methods synchronously
            RunAsync().GetAwaiter().GetResult();

            Console.WriteLine("\nAll done.");
        }

        static async Task RunAsync()
        {
            // 1. Task (no return value)
            await WaitAndApologizeAsync();

            // 2. Task<TResult>
            int hours = await GetLeisureHoursAsync();
            Console.WriteLine($"Today's hours of leisure: {hours}\n");

            // 3. ValueTask<TResult> replaced with Task<TResult> (C# 7.3 doesn't support ValueTask well)
            int diceRoll = await GetDiceRollAsync();
            Console.WriteLine($"You rolled: {diceRoll}\n");

            // 4. IAsyncEnumerable<T> NOT available – simulate async stream with method
            Console.WriteLine("Reading words from stream:");
            string[] words = await ReadWordsSimulatedAsync();
            foreach (var word in words)
            {
                Console.Write(word + " ");
            }

            // 5. async void event handler demo
            await AsyncVoidEventHandlerDemoAsync();
        }

        // Task – no return value
        static async Task WaitAndApologizeAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Sorry for the delay...\n");
        }

        // Task<TResult> – returns a value
        static async Task<int> GetLeisureHoursAsync()
        {
            DayOfWeek today = await Task.FromResult(DateTime.Now.DayOfWeek);
            return (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday) ? 16 : 5;
        }

        // Simulate ValueTask with Task
        static async Task<int> GetDiceRollAsync()
        {
            await Task.Delay(500);
            return new Random().Next(1, 7);
        }

        // Simulate async stream by returning array
        static async Task<string[]> ReadWordsSimulatedAsync()
        {
            string data = @"This is a line of text.
                        Here is the second line of text.";

            await Task.Delay(200); // Simulate async work

            var list = new System.Collections.Generic.List<string>();
            using (var reader = new StringReader(data))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    list.AddRange(words);
                }
            }

            return list.ToArray();
        }

        // Async void event handler demo
        static async Task AsyncVoidEventHandlerDemoAsync()
        {
            var button = new FakeButton();
            button.Clicked += OnButtonClickedAsync;

            Console.WriteLine("\nClicking the button...");
            button.Click();

            await Task.Delay(1500); // Wait for async handler to complete
        }

        private static async void OnButtonClickedAsync(object sender, EventArgs e)
        {
            Console.WriteLine("   Handler is starting...");
            await Task.Delay(1000);
            Console.WriteLine("   Handler is done.");
        }

        public class FakeButton
        {
            public event EventHandler Clicked;

            public void Click()
            {
                Console.WriteLine("Button clicked. Raising event...");
                Clicked?.Invoke(this, EventArgs.Empty);
                Console.WriteLine("Event raised.");
            }
        }
    }
}
