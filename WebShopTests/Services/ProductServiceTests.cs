using FakeItEasy;
using WebShop.Models;
using WebShop.Services;
using WebShop.UnitOfWork;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Tests;

public class ProductServiceTests
{
    private readonly IUnitOfWork _unitOfWork = A.Fake<IUnitOfWork>();
    private readonly ProductService _productService;
    
    public ProductServiceTests()
    {
        _productService = new ProductService(_unitOfWork);
    }
    
    [Fact]
    public async Task GetAll_ReturnsProducts()
    {
        // Arrange
        var products = new List<ProductEntity>
        {
            new ProductEntity { Id = 1, Name = "Test1", Description = "Test1", Price = 10 },
            new ProductEntity { Id = 2, Name = "Test2", Description = "Test2", Price = 20 }
        };
        
        A.CallTo(() => _unitOfWork.Products.ListAllAsync()).Returns(products);
        
        // Act
        var result = await _productService.GetAll();
        
        // Assert
        Assert.Equal(2, result.Count());
    }
    
    [Fact]
    public async Task GetAll_ReturnsEmptyList()
    {
        // Arrange
        A.CallTo(() => _unitOfWork.Products.ListAllAsync())
            .Returns(Enumerable.Empty<ProductEntity>());
        // Act
        var result = await _productService.GetAll();
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public async Task GetById_ReturnsProduct()
    {
        // Arrange
        var product = new ProductEntity { Id = 1, Name = "Test", Description = "Test", Price = 10 };
        
        A.CallTo(() => _unitOfWork.Products.GetById(A<int>._)).Returns(product);
        
        // Act
        var result = await _productService.GetById(1);
        
        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetById_ReturnsNull()
    {
        // Arrange
        A.CallTo(() => _unitOfWork.Products.GetById(A<int>._)).Returns((ProductEntity)null);
        
        // Act
        var result = await _productService.GetById(1);
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public async Task Create_AddsProduct()
    {
        // Arrange
        var productDto = new ProductDto { Name = "Test", Description = "Test", Price = 10 };
        
        // Act
        await _productService.Create(productDto);
        
        // Assert
        A.CallTo(() => _unitOfWork.Products.AddAsync(A<ProductEntity>._)).MustHaveHappenedOnceExactly();
    }
    
    [Fact]
    public async Task Create_CallsNotifyProductAdded()
    {
        // Arrange
        var productDto = new ProductDto { Name = "Test", Description = "Test", Price = 10 };
        
        // Act
        await _productService.Create(productDto);
        
        // Assert
        A.CallTo(() => _unitOfWork.NotifyProductAdded(A<ProductEntity>._)).MustHaveHappenedOnceExactly();
    }
    
    [Fact]
    public async Task Create_CallsCommitAsync()
    {
        // Arrange
        var productDto = new ProductDto { Name = "Test", Description = "Test", Price = 10 };
        
        // Act
        await _productService.Create(productDto);
        
        // Assert
        A.CallTo(() => _unitOfWork.CommitAsync()).MustHaveHappenedOnceExactly();
    }
    
    [Fact]
    public async Task Update_UpdatesProduct()
    {
        // Arrange
        var productDto = new ProductDto { Name = "Test", Description = "Test", Price = 10 };
        
        // Act
        await _productService.Update(productDto);
        
        // Assert
        A.CallTo(() => _unitOfWork.Products.UpdateAsync(A<ProductEntity>._)).MustHaveHappenedOnceExactly();
    }
    
    [Fact]
    public async Task Update_CallsCommitAsync()
    {
        // Arrange
        var productDto = new ProductDto { Name = "Test", Description = "Test", Price = 10 };
        
        // Act
        await _productService.Update(productDto);
        
        // Assert
        A.CallTo(() => _unitOfWork.CommitAsync()).MustHaveHappenedOnceExactly();
    }
    
    [Fact]
    public async Task Delete_DeletesProduct()
    {
        // Arrange
        var id = 1;
        
        // Act
        await _productService.Delete(id);
        
        // Assert
        A.CallTo(() => _unitOfWork.Products.DeleteAsync(id)).MustHaveHappenedOnceExactly();
    }
    
    
    
    
}