using WebShop.Models;
using WebShop.Repositories;
using WebShop.UnitOfWork;
using WebShopSolution.DataAccess;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto> GetById(int id);
    Task<ProductDto> Create(ProductDto customerDto);
    Task Update(ProductDto customerDto);
    Task Delete(int id);
}
public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    public async Task<IEnumerable<ProductDto>>? GetAll()
    {
        
        using (unitOfWork)
        { 
            await unitOfWork.BeginTransactionAsync();
            var result = await unitOfWork.Products.ListAllAsync();
            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();

            if (result != null)
            {
                return result.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                });
                
            }
        }
        
        return Enumerable.Empty<ProductDto>();
    }

    public Task<ProductDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDto> Create(ProductDto customerDto)
    {
        using (unitOfWork)
        {
            await unitOfWork.BeginTransactionAsync();
            var product = new ProductEntity
            {
                Name = customerDto.Name,
                Description = customerDto.Description,
                Price = customerDto.Price
            };
            await unitOfWork.Products.AddAsync(product);
            await unitOfWork.SaveChangesAsync();
            await unitOfWork.NotifyProductAdded(product);
            await unitOfWork.CommitTransactionAsync();
        }
        
        return customerDto;
    }

    public async Task Update(ProductDto customerDto)
    {
        using (unitOfWork)
        {
            await unitOfWork.BeginTransactionAsync();
            var product = new ProductEntity
            {
                Name = customerDto.Name,
                Description = customerDto.Description,
                Price = customerDto.Price
            };
        }
    }

    public async Task Delete(int id)
    {
        using (unitOfWork)
        {
            await unitOfWork.BeginTransactionAsync();
            await unitOfWork.Products.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();
        }
    }
}