using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly AppDbContext dbContext;

        public SQLWalkRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            var difficulty = await dbContext.Difficulties.FirstOrDefaultAsync(x => x.Id == walk.DifficultyId);
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == walk.RegionId);
            
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            walk.Difficulty = difficulty;
            walk.Region = region;
            return walk;
        }

        async Task<List<Walk>> IWalkRepository.GetAllAsync()
        {
            // Include() allows us to return the data from the referenced types
            return await dbContext.Walks
                .Include("Difficulty")
                .Include("Region").
                ToListAsync();
            //return await dbContext.Walks.Include(x => x.Difficulty).Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
