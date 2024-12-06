using System.Text.Json.Serialization;

namespace sep3.orders.Model;

public class ShoppingCart
{
    public int Id { get; set; }
    public List<CartItem> CartItems { get; set; }
    [JsonIgnore]
    public Order Order { get; set; }
    
}