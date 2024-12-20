﻿namespace DTO.Cart;

public class CartItemDto
{
    public int CartItemId { get; set; }
    public long VariantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Size { get; set; }
    public int Quantity { get; set; }
}