using Microsoft.AspNetCore.Mvc;
using sep3.brokers.broker;

namespace sep3.brokers.controllers;


[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductBroker _productBroker;
    
    public ProductController(IProductBroker productBroker)
    {
        _productBroker = productBroker;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _productBroker.GetAllProductsAsync();
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return StatusCode(result.StatusCode, result.Message);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var result = await _productBroker.GetProductAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return StatusCode(result.StatusCode, result.Message);
    }
    
    
    
}