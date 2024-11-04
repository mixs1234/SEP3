using sep3.orders.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sep3.orders.Services;

public interface ILineItemRepository
{
    Task<LineItem> CreateLineItemAsync(LineItem lineItem);
    Task<LineItem> CreateLineItemAsync(int? orderId, int? productId, int? quantity, double? price);
    Task<List<LineItem>> GetLineItemsAsync();
    Task<LineItem> GetLineItemAsync(int? id);
    Task UpdateLineItemAsync(int? id, int? orderId, int? productId, int? quantity, double? price);
    Task DeleteLineItemAsync(int? id);
}