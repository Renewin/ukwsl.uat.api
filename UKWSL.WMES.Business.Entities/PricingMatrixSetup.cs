using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class PricingMatrixSetup : Log
    {
        public int? MatrixId { get; set; }
        public int MatrixTypeId { get; set; }
        public int? ContractorId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsSpecific { get; set; }
        public int? Specific_CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? Specific_ContractorId { get; set; }
        public string ContractorName { get; set; }
        public string MatrixIds { get; set; }
        public bool IsPriceUpdated { get; set; }
        public int CanDelete { get; set; }
        public int? ActionHeaderId { get; set; }
        public int ReturnId { get; set; }
    }
}
