using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class MasterInfo :Result
    {

        public List<PriceInflation> lstPriceInflation { get; set; }
        public List <MaterialType> lstMaterialType { get; set; }

        public List<ContainerType> lstContainerType { get; set; }

        public List<ContainerSize> lstContainerSize { get; set; }

        public List<FrequencyType> lstFrequencyType { get; set; }
        public List<FrequencySize> lstFrequencySize { get; set; }

        public List<PricingMethod> lstPricingMethod { get; set; }

        public List<WasteType> lstWasteTypes { get; set; }

        public List<User> lstUser { get; set; }

        public List<Container> lstContainer { get; set; }

        public List<ContainerConfigurations> lstContainerConfigurations { get; set; }

        public ContainerConfigurations containerConfigurations { get; set; }

        public List<CustomerQuantityType> lstCustomerQuantityType { get; set; }

        public List<Contractor> lstContractor { get; set; }

        public List<Contractor> lstAvailableContractor { get; set; }

        public List<EndDestinationType> lstEndDestinationTypes { get; set; }
        public List<BagType> lstBagType { get; set; }
        public List<SHEQDocumentTypes> lstSHEQDocumentTypes { get; set; }
        public int MasterId { get; set; }

        public int IsWasteTypeExist { get; set; }
        public int IsMaterialTypeExist { get; set; }
        public int IsContainerTypeExist { get; set; }
        public int IsContainerSizeExist { get; set; }
        public int IsContainerConfigExist { get; set; }
        public int IsFrequencyExist { get; set; }
        public int IsQuantityTypeExist { get; set; }
        public List<Sites> lstApprovedPricingSites { get; set; }

        public List<JobType> lstServiceJobType { get; set; }
        public List<ServiceDeliveryFailureType> lstServiceDeliveryFailureType { get; set; }
        public List<PricingUpdateStatus> lstPricingUpdateStatus { get; set; }
        public List<CountyInfo> lstCountyInfo { get; set; }

    }
}
