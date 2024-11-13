using Model;

namespace DTO.Product;

public class ProductDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public BrandDTO Brand { get; set; }
    public List<ProductVariant> ProductVariantDtos { get; set; }
    
    public ProductDTO()
    {
    }
    
    public ProductDTO(long id, string name, string description, BrandDTO brand, List<ProductVariant> productVariantDtos)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Brand = brand;
        this.ProductVariantDtos = productVariantDtos;
    }
    
}