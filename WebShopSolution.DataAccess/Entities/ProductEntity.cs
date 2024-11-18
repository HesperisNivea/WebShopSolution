namespace WebShopSolution.DataAccess.Entities;
 // Produktmodellen representerar en produkt i webbshoppen
public class ProductEntity
{
    public int Id { get; set; } // Unikt ID f�r produkten
    
    public string Name { get; set; } = string.Empty; // Namn p� produkten
    
}