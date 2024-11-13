using brokers.broker;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace sep3.broker
{
    public class Program
    {
        static IConfiguration configuration = GetConfiguration();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllers();
            builder.Services.AddScoped<IProductVariantBroker, ProductVariantBroker>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           
            builder.Services.AddHttpClient<IOrderBroker, OrderBroker>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5110/"); // Replace with your actual API base URL
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });
            
            builder.Services.AddHttpClient<IProductVariantBroker, ProductVariantBroker>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8080/"); // Replace with your actual API base URL
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });
            
            builder.Services.AddHttpClient<IProductBroker, ProductBroker>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8080/"); // Replace with your actual API base URL
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });

            var app = builder.Build();

            
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
            return config;
        }
    }
}