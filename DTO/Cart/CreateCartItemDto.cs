namespace DTO.Cart;

public class CreateCartItemDto
{
    public string ProductName { get; set; }
    public long ProductId { get; set; }
    public long VariantId { get; set; }
    
    public string Materials { get; set; }
    public string Size { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    
}