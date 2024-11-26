using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using WebShop.Models;
using WebShop.Notifications;
using WebShop.Repositories;
using WebShopSolution.DataAccess.Entities;
using Times = Moq.Times;


namespace WebShop.Tests
{
    public class UnitOfWorkTests
    {
        
        private readonly ICustomerRepository<CustomerEntity> _customers = A.Fake<ICustomerRepository<CustomerEntity>>();
        private readonly IProductRepository<ProductEntity> _products = A.Fake<IProductRepository<ProductEntity>>();
        private readonly IOrderDetailsRepository<OrderDetailEntity> _orderDetails = A.Fake<IOrderDetailsRepository<OrderDetailEntity>>();
        private readonly IOrderRepository<OrderEntity> _orders = A.Fake<IOrderRepository<OrderEntity>>();
        private readonly ProductSubject _productSubject = A.Fake<ProductSubject>();
        private readonly IWebShopDbContext _mockContext = A.Fake<IWebShopDbContext>();
        
        private readonly UnitOfWork.UnitOfWork _unitOfWork;
        
        public UnitOfWorkTests()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork(
                _mockContext,
                _customers,
                _products,
                _orderDetails,
                _orders,
                "Test@123.com",
                _productSubject
            );
        }

            
        [Fact]
        public void NotifyProductAdded_CallsObserverUpdate()
        {
            // Arrange
            var product = new ProductEntity { Id = 1, Name = "Test" };

            var mockObserver = A.Fake<INotificationObserver>();
            _productSubject.Attach(mockObserver);

            // Act
            _unitOfWork.NotifyProductAdded(product);

            // Assert
            A.CallTo(() => mockObserver.Update(product)).MustHaveHappenedOnceExactly();
        }
        
        
        [Fact]
        public async Task SaveChangesAsync_CallsDbContextSaveChangesAsync()
        {
            // Arrange
            A.CallTo(() => _mockContext.SaveChangesAsync(default)).Returns(1);

            // Act
            await _unitOfWork.CommitAsync();

            // Assert
            A.CallTo(() => _mockContext.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void Dispose_CallsDbContextDispose()
        {
            // Act
            _unitOfWork.Dispose();

            // Assert
            A.CallTo(() => _mockContext.Dispose()).MustHaveHappenedOnceExactly();
        }
       
    }
}
