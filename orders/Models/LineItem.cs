namespace sep3.orders.Model;

public class LineItem
{
    public int Id { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public LineItem()
    {
        
    }

    public LineItem(int id, Order order, Product product, int quantity, double? price)
    {
        this.Id = id;
        this.Order = order;
        this.Product = product;
        this.Quantity = quantity;
        if (price.HasValue)
            this.Price = price.Value;
        else
            this.Price = product.Price;
    }

    /*
    public static LineItem FromDTO(sep3.Model.LineItem lineItem)
    {
        LineItem lineItemDTO = new LineItem()
        {
            Id = lineItem.Id,
            OrderId = lineItem.OrderId,
            ProductId = lineItem.ProductId,
            Quantity = lineItem.Quantity,
            Price = lineItem.Price
        };
        return lineItemDTO;
    }

    public sep3.Model.LineItem ToDTO()
    {
        sep3.Model.LineItem lineItemDTO = new sep3.Model.LineItem()
        {
            Id = this.Id,
            OrderId = this.OrderId,
            ProductId = this.ProductId,
            Quantity = this.Quantity,
            Price = this.Price
        };
        return lineItemDTO;
    }
    */
}