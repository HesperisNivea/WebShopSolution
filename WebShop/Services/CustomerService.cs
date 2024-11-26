using WebShop.Models;
using WebShop.UnitOfWork;
using WebShopSolution.DataAccess;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Services;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAll();
    Task<CustomerDto> GetById(int id);
    Task<CustomerDto> GetByEmail(string email);
    Task<CustomerDto> Create(CustomerDto customerDto);
    Task Update(CustomerDto customerDto);
    Task Delete(int id);
}

public class CustomerService(IUnitOfWork unitOfWork) : ICustomerService
{
    
    public async Task<IEnumerable<CustomerDto>> GetAll()
    {
        using (unitOfWork)
        {
           
            var customers = await unitOfWork.Customers.ListAllAsync();
            await unitOfWork.CommitAsync();
            if (customers is not null)
            {
                var result = customers.Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CustomerEmail = c.CustomerEmail,
                    CustomerPhone = c.CustomerPhone,
                    Orders = c.Orders.Select(o => new OrderDto
                    {
                        Id = o.Id,
                        OrderDate = o.OrderDate
                        
                    }).ToList()
                  
                });
                return result;
            }
           
        }
        
        return Enumerable.Empty<CustomerDto>();
        
    }

    public Task<CustomerDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDto> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDto> Create(CustomerDto customerDto)
    {
        throw new NotImplementedException();
    }

    public Task Update(CustomerDto customerDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}
