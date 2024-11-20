namespace DTO.Order;

public class CreateOrderDTO
{
    public required int CustomerId { get; set; }
    public required int ProductId { get; set; }
}