using ConsoleApp1.Services;
using DTO.Product;
using Model;

namespace brokers.broker;

public interface IProductBroker
{
    Task<Result<int>> CreateProductAsync(ProductDTO ProductDto);
    Task<Result<ProductDTO>> GetProductAsync(int id);
    Task<Result<List<ProductVariant>>> GetProductVariantsAsync(int id);
    Task<Result<List<ProductDTO>>> GetAllProductsAsync();
    
    
}