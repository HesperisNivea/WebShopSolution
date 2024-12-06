using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using WebShop.Controllers;
using WebShop.Models;
using WebShop.Services;

namespace WebShop.Tests.Controllers;

public class CustomerControllerTests
{
    private readonly ICustomerService _customerService = A.Fake<ICustomerService>();
    
    private readonly CustomerController _controller;
    
    public CustomerControllerTests()
    {
        _controller = new CustomerController(_customerService);
    }
    
    [Fact]
    public async Task GetCustomers_ReturnsOkResult_WithAListOfCustomers()
    {
        // Arrange
        var customers = new List<CustomerDto> { new CustomerDto(), new CustomerDto() };
        A.CallTo(() => _customerService.GetAll()).Returns(customers);
        
        // Act
        var result = await _controller.GetCustomers();
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnCustomers = Assert.IsType<List<CustomerDto>>(okResult.Value);
        Assert.Equal(2, returnCustomers.Count);
    }
    
    [Fact]
    public async Task GetCustomers_ReturnsNotFound_WhenCustomersIsNull()
    {
        // Arrange
        A.CallTo(() => _customerService.GetAll()).Returns((IEnumerable<CustomerDto>)null);
        
        // Act
        var result = await _controller.GetCustomers();
        
        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
        Assert.Equal("No customers found.", notFoundResult.Value);
    }
    
    [Fact]
    public async Task GetCustomerById_ReturnsOkResult_WithCustomer()
    {
        // Arrange
        var customer = new CustomerDto { Id = 1, Name = "Test Customer" };
        A.CallTo(() => _customerService.GetById(1)).Returns(customer);
        
        // Act
        var result = await _controller.GetCustomerById(1);
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnCustomer = Assert.IsType<CustomerDto>(okResult.Value);
        Assert.Equal(1, returnCustomer.Id);
        Assert.Equal("Test Customer", returnCustomer.Name);
    }

    [Fact]
    public async Task GetCustomerById_ReturnsNotFound_WhenCustomerIsNull()
    {
        // Arrange
        A.CallTo(() => _customerService.GetById(1)).Returns((CustomerDto)null);
        // Act
        var result = await _controller.GetCustomerById(1);
        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetCustomerByEmail_ReturnsOkResult_WithCustomer()
    {
        // Arrange
        var customer = new CustomerDto { Id = 1, Name = "Test Customer", CustomerEmail = "sdka@sld.fe" };
        A.CallTo(() => _customerService.GetByEmail("")).Returns(customer);
        // Act
        var result = await _controller.GetCustomerByEmail("");
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnCustomer = Assert.IsType<CustomerDto>(okResult.Value);
        Assert.Equal(1, returnCustomer.Id);
        Assert.Equal("Test Customer", returnCustomer.Name);
    }
    
    [Fact]
    public async Task GetCustomerByEmail_ReturnsNotFound_WhenCustomerIsNull()
    {
        // Arrange
        A.CallTo(() => _customerService.GetByEmail("")).Returns((CustomerDto)null);
        // Act
        var result = await _controller.GetCustomerByEmail("");
        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
    
    [Fact]
    public async Task GetCustomerByEmail_ReturnsInternalServerError_WhenExceptionIsThrown()
    {
        // Arrange
        A.CallTo(() => _customerService.GetByEmail("")).Throws<Exception>();
        // Act
        var result = await _controller.GetCustomerByEmail("");
        // Assert
        Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(500, (result.Result as ObjectResult).StatusCode);
    }
    
    [Fact]
    public async Task AddCustomer_ReturnsOkResult()
    {
        // Arrange
        var customer = new CustomerDto { Id = 1, Name = "Test Customer" };
        // Act
        var result = await _controller.AddCustomer(customer);
        // Assert
        Assert.IsType<OkResult>(result);
    }
    
    [Fact]
    public async Task AddCustomer_ReturnsBadRequest_WhenCustomerIsNull()
    {
        // Act
        var result = await _controller.AddCustomer(null);
        // Assert
        Assert.IsType<BadRequestResult>(result);
    }
    [Fact]
    public async Task AddCustomer_ReturnsInternalServerError_WhenExceptionIsThrown()
    {
        // Arrange
        A.CallTo(() => _customerService.Create(null)).Throws<Exception>();
        // Act
        var result = await _controller.AddCustomer(null);
        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, (result as ObjectResult).StatusCode);
    }
    
    [Fact]
    public async Task UpdateCustomer_ReturnsOkResult()
    {
        // Arrange
        var customer = new CustomerDto { Id = 1, Name = "Updated Customer" };
        A.CallTo(() => _customerService.GetById(1)).Returns(customer);
        // Act
        var result = await _controller.UpdateCustomer(customer);
        // Assert
        Assert.IsType<OkResult>(result);
    }
    
    
}