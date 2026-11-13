using SPR521_t2.DAL.Entities;

namespace SPR521_t2.DAL.Repositories;

public interface ISushiTypeRepository
{
    Task<IReadOnlyList<SushiType>> GetAllAsync();
    Task<SushiType?> GetByIdAsync(int id);
    Task<SushiType> CreateAsync(SushiType sushiType);
    Task<SushiType?> UpdateAsync(int id, SushiType sushiType);
    Task<bool> DeleteAsync(int id);
}
