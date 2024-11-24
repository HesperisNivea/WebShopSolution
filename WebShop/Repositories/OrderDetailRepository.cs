using WebShopSolution.DataAccess.Entities;

namespace WebShop.Repositories;
public interface IOrderDetailsRepository<T> : IRepository<T> where T : class
{
    Task<IEnumerable<OrderDetailEntity>> GetByOrderId(int orderId);
    
    Task<IEnumerable<OrderDetailEntity>> GetByProductId(int productId);
}
public class OrderDetailRepository(WebShopDbContext context) : Repository<OrderDetailEntity>(context), IOrderDetailsRepository<OrderDetailEntity>
{
    public Task<IEnumerable<OrderDetailEntity>> GetByOrderId(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderDetailEntity>> GetByProductId(int productId)
    {
        throw new NotImplementedException();
    }
}