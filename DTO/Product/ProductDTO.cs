namespace DTO.Product;

public class ProductDTO
{
    public long id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public BrandDTO brand { get; set; }
    public List<ProductVariantDTO> _productVariantDtos { get; set; }
    
}