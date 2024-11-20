using System.Text.Json;
using ConsoleApp1.Services;
using sep3.broker.Model;
using sep3.DTO.Product;

namespace brokers.broker;

public class ProductVariantBroker : IProductVariantBroker
{
    private readonly HttpClient _httpClient;
    
    public ProductVariantBroker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
    public async Task<Result<ProductVariant>> GetProductVariantAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/variants/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");

            if (response.IsSuccessStatusCode)
            {
                var productVariant = JsonSerializer.Deserialize<ProductVariant>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (productVariant != null)
                {
                    return Result<ProductVariant>.Success(productVariant, "Product variant retrieved successfully.");
                }
                else
                {
                    return Result<ProductVariant>.Failure(500, "Failed to parse product variant from response.");
                }
            }
            else
            {
                return Result<ProductVariant>.Failure((int)response.StatusCode, responseContent);
            }
        }
        catch (Exception ex)
        {
            return Result<ProductVariant>.Failure(500, ex.Message);
        }
    }
    
    //Not implemented yet on java side
    public async Task<Result<List<ProductVariant>>> GetAllProductVariantsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/variants");
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");

            if (response.IsSuccessStatusCode)
            {
                var productVariants = JsonSerializer.Deserialize<List<ProductVariant>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (productVariants != null)
                {
                    return Result<List<ProductVariant>>.Success(productVariants, "Product variants retrieved successfully.");
                }
                else
                {
                    return Result<List<ProductVariant>>.Failure(500, "Failed to parse product variants from response.");
                }
            }
            else
            {
                return Result<List<ProductVariant>>.Failure((int)response.StatusCode, responseContent);
            }
        }
        catch (Exception ex)
        {
            return Result<List<ProductVariant>>.Failure(500, ex.Message);
        }
    }
    
   

    public Task<Result<int>> CreateProductVariantAsync(ProductVariantDTO productVariantDto)
    {
        throw new NotImplementedException();
    }
    

    public Task<Result> UpdateProductVariantAsync(ProductVariantDTO productVariantDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteProductVariantAsync(int id)
    {
        throw new NotImplementedException();
    }
}