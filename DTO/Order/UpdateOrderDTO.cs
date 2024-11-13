namespace DTO.Order
{
    public class UpdateOrderDTO
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public int? CustomerId { get; set; }
        public string LineItemsString { get; set; }
        public int? PaymentId { get; set; }
    }
}