using System.ComponentModel.DataAnnotations;

namespace WebShopSolution.DataAccess.Entities;

public class OrderDetailEntity
{
    // [Required]
    // public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;
    [Required]
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }
    
}