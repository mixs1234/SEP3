using sep3.broker.Services;
using sep3.DTO.Product;

namespace sep3.brokers.broker;

public class ProductVariantBroker : IProductVariantBroker
{
    private readonly HttpClient _httpClient;
    
    public ProductVariantBroker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<Result<List<ProductVariantDTO>>> GetProductVariantsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ProductVariantDTO>> CreateProductVariantAsync(ProductVariantDTO dto)
    {
        throw new NotImplementedException();
    }
}