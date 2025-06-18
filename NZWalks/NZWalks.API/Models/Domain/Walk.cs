namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; } // Unique identifier for the walk
        public required string Name { get; set; } // Name of the walk
        public required string Description { get; set; } // Length of the walk in kilometers or miles
        public double LengthInkm { get; set; } // URL of an image representing the walk
        public string? WalkImageUrl { get; set; } // Foreign key to the Region entity
        public Guid DifficultyId { get; set; } // Foreign key to the Difficulty entity
        public Difficulty Difficulty { get; set; } // Navigation property to the associated Difficulty entity
        public Guid RegionId { get; set; } // Foreign key to the Region entity
        public Region Region { get; set; } // Navigation property to the associated Region entity
    }
}
