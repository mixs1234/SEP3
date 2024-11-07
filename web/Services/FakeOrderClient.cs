using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;


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

    public Task<Order?> CreateOrderAsync(int customerId, string lineItemString, int paymentId)
    {
        PlaceOrder(customerId, lineItemString, paymentId);
        return Task.FromResult<Order?>(null);
    }
    
    private void PlaceOrder(int customerId, string lineItemString, int paymentId)
    {
        Console.WriteLine("Order placed:");
        Console.WriteLine($"Customer ID: {customerId}");
        Console.WriteLine($"Line items: {lineItemString}");
        Console.WriteLine($"Payment ID: {paymentId}");
    }

}