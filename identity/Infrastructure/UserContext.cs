using Duende.IdentityServer.AspNetIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sep3.identity.Models;

namespace sep3.identity.Infrastructure;

public class UserContext : IdentityDbContext<User>
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}