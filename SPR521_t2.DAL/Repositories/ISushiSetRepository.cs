using SPR521_t2.DAL.Entities;

namespace SPR521_t2.DAL.Repositories
{
    public interface ISushiSetRepository
    {
        Task<List<SushiSet>> GetAllAsync();
        Task<SushiSet?> GetByIdAsync(int id);
        Task<SushiSet> CreateAsync(SushiSet sushiSet);
        Task<bool> UpdateAsync(SushiSet sushiSet);
        Task<bool> DeleteAsync(int id);
    }
}