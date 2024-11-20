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

    public async Task<Order> CreateOrderAsync(int? customerId, int? productId)
    {
        if (customerId.HasValue && productId.HasValue)
        {
            Order order = new Order()
            {
                CustomerId = customerId.Value,
                ProductId = productId.Value
            };
            return await CreateOrderAsync(order);
        }
        else
            throw new ArgumentNullException();
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

    public async Task UpdateOrderAsync(int? id, int? customerId, int? productId)
    {
        if (id.HasValue && customerId.HasValue && productId.HasValue)
        {
            Order order = await GetOrderAsync(id) ?? throw new InvalidOperationException();
            order.CustomerId = customerId.Value;
            order.ProductId = productId.Value;
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