using brokers.broker;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using sep3.orders.Services;

namespace brokers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Register services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // Register Repositories
            builder.Services.AddTransient<IOrderRepository, OrderEFRepository>();
            builder.Services.AddTransient<ICustomerRepository, CustomerEFRepository>();
            builder.Services.AddTransient<IProductRepository, ProductEFRepository>();
            builder.Services.AddTransient<IPaymentRepository, PaymentEFRepository>();
            builder.Services.AddTransient<ILineItemRepository, LineItemEFRepository>();
            
            // Register Brokers
            

            var app = builder.Build();
            
            // Test the broker after building the app
            //await TestBroker(broker);

            app.Run();
        }
        
    }
}