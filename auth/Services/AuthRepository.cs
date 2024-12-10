using auth.Infrastructure;
using auth.Model;
using DTO.Auth;
using Microsoft.EntityFrameworkCore;

namespace auth.Services;

public class AuthRepository : IAuthRepository
{
    private readonly AuthDbContext _context;
    
    public AuthRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            
            if (user == null)
            {
                throw new Exception($"Could not find user with id {id}.");
            }
            
            return user;
        }
        catch (Exception e)
        {
            throw new Exception($"Could not find user with id {id}.", e);
        }
    }

    public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
    {
        try
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            
            if (user == null)
            {
                throw new Exception($"Could not find user with username {username} and password {password}.");
            }
            
            return user;
        }
        catch (Exception e)
        {
            throw new Exception($"Could not find user with username {username} and password {password}.", e);
        }
    }

    public Task<User> CreateUserAsync(CreateUserDto createUserDto)
    {
        try
        {
            var user = new User
            {
                Username = createUserDto.Username,
                Password = createUserDto.Password,
                Role = "CUSTOMER"
            };
            
            _context.Users.Add(user);
            _context.SaveChanges();
            
            return Task.FromResult(user);
        }
        catch (Exception e)
        {
            throw new Exception("Could not create user.", e);
        }
    }
}