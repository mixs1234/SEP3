using auth.Infrastructure.Configuration;
using auth.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace auth.Infrastructure;

public class AuthDbContext : DbContext
{
    
    public AuthDbContext()
    {
    }
    
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
    
}