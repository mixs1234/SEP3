using System.Text.Json.Serialization;
using DTO.Cart;
using sep3.DTO.Product;

namespace sep3.orders.Model;

public class CartItem
{
    public int Id { get; set; }
    public long VariantId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }

    public ProductDTO Product { get; set; }
    public ProductVariantDTO Variant { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public int ShoppingCartId { get; set; }

    public static List<CartItem> ToModel(List<CreateCartItemDto> createCartItemDtos)
    {
        return createCartItemDtos
            .Select(cartItem => new CartItem
            {
                VariantId = cartItem.VariantId,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
            })
            .ToList();
    }
}