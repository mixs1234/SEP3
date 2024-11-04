using sep3.orders.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sep3.orders.Services;

public interface ICustomerRepository
{
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer> CreateCustomerAsync(string name, string email, string phone);
    Task<List<Customer>> GetCustomersAsync();
    Task<Customer> GetCustomerAsync(int? id);
    Task UpdateCustomerAsync(int? id, string name, string email, string phone);
    Task DeleteCustomerAsync(int? id);
}