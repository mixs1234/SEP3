using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.DTO.Product;
using sep3.DTO.Product.Create;
using web.Model;

namespace web.Services;

public interface IVariantService
{
    Task<List<ProductVariant>> GetProductVariantsAsync();
    // Admin only
    Task<ProductVariant> CreateProductVariantAsync(CreateProductVariantDTO variant);
    Task<ProductVariant?> UpdateProductVariantAsync(int id, ProductVariantDTO variant);
}