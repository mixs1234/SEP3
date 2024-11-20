using sep3.orders.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sep3.orders.Services;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(Order order);
    Task<Order> CreateOrderAsync(int? customerId, int? productId);
    Task<List<Order>> GetOrdersAsync();
    Task<Order> GetOrderAsync(int? id);
    Task UpdateOrderAsync(int? id, int? customerId, int? productId);
    Task DeleteOrderAsync(int? id);
    
}