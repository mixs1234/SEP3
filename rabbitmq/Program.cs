using rabbitmq.Messaging.Pub;
using sep3.DTO.Order;

namespace rabbitmq;

class Program
{
    static async Task Main(string[] args)
    {
        var order = new CreateOrderConfirmationDTO()
        {
            OrderId = 1,
            ProductVariantId = 1
        };
        
        OrderPublisher orderPublisher = new OrderPublisher();
        
        await orderPublisher.PublishOrder(order);
    }
}