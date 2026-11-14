using Microsoft.EntityFrameworkCore;
using SPR521_t2.DAL.Entities;

namespace SPR521_t2.DAL.Repositories;

public class SushiTypeRepository : ISushiTypeRepository
{
    private readonly AppDbContext _context;

    public SushiTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<SushiType>> GetAllAsync()
    {
        return await _context.SushiTypes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<SushiType?> GetByIdAsync(int id)
    {
        return await _context.SushiTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task<SushiType> CreateAsync(SushiType sushiType)
    {
        await _context.SushiTypes.AddAsync(sushiType);
        await _context.SaveChangesAsync();

        return sushiType;
    }

    public async Task<SushiType?> UpdateAsync(int id, SushiType sushiType)
    {
        var existingSushiType = await _context.SushiTypes.FindAsync(id);

        if (existingSushiType is null)
        {
            return null;
        }

        existingSushiType.Name = sushiType.Name;
        await _context.SaveChangesAsync();

        return existingSushiType;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sushiType = await _context.SushiTypes.FindAsync(id);

        if (sushiType is null)
        {
            return false;
        }

        _context.SushiTypes.Remove(sushiType);
        await _context.SaveChangesAsync();

        return true;
    }
}
