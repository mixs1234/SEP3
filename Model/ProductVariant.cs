namespace sep3.Model;

using System.Text.Json.Serialization;

public class ProductVariant
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("size")]
    public string Size { get; set; }

    [JsonPropertyName("material")]
    public string Material { get; set; }

    [JsonPropertyName("stock")]
    public int Stock { get; set; }
    
}