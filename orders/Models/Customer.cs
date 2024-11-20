using sep3.Model;

namespace sep3.orders.Model;

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

    public static Customer FromDTO(sep3.Model.Customer customerDTO)
    {
        Customer customer = new Customer()
        {
            Id = customerDTO.Id,
            Name = customerDTO.Name,
            Email = customerDTO.Email,
            Phone = customerDTO.Phone
        };
        return customer;
    }

    public sep3.Model.Customer ToDTO()
    {
        sep3.Model.Customer customerDTO = new sep3.Model.Customer()
        {
            Id = this.Id,
            Name = this.Name,
            Email = this.Email,
            Phone = this.Phone
        };
        return customerDTO;
    }
}