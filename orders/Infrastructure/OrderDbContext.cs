using Microsoft.EntityFrameworkCore;
using sep3.orders.Infrastructure.Configuration;
using sep3.orders.Model;

namespace sep3.orders.Infrastructure;

public class OrderDbContext : DbContext
{
    private static OrderDbContext? _instance = null;


    public OrderDbContext(DbContextOptions<OrderDbContext> options, IConfiguration? configuration)
        : base(options)
    {
    }
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<StatusHistory> StatusHistory { get; set; }
    public DbSet<Customer> Customer { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
        modelBuilder.ApplyConfiguration(new CartItemConfiguration());
        modelBuilder.ApplyConfiguration(new StatusConfiguration());
        modelBuilder.ApplyConfiguration(new StatusHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
    
    
    
}