using System.Text.Json;
using sep3.broker.Services;
using sep3.DTO.Product;
using sep3.DTO.Product.Create;

namespace sep3.brokers.broker;

public class ProductBroker : IProductBroker
{
    
    private readonly HttpClient _httpClient;

    public ProductBroker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Result<ProductDTO>> GetProductAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");

            if (!response.IsSuccessStatusCode)
                return Result<ProductDTO>.Failure((int)response.StatusCode, responseContent);
            
            var product = JsonSerializer.Deserialize<ProductDTO>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return product != null ? Result<ProductDTO>.Success(product, "Product retrieved successfully.") 
                : Result<ProductDTO>.Failure(500, "Failed to parse product from response.");
        }
        catch (Exception ex)
        {
            return Result<ProductDTO>.Failure(500, ex.Message);
        }
    }
    

    public async Task<Result<List<ProductDTO>>> GetAllProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/products");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");

            if (!response.IsSuccessStatusCode)
                return Result<List<ProductDTO>>.Failure((int)response.StatusCode, responseContent);
            
            var products = JsonSerializer.Deserialize<List<ProductDTO>>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return products != null ? Result<List<ProductDTO>>.Success(products, "Products retrieved successfully.")
                : Result<List<ProductDTO>>.Failure(500, "Failed to parse products from response.");
        }
        catch (Exception ex)
        {
            return Result<List<ProductDTO>>.Failure(500, ex.Message);
        }
    }

    public async Task<Result<ProductDTO>> CreateProductAsync(CreateProductDTO dto)
    {
        try
        {
            var response =  await _httpClient.PostAsJsonAsync("api/products", dto);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");
            
            if (!response.IsSuccessStatusCode)
                return Result<ProductDTO>.Failure((int)response.StatusCode, responseContent);
            
            var product = JsonSerializer.Deserialize<ProductDTO>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return product != null ? Result<ProductDTO>.Success(product, "Product created successfully.")
                : Result<ProductDTO>.Failure(500, "Failed to parse product from response.");
        }
        catch (Exception ex)
        {
            return Result<ProductDTO>.Failure(500, ex.Message);
        }
    }

    public async Task<Result<List<ProductVariantDTO>>> GetProductVariantsAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/products/{id}/variants");
        var responseContent = await response.Content.ReadAsStringAsync();
        
        Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");
        
        if (!response.IsSuccessStatusCode)
            return Result<List<ProductVariantDTO>>.Failure((int)response.StatusCode, responseContent);
        
        var productVariants = JsonSerializer.Deserialize<List<ProductVariantDTO>>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        return productVariants != null ? Result<List<ProductVariantDTO>>.Success(productVariants, "Product variants retrieved successfully.") 
            : Result<List<ProductVariantDTO>>.Failure(500, "Failed to parse product variants from response.");
    }
}