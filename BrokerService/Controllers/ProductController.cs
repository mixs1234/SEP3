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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var result = await _productBroker.GetProductAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else
        {
            return StatusCode(result.StatusCode, result.Message ?? "Failed to retrieve product.");
        }
    }
    
    [HttpGet("{id}/variants")]
    public async Task<IActionResult> GetProductVariants(int id)
    {
        var result = await _productBroker.GetProductVariantsAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else
        {
            return StatusCode(result.StatusCode, result.Message ?? "Failed to retrieve product variants.");
        }
    }

    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _productBroker.GetAllProductsAsync();
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else
        {
            return StatusCode(result.StatusCode, result.Message ?? "Failed to retrieve products.");
        }
    }
}