using Microsoft.AspNetCore.Mvc;
using sep3.broker.Model;
using sep3.brokers.broker;
using sep3.DTO.Product;
using sep3.DTO.Product.Create;

namespace sep3.brokers.controllers;

[ApiController]
[Route("[controller]")]
public class ProductVariantController : ControllerBase
{
    private readonly IProductVariantBroker _productVariantBroker;

    public ProductVariantController(IProductVariantBroker productVariantBroker)
    {
        _productVariantBroker = productVariantBroker;
    }
    
    [HttpGet("{variantId}")]
    public async Task<IActionResult> GetProductVariantAsync(
        [FromRoute] int variantId
        )
    {
        var result = await _productVariantBroker.GetProductVariantAsync(variantId);
        
        return result.IsSuccess ? Ok(result.Data) : StatusCode(result.StatusCode, result.Message);
    }
    
    /*[HttpPost]
    public async Task<IActionResult> CreateProductVariantAsync(
        [FromBody] ProductVariant variant,
         [FromQuery] ProductDTO productDTO
        )
    {
        var createDTO = new CreateProductVariantDTO
        {
            Size = variant.Size,
            Material = variant.Material,
            Stock = variant.InitialStock,
            Product = productDTO
        };
        var result = await _productVariantBroker.CreateProductVariantAsync(createDTO);

        return result.IsSuccess ? Ok(result.Data) : StatusCode(result.StatusCode, result.Message);
    }*/
    
    [HttpPost]
    public async Task<IActionResult> CreateProductVariantAsync([FromBody] CreateProductVariantDTO variant)
    {
        var result = await _productVariantBroker.CreateProductVariantAsync(variant);

        return result.IsSuccess ? Ok(result.Data) : StatusCode(result.StatusCode, result.Message);
    }
    
    [HttpPut("{variantId}")]
    public async Task<IActionResult> UpdateProductVariantAsync(
        [FromBody] ProductVariantDTO variant
        )
    {
        var result = await _productVariantBroker.UpdateProductVariantAsync(variant);
        
        return result.IsSuccess ? Ok(result.Data) : StatusCode(result.StatusCode, result.Message);
    }
}