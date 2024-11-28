using sep3.broker.Services;
using sep3.DTO.Product;


namespace sep3.brokers.broker;

public interface IProductBroker
{
    
    Task<Result<ProductDTO>> GetProductAsync(int id);
    Task<Result<List<ProductDTO>>> GetAllProductsAsync();
    Task<Result<ProductDTO>> CreateProductAsync(ProductDTO dto);
}