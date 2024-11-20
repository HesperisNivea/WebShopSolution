using System.ComponentModel.DataAnnotations;

namespace WebShopSolution.DataAccess.Entities;
 // Produktmodellen representerar en produkt i webbshoppen
public class ProductEntity
{
    [Required]
    public int Id { get; set; } // Unikt ID f�r produkten
    [Required]
    public string Name { get; set; } = string.Empty; // Namn p� produkten
    
    public string Description { get; set; } = string.Empty; // Beskrivning av produkten
    public ICollection<OrderDetailEntity> OrderDetails { get; set; } = new List<OrderDetailEntity>(); // Ordrar som inneh�ller produkten

}