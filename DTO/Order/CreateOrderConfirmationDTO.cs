namespace sep3.DTO.Order;

public class CreateOrderConfirmationDTO
{
    public int OrderId { get; set; }
    public Dictionary<long, int> ProductVariantIdToQuantity { get; set; }
}