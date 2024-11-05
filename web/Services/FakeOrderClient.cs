using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.web.Models;

namespace web.Services;

public class FakeOrderClient : IOrderService
{
    public Task<List<Order>?> GetOrdersAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<Order?> CreateOrderAsync(Order order)
    {
        PlaceOrder(order);
        
        return Task.FromResult(order)!;
    }
    
    private void PlaceOrder(Order order)
    {
        Console.WriteLine("Order placed:");
        Console.WriteLine($"Order ID: {order.Id}");
        Console.WriteLine($"Created at: {order.CreatedAt}");
        Console.WriteLine($"Customer ID: {order.CustomerId}");
        Console.WriteLine($"Price: {order.Price}");
    }
    
}