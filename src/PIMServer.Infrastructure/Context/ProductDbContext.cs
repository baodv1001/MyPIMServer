using Microsoft.EntityFrameworkCore;
using PIMServer.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Infrastructure.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> option) : base(option)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Attribute_Product> Attribute_Products { get; set; }
    }
}
