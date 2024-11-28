using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebShop;
using WebShop.Controllers;
using WebShop.Models;
using WebShop.Repositories;
using WebShop.Services;
using WebShopSolution.DataAccess;
using WebShopSolution.DataAccess.Entities;


public class ProductControllerTests
{
    private readonly IProductService _productService = A.Fake<IProductService>();
    
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _controller = new ProductController(_productService);
    }

    [Fact]
public async Task GetProducts_ReturnsOkResult_WithAListOfProducts()
{
    // Arrange
    var products = new List<ProductDto> { new ProductDto(), new ProductDto() };
    A.CallTo(() => _productService.GetAll()).Returns(products);

    // Act
    var result = await _controller.GetProducts();

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result.Result);
    var returnProducts = Assert.IsType<List<ProductDto>>(okResult.Value);
    Assert.Equal(2, returnProducts.Count);
}

    [Fact]
    public async Task GetProductById_ReturnsOkResult_WithProduct()
    {
        // Arrange
        var product = new ProductDto { Id = 1, Name = "Test Product" };
        A.CallTo(() => _productService.GetById(1)).Returns(product);

        // Act
        var result = await _controller.GetProductById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnProduct = Assert.IsType<ProductDto>(okResult.Value);
        Assert.Equal(1, returnProduct.Id);
        Assert.Equal("Test Product", returnProduct.Name);
    }

    [Fact]
    public async Task GetProductById_ReturnsNotFound_WhenProductIsNull()
    {
        // Arrange
        A.CallTo(() => _productService.GetById(1)).Returns((ProductDto)null);

        // Act
        var result = await _controller.GetProductById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
    
    [Fact]
    public async Task AddProduct_ReturnsOkResult()
    {
        // Arrange
        var product = new ProductDto { Id = 1, Name = "Test Product" };

        // Act
        var result = await _controller.AddProduct(product);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task AddProduct_ReturnsBadRequest_WhenProductIsNull()
    {
        // Act
        var result = await _controller.AddProduct(null);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }
    
    [Fact]
    public async Task UpdateProduct_ReturnsOkResult()
    {
        // Arrange
        var product = new ProductDto { Id = 1, Name = "Updated Product" };
        A.CallTo(() => _productService.GetById(1)).Returns(product);

        // Act
        var result = await _controller.UpdateProduct(product);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task UpdateProduct_ReturnsNotFound_WhenProductIsNull()
    {
        // Arrange
        var product = new ProductDto { Id = 1, Name = "Updated Product" };
        A.CallTo(() => _productService.GetById(1)).Returns((ProductDto)null);

        // Act
        var result = await _controller.UpdateProduct(product);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateProduct_ReturnsBadRequest_WhenProductIsNull()
    {
        // Act
        var result = await _controller.UpdateProduct(null);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }
    
    [Fact]
    public async Task Delete_ReturnsOkResult()
    {
        // Arrange
        var product = new ProductDto { Id = 1, Name = "Test Product" };
        A.CallTo(() => _productService.GetById(1)).Returns(product);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnProduct = Assert.IsType<ProductDto>(okResult.Value);
        Assert.Equal(1, returnProduct.Id);
    }

    [Fact]
    public async Task Delete_ReturnsBadRequest_WhenProductIsNull()
    {
        // Arrange
        A.CallTo(() => _productService.GetById(A<int>.Ignored)).Returns((ProductDto)null);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }
}
