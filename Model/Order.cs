namespace sep3.Model;

public class Order
{
    
    
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }

    public Order()
    {
        
    }

    public Order(int id, int CustomerId, int ProductId)
    {
        this.Id = id;
        this.CustomerId = CustomerId;
        this.ProductId = ProductId;
    }
}
