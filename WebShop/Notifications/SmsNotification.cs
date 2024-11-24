using WebShopSolution.DataAccess.Entities;

namespace WebShop.Notifications;

public class SmsNotification(string phoneNumber) : INotificationObserver
{
    public void Update(ProductEntity product)
    {
        throw new NotImplementedException();
    }
}