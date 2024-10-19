using Zust.Business.Abstract;
using Zust.DataAccess.Abstract;
using Zust.Entities.Entities;

namespace Zust.Business.Concrete
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationService(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public async Task AddNotification(Notification notification)
        {
            await _notificationDal.AddAsync(notification);
        }

        public async Task DeclineNotification(string userId)
        {
            var notifications = await _notificationDal.GetAllAsync(n => n.SenderId == userId || n.ReceiverId == userId);

            if (notifications != null)
            {
                foreach (var notification in notifications)
                {
                    await _notificationDal.DeleteAsync(notification);
                }
            }
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications(string userId)
        {
            return await _notificationDal.GetAllAsync(n => n.ReceiverId == userId);
        }
    }
}
