using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Repositories
{
    // Concrete implementation of the IRegionRepository interface using Entity Framework Core
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        // Constructor with dependency injection of the database context
        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Retrieves all regions from the database asynchronously
        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        // Retrieves a specific region by its unique identifier
        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Regions.FindAsync(id);
        }

        // Creates a new region in the database
        public async Task<Region> CreateRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);       // Add new region to DbContext
            await dbContext.SaveChangesAsync();              // Save changes to the database
            return region;                                   // Return the newly created region
        }

        // Updates an existing region with the given ID
        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null; // Return null if region not found
            }

            // Update region properties
            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync(); // Commit updates to the database
            return existingRegion;
        }

        // Deletes a region with the specified ID
        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null; // Return null if region not found
            }

            dbContext.Regions.Remove(existingRegion); // Remove the region
            await dbContext.SaveChangesAsync();       // Save changes to the database

            return existingRegion; // Return the deleted region
        }
    }
}
