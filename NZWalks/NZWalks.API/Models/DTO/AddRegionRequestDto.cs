namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        public required string Name { get; set; } // Name of the region
        public required string Code { get; set; } // Code representing the region (e.g., NZL for New Zealand)
        public string? RegionImageUrl { get; set; } // Area of the region in square kilometers or miles
    }
}
