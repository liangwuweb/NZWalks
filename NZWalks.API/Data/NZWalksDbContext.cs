using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Difficulties
            //Easy, Medium, Hard
            var difficulties = new List<Difficulty>() {
                new Difficulty()
                {
                    Id = Guid.Parse("CF485D88-A013-42B2-9DBC-3844BEC54D1C"),
                    Name ="Easy"

                },
                new Difficulty()
                {
                    Id = Guid.Parse("089DB1E9-4042-40E9-86EB-CFC54AF2564A"),
                    Name ="Medium"

                },
                new Difficulty()
                {
                    Id = Guid.Parse("823AC9EB-67F5-4218-AD6F-569EB1577DBC"),
                    Name ="Hard"

                },
            };

            //Seed difficulties data for Regions
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>
            {
                new Region
                {
                    Id=Guid.Parse("27C62ABC-9A69-449A-91E9-60EBDDA21B5D"),
                    Name="Bay Of Plenty",
                    Code="BOP",
                    RegionImageUrl="https://unsplash.com/photos/tltoIabpBT8"

                },
                new Region
                {
                    Id=Guid.Parse("8EBC4748-EE50-4A70-9F1C-4C819958DE05"),
                    Name="Wellington",
                    Code="WGN",
                    RegionImageUrl="https://unsplash.com/photos/1Q3neJv6zHU"

                },
                new Region
                {
                    Id=Guid.Parse("A5C79BC2-82E4-4273-B27B-2C67ABE5A6BC"),
                    Name="Nelson",
                    Code="NSN",
                    RegionImageUrl="https://unsplash.com/photos/p4q-Ra__g8M"

                },
                new Region
                {
                    Id=Guid.Parse("7AA65464-9432-49E0-A3F6-024052467757"),
                    Name="Southland",
                    Code="STL",
                    RegionImageUrl="https://unsplash.com/photos/uqAUg1zvMXQ"

                }

            };

            modelBuilder.Entity<Region>().HasData(regions);
            
        }
    }
}
