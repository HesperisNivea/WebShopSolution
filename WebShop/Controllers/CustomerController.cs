using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Services;

namespace WebShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService)
{
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    // {
    //     var customers = await customerService.GetAll();
    //     return Ok(customers);
    // }
}