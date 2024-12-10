using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTO.Auth;
using Newtonsoft.Json;

namespace web.Services;

public class HttpAuthClient : IAuthService
{
    private readonly HttpClient _httpClient;
    
    public HttpAuthClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<UserDto?> GetUserFromIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/auth/{id}");
        var content = await response.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<UserDto>(content);
        return user;
    }

    public async Task<UserDto?> LoginAsync(string username, string password)
    {
        var response = await _httpClient.GetAsync($"/api/auth/?username={username}&password={password}");
        var content = await response.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<UserDto>(content);
        return user;
    }

    public Task<UserDto> RegisterAsync(CreateUserDto createUserDto)
    {
        var response = _httpClient.PostAsJsonAsync("/api/auth", createUserDto);
        var content = response.Result.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<UserDto>(content.Result);
        return Task.FromResult(user);
    }
}