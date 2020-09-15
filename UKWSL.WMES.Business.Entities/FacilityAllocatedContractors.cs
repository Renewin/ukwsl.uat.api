using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class FacilityAllocatedContractors : Log
    {
        public int ContractorAllocationId { get; set; }
        public int FacilityId { get; set; }
        public int ContractorId { get; set; }
        public string ContractorName { get; set; }
        public string Address { get; set; }
        public int ActiveDepots { get; set; }
        public int Warning { get; set; }
        public int CanDelete { get; set; }

        public string ContractorIds { get; set; }
    }
}
