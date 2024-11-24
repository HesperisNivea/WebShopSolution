using Microsoft.EntityFrameworkCore;

namespace WebShop.Repositories;

public interface IRepository<T> where T : class
{
    //Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>?> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}

public class Repository<T>(WebShopDbContext context) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>?> ListAllAsync()
    {
        return await context.Set<T>().ToListAsync() ?? null;
    }

    public Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }
}