using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLDifficultyRespository : IDifficultyRespository
    {
        private readonly AppDbContext _dbContext;
        public SQLDifficultyRespository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Difficulty> CreateAsync(Difficulty difficulty)
        {
            await _dbContext.Difficulties.AddAsync(difficulty);
            await _dbContext.SaveChangesAsync();
            return difficulty;
        }

        public async Task<Difficulty?> DeleteAsync(Guid id)
        {
            var existingDifficulty = await _dbContext.Difficulties.FirstOrDefaultAsync(x => x.Id == id);

            if (existingDifficulty == null)
            {
                return null;
            }

            _dbContext.Difficulties.Remove(existingDifficulty);
            await _dbContext.SaveChangesAsync();
            return (existingDifficulty);
        }

        public async Task<List<Difficulty>> GetAllAsync()
        {
            return await _dbContext.Difficulties.ToListAsync();
        }

        public async Task<Difficulty?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Difficulties.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Difficulty?> UpdateAsync(Guid id, Difficulty difficulty)
        {
            var existingDifficulty = await _dbContext.Difficulties.FirstOrDefaultAsync(x => x.Id == id);

            if (existingDifficulty == null)
            {
                return null;
            }

            existingDifficulty.Name = difficulty.Name;

            await  _dbContext.SaveChangesAsync();
            return existingDifficulty;
        }
    }
}
