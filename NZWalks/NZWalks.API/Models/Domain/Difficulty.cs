namespace NZWalks.API.Models.Domain
{
    public class Difficulty
    {
        public Guid Id { get; set; } // Unique identifier for the difficulty level
        public required string Name { get; set; } // Name of the difficulty level (e.g., Easy, Medium, Hard)

    }
}
