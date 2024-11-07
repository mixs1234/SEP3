namespace DTO.Order;

public class CreateOrderDTO
{
    public required int CustomerId { get; set; }
    public required List<int> LineItemsId { get; set; }
    public required int PaymentId { get; set; }
}