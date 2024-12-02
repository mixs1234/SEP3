using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.DTO.Product;
using web.Model;

namespace web.Services;

public interface IVariantService
{
    Task<List<ProductVariant>> GetProductVariantsAsync();
    Task<ProductVariant?> GetProductVariantAsync(int id);
    // Admin only
    Task<ProductVariant> CreateProductVariantsAsync(ProductVariantDTO variant);
    Task<ProductVariant?> UpdateProductVariantAsync(int id, ProductVariant variant);
    Task DeleteProductVariantAsync(int id);
}