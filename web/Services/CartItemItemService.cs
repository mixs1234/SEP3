using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using orders.Migrations;
using web.Model;

namespace web.Services;

public class CartItemItemService : ICartItemService
{
    private readonly List<CartItem> _productVariants = new List<CartItem>();
    public event Action<int> CartItemsUpdated;

    public Task AddToCartASync(ProductVariant productVariant, Product product, int quantity)
    {
        CartItem cartItem = new CartItem
        {
            VariantId = productVariant.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Size = productVariant.Size,
            Quantity = quantity
        };
        _productVariants.Add(cartItem);
        
        CartItemsUpdated?.Invoke(_productVariants.Count);
        
        return Task.CompletedTask;
    }

    public Task RemoveFromCartASync(CartItem cartItem)
    {
        _productVariants.Remove(cartItem);
        
        CartItemsUpdated?.Invoke(_productVariants.Count);
        return Task.CompletedTask;
    }

    public Task<List<CartItem>> GetCartASync()
    {
        return Task.FromResult(_productVariants);
    }

    public void SubscribeToChanges(Action<int> callback)
    {
        CartItemsUpdated += callback;
    }

    public void UnsubscribeFromChanges(Action<int> callback)
    {
        CartItemsUpdated -= callback;
    }
}