using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    // Interface defining operations for managing Region entities
    public interface IRegionRepository
    {
        // Retrieves all regions from the database asynchronously
        Task<List<Region>> GetAllRegionsAsync();

        // Retrieves a specific region by its unique identifier (GUID)
        Task<Region?> GetRegionByIdAsync(Guid id);

        // Adds a new region to the database
        Task<Region> CreateRegionAsync(Region region);

        // Updates an existing region identified by its GUID
        Task<Region?> UpdateRegionAsync(Guid id, Region region);

        // Deletes a region from the database using its GUID
        Task<Region?> DeleteRegionAsync(Guid id);
    }
}
