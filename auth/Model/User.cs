using DTO.Auth;

namespace auth.Model;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }
    
    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            Username = user.Username,
            Password = user.Password,
            Role = user.Role
        };
    }
    
}