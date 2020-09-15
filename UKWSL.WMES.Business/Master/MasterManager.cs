using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Master;

namespace UKWSL.WMES.Business.Master
{
    public class MasterManager : IMasterManager
    {

        private IMasterRepository _masterRepository;

        #region GetMethod
        public MasterManager(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }
        public MasterInfo GetPriceInflation()
        {
            return (_masterRepository.GetPriceInflation());
        }
        public MasterInfo GetMaterialType()
        {

            return (_masterRepository.GetMaterialType());
        }
        public MasterInfo GetContainerType()
        {
            return (_masterRepository.GetContainerType());
        }
        public MasterInfo GetContainerSize()
        {
            return (_masterRepository.GetContainerSize());
        }

        public MasterInfo GetPricingMethod()
        {
            return (_masterRepository.GetPricingMethod());
        }

        public MasterInfo GetFrequencySize()
        {
            return (_masterRepository.GetFrequencySize());
        }


        public MasterInfo GetFrequencySizeById(FrequencyType frequencyType)
        {
            return (_masterRepository.GetFrequencySizeById(frequencyType));
        }
        public MasterInfo GetFrequencyType()
        {
            return (_masterRepository.GetFrequencyType());
        }
        public MasterInfo GetWasteType()
        {
            return (_masterRepository.GetWasteType());
        }

        public MasterInfo GetAllSalesUser()
        {
            return (_masterRepository.GetAllSalesUser());
        }

        public MasterInfo GetMaterialTypeByContainer(Container model)
        {
            return (_masterRepository.GetMaterialTypeByContainer(model));
        }

        public MasterInfo GetContainerTypeByContainer(Container model)
        {
            return (_masterRepository.GetContainerTypeByContainer(model));
        }

        public MasterInfo GetContainerSizeByContainer(Container model)
        {
            return (_masterRepository.GetContainerSizeByContainer(model));
        }

        public MasterInfo GetContainerAvgWeightByContainer(Container model)
        {
            return (_masterRepository.GetContainerAvgWeightByContainer(model));
        }

        public MasterInfo GetAllContainerConfigurations()
        {
            return (_masterRepository.GetAllContainerConfigurations());
        }
        public MasterInfo GetContractor()
        {
            return (_masterRepository.GetContractor());

        }

        public MasterInfo GetEndDestinationType()
        {
            return (_masterRepository.GetEndDestinationType());

        }

        public MasterInfo GetCustomerQuantityType()
        {
            return (_masterRepository.GetCustomerQuantityType());
        }

        public MasterInfo GetAvailableContractor(PricingInfo pricingInfo)
        {
            return (_masterRepository.GetAvailableContractor(pricingInfo));
        }

        public MasterInfo GetBagType()
        {
            return (_masterRepository.GetBagType());
        }

        public MasterInfo GetApprovedPricingSites(SOSInfo sOSInfo)
        {
            return _masterRepository.GetApprovedPricingSites(sOSInfo);
        }

        public MasterInfo GetServiceJobType()
        {
            return _masterRepository.GetServiceJobType();
        }

        public MasterInfo GetServiceDeliveryFailureType()
        {
            return _masterRepository.GetServiceDeliveryFailureType();
        }
        public MasterInfo GetAllSHEQDocumentTypes()
        {
            return _masterRepository.GetAllSHEQDocumentTypes();
        }

       public MasterInfo GetPriceUpdateStatus()
        {
            return _masterRepository.GetPriceUpdateStatus();
        }
        public MasterInfo GetCountyDetails()
        {
            return (_masterRepository.GetCountyDetails());
        }

       public MasterInfo GetMultipleMaterialTypeByContainer(Container model)
        {
            return _masterRepository.GetMultipleMaterialTypeByContainer(model);
        }

        #endregion

        #region CheckIfExist Methods
        public MasterInfo CheckWasteType(WasteType wasteType)
        {
            return (_masterRepository.CheckWasteTypeExist(wasteType));
        }

        public MasterInfo CheckMaterialType(MaterialType materialType)
        {
            return (_masterRepository.CheckMaterialTypeExist(materialType));
        }

        public MasterInfo CheckContainerType(ContainerType containerType)
        {
            return (_masterRepository.CheckContainerTypeExist(containerType));
        }

        public MasterInfo CheckContainerSize(ContainerSize containerSize)
        {
            return (_masterRepository.CheckContainerSizeExist(containerSize));
        }

        public MasterInfo CheckContainerConfig(ContainerConfigurations containerConfigurations)
        {
            return (_masterRepository.CheckContainerConfigExist(containerConfigurations));
        }

        public MasterInfo CheckFrequency(FrequencySize frequencySize)
        {
            return (_masterRepository.CheckFrequencyExist(frequencySize));
        }

        public MasterInfo CheckQuantityType(CustomerQuantityType customerQuantityType)
        {
            return (_masterRepository.CheckQuantityTypeExist(customerQuantityType));
        }
        #endregion

        #region Insert/Update Methods
        public MasterInfo InsertUpdateWasteType(WasteType wasteType)
        {
            return (_masterRepository.InsertUpdateWasteType(wasteType));
        }
        public MasterInfo InsertUpdateMaterialType(MaterialType materialType)
        {
            return (_masterRepository.InsertUpdateMaterialType(materialType));
        }
        public MasterInfo InsertUpdateContainerType(ContainerType containerType)
        {
            return (_masterRepository.InsertUpdateContainerType(containerType));
        }
        public MasterInfo InsertUpdateContainerSize(ContainerSize containerSize)
        {
            return (_masterRepository.InsertUpdateContainerSize(containerSize));
        }
        public MasterInfo InsertUpdateFrequency(FrequencySize frequencySize)
        {
            return (_masterRepository.InsertUpdateFrequency(frequencySize));
        }
        public MasterInfo InsertUpdateQuantityType(CustomerQuantityType customerQuantityType)
        {
            return (_masterRepository.InsertUpdateQuantityType(customerQuantityType));
        }
        public MasterInfo InsertUpdateContainerConfiguration(ContainerConfigurations containerConfigurations)
        {
            return (_masterRepository.InsertUpdateContainerConfiguration(containerConfigurations));
        }
        #endregion

    }
}
