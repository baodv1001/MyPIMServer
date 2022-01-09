using Microsoft.EntityFrameworkCore;
using AttributeService.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeService.Infrastructure.Context
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> option) : base(option)
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
