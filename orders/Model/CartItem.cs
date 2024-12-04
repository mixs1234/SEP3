namespace sep3.orders.Model;

public class CartItem
{
    public int Id { get; set; }
    public long VariantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Size { get; set; }
    public int Quantity { get; set; }

    public ShoppingCart ShoppingCart { get; set; }
    public int ShoppingCartId { get; set; }

    public CartItem()
    {
    }

    public CartItem(int id, long variantId, string name, string description, double price, string size, int quantity)
    {
        Id = id;
        VariantId = variantId;
        Name = name;
        Description = description;
        Price = price;
        Size = size;
        Quantity = quantity;
    }
}