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

    public async Task<Order> CreateOrderAsync(DateTimeOffset? createdAt, int? customerId, double? price)
    {
        if (createdAt.HasValue && customerId.HasValue && price.HasValue)
        {
            Order order = new Order()
            {
                CreatedAt = createdAt.Value,
                CustomerId = customerId.Value,
                Price = price.Value
            };
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

    public async Task UpdateOrderAsync(int? id, DateTimeOffset? createdAt, int? customerId, double? price)
    {
        if (id.HasValue && createdAt.HasValue && customerId.HasValue && price.HasValue)
        {
            Order order = await GetOrderAsync(id);
            order.CreatedAt = createdAt.Value;
            order.CustomerId = customerId.Value;
            order.Price = price.Value;
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
            Order order = _context.Orders.Where(o => o.Id == id.Value).FirstOrDefault() ?? throw new InvalidOperationException();
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            // TODO: Event
        }
        else
            throw new ArgumentNullException(nameof(id));
    }
}