using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerGroupInfo :Log
    {
        public int CustomerId { get; set; }
        public int Customer_GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime InvoiceStartDate { get; set; }
        public int MonthlyPaymentId { get; set; }
        public string GroupNotes { get; set; }
        public string InvoicingNotes { get; set; }
        public string AccountName { get; set; }
        public string AccountIds { get; set; }
        public string GroupTypeIds { get; set; }
        public string GroupTypeName { get; set; }
        public string MonthlyPaymentTypeName { get; set; }
        public string SiteIds { get; set; }
        public int ReturnId { get; set; }
        public string GroupIds { get; set; }
    }
}
