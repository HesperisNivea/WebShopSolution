using System.ComponentModel.DataAnnotations;
using WebShopSolution.DataAccess.Entities.Enums;

namespace WebShopSolution.DataAccess.Entities;

public class PaymentMethodEntity
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    [Required]
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Unknown;
    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    
}