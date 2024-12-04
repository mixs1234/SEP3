using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTO.Cart;
using sep3.DTO.Order;
using Newtonsoft.Json;
using orders.Migrations;
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


    public async Task<Order?> CreateOrderAsync(List<CartItem> cartItems)
    {
        var cartItemsDto = cartItems.Select(item => new CreateCartItemDto()
        {
            Description = item.Description,
            Name = item.Name,
            Price = item.Price,
            Quantity = item.Quantity,
            Size = item.Size,
            VariantId = item.VariantId
        }).ToList();

        if (!cartItemsDto.Any())
        {
            throw new Exception($"Failed to add order with, there is no items in order");
        }

        var createOrderDto = new CreateOrderDTO()
        {
            CartItems = cartItemsDto
        };
        
        var httpResponse = await _httpClient.PostAsJsonAsync("/Order", createOrderDto);

        var response = await httpResponse.Content.ReadAsStringAsync();

        return new Order();
    }
}