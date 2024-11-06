using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using web.Models;
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
        var httpResponse = await _httpClient.DeleteAsync($"Order/Orders/{id}");
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to delete order with ID {id}: {httpResponse.ReasonPhrase}");
        }
        Console.WriteLine($"Order with ID {id} deleted");
    }
    
    
    public async Task<Order?> CreateOrderAsync(Customer customer, List<LineItem> lineItems, Payment payment)
    {
        // Serialize the lineItems as JSON
        var json = JsonConvert.SerializeObject(lineItems);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Build the URL with query parameters for customerId and paymentId
        var url = $"Order/Orders?customerId={customer.Id}";

        // Include paymentId if it's not null or zero
        if (payment != null && payment.Id != 0)
        {
            url += $"&paymentId={payment.Id}";
        }

        HttpResponseMessage httpResponse;
        try
        {
            httpResponse = await _httpClient.PostAsync(url, content);
        }
        catch (Exception ex)
        {
            // Log exception or handle failure
            throw new HttpRequestException("An error occurred while sending the order request.", ex);
        }

        if (!httpResponse.IsSuccessStatusCode)
        {
            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            // Log the error response if needed
            throw new HttpRequestException($"Failed to add order. Status Code: {httpResponse.StatusCode}, Response: {responseContent}");
        }
        return JsonConvert.DeserializeObject<Order>(await httpResponse.Content.ReadAsStringAsync());
    }

}