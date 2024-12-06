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

        public OrderController(IOrderBroker orderBroker,IProductBroker productBroker, IProductVariantBroker productVariantBroker)
        {
            _orderBroker = orderBroker;
            _productBroker = productBroker;
            _productVariantBroker = productVariantBroker;
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
                    var productResult = await _productBroker.GetProductAsync(cartItem.ProductId);
                    if (productResult?.IsSuccess == true && productResult.Data != null)
                    {
                        cartItem.Product = productResult.Data;
                    }

                    // Fetch Variant
                    var variantResult = await _productVariantBroker.GetProductVariantAsync(cartItem.VariantId);
                    if (variantResult?.IsSuccess == true && variantResult.Data != null)
                    {
                        cartItem.Variant = variantResult.Data;
                    }
                }
            }

            return Ok(orders);
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
