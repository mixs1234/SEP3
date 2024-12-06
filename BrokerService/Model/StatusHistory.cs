using sep3.broker.Model;

namespace sep3.orders.Model;

public class StatusHistory
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int StatusId { get; set; }
    public DateTime ChangedAt { get; set; }
    
    public Order Order { get; set; }
    public Status Status { get; set; }
}