using Microsoft.EntityFrameworkCore;
using PIMServer.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Infrastructure.Context
{
    public class AttributeDbContext: DbContext
    {
        public AttributeDbContext(DbContextOptions<AttributeDbContext> option) : base(option)
        {
        }
        public virtual DbSet<Entities.Attribute> Attributes { get; set; }
        public virtual DbSet<AttributeGroup> AttributeGroups { get; set; }
        public virtual DbSet<Attribute_Product> Attribute_Products { get; set; }

    }
}
