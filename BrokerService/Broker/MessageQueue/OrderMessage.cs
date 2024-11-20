using sep3.DTO.Order;

namespace brokers.broker;

public class OrderMessage
{
    public string Action { get; set; } // e.g., "CreateOrder", "UpdateOrder"
    public CreateOrderDTO OrderData { get; set; }
    public int OrderId { get; set; }
}