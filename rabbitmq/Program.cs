using rabbitmq.Messaging.Pub;

namespace rabbitmq;

class Program
{
    static async Task Main(string[] args)
    {
        var order = new Model.OrderDTO
        {
            OrderId = "123",
            ProductVariantId = "456"
        };
        
        OrderPublisher orderPublisher = new OrderPublisher();
        
        await orderPublisher.PublishOrder(order);
    }
}