using Microsoft.EntityFrameworkCore;
using PIMServer.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Infrastructure.Context
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> option) : base(option)
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
