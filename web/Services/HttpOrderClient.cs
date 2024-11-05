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

    public Task<Order?> CreateOrderAsync(Order order)
    {
        throw new System.NotImplementedException();
    }
}