using System;

namespace web.Model;

public class ShoppingCartItem
{
    public long VariantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Size { get; set; }
    public int Quantity { get; set; }

    public ShoppingCartItem()
    {
    }

    public ShoppingCartItem(long variantId, string name, string description, double price, string size, int quantity)
    {
        VariantId = variantId;
        Name = name;
        Description = description;
        Price = price;
        Size = size;
        Quantity = quantity;
    }
}