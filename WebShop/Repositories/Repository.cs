﻿using Microsoft.EntityFrameworkCore;

namespace WebShop.Repositories;

public interface IRepository<T> where T : class
{
    //Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>?> ListAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

public class Repository<T>(WebShopDbContext context) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>?> ListAllAsync()
    {
        return await context.Set<T>().ToListAsync() ?? null;
    }

    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
       context.Update(entity);
       return Task.CompletedTask;

    }

    public Task DeleteAsync(int id)
    {
        context.Remove(id);
        return Task.CompletedTask;
    }
}