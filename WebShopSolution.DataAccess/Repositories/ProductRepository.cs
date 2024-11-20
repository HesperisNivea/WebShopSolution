using WebShopSolution.DataAccess.Entities;

namespace WebShopSolution.DataAccess;

public interface IProductRepository : IRepository<ProductEntity>
{
    //Task<List<Product>> GetFeaturedProducts(int take);
}

public class ProductRepository(WebShopDbContext context) : Repository<ProductEntity>(context), IProductRepository
{
    
}