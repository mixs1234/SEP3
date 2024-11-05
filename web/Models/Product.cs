namespace sep3.web.Models;

public class Product
{
    public string Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public string Category { get; set; }
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    public string Material { get; set; }
    public double Discount { get; set; }
    
    public Product()
    {
        
    }
    
    public Product(string price, string name, string description, string imagePath, string category, int id, string brand, string color, string size, string material, double discount)
    {
        this.Price = price;
        this.Name = name;
        this.Description = description;
        this.ImagePath = imagePath;
        this.Category = category;
        this.Id = id;
        this.Brand = brand;
        this.Color = color;
        this.Size = size;
        this.Material = material;
        this.Discount = discount;
    }
    
}