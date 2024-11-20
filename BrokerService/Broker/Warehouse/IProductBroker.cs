using ConsoleApp1.Services;
using sep3.broker.Model;
using sep3.DTO.Product;


namespace brokers.broker;

public interface IProductBroker
{
    Task<Result<int>> CreateProductAsync(ProductDTO ProductDto);
    Task<Result<ProductDTO>> GetProductAsync(int id);
    Task<Result<List<ProductVariant>>> GetProductVariantsAsync(int id);
    Task<Result<List<ProductDTO>>> GetAllProductsAsync();
    
    
}