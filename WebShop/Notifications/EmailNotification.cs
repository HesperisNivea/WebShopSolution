using WebShop.Models;
using WebShopSolution.DataAccess.Entities;

namespace WebShop.Notifications
{
    // En konkret observatör som skickar e-postmeddelanden
    public class EmailNotification(string? email = null) : INotificationObserver
    {
        public void Update(ProductEntity product)
        {
            // Här skulle du implementera logik för att skicka ett e-postmeddelande
            // För enkelhetens skull skriver vi ut till konsolen
            if (email is null)
            {
                Console.WriteLine("Email is not set");
                return;
            }
            
            Console.WriteLine("Send to" + email);
            Console.WriteLine($"Email Notification: New product added - {product.Name}");
        }
    }
}
