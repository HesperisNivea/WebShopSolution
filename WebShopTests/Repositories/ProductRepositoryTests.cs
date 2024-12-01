using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using WebShop.Repositories;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Tests.Repositories;

public class ProductRepositoryTests
{
    private readonly IWebShopDbContext _context = A.Fake<IWebShopDbContext>();
    private readonly IProductRepository<ProductEntity> _productRepository;
    
    public ProductRepositoryTests()
    {
        _productRepository = new ProductRepository(_context);
    }
    [Fact]
    public async Task GetById_ReturnsProduct_WhenProductExists()
    {
        
    }
    
    [Fact]
    public async Task GetById_ReturnsNull_WhenProductDoesNotExist()
    {
        
    }
    
    // [Fact]
    // public async Task ListAllAsync_ReturnsProducts_WhenProductsExist()
    // {
    //     // Arrange
    //     var products = new List<ProductEntity>
    //     {
    //         new ProductEntity { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10 },
    //         new ProductEntity { Id = 2, Name = "Product 2", Description = "Description 2", Price = 20 },
    //         new ProductEntity { Id = 3, Name = "Product 3", Description = "Description 3", Price = 30 }
    //     };
    //     
    //     A.CallTo(() => _context.Set<ProductEntity>().AsNoTracking().ToListAsync(default)).Returns(products);
    //     
    //     // Act
    //     var result = await _productRepository.ListAllAsync();
    //     
    //     // Assert
    //     Assert.Equal(3, result.Count());
    //     
    // }
        
}