using sep3.orders.Model;
using sep3.orders.Services;
using sep3.orders.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Order;

namespace sep3.orders.Controllers;

[ApiController]
public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        this._orderRepository = orderRepository;
    }

    [HttpGet]
    [Route("Orders")]
    public async Task<IActionResult> GetOrders()
    {
        try
        {
            List<Order> orders = await _orderRepository.GetOrdersAsync();
            return Content(JsonConvert.SerializeObject(orders, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Orders/{id:int}")]
    public async Task<IActionResult> GetOrder(int? id)
    {
        try
        {
            Order order = await _orderRepository.GetOrderAsync(id);
            return Content(JsonConvert.SerializeObject(order, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("Orders")]
    public async Task<IActionResult> CreateOrder(CreateOrderDTO createOrderDto)
    {
        try
        {
            Order order = await _orderRepository.CreateOrderAsync(createOrderDto.CustomerId, createOrderDto.ProductId);
            return Content(order.Id.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    [Route("Orders")]
    public async Task<IActionResult> UpdateOrder(int? id, int? customerId, int? productId)
    {
        try
        {
            await _orderRepository.UpdateOrderAsync(id, customerId, productId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("Orders/{id:int}")]
    public async Task<IActionResult> DeleteOrder(int? id)
    {
        try
        {
            await _orderRepository.DeleteOrderAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(410, ex.Message);
        }
    }
}