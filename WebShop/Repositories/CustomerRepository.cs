using Microsoft.EntityFrameworkCore;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Repositories;

public interface ICustomerRepository<T> : IRepository<T> where T : class
{
    Task<CustomerEntity?> GetByEmail(string email);
    
    Task<CustomerEntity?> GetById(int id);
}
public class CustomerRepository(WebShopDbContext context) :  Repository<CustomerEntity>(context), ICustomerRepository<CustomerEntity>
{
    public async Task<CustomerEntity?> GetByEmail(string email)
    {
        return await context.Customers.FirstOrDefaultAsync(c => c.CustomerEmail == email);
        
    }

    public async Task<CustomerEntity?> GetById(int id)
    {
        return await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        
    }
}