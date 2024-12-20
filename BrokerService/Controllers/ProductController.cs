﻿using Microsoft.AspNetCore.Mvc;
using sep3.brokers.broker;
using sep3.DTO.Product;
using sep3.DTO.Product.Create;

namespace sep3.brokers.controllers;


[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductBroker _productBroker;
    private readonly IProductVariantBroker _productVariantBroker;
    
    public ProductController(IProductBroker productBroker, IProductVariantBroker productVariantBroker)
    {
        _productBroker = productBroker;
        _productVariantBroker = productVariantBroker;
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
    
    [HttpGet("{id}/variants")]
    public async Task<IActionResult> GetProductVariants(int id)
    {
        var result = await _productBroker.GetProductVariantsAsync(id);
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
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductDTO dto)
    {
        var createProductDTO = new CreateProductDTO
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            ImagePath = dto.ImagePath,
            Brand = new BrandDTO()
            {
                Id = dto.Brand.Id,
                Name = dto.Brand.Name
            }
        };
        
        Console.WriteLine(createProductDTO);
        
        var result = await _productBroker.CreateProductAsync(createProductDTO);
        
        Console.WriteLine($"Product creation result: {result.Data}");
        
        if (!result.IsSuccess) return StatusCode(result.StatusCode, result.Message);
        
        foreach (var createProductVariantDto in dto.ProductVariants.Select(productVariant => new CreateProductVariantDTO
                 {
                     Size = productVariant.Size,
                     Material = productVariant.Material,
                     Stock = productVariant.Stock,
                     ProductId = (int)result.Data.Id
                 }))
        {
            var productVariantResult = await _productVariantBroker.CreateProductVariantAsync(createProductVariantDto);
            if (!productVariantResult.IsSuccess)
            {
                return StatusCode(productVariantResult.StatusCode, productVariantResult.Message);
            }
        }

        return StatusCode(result.StatusCode, result.Message);
    }
    
}