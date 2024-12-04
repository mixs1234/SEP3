namespace DTO.Cart;

public class ShoppingCartDto
{
    public int Id { get; set; }
    public List<CartItemDto> CartItems { get; set; }
}