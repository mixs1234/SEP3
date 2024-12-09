using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using sep3web.Services;
using web.Model.Order;
using web.Services;

namespace web.test;
using Xunit;

public class HttpOrderClientTests
{
    [Fact]
    public async Task GetOrdersAsync_ReturnsExpectedOrders_WithMockHttp()
    {
        var shoppingCart =new ShoppingCart
        {
            Id = 1, CartItems = new List<CartItem>
            {
                new CartItem
                {
                    Id = 1, ProductId = 1, VariantId = 1, ProductName = "Product 1", Materials = "Material 1",
                    Size = "Size 1", Price = 10.0, Quantity = 1, ShoppingCartId = 1
                },
                new CartItem
                {
                    Id = 2, ProductId = 2, VariantId = 2, ProductName = "Product 2", Materials = "Material 2",
                    Size = "Size 2", Price = 20.0, Quantity = 2, ShoppingCartId = 1
                }
            }
        };
        
        var expectedOrders = new List<Order>
        {
            
            
            new Order {Id = 1, CustomerId = 1, StatusId = 1},
            new Order {Id = 2, CustomerId = 1, StatusId = 1},
            new Order {Id = 3, CustomerId = 2, StatusId = 1}
        };
        
        expectedOrders[0].ShoppingCart = shoppingCart;
        expectedOrders[1].ShoppingCart = shoppingCart;
        expectedOrders[2].ShoppingCart = shoppingCart;
        
        var json = JsonConvert.SerializeObject(expectedOrders);
        
        // Create the mock HTTP handler
        var mockHttp = new MockHttpMessageHandler();
        
        // Set up your mock response
        // When the HttpOrderClient calls GET http://test.com/Order,
        // return the JSON data we created above.
        mockHttp.When("http://test.com/Order")
            .Respond("application/json", json);
        
        // Create HttpClient with the mock handler
        var httpClient = new HttpClient(mockHttp)
        {
            BaseAddress = new System.Uri("http://test.com")
        };
        
        // Pass it into HttpOrderClient
        IOrderService orderService = new HttpOrderClient(httpClient);

        // Act
        var orders = await orderService.GetOrdersAsync();
        
        // Assert
        Assert.NotNull(orders);
        Assert.Equal(expectedOrders.Count, orders.Count);

        // Optional: more detailed checks
        Assert.Equal(expectedOrders[0].Id, orders[0].Id);
        Assert.Equal(expectedOrders[0].ShoppingCart.CartItems.Count, orders[0].ShoppingCart.CartItems.Count);
        Assert.Equal(expectedOrders[1].CustomerId, orders[1].CustomerId);
    }
}
    