using System.Collections.Generic;
using System.Threading.Tasks;
using web.Model;

namespace web.Services;

public interface IShoppingCartService
{
    Task AddToCartASync(ProductVariant productVariant, Product product, int quantity);
    Task RemoveFromCartASync(ShoppingCartItem shoppingCartItem);
    Task<List<ShoppingCartItem>> GetCartASync();
}