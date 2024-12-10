using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace sep3.identity.Models;

public class User : IdentityUser
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Email { get; set; }
    public string Roles { get; set; }

    public List<Claim> GetRoles()
    {
        List<Claim> roles = new List<Claim>();
        foreach (string role in this.Roles.Split(','))
        {
            roles.Add(new Claim(JwtClaimTypes.Role, role));
        }
        return roles;
    }
}