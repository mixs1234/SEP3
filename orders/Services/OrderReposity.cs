using rabbitmq.Messaging.Pub;
using sep3.DTO.Order;
using sep3.orders.Infrastructure;
using sep3.orders.Model;

namespace sep3.orders.Services;

public class OrderReposity : IOrderRepository
{
    private readonly OrderDbContext _context;
    private readonly OrderPublisher _orderPublisher;
    
    public OrderReposity(OrderDbContext context, OrderPublisher orderPublisher)
    {
        _context = context;
        _orderPublisher = orderPublisher;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderDTO createOrderDto)
    {
        try
        {
            var shoppingCart = new ShoppingCart
            {
                CartItems = CartItem.ToModel(createOrderDto.CartItems)
            };
            
            await _context.ShoppingCarts.AddAsync(shoppingCart);
            
            var order = new Order
            {
                ShoppingCart = shoppingCart
            };
            
            var orderCreated = await _context.orders.AddAsync(order);
            
            await _context.SaveChangesAsync();
            
            var orderCreatedID = orderCreated.Entity.Id;
            
            var productVariantIdQuantityDictionary = createOrderDto.CartItems.
                ToDictionary(cartItem => cartItem.VariantId, cartItem => cartItem.Quantity);

            var createOrderConfirmation = new CreateOrderConfirmationDTO
            {
                OrderId = orderCreatedID,
                ProductVariantIdToQuantity = productVariantIdQuantityDictionary
            };
            
            await _orderPublisher.PublishOrder(createOrderConfirmation);
            return orderCreated.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while saving changes: " + ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }
            throw;
        }
    }
}