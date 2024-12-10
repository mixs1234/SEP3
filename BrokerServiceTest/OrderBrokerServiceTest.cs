using System.Net;
using brokers.broker;
using DTO.Cart;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using sep3.broker.Services;
using sep3.DTO.Order;

namespace BrokerTest;

public class OrderBrokerServiceTest
{
    [Fact]
    public async Task Create_Order_Test_Success()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
    
        var cartItem = new CreateCartItemDto
        {
            Materials = "test",
            Price = 1,
            ProductId = 1,
            ProductName = "test",
            Quantity = 1,
            Size = "test",
            VariantId = 1
        };

        var order = new CreateOrderDTO
        {
            CartItems = new List<CreateCartItemDto> { cartItem }
        };
        
        mockHttp.When(HttpMethod.Post, "http://test.com/api/orders")
            .Respond("application/json", "1");

        var httpClient = new HttpClient(mockHttp)
        {
            BaseAddress = new Uri("http://test.com")
        };

        IOrderBroker broker = new OrderBroker(httpClient);

        // Act
        var response = await broker.CreateOrderAsync(order);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("1", response.Data.ToString());
        Assert.Equal("Order created successfully.", response.Message);
    }
    
    [Fact]
    public async Task Create_Order_Test_Failure()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        var cartItem = new CreateCartItemDto
        {
            Materials = "test",
            Price = 1,
            ProductId = 1,
            ProductName = "test",
            Quantity = 1,
            Size = "test",
            VariantId = 1
        };

        var order = new CreateOrderDTO
        {
            CartItems = new List<CreateCartItemDto> { cartItem }
        };

        var errorMessage = "Order creation failed.";

        mockHttp.When(HttpMethod.Post, "http://test.com/api/orders")
            .Respond(HttpStatusCode.BadRequest, "application/json", JsonConvert.SerializeObject(errorMessage));

        var httpClient = new HttpClient(mockHttp)
        {
            BaseAddress = new Uri("http://test.com")
        };

        IOrderBroker broker = new OrderBroker(httpClient);

        // Act
        var response = await broker.CreateOrderAsync(order);

        // Assert
        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
        Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
        
        var deserializedMessage = JsonConvert.DeserializeObject<string>(response.Message);
        Assert.Equal(errorMessage, deserializedMessage);
    }
}