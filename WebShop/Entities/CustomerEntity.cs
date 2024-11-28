using System.ComponentModel.DataAnnotations;

namespace WebShopSolution.DataAccess.Entities;

public class CustomerEntity
{
    [Required]
    public int  Id { get; set; }
    public string Name { get; set; }
    
    [EmailAddress,Required]
    public string CustomerEmail { get; set; } = string.Empty;
    [Phone]
    public string CustomerPhone { get; set; } = string.Empty;
    public virtual ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}