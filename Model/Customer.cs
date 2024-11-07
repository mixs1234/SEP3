namespace Model;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Order> Orders { get; set; }

    public Customer()
    {
        
    }

    public Customer(int id, string name, string email, string phone, List<Order> orders)
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.Phone = phone;
        this.Orders = orders;
    }
}