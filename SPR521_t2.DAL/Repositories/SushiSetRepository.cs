using Microsoft.EntityFrameworkCore;
using SPR521_t2.DAL.Entities;

namespace SPR521_t2.DAL.Repositories
{
    public class SushiSetRepository : ISushiSetRepository
    {
        private readonly AppDbContext _context;

        public SushiSetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SushiSet>> GetAllAsync()
        {
            return await _context.SushiSets
                .Include(s => s.SushiType)
                .ToListAsync();
        }

        public async Task<SushiSet?> GetByIdAsync(int id)
        {
            return await _context.SushiSets
                .Include(s => s.SushiType)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SushiSet> CreateAsync(SushiSet sushiSet)
        {
            _context.SushiSets.Add(sushiSet);
            await _context.SaveChangesAsync();
            return sushiSet;
        }

        public async Task<bool> UpdateAsync(SushiSet sushiSet)
        {
            var existing = await _context.SushiSets.FindAsync(sushiSet.Id);
            if (existing == null)
                return false;

            existing.Name = sushiSet.Name;
            existing.Price = sushiSet.Price;
            existing.Weight = sushiSet.Weight;
            existing.SushiTypeId = sushiSet.SushiTypeId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.SushiSets.FindAsync(id);
            if (existing == null)
                return false;

            _context.SushiSets.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}