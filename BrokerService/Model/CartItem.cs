using System.Text.Json.Serialization;
using DTO.Cart;
using sep3.DTO.Product;

namespace sep3.orders.Model;

public class CartItem
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    
    public long ProductId { get; set; }
    public long VariantId { get; set; }
    
    public string Materials { get; set; }
    public string Size { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    
    
    

    public static List<CartItem> ToModel(List<CreateCartItemDto> createCartItemDtos)
    {
        return createCartItemDtos
            .Select(cartItem => new CartItem
            {
                ProductName = cartItem.ProductName,
                ProductId = cartItem.ProductId,
                VariantId = cartItem.VariantId,
                Materials = cartItem.Materials,
                Size = cartItem.Size,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price,
            })
            .ToList();
    }
}