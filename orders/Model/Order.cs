using sep3.DTO.Order;

namespace sep3.orders.Model;

public class Order
{
    public int Id { get; set; }
    public int ProductVariantId { get; set; }
    
    public static CreateOrderDTO ToCreateOrderDto(Order order)
    {
        return new CreateOrderDTO
        {
            ProductVariantId = order.ProductVariantId
        };
    }
    
    public static Order FromCreateOrderDto(CreateOrderDTO createOrderDto)
    {
        return new Order
        {
            ProductVariantId = createOrderDto.ProductVariantId
        };
    }
    
    public static CreateOrderConfirmationDTO ToCreateOrderConfirmationDto(Order order)
    {
        return new CreateOrderConfirmationDTO
        {
            OrderId = order.Id,
            ProductVariantId = order.ProductVariantId
        };
    }
    
}