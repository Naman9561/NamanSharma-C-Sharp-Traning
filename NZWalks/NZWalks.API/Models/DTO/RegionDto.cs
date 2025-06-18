namespace NZWalks.API.Models.DTO
{
    public class RegionDto
    {
        public Guid Id { get; set; } // Unique identifier for the region
        public required string Name { get; set; } // Name of the region
        public required string Code { get; set; } // Code representing the region (e.g., NZL for New Zealand)
        public string? RegionImageUrl { get; set; } // Area of the region in square kilometers or miles
    }
}
