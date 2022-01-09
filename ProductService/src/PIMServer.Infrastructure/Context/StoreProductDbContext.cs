using Microsoft.EntityFrameworkCore;
using PIMServer.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Infrastructure.Context
{
    public class StoreProductDbContext : DbContext
    {
        public StoreProductDbContext(DbContextOptions<StoreProductDbContext> option) : base(option)
        {
        }
        public virtual DbSet<StoreProduct> StoreProducts { get; set; }
    }
}
