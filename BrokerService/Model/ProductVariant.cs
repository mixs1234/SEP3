namespace sep3.broker.Model;

public class ProductVariant
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public string Size { get; set; }
    public string Material { get; set; }
    public int InitialStock { get; set; }
}