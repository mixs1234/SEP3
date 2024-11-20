
using ConsoleApp1.Services;
using sep3.DTO.Order;
using sep3.Model;


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