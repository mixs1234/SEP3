using ConsoleApp1.Services;
using DTO.Product;

namespace brokers.broker;

public interface IProductBroker
{
    Task<Result<int>> CreateProductAsync(ProductDTO ProductDto);
    Task<Result<ProductDTO>> GetProductAsync(int id);
    Task<Result<ProductDTO>> GetProductWithVariantsAsync(int id);
    Task<Result<List<ProductDTO>>> GetAllProductsAsync();
    
    
}