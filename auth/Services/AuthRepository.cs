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

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            
            if (user == null)
            {
                throw new Exception($"Could not find user with id {id}.");
            }
            
            return User.ToDto(user);
        }
        catch (Exception e)
        {
            throw new Exception($"Could not find user with id {id}.", e);
        }
    }

    public async Task<UserDto> GetUserByUsernameAndPasswordAsync(string username, string password)
    {
        try
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            
            if (user == null)
            {
                throw new Exception($"Could not find user with username {username} and password {password}.");
            }
            
            return User.ToDto(user);
        }
        catch (Exception e)
        {
            throw new Exception($"Could not find user with username {username} and password {password}.", e);
        }
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        try
        {
            var user = new User
            {
                Username = createUserDto.Username,
                Password = createUserDto.Password,
                Role = "CUSTOMER"
            };
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return User.ToDto(user);
        }
        catch (Exception e)
        {
            throw new Exception("Could not create user.", e);
        }
    }
}