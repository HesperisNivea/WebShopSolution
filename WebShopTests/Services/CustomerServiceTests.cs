using FakeItEasy;
using WebShop.Services;
using WebShop.UnitOfWork;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Tests;

public class CustomerServiceTests
{
    private readonly IUnitOfWork _unitOfWork = A.Fake<IUnitOfWork>();
    private readonly CustomerService _customerService;
    
    public CustomerServiceTests()
    {
        _customerService = new CustomerService(_unitOfWork);
    }

    [Fact]
    public async Task GetAll_ReturnsCustomers()
    {
        //Arrange
        var customers = new List<CustomerEntity>
        {
            new CustomerEntity { Id = 1, Name = "Test1", CustomerEmail = "customer@1.com" },
            new CustomerEntity { Id = 1, Name = "Test1", CustomerEmail = "customer@1.com" },
        };
        
        //Act
        //Assert
    }
    
    [Fact]
    public async Task GetAll_ReturnsEmptyList()
    {
        //Arrange
        //Act
        //Assert
    }
    
    [Fact]
    public async Task GetById_ReturnsCustomer()
    {
        //Arrange
        //Act
        //Assert
    }
    
    [Fact]
    public async Task GetById_ReturnsNull()
    {
        //Arrange
        //Act
        //Assert
    }
    
    [Fact]
    public async Task GetByEmail_ReturnsCustomer()
    {
        //Arrange
        //Act
        //Assert
    }
    
    [Fact]
    public async Task GetByEmail_ReturnsNull()
    {
        //Arrange
        //Act
        //Assert
    }
    
    [Fact]
    public async Task Create_ReturnsCustomer()
    {
        //Arrange
        //Act
        //Assert
    }
    
    [Fact]
    public async Task Update_ReturnsCustomer()
    {
        //Arrange
        //Act
        //Assert
    }
    
    [Fact]
    public async Task Delete_ReturnsCustomer()
    {
        //Arrange
        //Act
        //Assert
    }
}