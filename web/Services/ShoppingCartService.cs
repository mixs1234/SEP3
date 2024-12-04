using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using orders.Migrations;
using web.Model;

namespace web.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly List<ShoppingCartItem> _productVariants = new List<ShoppingCartItem>();


    public Task AddToCartASync(ProductVariant productVariant, Product product, int quantity)
    {
        ShoppingCartItem shoppingCartItem = new ShoppingCartItem
        {
            VariantId = productVariant.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Size = productVariant.Size,
            Quantity = quantity
        };
        
        _productVariants.Add(shoppingCartItem);
        return Task.CompletedTask;
    }

    public Task RemoveFromCartASync(ShoppingCartItem shoppingCartItem)
    {
        _productVariants.Remove(shoppingCartItem);
        return Task.CompletedTask;
    }

    public Task<List<ShoppingCartItem>> GetCartASync()
    {
        return Task.FromResult(_productVariants);
    }
}