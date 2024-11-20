using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.Model;
using sep3.DTO.Order;

namespace web.Services;

public interface IOrderService
{
    Task<List<Order?>> GetOrdersAsync();
    
    Task RemoveOrderAsync(int id);
    
    Task<Order?> CreateOrderAsync(int customerId, int productId);
    
    Task<Order?> CreateOrderAsync(CreateOrderDTO createOrderDTO);

}