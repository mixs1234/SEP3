using brokers.broker;
using DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace brokers.controllers;


[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductBroker _productBroker;
    
    public ProductController(IProductBroker productBroker)
    {
        _productBroker = productBroker;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDto)
    {
        var result = await _productBroker.CreateProductAsync(productDto);
        if (result.IsSuccess)
        {
            return Ok(new { ProductId = result.Data, result.Message });
        }
        else
        {
            return StatusCode(result.StatusCode, result.Message ?? "Failed to create product.");
        }
    }
}