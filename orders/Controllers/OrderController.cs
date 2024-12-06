using Microsoft.AspNetCore.Mvc;
using sep3.DTO.Order;
using sep3.orders.Services;

namespace sep3.orders.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController :Controller
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDTO order)
    {
        Console.WriteLine("Creating order");
        var createdOrder = await _orderRepository.CreateOrderAsync(order);
        return Ok(createdOrder.Id.ToString());
    }
    
    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetOrdersAsync(int customerId)
    {
        var orders = await _orderRepository.GetOrderAsync(customerId);
        return Ok(orders);
    }
    
    
    
}