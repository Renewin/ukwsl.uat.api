using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Notification;

namespace UKWSL.WMES.Business.Notification
{
    public class NotificationManager : INotificationManager
    {
        private INotificationRepository _notificationRepository;
        public NotificationManager(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public NotificationInfo GetNotificationsByDepartmentfunction(NotificationInfo notificationInfo)
        {
            return _notificationRepository.GetNotificationsByDepartmentfunction(notificationInfo);
        }
        public NotificationInfo GetNotificationsByNotificationId(Notifications notifications)
        {
            return _notificationRepository.GetNotificationsByNotificationId(notifications);
        }
        public Notifications CreateNewNotification(Notifications notifications)
        {
            return _notificationRepository.CreateNewNotification(notifications);
        }
    }
}
