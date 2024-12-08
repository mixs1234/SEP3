using sep3.broker.Services;

namespace sep3.brokers.broker;

public class ArchiveStatusBroker : IArchiveStatusBroker
{
    private readonly HttpClient _httpClient;
    
    public ArchiveStatusBroker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Result<string>> GetAllArchiveStatusAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/archiveStatuses");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");
            
            return !response.IsSuccessStatusCode ? Result<string>.Failure((int)response.StatusCode, responseContent) :
                Result<string>.Success(responseContent, "Archive statuses retrieved successfully.");
        }
        catch (Exception ex)
        {
            return Result<string>.Failure(500, ex.Message);
        }
    }
}