using sep3.orders.Services;
using sep3.DTO.Order;

namespace sep3.orders.Model;

public class Order
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public List<LineItem> LineItems { get; set; }
    public Payment Payment { get; set; }

    private static IProductRepository _productRepository;
    private static readonly Random random = new Random();
    private static readonly double randomLower = 0.01;
    private static readonly double randomUpper = 99.99;
    
    public Order()
    {
        
    }

    public Order(int id, DateTimeOffset createdAt, Customer customer, List<LineItem> lineItems, Payment payment)
    {
        this.Id = id;
        this.CreatedAt = createdAt;
        this.Customer = customer;
        this.LineItems = lineItems;
        this.Payment = payment;
    }

    public static void SetRepo(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public static Order FromDTO(CreateOrderDTO orderDTO)
    {
        Order order = new Order()
        {
            CreatedAt = DateTimeOffset.UtcNow,
            CustomerId = orderDTO.CustomerId,
            LineItems = new List<LineItem>()
            {
                new()
                {
                    ProductId = orderDTO.ProductVariantId,
                    Quantity = 1,
                    Price = Math.Round(randomLower + (random.NextDouble() * (randomUpper - randomLower)), 2) // https://stackoverflow.com/a/20785539
                }
            }
        };
        /*foreach (int productId in orderDTO.LineItemsId)
        {
            LineItem lineItem = new LineItem()
            {
                ProductId = productId,
                Quantity = 1,
                Order = order
            };
            if (_productRepository != null)
                lineItem.Price = _productRepository.GetProductAsync(productId).Result.Price * lineItem.Quantity;
            else
                lineItem.Price = Math.Round(randomLower + (random.NextDouble() * (randomUpper - randomLower)), 2); // https://stackoverflow.com/a/20785539
            order.LineItems.Add(lineItem);
        }*/
        
        order.Payment = new Payment()
        {
            Order = order,
            PaymentIdentifier = "1",
            PaymentMethod = "Test Payment",
            Amount = order.LineItems.Sum(li => li.Price),
            Timestamp = DateTimeOffset.UtcNow,
            PaymentConfirmation = $"{"Test Payment"}.{1}"
        };
        return order;
    }

    public CreateOrderDTO ToDTO()
    {
        CreateOrderDTO orderDTO = new CreateOrderDTO
        {
            CustomerId = this.CustomerId,
            ProductVariantId = LineItems.First().ProductId
        };
        return orderDTO;
    }
    
    public CreateOrderConfirmationDTO ToConfirmationDTO()
    {
        CreateOrderConfirmationDTO orderDTO = new CreateOrderConfirmationDTO
        {
            OrderId = this.Id,
            CustomerId = this.CustomerId,
            ProductVariantId = LineItems.First().ProductId
        };
        return orderDTO;
    }

}