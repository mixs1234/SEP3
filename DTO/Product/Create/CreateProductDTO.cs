namespace sep3.DTO.Product.Create;

public class CreateProductDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImagePath { get; set; }
    public BrandDTO BrandDTO { get; set; }
}