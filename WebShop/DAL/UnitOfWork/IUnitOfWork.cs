
using WebShop.Models;
using WebShop.Notifications;
using WebShop.Repositories;
using WebShopSolution.DataAccess;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.UnitOfWork
{
    // Gränssnitt för Unit of Work
    public interface IUnitOfWork : IDisposable
    {
         // Repository för produkter
            IProductRepository<ProductEntity> Products { get; }
            IOrderDetailsRepository<OrderDetailEntity> OrderDetails { get; }
            IOrderRepository<OrderEntity> Orders { get; }
            IPaymentMethodRepository<PaymentMethodEntity> Payments { get; }
            ICustomerRepository<CustomerEntity> Customers { get; }

            // Sparar förändringar (om du använder en databas)
         Task<int> SaveChangesAsync();
         Task BeginTransactionAsync();
         Task CommitTransactionAsync();
         Task RollbackTransactionAsync();
        Task NotifyProductAdded(ProductEntity product); // Notifierar observatörer om ny produkt
        
        
    }
}

