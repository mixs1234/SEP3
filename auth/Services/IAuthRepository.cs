using auth.Model;
using DTO.Auth;

namespace auth.Services;

public interface IAuthRepository
{
    Task<UserDto> GetUserByIdAsync(int id);
    Task<UserDto> GetUserByUsernameAndPasswordAsync(string username, string password);
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
}