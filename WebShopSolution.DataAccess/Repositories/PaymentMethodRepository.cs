﻿using WebShopSolution.DataAccess.Entities;

namespace WebShopSolution.DataAccess;

interface IPaymentMethodRepository<T> : IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
}

public class PaymentMethodRepository(WebShopDbContext context) : Repository<PaymentMethodEntity>(context), IPaymentMethodRepository<PaymentMethodEntity>
{
    public Task<PaymentMethodEntity?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}