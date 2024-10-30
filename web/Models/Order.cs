using System;

namespace sep3.web.Models;

public class Order
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int CustomerId { get; set; }
    public double Price { get; set; }

    public Order()
    {
        
    }

    public Order(int id, DateTimeOffset createdAt, int customerId, double price)
    {
        this.Id = id;
        this.CreatedAt = createdAt;
        this.CustomerId = customerId;
        this.Price = price;
    }
}