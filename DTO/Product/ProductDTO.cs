namespace sep3.DTO.Product;

public class ProductDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImagePath { get; set; }
    public BrandDTO Brand { get; set; }
    public List<ProductVariantDTO> ProductVariants { get; set; }
}