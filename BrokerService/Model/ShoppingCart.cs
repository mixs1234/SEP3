using System.Text.Json.Serialization;
using DTO.Cart;
using sep3.broker.Model;
using sep3.DTO.Order;

namespace sep3.orders.Model;

public class ShoppingCart
{
    public int Id { get; set; }
    public List<CartItem> CartItems { get; set; }
    
    [JsonIgnore]
    public Order Order { get; set; }
    
}