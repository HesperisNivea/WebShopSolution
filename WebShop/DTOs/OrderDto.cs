using WebShopSolution.DataAccess.Entities.Enums;

namespace WebShop.Models;

public class OrderDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; } 
    public DateTime OrderDate { get; set; } 
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Unknown;
    public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}