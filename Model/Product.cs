namespace sep3.Model;

public class Product
{
    
    public double Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public string Category { get; set; }
    public int Id { get; set; }
    public Brand Brand { get; set; }

    
    public Product()
    {
    }
    
    public Product(double price, string name, string description, string imagePath, string category, int id, Brand brand, string color, string size, string material, double discount)
    {
        this.Price = price;
        this.Name = name;
        this.Description = description;
        this.ImagePath = imagePath;
        this.Category = category;
        this.Id = id;
        this.Brand = brand;
    }
}