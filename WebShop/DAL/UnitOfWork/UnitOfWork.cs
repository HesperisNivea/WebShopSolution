

using Microsoft.EntityFrameworkCore.Storage;
using WebShop.Models;
using WebShop.Notifications;
using WebShop.Repositories;
using WebShopSolution.DataAccess;
using WebShopSolution.DataAccess.Entities;


namespace WebShop.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        // Hämta produkter från repository
        private bool _disposed = false;
        private readonly WebShopDbContext _context;
        private IDbContextTransaction _transaction;
        public IProductRepository<ProductEntity> Products { get; private set; }
        public IOrderDetailsRepository<OrderDetailEntity> OrderDetails { get; private set; }
        public IOrderRepository<OrderEntity> Orders { get; private set; }
        public IPaymentMethodRepository<PaymentMethodEntity> Payments { get; private set; }
        public ICustomerRepository<CustomerEntity> Customers { get; }

        private readonly ProductSubject _productSubject;
        
        public UnitOfWork(WebShopDbContext context, ICustomerRepository<CustomerEntity> customers, string email = null, ProductSubject productSubject = null)
            {
                _context = context;
                Customers = customers;
                Products = new ProductRepository(context);
                OrderDetails = new OrderDetailRepository(context);
                Orders = new OrderRepository(context);
                Payments = new PaymentMethodRepository(context);
                _productSubject = productSubject;
                
                // Om inget ProductSubject injiceras, skapa ett nytt
                _productSubject = productSubject ?? new ProductSubject();

                // Registrera standardobservatörer
                _productSubject.Attach(new EmailNotification("dhjdsjdk"));
            }

        
        public void NotifyProductAdded(ProductEntity product)
        {
            _productSubject.Notify(product);
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync() 
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await _transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null!;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._disposed = true;
            }
        }

    
    }
}
