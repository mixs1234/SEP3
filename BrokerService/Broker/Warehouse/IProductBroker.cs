using ConsoleApp1.Services;
using sep3.DTO.Product;
using sep3.Model;

namespace brokers.broker;

public interface IProductBroker
{
    Task<Result<int>> CreateProductAsync(ProductDTO ProductDto);
    Task<Result<ProductDTO>> GetProductAsync(int id);
    Task<Result<List<ProductVariant>>> GetProductVariantsAsync(int id);
    Task<Result<List<ProductDTO>>> GetAllProductsAsync();
    
    
}