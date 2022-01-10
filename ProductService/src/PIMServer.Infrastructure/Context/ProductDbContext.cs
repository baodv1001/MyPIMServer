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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // enbale lazy loading
            optionsBuilder.UseLazyLoadingProxies();
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Product_Translation> Translations { get; set; }
    }
}
