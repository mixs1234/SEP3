using brokers.broker;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using sep3.broker.Services;
using sep3.brokers.broker;
using sep3.DTO.Product;

namespace BrokerTest;

public class ProductVariantBrokerServiceTest
{
    [Fact]
    public async Task ProductVariant_Update_succes()
    {
        var mockHttp = new MockHttpMessageHandler();

        var productVariantDto = new ProductVariantDTO()
        {
            Id = 1,
            ArchiveStatusId = 1,
            Material = "test",
            Size = "test",
            Stock = 1
        };

        var expectedSuccesMessage = "Product variant created successfully.";

        // Mock response as JSON including product variant data
        var mockedResponse = new
        {
            message = expectedSuccesMessage,
            data = new
            {
                Id = 1,
                ArchiveStatusId = 1,
                Material = "test",
                Size = "test",
                Stock = 1
            }
        };

        var mockedResponseJson = JsonConvert.SerializeObject(mockedResponse);

        mockHttp.When(HttpMethod.Put, "http://test.com/api/variants")
            .Respond("application/json", mockedResponseJson);

        var httpClient = new HttpClient(mockHttp)
        {
            BaseAddress = new Uri("http://test.com")
        };

        IProductVariantBroker broker = new ProductVariantBroker(httpClient);

        // Call the method
        var response = await broker.UpdateProductVariantAsync(productVariantDto);

        // Directly compare the response message and Id
        Assert.True(response.IsSuccess);
        Assert.Equal(expectedSuccesMessage, response.Message);
    }
}