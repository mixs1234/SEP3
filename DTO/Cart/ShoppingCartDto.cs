namespace DTO.Cart;

public class ShoppingCartDto
{
    public int Id { get; set; }
    public List<CartItemDto> CartItems { get; set; }

    public ShoppingCartDto()
    {
    }

    public ShoppingCartDto(int id, List<CartItemDto> cartItems)
    {
        Id = id;
        CartItems = cartItems;
    }

    public ShoppingCartDto(List<CartItemDto> cartItems)
    {
        CartItems = cartItems;
    }
}