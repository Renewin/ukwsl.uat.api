﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Notification
{
    public interface INotificationManager
    {
        NotificationInfo GetNotificationsByDepartmentfunction(NotificationInfo notificationInfo);
        NotificationInfo GetNotificationsByNotificationId(Notifications notifications);
        Notifications CreateNewNotification(Notifications notifications);
    }
}
