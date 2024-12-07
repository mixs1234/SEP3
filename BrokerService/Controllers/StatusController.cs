using brokers.broker;
using Microsoft.AspNetCore.Mvc;

namespace sep3.brokers.controllers;

[ApiController]

public class StatusController : Controller
{
    
    private readonly IStatusBroker _statusBroker;
    
    public StatusController(IStatusBroker statusBroker)
    {
        _statusBroker = statusBroker;
    }
    
    [HttpGet]
    [Route("Status")]
    public async Task<IActionResult> GetStatusesAsync()
    {
        var statuses = await _statusBroker.GetStatusesAsync();
        return Ok(statuses.Data);
    }
    
}