using auth.Services;
using DTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace auth.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepository;
    
    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var user = await _authRepository.GetUserByIdAsync(id);
        return Ok(user);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUserByUsernameAndPasswordAsync([FromQuery] string username, [FromQuery] string password)
    {
        var user = await _authRepository.GetUserByUsernameAndPasswordAsync(username, password);
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto createUserDto)
    {
        var user = await _authRepository.CreateUserAsync(createUserDto);
        return Ok(user);
    }
    
    
    
}