using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Master
{
    public interface IMasterManager
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
        MasterInfo GetAllSalesUser();

        MasterInfo GetMaterialTypeByContainer(Container model);
        MasterInfo GetContainerTypeByContainer(Container model);
        MasterInfo GetContainerSizeByContainer(Container model);
        MasterInfo GetContainerAvgWeightByContainer(Container model);
        MasterInfo GetAllContainerConfigurations();

        MasterInfo GetContractor();
        MasterInfo GetEndDestinationType();
        MasterInfo GetCustomerQuantityType();
        MasterInfo GetAvailableContractor(PricingInfo pricingInfo);

        MasterInfo CheckWasteType(WasteType wasteType);
        MasterInfo CheckMaterialType(MaterialType materialType);
        MasterInfo CheckContainerType(ContainerType containerType);
        MasterInfo CheckContainerSize(ContainerSize containerSize);
        MasterInfo CheckContainerConfig(ContainerConfigurations containerConfigurations);
        MasterInfo CheckFrequency(FrequencySize frequencySize);
        MasterInfo CheckQuantityType(CustomerQuantityType customerQuantityType);

        MasterInfo InsertUpdateWasteType(WasteType wasteType);
        MasterInfo InsertUpdateMaterialType(MaterialType materialType);
        MasterInfo InsertUpdateContainerType(ContainerType containerType);
        MasterInfo InsertUpdateContainerSize(ContainerSize containerSize);
        MasterInfo InsertUpdateFrequency(FrequencySize frequencySize);
        MasterInfo InsertUpdateContainerConfiguration(ContainerConfigurations containerConfigurations);
        MasterInfo InsertUpdateQuantityType(CustomerQuantityType customerQuantityType);
        MasterInfo GetBagType();
        MasterInfo GetApprovedPricingSites(SOSInfo sOSInfo);

        MasterInfo GetServiceJobType();
        MasterInfo GetServiceDeliveryFailureType();
        MasterInfo GetAllSHEQDocumentTypes();
        MasterInfo GetPriceUpdateStatus();
        MasterInfo GetMultipleMaterialTypeByContainer(Container model);
        MasterInfo GetCountyDetails();
    }
}
