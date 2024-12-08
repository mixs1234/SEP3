using System;

namespace web.Model;

public class CartItem
{
    public long VariantId { get; set; }
    public long ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    
    public string Materials { get; set; }
    public string Size { get; set; }
    public int Quantity { get; set; }
}