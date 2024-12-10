using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.broker.Model;
using web.Model.Order;
using CartItem = web.Model.CartItem;

namespace web.Services;

public interface IOrderService
{
    Task<List<Order>?> GetOrdersAsync();
    Task<List<Order>?> GetOrdersAsync(int customerId);
    Task<OrderResponse?> CreateOrderAsync(List<CartItem> cartItems, int customerId);
    Task<Order?> UpdateOrderAsync(int orderId, int statusId);
    Task<int> GetOrderStatusAsync(int orderId);
    

}