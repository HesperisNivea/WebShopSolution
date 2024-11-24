using WebShopSolution.DataAccess.Entities;

namespace WebShop.Repositories;

public interface IOrderRepository<T> : IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
}

public class OrderRepository(WebShopDbContext context) : Repository<OrderEntity>(context), IOrderRepository<OrderEntity>
{
    public Task<OrderEntity?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}