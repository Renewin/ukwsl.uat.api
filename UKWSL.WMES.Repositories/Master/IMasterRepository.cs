using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Master
{
   public interface IMasterRepository
    {
        MasterInfo GetPriceInflation();

        MasterInfo GetMaterialType();
        MasterInfo GetContainerType();

        MasterInfo GetContainerSize();
        MasterInfo GetPricingMethod();
        MasterInfo GetFrequencySizeById(FrequencyType frequencyType);
        MasterInfo GetFrequencyType();
        MasterInfo GetFrequencySize();
        MasterInfo GetWasteType();

        MasterInfo GetServiceJobType();

        MasterInfo GetAllSalesUser();

        MasterInfo GetAllSHEQDocumentTypes();

        MasterInfo GetMaterialTypeByContainer(Container model);
        MasterInfo GetContainerTypeByContainer(Container model);
        MasterInfo GetContainerSizeByContainer(Container model);
        MasterInfo GetContainerAvgWeightByContainer(Container model);

        MasterInfo GetAllContainerConfigurations();
        MasterInfo GetContractor();

        MasterInfo GetEndDestinationType();
        MasterInfo GetCustomerQuantityType();
        MasterInfo GetAvailableContractor(PricingInfo pricingInfo);

        MasterInfo CheckWasteTypeExist(WasteType wasteType);
        MasterInfo CheckMaterialTypeExist(MaterialType materialType);
        MasterInfo CheckContainerTypeExist(ContainerType containerType);
        MasterInfo CheckContainerSizeExist(ContainerSize containerSize);
        MasterInfo CheckContainerConfigExist(ContainerConfigurations containerConfigurations);
        MasterInfo CheckFrequencyExist(FrequencySize frequencySize);
        MasterInfo CheckQuantityTypeExist(CustomerQuantityType customerQuantityType);

        MasterInfo InsertUpdateWasteType(WasteType wasteType);
        MasterInfo InsertUpdateMaterialType(MaterialType materialType);
        MasterInfo InsertUpdateContainerType(ContainerType containerType);
        MasterInfo InsertUpdateContainerSize(ContainerSize containerSize);
        MasterInfo InsertUpdateFrequency(FrequencySize frequencySize);
        MasterInfo InsertUpdateQuantityType(CustomerQuantityType customerQuantityType);
        MasterInfo InsertUpdateContainerConfiguration(ContainerConfigurations containerConfigurations);
        MasterInfo GetBagType();
        MasterInfo GetApprovedPricingSites(SOSInfo sOSInfo);
        MasterInfo GetServiceDeliveryFailureType();
        MasterInfo GetPriceUpdateStatus();
        MasterInfo GetMultipleMaterialTypeByContainer(Container model);
        MasterInfo GetCountyDetails();
    }
}
