namespace sep3.Model;

public class Brand
{
    private long Id { get; set; }
    private string Name { get; set; }
    private List<Product> Products;

    public Brand()
    {
    }

    public Brand(List<Product> products, long id, string name)
    {
        Products = products;
        Id = id;
        Name = name;
    }
}