using Microsoft.AspNetCore.Http.HttpResults;
using WebShop.Models;
using WebShop.Repositories;
using WebShop.UnitOfWork;
using WebShopSolution.DataAccess;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto?> GetById(int id);
    Task<ProductDto> Create(ProductDto product);
    Task Update(ProductDto customerDto);
    Task Delete(int id);
}
public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        
            var result = await unitOfWork.Products.ListAllAsync();
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

        return Enumerable.Empty<ProductDto>();
    }

    public async Task<ProductDto?> GetById(int id)
    {
            var product = await unitOfWork.Products.GetById(id);
            if (product is not null)
            {
                return new ProductDto()
                {
                    Id = product.Id,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price
                };
            }
        
        return null;
    }

    public async Task<ProductDto> Create(ProductDto customerDto)
    {
            var product = new ProductEntity
            {
                Name = customerDto.Name,
                Description = customerDto.Description,
                Price = customerDto.Price
            };
            await unitOfWork.Products.AddAsync(product);
            unitOfWork.NotifyProductAdded(product);
            await unitOfWork.CommitAsync();
            
        return customerDto;
    }

    public async Task Update(ProductDto product)
    {
            var result = new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
            await unitOfWork.Products.UpdateAsync(result);
            await unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
            await unitOfWork.Products.DeleteAsync(id);
            await unitOfWork.CommitAsync();
    }
}