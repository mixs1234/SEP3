using System.Net;
using web.Model;

namespace sep3.broker.Model;

public class OrderResponse
{
    public OrderResponse(bool isSuccess, string orderId, HttpStatusCode statusCode)
    {
        IsSuccess = isSuccess;
        this.orderId = orderId;
        StatusCode = statusCode;
    }

    public OrderResponse(bool isSuccess, string orderId, string? errorMessage, HttpStatusCode statusCode)
    {
        IsSuccess = isSuccess;
        this.orderId = orderId;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }


    public bool IsSuccess { get; set; }
    public string orderId { get; set; }
    public string? ErrorMessage { get; set; }
    public System.Net.HttpStatusCode StatusCode { get; set; }
}