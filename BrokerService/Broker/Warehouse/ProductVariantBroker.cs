using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using sep3.broker.Services;
using sep3.DTO.Product;
using sep3.DTO.Product.Create;

namespace sep3.brokers.broker;

public class ProductVariantBroker : IProductVariantBroker
{
    private readonly HttpClient _httpClient;
    
    public ProductVariantBroker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Result<ProductVariantDTO>> GetProductVariantAsync(
        int id
    )
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/variants/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");
            
            if (!response.IsSuccessStatusCode)
                return Result<ProductVariantDTO>.Failure((int)response.StatusCode, responseContent);
            
            var productVariants = JsonSerializer.Deserialize<ProductVariantDTO>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return productVariants != null ? Result<ProductVariantDTO>.Success(productVariants, "Product variants retrieved successfully.") 
                : Result<ProductVariantDTO>.Failure(500, "Failed to parse product variants from response.");
            
        }
        catch (Exception ex)
        {
            return Result<ProductVariantDTO>.Failure(500, ex.Message);
        }
    }
    
    

    public async Task<Result<ProductVariantDTO>> CreateProductVariantAsync(CreateProductVariantDTO createDTO)
    {
        var response = await _httpClient.PostAsJsonAsync("api/variants", createDTO);
        var responseContent = await response.Content.ReadAsStringAsync();
        
        Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");
        
        if (!response.IsSuccessStatusCode)
            return Result<ProductVariantDTO>.Failure((int)response.StatusCode, responseContent);
        
        var productVariant = JsonSerializer.Deserialize<ProductVariantDTO>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        return productVariant != null ? Result<ProductVariantDTO>.Success(productVariant, "Product variant created successfully.") 
            : Result<ProductVariantDTO>.Failure(500, "Failed to parse product variant from response.");
    }

    public async Task<Result<ProductVariantDTO>> UpdateProductVariantAsync(ProductVariantDTO variant)
    {
        var response = await _httpClient.PutAsJsonAsync("api/variants", variant);
        var responseContent = await response.Content.ReadAsStringAsync();
        
        Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");
        
        if(!response.IsSuccessStatusCode)
            return Result<ProductVariantDTO>.Failure((int)response.StatusCode, responseContent);
        
        var productVariant = JsonSerializer.Deserialize<ProductVariantDTO>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        return productVariant != null ? Result<ProductVariantDTO>.Success(productVariant, "Product variant created successfully.") 
            : Result<ProductVariantDTO>.Failure(500, "Failed to parse product variant from response.");
    }
}