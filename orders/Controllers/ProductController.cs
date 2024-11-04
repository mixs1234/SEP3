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

[Route("[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductRepository _orderRepository;

    public ProductController(IProductRepository orderRepository)
    {
        this._orderRepository = orderRepository;
    }
    
    [HttpGet]
    [Route("Products")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            List<Product> products = await _orderRepository.GetProductsAsync();
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
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("Products")]
    public async Task<IActionResult> CreateProduct(string name, double? price)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route("Products")]
    public async Task<IActionResult> UpdateProduct(int? id, string name, double? price)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("Products/{id:int}")]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        throw new NotImplementedException();
    }
}