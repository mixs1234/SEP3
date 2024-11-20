using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.DTO.Order;
using sep3.Model;


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

    public async Task<Order?> CreateOrderAsync(int customerId, int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<Order?> CreateOrderAsync(CreateOrderDTO createOrderDTO)
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