namespace sep3.DTO.Order;

public class CreateOrderDTO
{
    public required int ProductVariantId { get; set; }
    public required int Quantity { get; set; }
    
}