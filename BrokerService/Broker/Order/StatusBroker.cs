using sep3.broker.Model;
using sep3.broker.Services;

namespace brokers.broker;

public class StatusBroker : IStatusBroker
{
    private readonly HttpClient _httpClient;
        
    public StatusBroker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Result<string>> GetStatusesAsync()
    {
        
        var response = await _httpClient.GetAsync("api/statuses");
        
        if (response.IsSuccessStatusCode)
        {
            var statuses = await response.Content.ReadAsStringAsync();
            return Result<string>.Success(statuses, "Statuses fetched successfully.");
        }
        
        var error = await response.Content.ReadAsStringAsync();
        
        return Result<string>.Failure((int)response.StatusCode, error);
        
    }
}