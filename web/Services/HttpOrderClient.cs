using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using sep3.DTO.Order;
using Newtonsoft.Json;
using web.Model;
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
        var httpResponse = _httpClient.GetAsync("/Orders");
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        var orders = JsonConvert.DeserializeObject<List<Order>>(content.Result);
        return Task.FromResult(orders);
    }
    
    public async Task RemoveOrderAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"/Orders/{id}");
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to delete order with ID {id}: {httpResponse.ReasonPhrase}");
        }
        Console.WriteLine($"Order with ID {id} deleted");
    }


    public async Task<Order?> CreateOrderAsync(int customerId, int productId, int quantity)
    {
        var createOrderDto = new CreateOrderDTO()
        {
            ProductVariantId = productId,
            Quantity = quantity,
        };

        var httpResponse = await _httpClient.PostAsJsonAsync("/Orders", createOrderDto);
        
        var response = await httpResponse.Content.ReadAsStringAsync();

        return new Order();

    }

}