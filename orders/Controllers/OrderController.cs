using Microsoft.AspNetCore.Mvc;
using sep3.DTO.Order;
using sep3.orders.Services;

namespace sep3.orders.Controllers;

[ApiController]
public class OrderController :Controller
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    [HttpPost]
    [Route("api/orders")]
    public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDTO order)
    {
        Console.WriteLine("Creating order");
        var createdOrder = await _orderRepository.CreateOrderAsync(order);
        return Ok(createdOrder.Id.ToString());
    }
    
    
    
}