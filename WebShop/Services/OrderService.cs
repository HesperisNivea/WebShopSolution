using WebShop.Models;
using WebShop.Repositories;
using WebShop.UnitOfWork;
using WebShopSolution.DataAccess;

namespace WebShop.Services;

interface IOrderService
{
    Task<OrderDto?> GetOrderByIdAsync(int id);
    Task<OrderDto?> CreateOrderAsync(OrderDto order);
    Task<OrderDto?> UpdateOrderAsync(OrderDto order);
    Task<OrderDto?> DeleteOrderAsync(int id);
}

public class OrderService(IUnitOfWork unitOfWork, IOrderRepository<OrderDto> orderRepository) : IOrderService
{
    public Task<OrderDto?> GetOrderByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto?> CreateOrderAsync(OrderDto order)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto?> UpdateOrderAsync(OrderDto order)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto?> DeleteOrderAsync(int id)
    {
        throw new NotImplementedException();
    }
}