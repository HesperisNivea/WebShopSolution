using WebShopSolution.DataAccess.Entities;

namespace WebShop.Repositories;

public interface IProductRepository<T> : IRepository<T> where T : class
{
  
}

public class ProductRepository(WebShopDbContext context) : Repository<ProductEntity>(context), IProductRepository<ProductEntity>
{
  
}