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
public class PaymentController : Controller
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentController(IPaymentRepository paymentRepository)
    {
        this._paymentRepository = paymentRepository;
    }
    
    [HttpGet]
    [Route("Payments")]
    public async Task<IActionResult> GetPayments()
    {
        try
        {
            List<Payment> payments = await _paymentRepository.GetPaymentsAsync();
            return Content(JsonConvert.SerializeObject(payments, Formatting.None,
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
    [Route("Payments/{id:int}")]
    public async Task<IActionResult> GetPayment(int? id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("Payments")]
    public async Task<IActionResult> CreatePayment(int? orderId, string paymentMethod, DateTimeOffset? timestamp, string paymentIdentifier, string paymentConfirmation, double? amount)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route("Payments")]
    public async Task<IActionResult> UpdatePayment(int? id, int? orderId, string paymentMethod, DateTimeOffset? timestamp, string paymentIdentifier, string paymentConfirmation, double? amount)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("Payments/{id:int}")]
    public async Task<IActionResult> DeletePayment(int? id)
    {
        throw new NotImplementedException();
    }
}