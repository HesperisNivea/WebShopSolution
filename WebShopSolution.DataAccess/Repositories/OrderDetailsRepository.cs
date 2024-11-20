using WebShopSolution.DataAccess.Entities;

namespace WebShopSolution.DataAccess;
public interface IOrderDetailsRepository : IRepository<OrderDetailEntity>
{
    Task<IEnumerable<OrderDetailEntity>> GetByOrderId(int orderId);
    
    Task<IEnumerable<OrderDetailEntity>> GetByProductId(int productId);
}
public class OrderDetailsRepository(WebShopDbContext context) : Repository<OrderDetailEntity>(context), IOrderDetailsRepository
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