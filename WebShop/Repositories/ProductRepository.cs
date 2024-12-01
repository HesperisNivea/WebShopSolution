using Microsoft.EntityFrameworkCore;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Repositories;

public interface IProductRepository<T> : IRepository<T> where T : class
{
  Task<ProductEntity?> GetById(int id);
  
}

public class ProductRepository(IWebShopDbContext context) : Repository<ProductEntity>(context), IProductRepository<ProductEntity>
{
  public async Task<ProductEntity?> GetById(int id)
  {
    var product = await context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

    if (product is null)
    {
      return null;
    }
    
    return product;
  }
}