using System.ComponentModel.DataAnnotations;

namespace WebShopSolution.DataAccess.Entities;

public class OrderEntity
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public int PaymentMethodId { get; set; }
    [Required]
    public PaymentMethodEntity PaymentMethod { get; set; } = null!;
    
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public CustomerEntity Customer { get; set; } = null!;
    
    public ICollection<OrderDetailEntity> OrderDetails { get; set; } = new List<OrderDetailEntity>();
    
}