using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sep3.orders.Model;
using sep3.orders.Infrastructure;
using rabbitmq.Messaging.Pub;

namespace sep3.orders.Services;

public class OrderEFRepository : IOrderRepository
{
    private readonly OrdersContext _context;
    private readonly OrderPublisher _orderPublisher;

    public OrderEFRepository(OrdersContext context)
    {
        _context = context;
        _orderPublisher = new OrderPublisher();
        if (_context == null)
            _context = OrdersContext.GetInstance(null);
    }
    
    public async Task<Order> CreateOrderAsync(Order order)
    {
        try
        {
            Console.WriteLine("Creating order");
            _context.Orders.Add(order);
            Console.WriteLine("Order added to context");
            await _context.SaveChangesAsync();
            Console.WriteLine("Context saved");
            await _orderPublisher.PublishOrder(order.ToConfirmationDTO());
            Console.WriteLine("Order published");
            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while saving changes: " + ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }
            throw; // Re-throw to propagate the exception
        }
    }

    public async Task<Order> CreateOrderAsync(DateTimeOffset? createdAt, int? customerId, List<LineItem> lineItems, int? paymentId)
    {
        if (!createdAt.HasValue || !customerId.HasValue || lineItems == null) throw new ArgumentNullException();
        
        Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId.Value);
        if (customer == null)
            throw new Exception($"Customer {customerId} not found");
        Payment? payment = null;
        if (paymentId.HasValue)
            payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == paymentId);
        Order order = null;
        if (payment == null) // Order isn't paid yet
        {
            order = new Order()
            {
                CreatedAt = createdAt.Value,
                Customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId.Value),
                LineItems = lineItems
            };
        }
        else
        {
            order = new Order()
            {
                CreatedAt = createdAt.Value,
                Customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId.Value),
                LineItems = lineItems,
                Payment = payment
            };
        }
        if (lineItems != null && lineItems.Any())
        {
            foreach (LineItem lineItem in lineItems)
                lineItem.Order = order;
        }
        return await CreateOrderAsync(order);

    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.LineItems)
            .ToListAsync(); // Eager loading https://learn.microsoft.com/en-us/ef/core/querying/related-data/eager
    }

    public async Task<Order> GetOrderAsync(int? id)
    {
        if (id.HasValue)
            return await _context.Orders
                .Where(o => o.Id == id.Value)
                .Include(o => o.Customer)
                .Include(o => o.LineItems)
                .ThenInclude(li => li.Product)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync();
        else
            throw new ArgumentNullException(nameof(id));
    }

    public async Task UpdateOrderAsync(int? id, DateTimeOffset? createdAt, int? customerId, List<LineItem> lineItems, int? paymentId)
    {
        if (id.HasValue && customerId.HasValue && lineItems != null && lineItems.Any())
        {
            Order order = await GetOrderAsync(id) ?? throw new InvalidOperationException();
            order.CreatedAt = createdAt.Value;
            if (customerId.HasValue)
                order.Customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId.Value);
            order.LineItems = lineItems;
            if (paymentId.HasValue)
                order.Payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == paymentId.Value);
            await _context.SaveChangesAsync();
            // TODO: Event
        }
        else
            throw new ArgumentNullException();
    }

    public async Task DeleteOrderAsync(int? id)
    {
        if (id.HasValue)
        {
            Order order = await _context.Orders.Where(o => o.Id == id.Value).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            // TODO: Event
        }
        else
            throw new ArgumentNullException(nameof(id));
    }
}