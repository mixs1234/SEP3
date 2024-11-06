using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web.Models;


namespace web.Services;

public class FakeOrderClient : IOrderService
{
    public Task<List<Order?>> GetOrdersAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Order?> CreateOrderAsync(Customer customer, List<LineItem> lineItems, Payment payment)
    {
        var order = new Order()
        {
            Id = 1,
            CreatedAt = DateTimeOffset.Now,
            Customer = customer,
            CustomerId = customer.Id,
            LineItems = lineItems,
            Payment = payment
        };
        PlaceOrder(order);
        return new Task<Order?>(() => order);
    }
    
    private void PlaceOrder(Order order)
    {
        Console.WriteLine("Order placed:");
        Console.WriteLine($"Order ID: {order.Id}");
        Console.WriteLine($"Created at: {order.CreatedAt}");
        Console.WriteLine($"Customer ID: {order.CustomerId}");
        Console.WriteLine($"Price: {order.Payment.Amount}");
    }

}