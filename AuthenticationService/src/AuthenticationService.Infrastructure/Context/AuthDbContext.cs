using Microsoft.EntityFrameworkCore;
using AuthService.Infrastructure.Entities;

namespace AuthService.Infrastructure.Context
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> option) : base(option)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

    }
}
