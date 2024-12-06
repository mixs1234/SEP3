namespace DTO.Cart;

public class CreateCartItemDto
{
    public long VariantId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}