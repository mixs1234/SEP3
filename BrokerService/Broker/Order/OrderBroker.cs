
using sep3.broker.Services;
using sep3.DTO.Order;
using Microsoft.AspNetCore.Mvc;
using sep3.broker.Model;


namespace brokers.broker
{

    public class OrderBroker : ControllerBase, IOrderBroker
    {
        private readonly HttpClient _httpClient;

        public OrderBroker(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<int>> CreateOrderAsync(CreateOrderDTO createOrderDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/orders", createOrderDto);
                if (response.IsSuccessStatusCode)
                {
                    var orderIdString = await response.Content.ReadAsStringAsync();
                    if (int.TryParse(orderIdString, out int orderId))
                    {
                        return Result<int>.Success(orderId, "Order created successfully.");
                    }
                }

                var error = await response.Content.ReadAsStringAsync();
                return Result<int>.Failure((int)response.StatusCode, error);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(500, ex.Message);
            }
        }

        public async Task<Result<string>> GetAllOrdersAsync()
        {
            var response = await _httpClient.GetAsync("api/orders");
            if (response.IsSuccessStatusCode)
            {
                var orders = await response.Content.ReadAsStringAsync();
                return Result<string>.Success(orders, "Orders fetched successfully.");
            }
            
            var error = await response.Content.ReadAsStringAsync();
            return Result<string>.Failure((int)response.StatusCode, error);
            
        }

        public async Task<Result<string>> UpdateOrderAsync(int orderId, int statusId)
        {
            var response = _httpClient.PutAsync($"api/orders/{orderId}?statusId={statusId}", null);
            
            if (response.Result.IsSuccessStatusCode)
            {
                var content = await response.Result.Content.ReadAsStringAsync();
                return Result<string>.Success(content,"Order updated successfully.");
            }
            
            var error = response.Result.Content.ReadAsStringAsync();
            return Result<string>.Failure((int)response.Result.StatusCode, error.Result);
        }

        public async Task<Result<IEnumerable<Order>>> GetAllOrdersAsync(int customerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/orders/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadFromJsonAsync<IEnumerable<Order>>();
                    return Result<IEnumerable<Order>>.Success(orders, "Orders retrieved successfully.");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return Result<IEnumerable<Order>>.Failure((int)response.StatusCode, error);
                }
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Order>>.Failure(500, ex.Message);
            }
        }
    }
}
