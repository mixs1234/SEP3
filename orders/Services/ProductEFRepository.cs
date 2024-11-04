using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sep3.orders.Model;
using sep3.orders.Infrastructure;

namespace sep3.orders.Services;

public class ProductEFRepository : IProductRepository
{
    private readonly OrdersContext _context;

    public ProductEFRepository(OrdersContext context)
    {
        _context = context;
        if (_context == null)
            _context = OrdersContext.GetInstance(null);
    }
    
    public async Task<Product> CreateProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
        // TODO: Event
    }

    public async Task<Product> CreateProductAsync(int? id, string name, double? price)
    {
        if (!string.IsNullOrEmpty(name) && price.HasValue)
        {
            Product product = null;
            if (id.HasValue)
            {
                product = new Product()
                {
                    Id = id.Value,
                    Name = name,
                    Price = price.Value
                };
            }
            else
            {
                product = new Product()
                {
                    Name = name,
                    Price = price.Value
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
            // TODO: Event
        }
        else
            throw new ArgumentNullException();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductAsync(int? id)
    {
        if (id.HasValue)
            return await _context.Products.Where(p => p.Id == id.Value).FirstOrDefaultAsync();
        else
            throw new ArgumentNullException(nameof(id));
    }

    public async Task UpdateProductAsync(int? id, string name, double? price)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteProductAsync(int? id)
    {
        if (id.HasValue)
        {
            Product product = await _context.Products.Where(p => p.Id == id.Value).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            // TODO: Event
        }
        else
            throw new ArgumentNullException(nameof(id));
    }
}