using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using sep3.identity.Infrastructure;
using sep3.identity.Models;

namespace sep3.identity;

public class UsersSeed
{
    private ILogger<UsersSeed> _logger;
    private UserManager<User> _userManager;
    
    public UsersSeed(ILogger<UsersSeed> logger, UserManager<User> userManager)
    {
        
    }
    
    public static User DefaultAdmin()
    {
        return new User
        {
            UserName = "admin",
            Email = "admin@sep3.via",
            EmailConfirmed = true,
            Address = "Test Street Address",
            Name = "Default Administrator",
            Id = Guid.NewGuid().ToString(),
            PhoneNumber = "0123456789",
            PhoneNumberConfirmed = true,
            Roles = "admin employee.customeradmin"
        };
    }

    public async Task SeedAsync()
    {
        var admin = await _userManager.FindByNameAsync("admin");
        if (admin == null)
        {
            var result = await _userManager.CreateAsync(DefaultAdmin(), "admin");
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Default admin account created");
            }
        }
        else
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("Default admin account already exists");
            }
        }
    }
}