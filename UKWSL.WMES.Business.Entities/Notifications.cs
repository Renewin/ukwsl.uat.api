using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Notifications:Log
    {
        public int NotificationId { get; set; }        
        public string NotificationTypeName { get; set; }
        public string NotificationSubject { get; set; }
        public string NotificationMessage { get; set; }
        public bool IsRead { get; set; }

        public string NotificationUrl { get; set; }
        public string NotificationValues { get; set; }

        public int SentBy { get; set; }
        public int SentTo { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
