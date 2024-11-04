using System;
using System.Collections.Generic;

namespace sep3.orders.Model;

public class Order
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public List<LineItem> LineItems { get; set; }
    public Payment Payment { get; set; }

    public Order()
    {
        
    }

    public Order(int id, DateTimeOffset createdAt, Customer customer, List<LineItem> lineItems, Payment payment)
    {
        this.Id = id;
        this.CreatedAt = createdAt;
        this.Customer = customer;
        this.LineItems = lineItems;
        this.Payment = payment;
    }
}