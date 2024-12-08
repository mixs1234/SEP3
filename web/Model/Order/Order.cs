using System;
using System.Collections.Generic;

namespace web.Model.Order;

public class Order
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public int ShoppingCartId { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public CurrentStatus CurrentStatus { get; set; }
    public List<StatusHistory> StatusHistories { get; set; }
}

public class Customer
{
    public int Id { get; set; }
}

public class ShoppingCart
{
    public int Id { get; set; }
    public List<CartItem> CartItems { get; set; }
}

public class CartItem
{
    public int Id { get; set; }
    public int VariantId { get; set; }
    public int ProductId { get; set; }
    
    public string ProductName { get; set; }
    public string Materials { get; set; }
    public string Size { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int ShoppingCartId { get; set; }
}

public class CurrentStatus
{
    public int Id { get; set; }
    public string StatusName { get; set; }
}

public class StatusHistory
{
    public int Id { get; set; }
    public DateTime ChangedAt { get; set; }
    public int StatusId { get; set; }
}
