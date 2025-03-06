using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IDifficultyRespository
    {
        Task<List<Difficulty>> GetAllAsync();
        Task<Difficulty?> GetByIdAsync(Guid id);
        Task<Difficulty> CreateAsync(Difficulty difficuly);
        Task<Difficulty?> UpdateAsync(Guid id, Difficulty difficulty);
        Task<Difficulty?> DeleteAsync(Guid id);
    }
}
