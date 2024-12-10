using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DTO.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using web.Services;

namespace web.Auth;

public class CAuthenticationStateProvider : AuthenticationStateProvider
{
    
    private readonly IAuthService authService;
    private readonly IJSRuntime jsRuntime;
    
    public CAuthenticationStateProvider( IJSRuntime jsRuntime, IAuthService authService)
    {
        this.jsRuntime = jsRuntime;
        this.authService = authService;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var userAsJson = "";
        try
        {
            userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
        }
        catch (InvalidOperationException e)
        {
            return new AuthenticationState(new());
        }

        if (string.IsNullOrEmpty(userAsJson))
        {
            return new AuthenticationState(new());
        }

        var userDto = JsonConvert.DeserializeObject<UserDto>(userAsJson)!;
        
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
            new Claim(ClaimTypes.Role, userDto.Role),
        };
        var identity = new ClaimsIdentity(claims, "apiauth");
        var claimsPrincipal = new ClaimsPrincipal(identity);
        
        return new AuthenticationState(claimsPrincipal);
    }
    
    public async Task Login(string username, string password)
    {
        var user = await authService.LoginAsync(username, password);
        var userAsJson = JsonConvert.SerializeObject(user);
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", userAsJson);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var identity = new ClaimsIdentity(claims, "apiauth");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
    
    public async Task Logout()
    {
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new())));
    }
}