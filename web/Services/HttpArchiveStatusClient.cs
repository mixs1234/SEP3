using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using web.Model;

namespace web.Services;

public class HttpArchiveStatusClient : IArchiveStatusService
{
    
    private readonly HttpClient _httpClient;
    
    public HttpArchiveStatusClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<ArchiveStatus>> GetArchiveStatusesAsync()
    {
        var httpResponse = await _httpClient.GetAsync("/ArchiveStatus");
        var content = await httpResponse.Content.ReadAsStringAsync();
        var statuses = System.Text.Json.JsonSerializer.Deserialize<List<ArchiveStatus>>(content, new System.Text.Json.JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return statuses;
    }
}