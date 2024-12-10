using System.Net;
using RichardSzalay.MockHttp;
using sep3.brokers.broker;
using Xunit;
using ArchiveStatusBroker = sep3.brokers.broker.ArchiveStatusBroker;
using Assert = NUnit.Framework.Assert;

namespace BrokerTest;

public class ArchiveStatusBrokerTests
{
    [Fact]
    public async Task GetAllArchiveStatusAsync_ReturnsSuccess_OnValidResponse()
    {
        // Arrange
        var expectedJson = "[{\"id\":1,\"name\":\"Archived\"}]";
        var mockHttp = new MockHttpMessageHandler();

        // Setup a mock response
        mockHttp.When("http://test.com/api/archiveStatuses")
            .Respond("application/json", expectedJson);

        var httpClient = new HttpClient(mockHttp)
        {
            BaseAddress = new Uri("http://test.com")
        };

        IArchiveStatusBroker broker = new ArchiveStatusBroker(httpClient);

        // Act
        var result = await broker.GetAllArchiveStatusAsync();

        // Assert
        Assert.True(result.IsSuccess, "The result should indicate success.");
        Xunit.Assert.Equal(expectedJson, result.Data);
        Xunit.Assert.Equal("Archive statuses retrieved successfully.", result.Message);
    }

    [Fact]
    public async Task GetAllArchiveStatusAsync_ReturnsFailure_OnErrorResponse()
    {
        // Arrange
        var errorMessage = "Not found";
        var mockHttp = new MockHttpMessageHandler();

        // Setup a mock error response (e.g., 404)
        mockHttp.When("http://test.com/api/archiveStatuses")
            .Respond(HttpStatusCode.NotFound, "text/plain", errorMessage);
        var httpClient = new HttpClient(mockHttp)
        {
            BaseAddress = new Uri("http://test.com")
        };

        IArchiveStatusBroker broker = new ArchiveStatusBroker(httpClient);

        // Act
        var result = await broker.GetAllArchiveStatusAsync();

        // Assert
        Assert.False(result.IsSuccess, "The result should indicate failure.");
        Xunit.Assert.Equal(404, result.StatusCode);
        Xunit.Assert.Equal(errorMessage, result.Message);
    }
    
}