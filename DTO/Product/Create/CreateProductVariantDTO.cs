namespace sep3.DTO.Product.Create;

public class CreateProductVariantDTO
{
    public string Size { get; set; }
    public string Material { get; set; }
    public int Stock { get; set; }
    public ProductDTO Product { get; set; }
}