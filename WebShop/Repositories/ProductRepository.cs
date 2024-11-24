using WebShopSolution.DataAccess.Entities;

namespace WebShop.Repositories;

public interface IProductRepository<T> : IRepository<T> where T : class
{
    Task<List<ProductEntity>> GetFeaturedProducts(int take); 
}

public class ProductRepository(WebShopDbContext context) : Repository<ProductEntity>(context), IProductRepository<ProductEntity>
{
    public Task<List<ProductEntity>> GetFeaturedProducts(int take)
    {
        throw new NotImplementedException();
    }
}