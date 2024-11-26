

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
        private readonly IWebShopDbContext _context;
        public IProductRepository<ProductEntity> Products { get; private set; }
        public IOrderDetailsRepository<OrderDetailEntity> OrderDetails { get; private set; }
        public IOrderRepository<OrderEntity> Orders { get; private set; }
        public ICustomerRepository<CustomerEntity> Customers { get; }

        private readonly ProductSubject _productSubject;
        
        public UnitOfWork(IWebShopDbContext context,
        ICustomerRepository<CustomerEntity> customers,
        IProductRepository<ProductEntity> products,
        IOrderDetailsRepository<OrderDetailEntity> orderDetails,
        IOrderRepository<OrderEntity> orders,
        string email =null,
        ProductSubject productSubject = null)
            {
                _context = context;
                Customers = customers;
                Products = products;
                OrderDetails = orderDetails;
                Orders = orders;
                
                _productSubject = productSubject;
                
                // Om inget ProductSubject injiceras, skapa ett nytt
                _productSubject = productSubject ?? new ProductSubject();

                // Registrera standardobservatörer
                _productSubject.Attach(new EmailNotification("example@email.com"));
                _productSubject.Attach(new SmsNotification("042838298"));
            }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void NotifyProductAdded(ProductEntity product)
        {
             _productSubject.Notify(product);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
        
    }
}
