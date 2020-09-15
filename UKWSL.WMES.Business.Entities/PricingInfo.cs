using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class PricingInfo : Log
    {

        public List<Deal> lstdeals { get; set; }
        public int SOSId { get; set; }
        public int SOSHeaderId { get; set; }
        public int DealId { get; set; }

        public int PCId { get; set; }

        public Filedetails filedetails { get; set; }

        public List<PricingToolUDTFileData> lstpricingToolUDTFileData { get; set; }
        public List<ContractorPrice> lstContractorPrice { get; set; }
        public PreferredContractorPrice preferredContractorPrice { get; set; }
        public List<PreferredContractorPrice> lstPreferredContractorPrice { get; set; }
        public ContractorPrice contractorPrice { get; set; }
        public int IsUploadSuccess { get; set; }
        public int SUploadId { get; set; }

    }
}
