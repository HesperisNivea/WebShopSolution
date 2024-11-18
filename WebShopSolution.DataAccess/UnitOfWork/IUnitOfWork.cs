
using WebShopSolution.DataAccess.Entities;

namespace WebShop.UnitOfWork
{
    // Gränssnitt för Unit of Work
    public interface IUnitOfWork
    {
         // Repository för produkter
         // Sparar förändringar (om du använder en databas)
        void NotifyProductAdded(ProductEntity product); // Notifierar observatörer om ny produkt
    }
}

