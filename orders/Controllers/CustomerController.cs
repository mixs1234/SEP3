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
public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }
    
    [HttpGet]
    [Route("Customers")]
    public async Task<IActionResult> GetCustomers()
    {
        try
        {
            List<Customer> customers = await _customerRepository.GetCustomersAsync();
            return Content(JsonConvert.SerializeObject(customers, Formatting.None,
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
    [Route("Customers/{id:int}")]
    public async Task<IActionResult> GetCustomer(int? id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("Customers")]
    public async Task<IActionResult> CreateCustomer(string name, string email, string phone)
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    [Route("Customers")]
    public async Task<IActionResult> UpdateCustomer(int? id, string name, string email, string phone)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("Customers/{id:int}")]
    public async Task<IActionResult> DeleteCustomer(int? id)
    {
        throw new NotImplementedException();
    }
}