using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using sep3.DTO.Order;
using Newtonsoft.Json;
using sep3.Model;
using web.Services;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

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
        var httpResponse = _httpClient.GetAsync("/Order");
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        var orders = JsonConvert.DeserializeObject<List<Order>>(content.Result);
        return Task.FromResult(orders);
    }
    
    public async Task RemoveOrderAsync(int id)
    {
        var httpResponse = await _httpClient.DeleteAsync($"/Order/{id}");
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to delete order with ID {id}: {httpResponse.ReasonPhrase}");
        }
        Console.WriteLine($"Order with ID {id} deleted");
    }


    public async Task<Order?> CreateOrderAsync(int customerId, int productId)
    {
        var createOrderDTO = new CreateOrderDTO()
        {
            CustomerId = customerId,
            ProductId = productId
        };

        var httpResponse = await _httpClient.PostAsJsonAsync("/Order", createOrderDTO);
        var response = await httpResponse.Content.ReadAsStringAsync();

        return new Order();

    }

    public async Task<Order?> CreateOrderAsync(CreateOrderDTO createOrderDTO)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("/Order", createOrderDTO);
        var response = await httpResponse.Content.ReadAsStringAsync();

        return new Order();
    }
}