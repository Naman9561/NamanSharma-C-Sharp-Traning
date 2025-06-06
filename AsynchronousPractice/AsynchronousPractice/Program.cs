using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsynchronousPractice
{

    class DamageResult
    {
        public int Damage { get; set; } = new Random().Next(10, 100); // Simulated damage
    }

    class User
    {
        public int id { get; set; }
        public bool isEnabled { get; set; } = false; // Simulated user property
    }

    class Program
    {
        private static readonly HttpClient s_httpClient = new HttpClient();

        private static readonly IEnumerable<string> s_urlList = new string[]
        {
        "https://learn.microsoft.com",
        "https://learn.microsoft.com/dotnet",
        "https://dotnetfoundation.org"
        };

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Application started ===\n");

            await CountDotNetOccurrences();
            await RetrieveUsersAsync();
            await CalculateDamageAsync();

            Console.WriteLine("\n=== Application ended ===");
        }

        // Example: Asynchronous I/O-bound operation
        static async Task CountDotNetOccurrences()
        {
            Console.WriteLine("Counting '.NET' occurrences in websites...");

            int total = 0;
            foreach (var url in s_urlList)
            {
                var html = await s_httpClient.GetStringAsync(url);
                int count = Regex.Matches(html, @"\.NET").Count;
                Console.WriteLine($"{url}: {count}");
                total += count;
            }

            Console.WriteLine($"Total '.NET' mentions: {total}\n");
        }

        // Example: Simulated I/O-bound user retrieval
        static async Task<IEnumerable<User>> GetUsersAsync(IEnumerable<int> userIds)
        {
            var tasks = userIds.Select(id => Task.FromResult(new User { id = id })).ToArray();
            return await Task.WhenAll(tasks);
        }

        static async Task RetrieveUsersAsync()
        {
            Console.WriteLine("Retrieving user list...");

            var userIds = Enumerable.Range(1, 5);
            var users = await GetUsersAsync(userIds);

            foreach (var user in users)
            {
                Console.WriteLine($"User ID: {user.id}, IsEnabled: {user.isEnabled}");
            }

            Console.WriteLine();
        }

        // Example: CPU-bound calculation offloaded to background thread
        static DamageResult CalculateDamage()
        {
            // Simulating expensive calculation
            Task.Delay(1000).Wait(); // Blocking delay for simulation
            return new DamageResult();
        }

        static async Task CalculateDamageAsync()
        {
            Console.WriteLine("Calculating damage (CPU-bound work)...");

            var result = await Task.Run(() => CalculateDamage());
            Console.WriteLine($"Damage result: {result.Damage}\n");
        }
    }
}
