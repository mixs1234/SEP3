using sep3.DTO.Order;

namespace sep3.orders.Model;

public class Order
{
    public int Id { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public int ShoppingCartId { get; set; }

    public Order()
    {
    }

    public Order(int id, ShoppingCart shoppingCart)
    {
        Id = id;
        ShoppingCart = shoppingCart;
    }

    public static CreateOrderDTO ToCreateOrderDto(Order order)
    {
        throw new NotImplementedException();
    }
    
    public static Order FromCreateOrderDto(CreateOrderDTO createOrderDto)
    {
        throw new NotImplementedException();
    }
    
    public static CreateOrderConfirmationDTO ToCreateOrderConfirmationDto(Order order)
    {
        throw new NotImplementedException();
    }
    
}