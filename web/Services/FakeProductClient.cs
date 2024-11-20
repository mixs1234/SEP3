using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Model;

namespace web.Services;

public class FakeProductClient : IProductService
{
    private readonly List<Product> _products =
    [
        new Product
        {
            Id = 1,
            Name = "Product 1",
            Price = 100,
            ImagePath = "/img/product-img/Basic-Black-Sweatshirt.png",
            Description = "This is product 1"
        },

        new Product
        {
            Id = 2,
            Name = "Product 2",
            Price = 200,
            ImagePath = "/img/product-img/Basic-Red-Sneakers.png",
            Description = "This is product 2"
        },

        new Product
        {
            Id = 3,
            Name = "Product 3",
            Price = 300,
            ImagePath = "/img/product-img/Basic-White-T-Shirt.png",
            Description = "This is product 3"
        }
    ];
    
    
    public Task<List<Product>> GetProductsAsync()
    {
        return Task.FromResult(_products);
    }

    public Task<Product?> GetProductAsync(int id)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    }
}