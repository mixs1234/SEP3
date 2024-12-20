﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            ProductId = product.Id,
            Name = product.Name,
            Description = product.Description,
            Materials = productVariant.Material,
            Price = product.Price,
            Size = productVariant.Size,
            Quantity = quantity
        };

        foreach (var item in _productVariants)
        {
            if (cartItem.VariantId == item.VariantId)
            {
                item.Quantity += cartItem.Quantity;
                return Task.CompletedTask;
            }
        }
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

    public Task ClearCartAsync()
    {
        _productVariants.Clear();
        CartItemsUpdated?.Invoke(_productVariants.Count);
        return Task.CompletedTask;
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