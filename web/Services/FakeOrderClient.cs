using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.Order;
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

    public Task<Order?> CreateOrderAsync(int customerId, int productId)
    {
        PlaceOrder(customerId, productId);
        return Task.FromResult<Order?>(null);
    }

    public Task<Order?> CreateOrderAsync(CreateOrderDTO createOrderDTO)
    {
        throw new NotImplementedException();
    }

    private void PlaceOrder(int customerId, int productId)
    {
        Console.WriteLine("Order placed:");
        Console.WriteLine($"Customer ID: {customerId}");
        Console.WriteLine($"Product ID: {productId}");
    }

}