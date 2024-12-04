using DTO.Cart;

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


    public static List<CartItem> ToModel(List<CreateCartItemDto> createCartItemDtos)
    {
        return createCartItemDtos
            .Select(cartItem => new CartItem
            {
                VariantId = cartItem.VariantId,
                Name = cartItem.Name,
                Description = cartItem.Description,
                Price = cartItem.Price,
                Size = cartItem.Size,
                Quantity = cartItem.Quantity,
            })
            .ToList();
    }
}