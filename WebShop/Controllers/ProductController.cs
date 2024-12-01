using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Services;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProductController : ControllerBase
    {
        
        private readonly IProductService _productService;

        // Constructor with IProductService injected
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        // Endpoint f�r att h�mta alla produkter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await _productService.GetAll();
                if (products == null || !products.Any())
                {
                    return NotFound("No products found.");
                }
    
                return Ok(products);
            }
            catch (Exception ex)    
            {
                // Log the exception 
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
            
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Endpoint f�r att l�gga till en ny produkt
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]ProductDto? product)
        {
            //model state
            if(product is null)
            {
                return BadRequest();
            }

            await _productService.Create(product);
            return Ok();
            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto? product)
        {
            if (product is null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _productService.GetById(product.Id);
                if (result is null)
                {
                    return NotFound();
                }
                await _productService.Update(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
            
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                 var result = await _productService.GetById(id);
                 if (result is null)
                 {
                     return NotFound();
                 }
                 await _productService.Delete(id);
                 return Ok(true);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
            
        }
        
        
    }
}
