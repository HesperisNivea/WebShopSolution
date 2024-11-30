
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
        try
        {
            var customers = await _customerService.GetAll();
            if (customers == null || !customers.Any())
            {
                return NotFound("No customers found.");
            }

            return Ok(customers);
        }
        catch (Exception ex)    
        {
            // Log the exception 
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
            
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
        try
        {
            var customer = await _customerService.GetById(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
       
    }
    
    [HttpGet("{email}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerByEmail(string email)
    {
        try
        {
            var customer = await _customerService.GetByEmail(email);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
        
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer([FromBody]CustomerDto? customer)
    {
        try
        {
            await _customerService.Create(customer);
            if (customer is null)
            {
                return BadRequest();
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
    
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateCustomer([FromBody]CustomerDto? customer)
    {
        try
        {
            if (customer is null)
            {
                return BadRequest();
            }

            await _customerService.Update(customer);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
    }
    
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        try
        {
            var customer = await _customerService.GetById(id);
            if (customer is null)
            {
                return NotFound();
            }
            await _customerService.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
       
    }
}