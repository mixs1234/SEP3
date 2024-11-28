using Microsoft.AspNetCore.Mvc;
using sep3.brokers.broker;

namespace sep3.brokers.controllers;

[ApiController]
[Route("product/{id}/[controller]")]
public class ProductVariantController : ControllerBase
{
    private readonly IProductVariantBroker _productVariantBroker;

    public ProductVariantController(IProductVariantBroker productVariantBroker)
    {
        _productVariantBroker = productVariantBroker;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductVariantsAsync(
        [FromRoute] int id
        )
    {
        return Ok();
    }
}