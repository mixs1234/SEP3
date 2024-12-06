using sep3.DTO.Order;
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
        
        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, [FromQuery] int statusId)
        {
            var result = await _orderBroker.UpdateOrderAsync(orderId, statusId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return StatusCode(result.StatusCode, result.Message);
        }
        
    }
}
