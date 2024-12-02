using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.DTO.Product;
using web.Model;

namespace web.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<Product?> GetProductAsync(int id);
    // Admin only
    Task<Product> CreateProductAsync(ProductDTO product);
    Task<Product?> UpdateProductAsync(int id, Product product);
    Task DeleteProductAsync(int id);
}