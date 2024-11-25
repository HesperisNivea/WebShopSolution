using WebShop.Models;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Notifications
{
    // Gränssnitt för notifieringsobservatörer enligt Observer Pattern
    public interface INotificationObserver
    {
        Task Update(ProductEntity product); // Metod som kallas när en ny produkt läggs till
    }
}
