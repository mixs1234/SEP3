using Microsoft.EntityFrameworkCore;
using rabbitmq.Messaging.Pub;
using sep3.orders.Infrastructure;
using sep3.orders.Services;

namespace sep3.orders;

public class Program
{
    static IConfiguration configuration = GetConfiguration();
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<OrderDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("OrderContext")));
        OrderDbContext.GetInstance(configuration);
        builder.Services.AddTransient<IOrderRepository, OrderReposity>();
        builder.Services.AddScoped<OrderPublisher>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        app.Run();
    }

    private static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        var config = builder.Build();
        return builder.Build();
    }
}