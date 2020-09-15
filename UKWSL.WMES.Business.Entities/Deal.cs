using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Deal : Log
    {
        public int Did { get; set; }
        public string DealId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int SalesOwnerId { get; set; }
        public int ContractDuration { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public decimal DealAmount { get; set; }
        public int SOSStatus { get; set; }
        public string SalesOwnerName { get; set; }
        public int IsDealExist { get; set; }
        public string DealPipeline { get; set; }
        public string DealStatusName { get; set; }
        public int DealStatusId { get; set; }
        public int SetupStatus { get; set; }
    }
}
