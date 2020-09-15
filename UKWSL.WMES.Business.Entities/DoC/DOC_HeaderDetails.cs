using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
    public class DOC_HeaderDetails
    {
        public int DOCId { get; set; }
        public int CustomerId { get; set; }
        public int FYId { get; set; }
        public string ActionFlag { get; set; }
        public int Customer_AccountId { get; set; }
        public int? Customer_GroupId { get; set; }
        public string Customer_SICCode { get; set; }
        public string DOCContactName { get; set; }
        public string DOCContactEmail { get; set; }
        public string EnquiryNumber { get; set; }
        public int NoofServices { get; set; }
        public int NoofContractors { get; set; }
        public string EmailorPosted { get; set; }
        public bool IsDOCSigned { get; set; }
        public bool IsIncludedUnscheduledService { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
