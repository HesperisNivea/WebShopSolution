using Microsoft.AspNetCore.Mvc;
using Moq;
using WebShop;
using WebShop.Controllers;
using WebShop.Repositories;
using WebShopSolution.DataAccess;
using WebShopSolution.DataAccess.Entities;


public class ProductControllerTests
{
    private readonly Mock<IProductRepository<ProductEntity>> _mockProductRepository;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mockProductRepository = new Mock<IProductRepository<ProductEntity>>();

        // St�ll in mock av Products-egenskapen
    }

    [Fact]
    public void GetProducts_ReturnsOkResult_WithAListOfProducts()
    {
        // Arrange

        // Act

        // Assert
    }

    [Fact]
    public void AddProduct_ReturnsOkResult()
    {
        // Arrange

        // Act

        // Assert
    }
}
