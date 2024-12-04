using System.Collections.Generic;
using System.Threading.Tasks;
using web.Model;

namespace web.Services;

public interface ICartItemService
{
    Task AddToCartASync(ProductVariant productVariant, Product product, int quantity);
    Task RemoveFromCartASync(CartItem cartItem);
    Task<List<CartItem>> GetCartASync();
}