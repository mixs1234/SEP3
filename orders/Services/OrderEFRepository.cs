using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sep3.orders.Model;
using sep3.orders.Infrastructure;

namespace sep3.orders.Services;

public class OrderEFRepository : IOrderRepository
{
    private readonly OrdersContext _context;

    public OrderEFRepository(OrdersContext context)
    {
        _context = context;
        if (_context == null)
            _context = OrdersContext.GetInstance(null);
    }
    
    public async Task<Order> CreateOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
        // TODO: Event
    }

    public async Task<Order> CreateOrderAsync(DateTimeOffset? createdAt, int? customerId, List<LineItem> lineItems, int? paymentId)
    {
        if (createdAt.HasValue && customerId.HasValue && lineItems != null && lineItems.Any())
        {
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
            return await CreateOrderAsync(order);
        }
        else
            throw new ArgumentNullException();
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetOrderAsync(int? id)
    {
        if (id.HasValue)
            return await _context.Orders.Where(o => o.Id == id.Value).FirstOrDefaultAsync();
        else
            throw new ArgumentNullException(nameof(id));
    }

    public async Task UpdateOrderAsync(int? id, DateTimeOffset? createdAt, int? customerId, List<LineItem> lineItems, int? paymentId)
    {
        if (id.HasValue && customerId.HasValue && lineItems != null && lineItems.Any())
        {
            Order order = await GetOrderAsync(id);
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