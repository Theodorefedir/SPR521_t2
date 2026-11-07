using Microsoft.EntityFrameworkCore;
using SPR521_t2.DAL.Entities;

namespace SPR521_t2.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<SushiType> SushiTypes { get; set; }
    public DbSet<SushiSet> SushiSets { get; set; }
}