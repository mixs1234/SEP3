using Microsoft.EntityFrameworkCore;
using sep3.DTO.Order;
using sep3.orders.Infrastructure;
using sep3.orders.Model;
using sep3.orders.Services;
using rabbitmq.Messaging.Pub;
using DTO.Cart;
using Microsoft.Extensions.Configuration;
using Moq;

namespace OrderTest
{
    public class OrderRepositoryTests
    {
        private OrderDbContext _context;
        private Mock<OrderPublisher> _mockPublisher;
        private OrderRepository _orderRepository;

        [SetUp]
        public void Setup()
        {
            var mockConfiguration = new Mock<IConfiguration>();
            
            var options = new DbContextOptionsBuilder<OrderDbContext>()
                .UseInMemoryDatabase(databaseName: "OrderTestDb")
                .EnableSensitiveDataLogging()
                .Options;


            _context = new OrderDbContext(options, mockConfiguration.Object);
            _mockPublisher = new Mock<OrderPublisher>();
            
            _context.Status.Add(new Status { Id = 1, StatusName = "Pending" });
            _context.Status.Add(new Status { Id = 2, StatusName = "Confirmed" });
            _context.SaveChanges();

            _orderRepository = new OrderRepository(_context, _mockPublisher.Object);
        }

        [Test]
        public async Task CreateOrderAsync_ShouldCreateOrder()
        {
            // Arrange
            var createOrderDto = new CreateOrderDTO
            {
                CustomerId = 1,
                CartItems = [new CreateCartItemDto
                {
                    VariantId = 1, 
                    Quantity = 2,
                    Materials = "Cotton",
                    Size = "M",
                    Price = 10.0,
                    ProductId = 1,
                    ProductName = "T-Shirt"
                }]
            };

            // Act
            var result = await _orderRepository.CreateOrderAsync(createOrderDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.CustomerId, Is.EqualTo(createOrderDto.CustomerId));
            _mockPublisher.Verify(p => p.PublishOrder(It.IsAny<CreateOrderConfirmationDTO>()), Times.Once);
        }
        
        [Test]
        public async Task CreateOrderAsync_ShouldThrowException_WhenInitialStatusNotFound()
        {
            // Arrange
            _context.Status.RemoveRange(_context.Status);
            _context.SaveChanges();
            
            var createOrderDto = new CreateOrderDTO
            {
                CustomerId = 1,
                CartItems = [new CreateCartItemDto
                {
                    VariantId = 1, 
                    Quantity = 2,
                    Materials = "Cotton",
                    Size = "M",
                    Price = 10.0,
                    ProductId = 1,
                    ProductName = "T-Shirt"
                }]
            };

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _orderRepository.CreateOrderAsync(createOrderDto));
        }
        
        [Test]
        public async Task UpdateOrderStatusAsync_ShouldUpdateOrderStatus()
        {
            // Arrange
            var order = new Order
            {
                CustomerId = 1,
                StatusId = 1,
                ShoppingCart = new ShoppingCart
                {
                    CartItems = new List<CartItem>
                    {
                        new CartItem
                        {
                            ProductId = 1,
                            ProductName = "T-Shirt",
                            VariantId = 1,
                            Materials = "Cotton",
                            Size = "M",
                            Quantity = 2,
                            Price = 10.0
                        }
                    }
                }
            };
            
            _context.Orders.Add(order);
            _context.SaveChanges();
            
            // Act
            var result = await _orderRepository.UpdateOrderStatusASync(order.Id, 2);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusId, Is.EqualTo(2));
        }
        
        [Test]
        public async Task UpdateOrderStatusAsync_ShouldThrowException_WhenOrderNotFound()
        {
            // Arrange
            var order = new Order
            {
                CustomerId = 1,
                StatusId = 1,
                ShoppingCart = new ShoppingCart
                {
                    CartItems = new List<CartItem>
                    {
                        new CartItem
                        {
                            ProductId = 1,
                            ProductName = "T-Shirt",
                            VariantId = 1,
                            Materials = "Cotton",
                            Size = "M",
                            Quantity = 2,
                            Price = 10.0
                        }
                    }
                }
            };
            
            _context.Orders.Add(order);
            _context.SaveChanges();
            
            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _orderRepository.UpdateOrderStatusASync(2, 2));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}