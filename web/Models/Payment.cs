using System;

namespace web.Models;

public class Payment
{
    public int Id { get; set; }
    public Order Order { get; set; }
    public string PaymentMethod { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public string PaymentIdentifier { get; set; }
    public string PaymentConfirmation { get; set; }
    public double Amount { get; set; }

    public Payment()
    {
        
    }

    public Payment(int id, Order order, string paymentMethod, DateTimeOffset timestamp, string paymentIdentifier, string paymentConfirmation, double amount)
    {
        this.Id = id;
        this.Order = order;
        this.PaymentMethod = paymentMethod;
        this.Timestamp = timestamp;
        this.PaymentIdentifier = paymentIdentifier;
        this.PaymentConfirmation = paymentConfirmation;
        this.Amount = amount;
    }
}