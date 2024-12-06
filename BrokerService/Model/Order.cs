using sep3.orders.Model;

namespace sep3.broker.Model;

using System.Text.Json.Serialization;
using sep3.DTO.Order;


public class Order
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public int ShoppingCartId { get; set; }
    public int CustomerId { get; set; }
    
    [JsonIgnore]
    public Customer Customer { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    
    [JsonIgnore]
    public Status CurrentStatus { get; set; }
    
    
    [JsonIgnore]
    public ICollection<StatusHistory> StatusHistories { get; set; }
    

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