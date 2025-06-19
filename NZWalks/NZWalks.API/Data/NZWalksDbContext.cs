using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    // This class represents the Entity Framework database context for the NZWalks API
    public class NZWalksDbContext : DbContext
    {
        // Constructor that accepts DbContext options (e.g., connection string)
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        // DbSet for Difficulties
        public DbSet<Difficulty> Difficulties { get; set; }

        // DbSet for Regions
        public DbSet<Region> Regions { get; set; }

        // DbSet for Walks
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            var difficulties = new List<Difficulty>
            {
                new Difficulty { Id = Guid.Parse("a5aa266e-eb88-4152-b511-739d2b73beb4"), Name = "Easy" },
                new Difficulty { Id = Guid.Parse("f54972a4-0bb2-4687-99aa-6875c2a9388e"), Name = "Medium" },
                new Difficulty { Id = Guid.Parse("79416f6b-6c8d-4dd0-a2ed-2ab26ffa3d2b"), Name = "Hard" }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions (all GUIDs are now unique)
            var regions = new List<Region>
            {
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000001"), Name = "North Island", Code = "NI", RegionImageUrl = "https://example.com/north-island.jpg" },
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000002"), Name = "South Island", Code = "SI", RegionImageUrl = "https://example.com/south-island.jpg" },
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000003"), Name = "Stewart Island", Code = "SI", RegionImageUrl = "https://example.com/stewart-island.jpg" },
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000004"), Name = "Chatham Islands", Code = "CI", RegionImageUrl = "https://example.com/chatham-islands.jpg" },
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000005"), Name = "Kermadec Islands", Code = "KI", RegionImageUrl = "https://example.com/kermadec-islands.jpg" },
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000006"), Name = "Auckland Islands", Code = "AI", RegionImageUrl = "https://example.com/auckland-islands.jpg" },
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000007"), Name = "Bounty Islands", Code = "BI", RegionImageUrl = "https://example.com/bounty-islands.jpg" },
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000008"), Name = "Antipodes Islands", Code = "AI", RegionImageUrl = "https://example.com/antipodes-islands.jpg" },
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000009"), Name = "Snares Islands", Code = "SI", RegionImageUrl = "https://example.com/snares-islands.jpg" },
                new Region { Id = Guid.Parse("10000000-0000-0000-0000-000000000010"), Name = "Campbell Island", Code = "CI", RegionImageUrl = "https://example.com/campbell-island.jpg" }
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
