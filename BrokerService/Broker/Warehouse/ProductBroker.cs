using System.Text.Json;
using ConsoleApp1.Services;
using sep3.DTO.Product;
using sep3.Model;

namespace brokers.broker;

public class ProductBroker : IProductBroker
{
    
    private readonly HttpClient _httpClient;

    public ProductBroker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Result<int>> CreateProductAsync(ProductDTO productDto)
    {
        try
        {
            
            if (string.IsNullOrWhiteSpace(productDto.Name))
            {
                return Result<int>.Failure(400, "Product name is required.");
            }
            if (string.IsNullOrWhiteSpace(productDto.Description))
            {
                return Result<int>.Failure(400, "Product description is required.");
            }

            var response = await _httpClient.PostAsJsonAsync("api/products", productDto);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");

            if (response.IsSuccessStatusCode)
            {
                var product = JsonSerializer.Deserialize<Product>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (product != null)
                {
                    return Result<int>.Success((int)product.Id, "Product created successfully.");
                }
                else
                {
                    return Result<int>.Failure(500, "Failed to parse product from response.");
                }
            }
            else
            {
                return Result<int>.Failure((int)response.StatusCode, responseContent);
            }
        }
        catch (Exception ex)
        {
            return Result<int>.Failure(500, ex.Message);
        }
    }

    public async Task<Result<ProductDTO>> GetProductAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");

            if (response.IsSuccessStatusCode)
            {
                var product = JsonSerializer.Deserialize<ProductDTO>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (product != null)
                {
                    return Result<ProductDTO>.Success(product, "Product retrieved successfully.");
                }
                else
                {
                    return Result<ProductDTO>.Failure(500, "Failed to parse product from response.");
                }
            }
            else
            {
                return Result<ProductDTO>.Failure((int)response.StatusCode, responseContent);
            }
        }
        catch (Exception ex)
        {
            return Result<ProductDTO>.Failure(500, ex.Message);
        }
    }

    public async Task<Result<List<ProductVariant>>> GetProductVariantsAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/{id}/variants");
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");

            if (response.IsSuccessStatusCode)
            {
                var variants = JsonSerializer.Deserialize<List<ProductVariant>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (variants != null)
                {
                    return Result<List<ProductVariant>>.Success(variants, "Product variants retrieved successfully.");
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


    public async Task<Result<List<ProductDTO>>> GetAllProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/products");
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Status: {response.StatusCode}, Content: {responseContent}");

            if (response.IsSuccessStatusCode)
            {
                var products = JsonSerializer.Deserialize<List<ProductDTO>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (products != null)
                {
                    return Result<List<ProductDTO>>.Success(products, "Products retrieved successfully.");
                }
                else
                {
                    return Result<List<ProductDTO>>.Failure(500, "Failed to parse products from response.");
                }
            }
            else
            {
                return Result<List<ProductDTO>>.Failure((int)response.StatusCode, responseContent);
            }
        }
        catch (Exception ex)
        {
            return Result<List<ProductDTO>>.Failure(500, ex.Message);
        }
    }
}