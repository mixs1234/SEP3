using ConsoleApp1.Services;
using DTO.Product;
using Model;

namespace brokers.broker;

public interface IProductVariantBroker
{
    Task<Result<List<ProductVariant>>> GetAllProductVariantsAsync();
    
    Task<Result<ProductVariant>> GetProductVariantAsync(int id);
    
    
    //Should maybe to changed to ProductVariant instead dunno we find out later
    Task<Result<int>> CreateProductVariantAsync(ProductVariantDTO productVariantDto);
    Task<Result> UpdateProductVariantAsync(ProductVariantDTO productVariantDto);
    Task<Result> DeleteProductVariantAsync(int id);
}