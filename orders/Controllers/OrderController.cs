using Microsoft.AspNetCore.Mvc;
using sep3.DTO.Order;
using sep3.orders.Services;

namespace sep3.orders.Controllers;

[ApiController]
public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    [Route(("api/orders"))]
    public async Task<IActionResult> GetOrdersAsync()
    {
        var orders = await _orderRepository.GetAllOrdersAsync();
        return Ok(orders);
    }
    
    [HttpPost]
    [Route("api/orders")]
    public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDTO order)
    {
        Console.WriteLine("Creating order");
        var createdOrder = await _orderRepository.CreateOrderAsync(order);
        return Ok(createdOrder.Id.ToString());
    }

    [HttpPut]
    [Route("api/orders/{orderId}")]
    public async Task<IActionResult> UpdateOrderAsync([FromQuery] int statusId, [FromRoute] int orderId)
    {
        var updatedOrder = await _orderRepository.UpdateOrderStatusASync(orderId, statusId);
        return Ok(updatedOrder);
    }
    
    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetOrdersAsync(int customerId)
    {
        var orders = await _orderRepository.GetOrderAsync(customerId);
        return Ok(orders);
    }
    
}