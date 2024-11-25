using WebShopSolution.DataAccess.Entities;

namespace WebShop.Notifications;

public class SmsNotification(string phoneNumber) : INotificationObserver
{
    public Task Update(ProductEntity product)
    {
        Console.WriteLine("Send to" + phoneNumber);
        Console.WriteLine($"SMS Notification: New product added - {product.Name}");
        return Task.CompletedTask;
    }
}