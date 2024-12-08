using sep3.DTO.Order;
using sep3.orders.Model;

namespace sep3.orders.Services;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(CreateOrderDTO createOrderDto);
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order> UpdateOrderStatusASync(int orderId, int statusId);
    
    Task<List<Order>?> GetOrderAsync(int customerId);
    
}