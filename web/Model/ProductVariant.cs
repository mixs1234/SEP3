namespace web.Model;

public class ProductVariant
{
    public int Id { get; set; }
    
    public string Size { get; set; }
    
    public string Material { get; set; }
    
    public int Stock { get; set; }

    public long ArchiveStatusId { get; set; }
}