using WebShop.Models;
using WebShop.Repositories;
using WebShop.UnitOfWork;
using WebShopSolution.DataAccess;

namespace WebShop.Services;

public class ProductService(IUnitOfWork unitOfWork,IProductRepository<ProductDto> productRepository)
{
    
}