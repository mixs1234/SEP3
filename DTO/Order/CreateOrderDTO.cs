using DTO.Cart;

namespace sep3.DTO.Order;

public class CreateOrderDTO
{
    public int CustomerId { get; set; }
    public List<CreateCartItemDto> CartItems { get; set; }
}