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
        try
        {
            Customer customer = await _customerRepository.GetCustomerAsync(id);
            return Content(JsonConvert.SerializeObject(customer, Formatting.None,
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
    [Route("Customers")]
    public async Task<IActionResult> CreateCustomer(string name, string email, string phone)
    {
        try
        {
            Customer customer = await _customerRepository.CreateCustomerAsync(name, email, phone);
            return Content(JsonConvert.SerializeObject(customer, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPatch]
    [Route("Customers")]
    public async Task<IActionResult> UpdateCustomer(int? id, string name, string email, string phone)
    {
        try
        {
            await _customerRepository.UpdateCustomerAsync(id, name, email, phone);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("Customers/{id:int}")]
    public async Task<IActionResult> DeleteCustomer(int? id)
    {
        try
        {
            await _customerRepository.DeleteCustomerAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(410, ex.Message);
        }
    }
}