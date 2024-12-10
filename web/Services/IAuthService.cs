using System.Threading.Tasks;
using DTO.Auth;

namespace web.Services;

public interface IAuthService
{
    Task<UserDto?> GetUserFromIdAsync(int id);
    Task<UserDto?> LoginAsync(string username, string password);
    Task<UserDto> RegisterAsync(CreateUserDto createUserDto);
}