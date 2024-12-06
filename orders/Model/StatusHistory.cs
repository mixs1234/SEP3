using System.Text.Json.Serialization;

namespace sep3.orders.Model;

public class StatusHistory
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int StatusId { get; set; }
    public DateTime ChangedAt { get; set; }
    
    [JsonIgnore]
    public Order Order { get; set; }
    public Status Status { get; set; }
}