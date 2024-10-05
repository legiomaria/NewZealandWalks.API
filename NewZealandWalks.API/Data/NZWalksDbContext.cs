using Microsoft.EntityFrameworkCore;
using NewZealandWalks.API.Models.Domain;

namespace NewZealandWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("52ce5d3d-57f8-4de5-9824-792397e14697"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("3b9a4379-7da3-4355-ae29-6a2397e19a0b"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("8e0cbae9-c25d-4293-888b-5aa9fd4b3b61"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("aca28b41-818d-4e31-9a93-7d4728d26e21"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://unsplash.com/photos/cityscape-photo-during-daytime-hIKVSVKH7No"
                },
                new Region
                {
                    Id = Guid.Parse("eef803ba-b4e8-4bda-a218-b2086a309b4a"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("33ad922a-0505-4859-b76e-d43d6ca48ccf"),
                    Name = "Bay of plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("19aa4a46-7e2c-4596-bde3-3268a7a6823e"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://unsplash.com/photos/mountain-near-body-of-water-during-daytime-LZVmvKlchM0"
                },
                new Region
                {
                    Id = Guid.Parse("33e7f348-0d4e-41e1-801b-35f78df64c4f"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://unsplash.com/photos/mountains-covered-with-snow-near-road-75_s8iWHKLs"
                },
                new Region
                {
                    Id = Guid.Parse("b7879ce9-aca7-435f-b0e9-7960f7c11d6a"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
