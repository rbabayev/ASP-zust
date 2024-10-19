using Zust.Entities.Entities;

namespace Zust.Business.Abstract
{
    public interface INotificationService
    {
        Task AddNotification(Notification notification);
        Task<IEnumerable<Notification>> GetAllNotifications(string userId);
        Task DeclineNotification(string userId);

    }
}
