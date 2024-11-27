using rabbitmq.Messaging.Pub;
using sep3.DTO.Order;
using sep3.orders.Infrastructure;
using sep3.orders.Model;

namespace sep3.orders.Services;

public class OrderReposity : IOrderRepository
{
    private readonly OrderDbContext _context;
    private readonly OrderPublisher _orderPublisher;
    
    public OrderReposity(OrderDbContext context, OrderPublisher orderPublisher)
    {
        _context = context;
        _orderPublisher = orderPublisher;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderDTO createOrderDto)
    {
        try
        {
            var orderCreated = _context.orders.Add(Order.FromCreateOrderDto(createOrderDto));
            await _context.SaveChangesAsync();
            await _orderPublisher.PublishOrder(Order.ToCreateOrderConfirmationDto(orderCreated.Entity));
            return orderCreated.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while saving changes: " + ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }
            throw;
        }
    }
}