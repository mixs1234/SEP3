using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.web.Model;

namespace web.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<Product?> GetProductAsync(int id);
    Task<Product?> CreateProductAsync(Product product);
    Task<Product?> UpdateProductAsync(int id, Product product);
    Task<Product?> DeleteProductAsync(int id);
}