﻿using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.Model;

namespace web.Services;

public class FakeProductClient : IProductService
{
    
    private List<Product> productsInMemoryList =
    [
        new Product()
        {
            Name = "T-shirt",
            Price = 20,
            Description = "A simple t-shirt",
            ImagePath = "img/product-img/Basic-White-T-Shirt.png",
            Category = "Clothing",
            Id = 1,

        },

        new Product()
        {
            Name = "Sweatshirt",
            Price = 20,
            Description = "A simple sweatshirt",
            ImagePath = "img/product-img/Basic-Black-Sweatshirt.png",
            Category = "Clothing",
            Id = 2,

        },

        new Product()
        {
            Name = "Sneakers",
            Price = 20,
            Description = "A simple pair of sneakers",
            ImagePath = "img/product-img/Basic-Red-Sneakers.png",
            Category = "Footwear",
            Id = 3,
            
        }
    ];


    public Task<List<Product>> GetProductsAsync()
    {
        return Task.FromResult(productsInMemoryList);
    }

    public Task<Product?> GetProductAsync(int id)
    {
        return Task.FromResult(productsInMemoryList.Find(product => product.Id == id));
    }

    public Task<Product?> CreateProductAsync(Product product)
    {
        throw new System.NotImplementedException();
    }

    public Task<Product?> UpdateProductAsync(int id, Product product)
    {
        throw new System.NotImplementedException();
    }

    public Task<Product?> DeleteProductAsync(int id)
    {
        throw new System.NotImplementedException();
    }
}