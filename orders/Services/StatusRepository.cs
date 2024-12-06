using Microsoft.EntityFrameworkCore;
using sep3.orders.Infrastructure;
using sep3.orders.Model;

namespace sep3.orders.Services;

public class StatusRepository : IStatusRepository
{
    private readonly OrderDbContext _context;

    public StatusRepository(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<List<Status>?> GetStatusesAsync()
    {
        return await _context.Status.ToListAsync();
    }
}