using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.Model;
using sep3.DTO.Product;

namespace web.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<Product?> GetProductAsync(int id);
    Task<Product> CreateProductAsync(ProductDTO product);
    Task<Product?> UpdateProductAsync(int id, Product product);
    Task DeleteProductAsync(int id);
}