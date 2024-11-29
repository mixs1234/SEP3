using sep3.broker.Services;
using sep3.DTO.Product;
using sep3.DTO.Product.Create;

namespace sep3.brokers.broker;

public interface IProductVariantBroker
{
    Task<Result<List<ProductVariantDTO>>> GetProductVariantsAsync(int id);
    Task<Result<ProductVariantDTO>> CreateProductVariantAsync(CreateProductVariantDTO createDTO);
}