using System.Net;
using web.Model;

namespace sep3.broker.Model;

public class OrderResponse
{
    public OrderResponse(bool isSuccess, string orderId, HttpStatusCode statusCode)
    {
        IsSuccess = isSuccess;
        this.OrderId = orderId;
        StatusCode = statusCode;
    }

    public OrderResponse(bool isSuccess, string orderId, string? errorMessage, HttpStatusCode statusCode)
    {
        IsSuccess = isSuccess;
        this.OrderId = orderId;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }


    public bool IsSuccess { get; set; }
    public string OrderId { get; set; }
    public string? ErrorMessage { get; set; }
    public System.Net.HttpStatusCode StatusCode { get; set; }
}