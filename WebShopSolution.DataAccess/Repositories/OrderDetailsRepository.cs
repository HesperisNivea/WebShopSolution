using WebShopSolution.DataAccess.Entities;

namespace WebShopSolution.DataAccess;
public interface IOrderDetailsRepository : IRepository<OrderDetailEntity>
{
    
}
public class OrderDetailsRepository(WebShopDbContext context) : Repository<OrderDetailEntity>(context), IOrderDetailsRepository
{
    
}