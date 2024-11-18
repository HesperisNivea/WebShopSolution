namespace WebShopSolution.DataAccess;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}

public class Repository<T> : IRepository<T> where T : class
{
    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> ListAllAsync()
    {
        throw new NotImplementedException();
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