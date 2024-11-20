using System.ComponentModel.DataAnnotations;

namespace WebShopSolution.DataAccess.Entities;

public class OrderEntity
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string CustomerName { get; set; } = string.Empty;
    
    //public string CustomerAddress { get; set; } = string.Empty;
    [EmailAddress,Required]
    public string CustomerEmail { get; set; } = string.Empty;
    [Phone]
    public string CustomerPhone { get; set; } = string.Empty;
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public int PaymentMethodId { get; set; }
    [Required]
    public PaymentMethodEntity PaymentMethod { get; set; } = null!;
    
    //public string PaymentStatus { get; set; } = string.Empty; // enum?
    
    //public string Status { get; set; } = string.Empty; // enum?
    
    public ICollection<OrderDetailEntity> OrderDetails { get; set; } = new List<OrderDetailEntity>();
    
}