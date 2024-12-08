namespace sep3.DTO.Product;

public class ProductVariantDTO
{
    public long Id { get; set; }
    public string Size { get; set; }
    public string Material { get; set; }
    public int Stock { get; set; }
    
    public long ArchiveStatusId { get; set; }

}