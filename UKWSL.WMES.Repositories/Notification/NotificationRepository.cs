using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Notification
{
    public class NotificationRepository : INotificationRepository
    {
        private string _connectionString;
        public NotificationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NotificationInfo GetNotificationsByDepartmentfunction(NotificationInfo notificationInfo)
        {
            NotificationInfo objNotificationInfo = new NotificationInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Notifications> lstEntity = new List<Notifications>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Notification_GetDataByDept_function]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepartmentId", notificationInfo.DepartmentId);
                        cmd.Parameters.AddWithValue("@FunctionId", notificationInfo.FunctionId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Notifications objEntity = new Notifications();
                                objEntity.NotificationId = string.IsNullOrEmpty(Convert.ToString(reader["NotificationId"])) ? 0 : Convert.ToInt32(reader["NotificationId"]);
                                objEntity.NotificationTypeName = Convert.ToString(reader["NotificationType_Name"]);
                                objEntity.NotificationSubject = Convert.ToString(reader["Notif_Subject"]);
                                objEntity.NotificationMessage = Convert.ToString(reader["Notif_Message"]);
                                objEntity.IsRead = string.IsNullOrEmpty(Convert.ToString(reader["IsRead"])) ? false : Convert.ToBoolean(reader["IsRead"]);
                                objEntity.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    objNotificationInfo.lstNotifications = lstEntity;
                }
                objNotificationInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objNotificationInfo.Status = Status.Failed;
                objNotificationInfo.Message = ex.Message;
            }
            return objNotificationInfo;
        }

        public NotificationInfo GetNotificationsByNotificationId(Notifications notifications)
        {
            NotificationInfo objNotificationInfo = new NotificationInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Notification_GetDataBy_NotificationId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NotificationId", notifications.NotificationId);
                        cmd.Parameters.AddWithValue("@CreatedBy", notifications.CreatedBy);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Notifications objEntity = new Notifications();
                                objEntity.NotificationId = string.IsNullOrEmpty(Convert.ToString(reader["NotificationId"])) ? 0 : Convert.ToInt32(reader["NotificationId"]);
                                objEntity.NotificationUrl = Convert.ToString(reader["Noti_Url"]);
                                objEntity.NotificationValues = Convert.ToString(reader["Noti_Values"]);
                                objEntity.NotificationTypeId = string.IsNullOrEmpty(Convert.ToString(reader["NotificationTypeId"])) ? 0 : Convert.ToInt32(reader["NotificationTypeId"]);
                                objNotificationInfo.Notifications = objEntity;
                            }
                        }
                    }
                }
                objNotificationInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objNotificationInfo.Status = Status.Failed;
                objNotificationInfo.Message = ex.Message;
            }
            return objNotificationInfo;
        }

        public Notifications CreateNewNotification(Notifications notifications)
        {
            Notifications objNotifications = new Notifications();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Notification_CreateNew]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NotificationTypeId", notifications.NotificationTypeId);
                        cmd.Parameters.AddWithValue("@SentBy", notifications.SentBy);
                        cmd.Parameters.AddWithValue("@Sentto", notifications.SentTo);
                        cmd.Parameters.AddWithValue("@Notif_Subject", notifications.NotificationSubject);
                        cmd.Parameters.AddWithValue("@Notif_Message", notifications.NotificationMessage);
                        cmd.Parameters.AddWithValue("@Noti_Url", notifications.NotificationUrl);
                        cmd.Parameters.AddWithValue("@Noti_Values", notifications.NotificationValues);
                        cmd.Parameters.AddWithValue("@CreatedBy", notifications.CreatedBy);
                        cmd.Parameters.Add("@NotificationId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objNotifications.NotificationId = Convert.ToInt32(cmd.Parameters["@NotificationId"].Value);
                    }
                }
                objNotifications.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objNotifications.Status = Status.Failed;
                objNotifications.Message = ex.Message;
            }
            return objNotifications;
        }
    }
}
