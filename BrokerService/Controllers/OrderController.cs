﻿using sep3.DTO.Order;
using Microsoft.AspNetCore.Mvc;
using brokers.broker; // Namespace where IOrderBroker is defined


namespace sep3.brokers.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBroker _orderBroker;

        public OrderController(IOrderBroker orderBroker)
        {
            _orderBroker = orderBroker;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO createOrderDto)
        {
            var result = await _orderBroker.CreateOrderAsync(createOrderDto);
            if (result.IsSuccess)
            {
                return Ok(new { OrderId = result.Data, result.Message });
            }

            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var result = await _orderBroker.GetOrderAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return StatusCode(result.StatusCode, result.Message ?? "Failed to retrieve order.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderBroker.GetAllOrdersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return StatusCode(result.StatusCode, result.Message);
        }
        
        [HttpGet("customer/{customerId}")]
         public async Task<IActionResult> GetAllOrders(int customerId)
        {
            var result = await _orderBroker.GetAllOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                
                return Ok(result.Data);
            }

            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] CreateOrderDTO createOrderDto)
        {
            var result = await _orderBroker.UpdateOrderAsync(createOrderDto);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderBroker.DeleteOrderAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
