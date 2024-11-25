using WebShopSolution.DataAccess.Entities;

namespace WebShop.Notifications;

public class SmsNotification(string? phoneNumber = null) : INotificationObserver
{
    public void Update(ProductEntity product)
    {
        Console.WriteLine("Sending SMS notification to " + phoneNumber);
        Console.WriteLine($"SMS: Product with name {product.Name} is now in stock!");
    }
}