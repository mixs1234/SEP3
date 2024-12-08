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
        private readonly IProductBroker _productBroker;
        private readonly IProductVariantBroker _productVariantBroker;

        public OrderController(IOrderBroker orderBroker, IProductVariantBroker productVariantBroker, IProductBroker productBroker)
        {
            _orderBroker = orderBroker;
            _productBroker = productBroker;
            _productVariantBroker = productVariantBroker;
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
            
            
            foreach (var order in orders)
            {
                if (order.ShoppingCart?.CartItems == null) continue; 

                foreach (var cartItem in order.ShoppingCart.CartItems)
                {
                    if (cartItem == null) continue; 

                    // Fetch Product
                    var productResult = await _productBroker.GetProductAsync((int)cartItem.ProductId);
                    if (productResult?.IsSuccess == true && productResult.Data != null)
                    {
                        cartItem.Product = productResult.Data;
                    }

                    // Fetch Variant
                    var variantResult = await _productVariantBroker.GetProductVariantAsync((int)cartItem.VariantId);
                    if (variantResult?.IsSuccess == true && variantResult.Data != null)
                    {
                        cartItem.Variant = variantResult.Data;
                    }
                }
            }

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
        
    }
}
