﻿using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class InMemoryDbContext : AppDbContext
    {
        private static bool _initialized = false;
        private static readonly object padlock = new object();

        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> dbContextOptions) : base(dbContextOptions)
        {
            lock (padlock)
            {
                if (!_initialized)
                {
                    _initialized = true;
                    this.Difficulties.AddRange(GetDifficultyData());
                    this.Regions.AddRange(GetRegionData());
                    this.Walks.AddRange(GetWalkData());
                    this.SaveChanges();
                }
            }
        }

        private List<Difficulty> GetDifficultyData()
        {
            return new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("73a82da0-59e8-49b6-9399-9e3f29470103"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("07354700-0a71-4797-bb2c-0c2e24c91094"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("6d5e0be6-2f68-44f8-bfb2-ec02b9e90e88"),
                    Name = "Hard"
                }
            };
        }

        private List<Region> GetRegionData()
        {
            return new List<Region>
            {
                 new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                }
            };
        }

        private List<Walk> GetWalkData()
        {
            return new List<Walk>
            {
                new Walk
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Name = "The Jolly Walk",
                    Description = "A really fun walk" ,
                    LengthInKm = 10,
                    WalkImageUrl = @"http://localhost:5072/api/photos",
                    RegionId = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    DifficultyId = Guid.Parse("73a82da0-59e8-49b6-9399-9e3f29470103")
                }
            };
        }
    }
}
