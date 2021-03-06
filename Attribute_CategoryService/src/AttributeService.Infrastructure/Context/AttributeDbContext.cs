using Microsoft.EntityFrameworkCore;
using AttributeService.Infrastructure.Entities;

namespace AttributeService.Infrastructure.Context
{
    public class AttributeDbContext : DbContext
    {
        public AttributeDbContext(DbContextOptions<AttributeDbContext> option) : base(option)
        {
        }
        public virtual DbSet<Entities.Attribute> Attributes { get; set; }
        public virtual DbSet<AttributeGroup> AttributeGroups { get; set; }
        public virtual DbSet<Attribute_Product> Attribute_Products { get; set; }

    }
}
