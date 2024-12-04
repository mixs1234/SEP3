using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.broker.Model;
using web.Model;

namespace web.Services;

public interface IOrderService
{
    Task<List<Order>?> GetOrdersAsync();
    
    Task RemoveOrderAsync(int id);
    
    Task<OrderResponse?> CreateOrderAsync(int customerId, int productId, int quantity);
    

}