using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sep3.orders.Infrastructure;
using sep3.orders.Model;

namespace sep3.orders.Services;

public class OrderEFRepository 
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