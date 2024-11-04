using sep3.orders.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sep3.orders.Services;

public interface IProductRepository
{
    Task<Product> CreateProductAsync(Product product);
    Task<Product> CreateProductAsync(int? id, string name, double? price);
    Task<List<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(int? id);
    Task UpdateProductAsync(int? id, string name, double? price);
    Task DeleteProductAsync(int? id);
}