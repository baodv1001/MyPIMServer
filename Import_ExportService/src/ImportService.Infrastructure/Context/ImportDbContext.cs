using Microsoft.EntityFrameworkCore;
using ImportService.Infrastructure.Entities;

namespace ImportService.Infrastructure.Context
{
    public class ImportDbContext : DbContext
    {
        public ImportDbContext(DbContextOptions<ImportDbContext> option) : base(option)
        {
        }
        public virtual DbSet<ImportFile> ImportFiles { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Attribute> Atteibutes { get; set; }
        public virtual DbSet<Channel> Channels{ get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Category> Categorys{ get; set; }

    }
}
