using web.Model;
using web.Services;
using Xunit;

public class CartItemItemServiceTests
{
    private readonly CartItemItemService _cartService;
    
    public CartItemItemServiceTests()
    {
        _cartService = new CartItemItemService();
    }

    [Fact]
    public async Task AddToCartAsync_AddsNewItem()
    {
        // Arrange
        var productVariant = new ProductVariant { Id = 1, Material = "Cotton", Size = "M" };
        var product = new Product { Id = 10, Name = "Shirt", Description = "A nice shirt", Price = 19.99 };

        // Act
        await _cartService.AddToCartASync(productVariant, product, 2);
        var cart = await _cartService.GetCartASync();

        // Assert
        Xunit.Assert.Single(cart);
        var item = cart.First();
        Xunit.Assert.Equal(productVariant.Id, item.VariantId);
        Xunit.Assert.Equal(product.Id, item.ProductId);
        Xunit.Assert.Equal("Shirt", item.Name);
        Xunit.Assert.Equal(2, item.Quantity);
    }

    [Fact]
    public async Task AddToCartAsync_SameVariantUpdatesQuantity()
    {
        // Arrange
        var productVariant = new ProductVariant { Id = 1, Material = "Cotton", Size = "M" };
        var product = new Product { Id = 10, Name = "Shirt", Description = "A nice shirt", Price = 19.99 };

        // Add the same item twice
        await _cartService.AddToCartASync(productVariant, product, 2);
        await _cartService.AddToCartASync(productVariant, product, 3);
        var cart = await _cartService.GetCartASync();

        // Assert
        Xunit.Assert.Single(cart);
        Xunit.Assert.Equal(5, cart[0].Quantity); // 2 + 3
    }

    [Fact]
    public async Task CartItemsUpdated_EventFiresOnAddToCart()
    {
        // Arrange
        int eventCount = -1;
        _cartService.SubscribeToChanges(count => eventCount = count);

        var productVariant = new ProductVariant { Id = 1, Material = "Cotton", Size = "M" };
        var product = new Product { Id = 10, Name = "Shirt", Description = "A nice shirt", Price = 19.99 };

        // Act
        await _cartService.AddToCartASync(productVariant, product, 1);

        // Assert
        Xunit.Assert.Equal(1, eventCount);
    }

    [Fact]
    public async Task RemoveFromCartAsync_RemovesItemAndFiresEvent()
    {
        // Arrange
        var productVariant = new ProductVariant { Id = 2, Material = "Wool", Size = "L" };
        var product = new Product { Id = 20, Name = "Sweater", Description = "A warm sweater", Price = 29.99 };

        await _cartService.AddToCartASync(productVariant, product, 1);
        var cart = await _cartService.GetCartASync();
        Xunit.Assert.Single(cart); // ensure item added

        int eventCount = -1;
        _cartService.SubscribeToChanges(count => eventCount = count);

        // Act
        await _cartService.RemoveFromCartASync(cart[0]);

        // Assert
        var updatedCart = await _cartService.GetCartASync();
        Xunit.Assert.Empty(updatedCart);
        Xunit.Assert.Equal(0, eventCount);
    }

    [Fact]
    public async Task ClearCartAsync_ClearsItemsAndFiresEvent()
    {
        // Arrange
        var productVariant1 = new ProductVariant { Id = 1, Material = "Cotton", Size = "M" };
        var product1 = new Product { Id = 10, Name = "Shirt", Description = "A nice shirt", Price = 19.99 };

        var productVariant2 = new ProductVariant { Id = 2, Material = "Wool", Size = "L" };
        var product2 = new Product { Id = 20, Name = "Sweater", Description = "A warm sweater", Price = 29.99 };

        await _cartService.AddToCartASync(productVariant1, product1, 1);
        await _cartService.AddToCartASync(productVariant2, product2, 1);

        int eventCount = -1;
        _cartService.SubscribeToChanges(count => eventCount = count);

        // Act
        await _cartService.ClearCartAsync();

        // Assert
        var cart = await _cartService.GetCartASync();
        Xunit.Assert.Empty(cart);
        Xunit.Assert.Equal(0, eventCount);
    }
    
}