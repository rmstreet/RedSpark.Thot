using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Core.Notifications
{
    public interface INotificationHandler
    {
        bool HasNotification();
        IReadOnlyList<Notification> GetNotifications();
        void Handler(Notification notification);
    }
}
