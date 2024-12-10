using DTO.Auth;

namespace auth.Model;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    
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