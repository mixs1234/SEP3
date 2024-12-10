using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace web.Auth;

public class CAuthenticationStateProvider : AuthenticationStateProvider
{
    
    private readonly HttpClient httpClient;
    private readonly IJSRuntime jsRuntime;
    
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new System.NotImplementedException();
    }
}