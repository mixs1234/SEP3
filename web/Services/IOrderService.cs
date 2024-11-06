using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web.Models;

namespace web.Services;

public interface IOrderService
{
    Task<List<Order?>> GetOrdersAsync();
    
    Task RemoveOrderAsync(int id);
    
    Task<Order?> CreateOrderAsync(Customer customer, List<LineItem> lineItems, Payment payment);

}