using sep3.orders.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sep3.orders.Services;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(Order order);
    Task<Order> CreateOrderAsync(DateTimeOffset? createdAt, int? customerId, double? price);
    Task<List<Order>> GetOrdersAsync();
    Task<Order> GetOrderAsync(int? id);
    Task UpdateOrderAsync(int? id, DateTimeOffset? createdAt, int? customerId, double? price);
    Task DeleteOrderAsync(int? id);
}