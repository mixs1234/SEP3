using sep3.orders.Model;

namespace sep3.orders.Services;

public interface IStatusRepository
{
    Task<List<Status>?> GetStatusesAsync();
}