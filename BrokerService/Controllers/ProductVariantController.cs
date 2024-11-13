using brokers.broker;
using Microsoft.AspNetCore.Mvc;

namespace brokers.controllers;

[ApiController]
[Route("[controller]")]
public class ProductVariantController: ControllerBase
{
    
    private readonly IProductVariantBroker _productVariantBroker;
    
    public ProductVariantController(IProductVariantBroker productVariantBroker)
    {
        _productVariantBroker = productVariantBroker;
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductVariant(int id)
    {
        var result = await _productVariantBroker.GetProductVariantAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else
        {
            return StatusCode(result.StatusCode, result.Message ?? "Failed to retrieve product variant.");
        }
    }
    
    /* Not implemented yet on java side
    [HttpGet]
    public async Task<IActionResult> GetProductVariants()
    {
        var result = await _productVariantBroker.GetAllProductVariantsAsync();
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else
        {
            return StatusCode(result.StatusCode, result.Message ?? "Failed to retrieve product variants.");
        }
    }
    */
    
}