﻿
using System.Collections.Generic;
using System.Threading.Tasks;
using web.Model;

namespace web.Services;

public interface IOrderService
{
    Task<List<Order>?> GetOrdersAsync();
    
    Task RemoveOrderAsync(int id);
    
    Task<Order?> CreateOrderAsync(int customerId, int productId, int quantity);
    

}