using System.Collections.Generic;

namespace web.Model;

public class ShoppingCart
{
    public int Id { get; set; }
    public List<CartItem> CartItems { get; set; }

    public ShoppingCart()
    {
    }

    public ShoppingCart(int id, List<CartItem> cartItems)
    {
        Id = id;
        CartItems = cartItems;
    }
}