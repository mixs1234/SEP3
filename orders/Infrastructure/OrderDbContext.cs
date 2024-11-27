using Microsoft.EntityFrameworkCore;
using sep3.orders.Infrastructure.Configuration;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure;

public class OrderDbContext : DbContext
{
    private static OrderDbContext? _instance = null;
    protected readonly IConfiguration Configuration;
    
    public OrderDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
        Database.Migrate();
    }
    
    public static OrderDbContext GetInstance(IConfiguration configuration)
    {
        return _instance ??= new OrderDbContext(configuration);
    }
    
    public DbSet<Order> orders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("OrderContext"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
    
    
    
}