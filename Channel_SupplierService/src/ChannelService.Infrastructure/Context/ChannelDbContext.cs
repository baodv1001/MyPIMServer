using Microsoft.EntityFrameworkCore;
using AttributeService.Infrastructure.Entities;
using ChannelService.Infrastructure.Entities;

namespace ChannelService.Infrastructure.Context
{
    public class ChannelDbContext : DbContext
    {
        public ChannelDbContext(DbContextOptions<ChannelDbContext> option) : base(option)
        {
        }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

    }
}
