using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class NotificationInfo: Result
    {
        public IList<Notifications> lstNotifications { get; set; }
        public Notifications Notifications { get; set; }
        public int DepartmentId { get; set; }
        public int FunctionId { get; set; }
    }
}
