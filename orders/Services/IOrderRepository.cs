using sep3.orders.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sep3.orders.Services;

public interface IOrderRepository
{
    
    

    Task<List<Order>> GetOrdersAsync();
    Task<Order> GetOrderAsync(int? id);

    Task DeleteOrderAsync(int? id);
    
}