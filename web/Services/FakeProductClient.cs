﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.Product;
using Model;

namespace web.Services;

public class FakeProductClient : IProductService
{
    


    public Task<List<Product>> GetProductsAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<Product?> GetProductAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<Product> CreateProductAsync(ProductDTO product)
    {
        throw new System.NotImplementedException();
    }

    public Task<Product?> CreateProductAsync(Product product)
    {
        throw new System.NotImplementedException();
    }

    public Task<Product?> UpdateProductAsync(int id, Product product)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteProductAsync(int id)
    {
        throw new System.NotImplementedException();
    }
}