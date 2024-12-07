using Microsoft.AspNetCore.Mvc;
using sep3.orders.Services;

namespace sep3.orders.Controllers;

[ApiController]
public class StatusController : Controller
{
    private readonly IStatusRepository _statusRepository;
    
    public StatusController(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }
    
    [HttpGet]
    [Route("api/statuses")]
    public async Task<IActionResult> GetStatusesAsync()
    {
        var statuses = await _statusRepository.GetStatusesAsync();
        return Ok(statuses);
    }
}