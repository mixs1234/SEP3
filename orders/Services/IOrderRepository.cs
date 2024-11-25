using sep3.DTO.Order;
using sep3.orders.Model;

namespace sep3.orders.Services;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(CreateOrderDTO createOrderDto);
}