using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTO.Cart;
using sep3.DTO.Order;
using Newtonsoft.Json;
using sep3.broker.Model;
using web.Model.Order;
using web.Services;
using CartItem = web.Model.CartItem;

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
        
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        
        var orders = JsonConvert.DeserializeObject<List<Order>>(content.Result, settings);
        return Task.FromResult(orders);
    }
    
    public async Task<OrderResponse?> CreateOrderAsync(List<CartItem> cartItems)
    {
        var cartItemsDto = cartItems.Select(item => new CreateCartItemDto()
        {
            Quantity = item.Quantity,
            ProductId = item.ProductId,
            VariantId = item.VariantId
        }).ToList();

        if (!cartItemsDto.Any())
        {
            throw new Exception($"Failed to add order with, there is no items in order");
        }

        var createOrderDto = new CreateOrderDTO()
        {
            CustomerId = 1, // HARDCODED
            CartItems = cartItemsDto
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

    public Task<Order?> UpdateOrderAsync(int orderId, int statusId)
    {
        var httpResponse = _httpClient.PutAsync($"/Order/{orderId}?statusId={statusId}", null);
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        
        var order = JsonConvert.DeserializeObject<Order>(content.Result, settings);
        
        return Task.FromResult(order);
    }
}