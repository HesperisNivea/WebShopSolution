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

        // Constructor with UnitOfWork injected
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        // Endpoint f�r att h�mta alla produkter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetAll();
            // Beh�ver anv�nda repository via Unit of Work f�r att h�mta produkter
            return Ok(products);
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
            if(product is null)
            {
                return BadRequest();
            }

            await _productService.Create(product);
            return Ok();
            // L�gger till produkten via repository
           
            // Sparar f�r�ndringar

            // Notifierar observat�rer om att en ny produkt har lagts till
            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto? product)
        {
            if (product is null)
            {
                return BadRequest();
            }

            var result = await _productService.GetById(product.Id);

            if (result is null)
            {
                return NotFound();
            }

            await _productService.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetById(id);

            if (product is null)
            {
                return BadRequest();
            }

            await _productService.Delete(id);

            return Ok(product);

        }
        
        
    }
}
