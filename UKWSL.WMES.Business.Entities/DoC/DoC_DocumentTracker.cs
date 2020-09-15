using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
    public class DoC_DocumentTracker
    {
        public int CustomerId { get; set; }
        public int FYId { get; set; }
        public int DOCId { get; set; }
        public string ContactEmail { get; set; }
        public string CustomerName { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int Customer_GroupId { get; set; }
        public string GroupName { get; set; }
        public string CompanySICCode { get; set; }
        public string AccountType { get; set; }
        public string DOCContact { get; set; }
        public string EmailReceived { get; set; }
        public string LinkOpened { get; set; }
        public string EnquiryNumber { get; set; }
        public string NoOfServices { get; set; }
        public string NoOfContractors { get; set; }
        public string NoOfDOCsGenerated { get; set; }
        public bool SICCodeExist { get; set; }
        public bool DOCContactExist { get; set; }
        public bool IsGroupSiteMissing { get; set; }
        public bool ExpiredWCL { get; set; }
        public string LastReminderLetter { get; set; }
        public string DOCSigned { get; set; }
        public string EmailorPosted { get; set; }

    }
}
