using auth.Model;
using DTO.Auth;

namespace auth.Services;

public interface IAuthRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);
    Task<User> CreateUserAsync(CreateUserDto createUserDto);
}