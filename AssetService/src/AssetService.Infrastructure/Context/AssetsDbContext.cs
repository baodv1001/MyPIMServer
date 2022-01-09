using AssetsService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetsService.Infrastructure.Context
{
    public class AssetsDbContext : DbContext
    {
        public AssetsDbContext(DbContextOptions<AssetsDbContext> option) : base(option)
        {
        }
        public virtual DbSet<Assets> Assets { get; set; }

    }
}
