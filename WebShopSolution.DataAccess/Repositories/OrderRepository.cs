using WebShopSolution.DataAccess.Entities;

namespace WebShopSolution.DataAccess;

public interface IOrderRepository : IRepository<OrderEntity>
{
    
}

public class OrderRepository(WebShopDbContext context) : Repository<OrderEntity>(context), IRepository<OrderEntity>
{

}