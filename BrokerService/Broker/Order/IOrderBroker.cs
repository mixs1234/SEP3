
using sep3.broker.Services;
using sep3.broker.Model;
using sep3.DTO.Order;



namespace brokers.broker
{
    public interface IOrderBroker
    {
        Task<Result<int>> CreateOrderAsync(CreateOrderDTO createOrderDto);
        Task<Result<string>> GetAllOrdersAsync();
        Task<Result<string>> UpdateOrderAsync(int orderId, int statusId);
        
        Task<Result<IEnumerable<Order>>> GetAllOrdersAsync(int customerId);
        
        Task<Result<string>> GetOrderStatusAsync(int orderId);
    }
}