using System;
using System.Collections.Generic;

namespace sep3.orders.Model;

public class Order
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int CustomerId { get; set; }
    public double Price { get; set; }

    public Order()
    {
        
    }

    public Order(int id, DateTime createdAt, int customerId, double price)
    {
        this.Id = id;
        this.CreatedAt = createdAt;
        this.CustomerId = customerId;
        this.Price = price;
    }
}