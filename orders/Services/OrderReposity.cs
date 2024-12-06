using rabbitmq.Messaging.Pub;
using sep3.DTO.Order;
using sep3.orders.Infrastructure;
using sep3.orders.Model;
using Microsoft.EntityFrameworkCore;

namespace sep3.orders.Services;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _context;
    private readonly OrderPublisher _orderPublisher;

    public OrderRepository(OrderDbContext context, OrderPublisher orderPublisher)
    {
        _context = context;
        _orderPublisher = orderPublisher;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderDTO createOrderDto)
    {
        try
        {
            // Fetch the initial status (e.g., "Pending") from the database
            var initialStatus = await _context.Status
                .FirstOrDefaultAsync(s => s.Id == 1);
            
            var customerInDb = await _context.Customer
                .FirstOrDefaultAsync(c => c.Id == createOrderDto.CustomerId);

            if (customerInDb == null)
            {
                await _context.Customer.AddAsync(new Customer { Id = createOrderDto.CustomerId });
            }

            if (initialStatus == null)
            {
                throw new InvalidOperationException("Initial status 'Pending' not found in the database.");
            }

            // Create ShoppingCart
            var shoppingCart = new ShoppingCart
            {
                CartItems = CartItem.ToModel(createOrderDto.CartItems)
            };

            await _context.ShoppingCarts.AddAsync(shoppingCart);

            // Create Order
            var order = new Order
            {
                ShoppingCart = shoppingCart,
                CustomerId = createOrderDto.CustomerId,
                StatusId = initialStatus.Id, // Set initial status
                StatusHistories = new List<StatusHistory>
                {
                    new StatusHistory
                    {
                        StatusId = initialStatus.Id,
                        ChangedAt = DateTime.UtcNow
                    }
                }
            };

            var orderCreated = await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            var orderCreatedID = orderCreated.Entity.Id;

            // Create a dictionary for the confirmation DTO
            var productVariantIdQuantityDictionary = createOrderDto.CartItems
                .ToDictionary(cartItem => cartItem.VariantId, cartItem => cartItem.Quantity);

            // Create confirmation DTO
            var createOrderConfirmation = new CreateOrderConfirmationDTO
            {
                OrderId = orderCreatedID,
                ProductVariantIdToQuantity = productVariantIdQuantityDictionary
            };

            // Publish the order creation event
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

    public Task<List<Order>> GetOrderAsync(int customerId)
    {
        return _context.Orders
            .Include(o => o.ShoppingCart)
            .ThenInclude(sc => sc.CartItems)
            .Include(o => o.StatusHistories)
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
    }
}
