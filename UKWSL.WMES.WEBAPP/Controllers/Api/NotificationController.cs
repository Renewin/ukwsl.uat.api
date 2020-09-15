using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.Notification;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class NotificationController : ApiController
    {
        private INotificationManager notificationManager;

        public NotificationController(INotificationManager manager)
        {
            notificationManager = manager;
        }

        [HttpPost]
        [ActionName("GetNotifications")]
        public IHttpActionResult GetNotifications(NotificationInfo notificationInfo)
        {
            if (notificationInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(notificationInfo.DepartmentId)) 
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(notificationInfo.FunctionId)))
                {
                    return Ok(new NotificationInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = notificationManager.GetNotificationsByDepartmentfunction(notificationInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new NotificationInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        [HttpPost]
        [ActionName("GetNotificationsByNotificationId")]
        public IHttpActionResult GetNotificationsByNotificationId(Notifications notifications)
        {
            if (notifications != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(notifications.NotificationId)))
                {
                    return Ok(new NotificationInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = notificationManager.GetNotificationsByNotificationId(notifications);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new NotificationInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("CreateNewNotification")]
        public IHttpActionResult CreateNewNotification(Notifications notifications)
        {
            if (notifications != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(notifications.NotificationTypeId)))
                {
                    return Ok(new Notifications
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(notificationManager.CreateNewNotification(notifications));
                }
            }
            else
            {
                return Ok(new Notifications
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
    }
}
