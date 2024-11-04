using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sep3.orders.Model;
using sep3.orders.Infrastructure;

namespace sep3.orders.Services;

public class CustomerEFRepository : ICustomerRepository
{
    private readonly OrdersContext _context;

    public CustomerEFRepository(OrdersContext context)
    {
        _context = context;
        if (_context == null)
            _context = OrdersContext.GetInstance(null);
    }
    
    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
        // TODO: Event
    }

    public async Task<Customer> CreateCustomerAsync(string name, string email, string phone)
    {
        if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(phone))
        {
            Customer customer = new Customer()
            {
                Name = name,
                Email = email,
                Phone = phone
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
            // TODO: Event
        }
        else
            throw new ArgumentNullException();
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerAsync(int? id)
    {
        if (id.HasValue)
            return await _context.Customers.Where(c => c.Id == id.Value).FirstOrDefaultAsync();
        else
            throw new ArgumentNullException(nameof(id));
    }

    public async Task UpdateCustomerAsync(int? id, string name, string email, string phone)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCustomerAsync(int? id)
    {
        if (id.HasValue)
        {
            Customer customer = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            // TODO: Event
        }
        else
            throw new ArgumentNullException(nameof(id));
    }
}