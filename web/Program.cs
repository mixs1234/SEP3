using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using sep3web.Services;
using web.Components;
using web.Services;

namespace web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        
        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5220")
        });
        
        
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<IOrderService, HttpOrderClient>();
        builder.Services.AddScoped<IProductService, HttpProductClient>();
        builder.Services.AddScoped<IVariantService, HttpVariantClient>();
        builder.Services.AddScoped<IBrandService, HttpBrandClient>();
        builder.Services.AddSingleton<ICartItemService, CartItemItemService>();
        builder.Services.AddScoped<IStatusService, HttpStatusClient>();

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}