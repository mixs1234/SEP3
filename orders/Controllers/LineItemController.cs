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
public class LineItemController : Controller
{
    private readonly ILineItemRepository _lineItemRepository;

    public LineItemController(ILineItemRepository lineItemRepository)
    {
        this._lineItemRepository = lineItemRepository;
    }
    
    [HttpGet]
    [Route("LineItems")]
    public async Task<IActionResult> GetLineItems()
    {
        try
        {
            List<LineItem> lineItems = await _lineItemRepository.GetLineItemsAsync();
            return Content(JsonConvert.SerializeObject(lineItems, Formatting.None,
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
    [Route("LineItems/{id:int}")]
    public async Task<IActionResult> GetLineItem(int? id)
    {
        try
        {
            LineItem lineItem = await _lineItemRepository.GetLineItemAsync(id);
            return Content(JsonConvert.SerializeObject(lineItem, Formatting.None,
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
    [Route("LineItems")]
    public async Task<IActionResult> CreateLineItem(int? orderId, int? productId, int? quantity, double? price)
    {
        try
        {
            LineItem lineItem = await _lineItemRepository.CreateLineItemAsync(orderId, productId, quantity, price);
            return Content(JsonConvert.SerializeObject(lineItem, Formatting.None,
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
    [Route("LineItems")]
    public async Task<IActionResult> UpdateLineItem(int? id, int? orderId, int? productId, int? quantity, double? price)
    {
        try
        {
            await _lineItemRepository.UpdateLineItemAsync(id, orderId, productId, quantity, price);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("LineItems/{id:int}")]
    public async Task<IActionResult> DeleteLineItem(int? id)
    {
        try
        {
            await _lineItemRepository.DeleteLineItemAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(410, ex.Message);
        }
    }
}