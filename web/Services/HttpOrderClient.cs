using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using sep3.DTO.Order;
using Newtonsoft.Json;
using sep3.broker.Model;
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


    public async Task<OrderResponse?> CreateOrderAsync(int customerId, int productId, int quantity)
    {
        var createOrderDto = new CreateOrderDTO()
        {
            ProductVariantId = productId,
            Quantity = quantity,
        };

        var httpResponse = await _httpClient.PostAsJsonAsync("/Order", createOrderDto);
        
        var response = await httpResponse.Content.ReadAsStringAsync();
        
        
        var orderStatus =  httpResponse;
        //Order created successfully
        if (orderStatus.IsSuccessStatusCode)
        {
            return new OrderResponse(orderStatus.IsSuccessStatusCode,response,orderStatus.StatusCode);
        }
        
        //Order creation failed add more in the future if needed like error messages
        return new OrderResponse(orderStatus.IsSuccessStatusCode,response,orderStatus.StatusCode);

    }

}