using sep3.orders.Model;
using sep3.orders.Services;
using sep3.orders.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sep3.orders.Controllers;

[ApiController]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    
    [HttpGet]
    [Route("Products")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            List<Product> products = await _productRepository.GetProductsAsync();
            return Content(JsonConvert.SerializeObject(products, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    [Route("Products/{id:int}")]
    public async Task<IActionResult> GetProduct(int? id)
    {
        try
        {
            Product product = await _productRepository.GetProductAsync(id);
            return Content(JsonConvert.SerializeObject(product, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("Products")]
    public async Task<IActionResult> CreateProduct(string name, double? price)
    {
        try
        {
            Product product = await _productRepository.CreateProductAsync(null, name, price);
            return Content(JsonConvert.SerializeObject(product, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("Products")]
    public async Task<IActionResult> UpdateProduct(int? id, string name, double? price)
    {
        try
        {
            await _productRepository.UpdateProductAsync(id, name, price);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("Products/{id:int}")]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        try
        {
            await _productRepository.DeleteProductAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(410, ex.Message);
        }
    }
}