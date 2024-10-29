using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using sep3.orders.Infrastructure.EntityConfigurations;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure;

public class OrdersContext : DbContext
{
    private static OrdersContext _instance = null;
    protected readonly IConfiguration Configuration;
    
    public OrdersContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public static OrdersContext GetInstance(IConfiguration configuration)
    {
        if (_instance == null)
            _instance = new OrdersContext(configuration);
        return _instance;
    }
    
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("OrderContext"));
    }
}