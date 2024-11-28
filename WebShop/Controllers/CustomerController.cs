
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Services;


namespace WebShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await _customerService.GetAll();
        return Ok(customers);
            
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
        var customer = await _customerService.GetById(id);
        if (customer is null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
    
    [HttpGet("{email}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerByEmail(string email)
    {
        var customer = await _customerService.GetByEmail(email);
        if (customer is null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer([FromBody]CustomerDto? customer)
    {
        if (customer is null)
        {
            return BadRequest();
        }

        await _customerService.Create(customer);
        return Ok();
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateCustomer([FromBody]CustomerDto? customer)
    {
        if (customer is null)
        {
            return BadRequest();
        }

        await _customerService.Update(customer);
        return Ok();
    }
    
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        await _customerService.Delete(id);
        return Ok();
    }
}