using DTO.Cart;
using sep3.DTO.Order;

namespace sep3.orders.Model;

public class ShoppingCart
{
    public int Id { get; set; }
    public List<CartItem> CartItems { get; set; }
    public Order Order { get; set; }
    
}