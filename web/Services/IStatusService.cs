using System.Collections.Generic;
using System.Threading.Tasks;
using web.Model.Order;

namespace web.Services;

public interface IStatusService
{
    Task<List<CurrentStatus>?> GetStatusesAsync();
}