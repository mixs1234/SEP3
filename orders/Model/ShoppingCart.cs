using DTO.Cart;
using sep3.DTO.Order;

namespace sep3.orders.Model;

public class ShoppingCart
{
    public int Id { get; set; }
    public List<CartItem> CartItems { get; set; }
    public Order Order { get; set; }
    


    public ShoppingCart()
    {
    }

    public ShoppingCart(int id, List<CartItem> cartItems)
    {
        Id = id;
        CartItems = cartItems;
    }


    public static ShoppingCart FromCreateOrderDto(CreateOrderDTO createOrderDto)
    {
        throw new NotImplementedException();
    }
    
}