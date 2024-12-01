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

    public async Task<CustomerDto?> GetById(int id)
    {
       var customer = await unitOfWork.Customers.GetById(id);
         if (customer is not null)
         {
              return new CustomerDto
              {
                Id = customer.Id,
                Name = customer.Name,
                CustomerEmail = customer.CustomerEmail,
                CustomerPhone = customer.CustomerPhone,
              };
         }
         
         return null;
    }

    public async Task<CustomerDto> GetByEmail(string email)
    {
        var customer = await unitOfWork.Customers.GetByEmail(email);
        if (customer is not null)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                CustomerEmail = customer.CustomerEmail,
                CustomerPhone = customer.CustomerPhone,
            };
        }

        return null;
    }

    public async Task<CustomerDto> Create(CustomerDto customerDto)
    {
        await unitOfWork.Customers.AddAsync(new CustomerEntity
        {
            Name = customerDto.Name,
            CustomerEmail = customerDto.CustomerEmail,
            CustomerPhone = customerDto.CustomerPhone,
        });
        await unitOfWork.CommitAsync();
        return customerDto;
    }
            
    public async Task Update(CustomerDto customerDto)
    {
        var customer = new CustomerEntity
        {
            Id = customerDto.Id,
            Name = customerDto.Name,
            CustomerEmail = customerDto.CustomerEmail,
            CustomerPhone = customerDto.CustomerPhone,
        };
        await unitOfWork.Customers.UpdateAsync(customer);
        await unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var customer = await unitOfWork.Customers.GetById(id);
        if (customer is not null)
        {
            await unitOfWork.Customers.DeleteAsync(id);
            await unitOfWork.CommitAsync();
        }
        
    }
        
}
