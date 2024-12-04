using DTO.Cart;

namespace sep3.DTO.Order;

public class CreateOrderDTO
{
    public List<CreateCartItemDto> CartItems { get; set; }
}