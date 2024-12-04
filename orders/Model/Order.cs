using sep3.DTO.Order;

namespace sep3.orders.Model;

public class Order
{
    public int Id { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public int ShoppingCartId { get; set; }
    

    public static CreateOrderDTO ToCreateOrderDto(Order order)
    {
        throw new NotImplementedException();
    }
    
    
    public static CreateOrderConfirmationDTO ToCreateOrderConfirmationDto(Order order)
    {
        throw new NotImplementedException();
    }

    public static Order ToModel(CreateOrderDTO createOrderDto)
    {
        return new Order()
        {
            ShoppingCart = new ShoppingCart()
            {
                CartItems = CartItem.ToModel(createOrderDto.CartItems)
            }
        };
    }

}