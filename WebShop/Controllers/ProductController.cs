using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.UnitOfWork;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProductController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;

        // Constructor with UnitOfWork injected
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        // Endpoint f�r att h�mta alla produkter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            // Beh�ver anv�nda repository via Unit of Work f�r att h�mta produkter
            var products = await _unitOfWork.Products.ListAllAsync();
            return Ok();
        }

        // Endpoint f�r att l�gga till en ny produkt
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]ProductEntity? product)
        {

            if (product is null)
            {
                return BadRequest("Product is null");
            }
            
            using (_unitOfWork)

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.NotifyProductAdded(product);
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransactionAsync();
                Console.WriteLine("Error: " + e.Message);
                throw;
            }
            finally
            {
                _unitOfWork.NotifyProductAdded(product);
            }
            
            // L�gger till produkten via repository
           
            // Sparar f�r�ndringar

            // Notifierar observat�rer om att en ny produkt har lagts till

            return Ok();
        }
    }
}
