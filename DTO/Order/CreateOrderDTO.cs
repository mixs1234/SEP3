using DTO.Cart;

namespace sep3.DTO.Order;

public class CreateOrderDTO
{
    public ShoppingCartDto ShoppingCartDto { get; set; }

    public CreateOrderDTO(ShoppingCartDto shoppingCartDto)
    {
        ShoppingCartDto = shoppingCartDto;
    }
}