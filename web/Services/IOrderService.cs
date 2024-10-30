using System.Collections.Generic;
using System.Threading.Tasks;
using sep3.web.Models;

namespace web.Services;

public interface IOrderService
{
    Task<List<Order>?> GetOrdersAsync();
    
}