namespace sep3.DTO.Product;

public class BrandDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}