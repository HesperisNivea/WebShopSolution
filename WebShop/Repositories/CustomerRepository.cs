using WebShopSolution.DataAccess.Entities;

namespace WebShop.Repositories;

public interface ICustomerRepository<T> : IRepository<T> where T : class
{
    Task<CustomerEntity> GetByEmail(string email);
}
public class CustomerRepository(WebShopDbContext context) :  Repository<CustomerEntity>(context), ICustomerRepository<CustomerEntity>
{
    public Task<CustomerEntity> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }
}