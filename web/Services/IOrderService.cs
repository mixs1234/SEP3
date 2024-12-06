using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.broker.Model;
using web.Model;

namespace web.Services;

public interface IOrderService
{
    Task<List<Order>?> GetOrdersAsync();
    
    Task<List<Order>?> GetOrdersAsync(int customerId);
    
    Task RemoveOrderAsync(int id);
    
    Task<OrderResponse?> CreateOrderAsync(List<CartItem> cartItems);
    

}