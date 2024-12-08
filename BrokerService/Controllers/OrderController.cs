using sep3.DTO.Order;
using Microsoft.AspNetCore.Mvc;
using brokers.broker;
using sep3.brokers.broker; // Namespace where IOrderBroker is defined


namespace sep3.brokers.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBroker _orderBroker;

        public OrderController(IOrderBroker orderBroker, IProductVariantBroker productVariantBroker, IProductBroker productBroker)
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
        
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetAllOrders(int customerId)
        {
            var result = await _orderBroker.GetAllOrdersAsync(customerId);
            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.Message);
            }

            var orders = result.Data;
            

            return Ok(orders);
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


        [HttpGet("{orderId}/status")]
        public async Task<IActionResult> GetOrderStatus(int orderId)
        {
            var result = await _orderBroker.GetOrderStatusAsync(orderId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return StatusCode(result.StatusCode, result.Message);
        }

    }
}
