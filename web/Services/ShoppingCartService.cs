using System.Collections.Generic;
using web.Model;

namespace web.Services;

public class ShoppingCartService
{
    private readonly List<ShoppingCartItem> _productVariants = new List<ShoppingCartItem>();


    public void AddToCart(ShoppingCartItem shoppingCartItem)
    {
        _productVariants.Add(shoppingCartItem);
    }

    public void RemoveFromCart(ShoppingCartItem shoppingCartItem)
    {
        _productVariants.Remove(shoppingCartItem);
    }
}