using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sep3.web.Models;
using web.Services;

namespace sep3web.Services;

public class HttpOrderClient : IOrderService
{
    
    private readonly HttpClient _httpClient;
    
    public HttpOrderClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<List<Order>?> GetOrdersAsync()
    {
        var httpResponse = _httpClient.GetAsync("Order/Orders");
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        var orders = JsonConvert.DeserializeObject<List<Order>>(content.Result);
        return Task.FromResult(orders);
    }
    
    public async Task RemoveOrderAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"Order/orders/{id}");
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to delete order with ID {id}: {httpResponse.ReasonPhrase}");
        }
        Console.WriteLine($"Order with ID {id} deleted");
    }

    
    public Task AddOrderAsync(DateTimeOffset? createdAt, int? customerId, double? price)
    {
        var order = new Order()
        {
            CreatedAt = createdAt.Value,
            CustomerId = customerId.Value,
            Price = price.Value
        };
        var json = JsonConvert.SerializeObject(order);
        var httpResponse = _httpClient.PostAsync("Order/Orders", new StringContent(json));
        return Task.CompletedTask;
    }
}