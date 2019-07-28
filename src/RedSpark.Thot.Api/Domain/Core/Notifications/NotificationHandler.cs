using System;
using System.Collections.Generic;
using System.Linq;

namespace RedSpark.Thot.Api.Domain.Core.Notifications
{
    public class NotificationHandler : INotificationHandler, IDisposable
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }
        
        public IReadOnlyList<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handler(Notification notification)
        {
            if(notification == null || string.IsNullOrEmpty(notification.Message))
            {
                return;
            }

            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<Notification>();
        }
    }
}
