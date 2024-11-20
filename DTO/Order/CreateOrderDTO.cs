namespace sep3.DTO.Order;

public class CreateOrderDTO
{
    public required int CustomerId { get; set; }
    public required int ProductVariantId { get; set; }
}