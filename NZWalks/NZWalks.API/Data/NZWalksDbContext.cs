using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; } // Represents the collection of Difficulty entities in the database
        public DbSet<Region> Regions { get; set; } // Represents the collection of Region entities in the database
        public DbSet<Walk> Walks { get; set; } // Represents the collection of Walk entities in the database
    }
}
