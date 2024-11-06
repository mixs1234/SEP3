using System;
using System.Collections.Generic;

namespace sep3.orders.Model;

public class Order
{
    
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int CustomerId { get; set; }

    public Order()
    {
        
    }

   
}