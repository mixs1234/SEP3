using auth.Infrastructure.Configuration;
using auth.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace auth.Infrastructure;

public class AuthDbContext : DbContext
{
    private static AuthDbContext? _instance = null;
    
    public AuthDbContext(DbContextOptions<AuthDbContext> options, IConfiguration? configuration)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
    
}