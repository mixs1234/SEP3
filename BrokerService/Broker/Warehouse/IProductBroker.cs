using sep3.broker.Services;
using sep3.DTO.Product;
using sep3.DTO.Product.Create;


namespace sep3.brokers.broker;

public interface IProductBroker
{
    
    Task<Result<ProductDTO>> GetProductAsync(int id);
    Task<Result<ProductDTO>> GetProductAsync(long id);
    Task<Result<List<ProductDTO>>> GetAllProductsAsync();
    Task<Result<ProductDTO>> CreateProductAsync(CreateProductDTO dto);
    Task<Result<List<ProductVariantDTO>>> GetProductVariantsAsync(int id);
}