
using sep3.broker.Services;
using sep3.broker.Model;
using sep3.DTO.Order;



namespace brokers.broker
{
    public interface IOrderBroker
    {
        Task<Result<int>> CreateOrderAsync(CreateOrderDTO createOrderDto);
        Task<Result<Order>> GetOrderAsync(int id);
        Task<Result<IEnumerable<Order>>> GetAllOrdersAsync();
        Task<Result> UpdateOrderAsync(CreateOrderDTO createOrderDto);
        Task<Result> DeleteOrderAsync(int id);
    }
}