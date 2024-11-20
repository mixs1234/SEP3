namespace sep3.DTO.Product;

public class ProductDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public BrandDTO Brand { get; set; }
    public List<ProductVariantDTO> ProductVariantDTOs { get; set; }
}