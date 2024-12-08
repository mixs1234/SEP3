
using Microsoft.AspNetCore.Mvc;
using sep3.brokers.broker;

namespace sep3.brokers.controllers;

[ApiController]
[Route("[controller]")]
public class ArchiveStatusController : ControllerBase
{
    private readonly IArchiveStatusBroker _archiveStatusBroker;
    
    public ArchiveStatusController(IArchiveStatusBroker archiveStatusBroker)
    {
        _archiveStatusBroker = archiveStatusBroker;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllArchiveStatus()
    {
        var result = await _archiveStatusBroker.GetAllArchiveStatusAsync();
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return StatusCode(result.StatusCode, result.Message);
    }
}