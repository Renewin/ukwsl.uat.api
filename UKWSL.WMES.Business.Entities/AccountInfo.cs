using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class AccountInfo:Log
    {
        public int AccountId { get; set; }
        public string CustomerAccount { get; set; }
        public int CustomerId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string PaymentType { get; set; }
        public string AccountDescription { get; set; }
        public string AccountIds { get; set; }
        public string DOCSendingPreferences { get; set; }
        public bool IsUnScheduledServiceIncluded { get; set; }
        public int ReturnId { get; set; }
    }
}
