using System.ComponentModel.DataAnnotations;

namespace WebShop.Models;

public class ProductDto
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(250)]
    public string Description { get; set; }
    public decimal Price { get; set; }
}