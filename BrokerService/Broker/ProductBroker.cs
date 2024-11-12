using ConsoleApp1.Services;
using DTO.Product;

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
            var response = await _httpClient.PostAsJsonAsync("api/products", productDto);
            if (response.IsSuccessStatusCode)
            {
                var orderIdString = await response.Content.ReadAsStringAsync();
                if (int.TryParse(orderIdString, out int orderId))
                {
                    return Result<int>.Success(orderId, "Order created successfully.");
                }
                else
                {
                    return Result<int>.Failure(500, "Failed to parse order ID.");
                }
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                return Result<int>.Failure((int)response.StatusCode, error);
            }
        }
        catch (Exception ex)
        {
            return Result<int>.Failure(500, ex.Message);
        }
    }

    public Task<Result<ProductDTO>> GetProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ProductDTO>> GetProductWithVariantsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<ProductDTO>>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }
}