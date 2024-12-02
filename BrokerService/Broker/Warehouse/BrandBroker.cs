using System.Text.Json;
using sep3.broker.Services;
using sep3.DTO.Product;

namespace sep3.brokers.broker;

public class BrandBroker : IBrandBroker
{
    private readonly HttpClient _httpClient;
    
    public BrandBroker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Result<BrandDTO>> GetBrandAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<BrandDTO>>> GetAllBrandsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/brands");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");

            if (!response.IsSuccessStatusCode)
                return Result<List<BrandDTO>>.Failure((int)response.StatusCode, responseContent);
            
            var brands = JsonSerializer.Deserialize<List<BrandDTO>>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return brands != null ? Result<List<BrandDTO>>.Success(brands, "Brands retrieved successfully.")
                : Result<List<BrandDTO>>.Failure(500, "Failed to parse brands from response.");
        }
        catch (Exception ex)
        {
            return Result<List<BrandDTO>>.Failure(500, ex.Message);
        }
    }
}