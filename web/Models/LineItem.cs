namespace web.Models;

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
}