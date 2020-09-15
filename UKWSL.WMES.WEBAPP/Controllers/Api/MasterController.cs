using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.Master;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class MasterController : ApiController
    {
        private IMasterManager masterManager;

        public MasterController(IMasterManager manager)
        {
            masterManager = manager;
        }

        #region GetMethods
        [HttpPost]
        [ActionName("GetPriceInflation")]
        public IHttpActionResult GetPriceInflation()
        {
            return Ok(masterManager.GetPriceInflation());
        }

        [HttpPost]
        [ActionName("GetMaterialType")]
        public IHttpActionResult GetMaterialType()
        {
            return Ok(masterManager.GetMaterialType());
        }


        [HttpPost]
        [ActionName("GetContainerType")]
        public IHttpActionResult GetContainerType()
        {
            return Ok(masterManager.GetContainerType());
        }

        [HttpPost]
        [ActionName("GetPricingMethod")]
        public IHttpActionResult GetPricingMethod()
        {
            return Ok(masterManager.GetPricingMethod());
        }

        [HttpPost]
        [ActionName("GetFrequencySize")]
        public IHttpActionResult GetFrequencySize()
        {
            return Ok(masterManager.GetFrequencySize());
        }


        [HttpPost]
        [ActionName("GetFrequencyType")]
        public IHttpActionResult GetFrequencyType()
        {
            return Ok(masterManager.GetFrequencyType());
        }

        [HttpPost]
        [ActionName("GetFrequencySizeByTypeId")]
        public IHttpActionResult GetFrequencySizeByTypeId(FrequencyType frequencyType)
        {
            return Ok(masterManager.GetFrequencySizeById(frequencyType));
        }

        [HttpPost]
        [ActionName("GetWasteType")]
        public IHttpActionResult GetWasteType()
        {
            return Ok(masterManager.GetWasteType());
        }

        [HttpPost]
        [ActionName("GetContainerSize")]
        public IHttpActionResult GetContainerSize()
        {
            return Ok(masterManager.GetContainerSize());
        }

        [HttpPost]
        [ActionName("GetAllSalesUser")]
        public IHttpActionResult GetAllSalesUser()
        {
            return Ok(masterManager.GetAllSalesUser());
        }

        [HttpPost]
        [ActionName("GetMaterialTypeByContainer")]
        public IHttpActionResult GetMaterialTypeByContainer(Container container)
        {
            if (container != null)
            {

                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.WasteTypeId)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.GetMaterialTypeByContainer(container));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetContainerTypeByContainer")]
        public IHttpActionResult GetContainerTypeByContainer(Container container)
        {
            if (container != null)
            {

                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.WasteTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.MaterialTypeId)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.GetContainerTypeByContainer(container));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetContainerSizeByContainer")]
        public IHttpActionResult GetContainerSizeByContainer(Container container)
        {
            if (container != null)
            {

                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.WasteTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.MaterialTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.ContainerTypeId)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.GetContainerSizeByContainer(container));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetContainerAvgWeightByContainer")]
        public IHttpActionResult GetContainerAvgWeightByContainer(Container container)
        {
            if (container != null)
            {

                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.WasteTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.MaterialTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.ContainerTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(container.ContainerSizeId)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.GetContainerAvgWeightByContainer(container));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        [HttpPost]
        [ActionName("GetAllContainerConfigurations")]
        public IHttpActionResult GetAllContainerConfigurations()
        {
            var result = masterManager.GetAllContainerConfigurations();
            return Ok(result);
        }

        [HttpPost]
        [ActionName("GetCustomerQuantityType")]
        public IHttpActionResult GetCustomerQuantityType()
        {
            var result = masterManager.GetCustomerQuantityType();
            result.Status = Status.Success;
            return Ok(result);

        }

        [HttpPost]
        [ActionName("GetContractorInfo")]
        public IHttpActionResult GetContractorInfo()
        {
            var result = masterManager.GetContractor();
            return Ok(result);

        }

        [HttpPost]
        [ActionName("GetEndDestinationType")]
        public IHttpActionResult GetEndDestinationType()
        {
            return Ok(masterManager.GetEndDestinationType());
        }

        [HttpPost]
        [ActionName("GetAvailableContractorInfo")]
        public IHttpActionResult GetAvailableContractor(PricingInfo pricingInfo)
        {
            if (pricingInfo != null)
            {

                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingInfo.SOSId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingInfo.SOSHeaderId)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.GetAvailableContractor(pricingInfo));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetBagType")]
        public IHttpActionResult GetBagType()
        {
            return Ok(masterManager.GetBagType());
        }

        [HttpPost]
        [ActionName("GetApprovedPricingSites")]
        public IHttpActionResult GetApprovedPricingSites(SOSInfo sOSInfo)
        {

            return Ok(masterManager.GetApprovedPricingSites(sOSInfo));
        }

        [HttpPost]
        [ActionName("GetServiceJobType")]
        public IHttpActionResult GetServiceJobType()
        {
            return Ok(masterManager.GetServiceJobType());
        }

        [HttpPost]
        [ActionName("GetServiceDeliveryFailureType")]
        public IHttpActionResult GetServiceDeliveryFailureType()
        {
            return Ok(masterManager.GetServiceDeliveryFailureType());
        }

        [HttpPost]
        [ActionName("GetAllSHEQDocumentTypes")]
        public IHttpActionResult GetAllSHEQDocumentTypes()
        {
            return Ok(masterManager.GetAllSHEQDocumentTypes());
        }

        [HttpPost]
        [ActionName("GetPriceUpdateStatus")]
        public IHttpActionResult GetPriceUpdateStatus()
        {
            return Ok(masterManager.GetPriceUpdateStatus());
        }

        [HttpPost]
        [ActionName("GetMultipleMaterialTypeByContainer")]
        public IHttpActionResult GetMultipleMaterialTypeByContainer(Container container)
        {
            if (container != null)
            {

                if (string.IsNullOrEmpty(Convert.ToString(container.WasteTypeIds)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.GetMultipleMaterialTypeByContainer(container));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetCountyDetails")]
        public IHttpActionResult GetCountyDetails()
        {
            return Ok(masterManager.GetCountyDetails());

        }

        #endregion

        #region CheckIsExists methods
        [HttpPost]
        [ActionName("CheckWasteType")]
        public IHttpActionResult CheckWasteType(WasteType wasteType)
        {
            if (wasteType != null)
            {
                if (string.IsNullOrEmpty(wasteType.WasteTypeName))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = masterManager.CheckWasteType(wasteType);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Sites
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("CheckMaterialType")]
        public IHttpActionResult CheckMaterialType(MaterialType materialType)
        {
            if (materialType != null)
            {
                if (string.IsNullOrEmpty(materialType.MaterialTypeName))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = masterManager.CheckMaterialType(materialType);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Sites
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("CheckContainerType")]
        public IHttpActionResult CheckContainerType(ContainerType containerType)
        {
            if (containerType != null)
            {
                if (string.IsNullOrEmpty(containerType.ContainerTypeName))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = masterManager.CheckContainerType(containerType);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Sites
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("CheckContainerSize")]
        public IHttpActionResult CheckContainerSize(ContainerSize containerSize)
        {
            if (containerSize != null)
            {
                if (string.IsNullOrEmpty(containerSize.ContainerSizeName))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = masterManager.CheckContainerSize(containerSize);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Sites
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("CheckContainerConfig")]
        public IHttpActionResult CheckContainerConfig(ContainerConfigurations containerConfigurations)
        {
            if (containerConfigurations != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(containerConfigurations.WasteTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(containerConfigurations.MaterialTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(containerConfigurations.ContainerTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(containerConfigurations.ContainerSizeId)))
                {
                    return Ok(new Sites
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = masterManager.CheckContainerConfig(containerConfigurations);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Sites
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("CheckFrequency")]
        public IHttpActionResult CheckFrequency(FrequencySize frequencySize)
        {
            if (frequencySize != null)
            {
                if (string.IsNullOrEmpty(frequencySize.FrequencyName))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = masterManager.CheckFrequency(frequencySize);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Sites
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("CheckQuantityType")]
        public IHttpActionResult CheckQuantityType(CustomerQuantityType customerQuantityType)
        {
            if (customerQuantityType != null)
            {
                if (string.IsNullOrEmpty(customerQuantityType.QuantityTypeName))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = masterManager.CheckQuantityType(customerQuantityType);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Sites
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }
        #endregion

        #region CreateMethods

        [HttpPost]
        [ActionName("CreateWasteType")]
        public IHttpActionResult InsertWasteType(WasteType wasteType)
        {
            if (wasteType != null)
            {
                if (String.IsNullOrEmpty(Convert.ToString(wasteType.WasteTypeName)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.InsertUpdateWasteType(wasteType));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        
        [HttpPost]
        [ActionName("CreateMaterialType")]
        public IHttpActionResult InsertMaterialType(MaterialType materialType)
        {
            if (materialType != null)
            {
                if (String.IsNullOrEmpty(Convert.ToString(materialType.MaterialTypeName)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.InsertUpdateMaterialType(materialType));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        
        [HttpPost]
        [ActionName("CreateContainerType")]
        public IHttpActionResult InsertContainerType(ContainerType containerType)
        {
            if (containerType != null)
            {
                if (String.IsNullOrEmpty(Convert.ToString(containerType.ContainerTypeName)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.InsertUpdateContainerType(containerType));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("CreateContainerSize")]
        public IHttpActionResult InsertContainerSize(ContainerSize containerSize)
        {
            if (containerSize != null)
            {
                if (String.IsNullOrEmpty(Convert.ToString(containerSize.ContainerSizeName)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.InsertUpdateContainerSize(containerSize));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("CreateFrequencySize")]
        public IHttpActionResult InsertFrequency(FrequencySize frequencySize )
        {
            if (frequencySize != null)
            {
                if (String.IsNullOrEmpty(Convert.ToString(frequencySize.FrequencyName)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.InsertUpdateFrequency(frequencySize));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("CreateQuantityType")]
        public IHttpActionResult InsertQuantityType(CustomerQuantityType customerQuantityType)
        {
            if (customerQuantityType != null)
            {
                if (String.IsNullOrEmpty(Convert.ToString(customerQuantityType.QuantityTypeName)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.InsertUpdateQuantityType(customerQuantityType));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        
        [HttpPost]
        [ActionName("CreateContainerConfiguration")]
        public IHttpActionResult InsertContainerConfiguration(ContainerConfigurations containerConfigurations)
        {
            if (containerConfigurations != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(containerConfigurations.WasteTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(containerConfigurations.MaterialTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(containerConfigurations.ContainerTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(containerConfigurations.ContainerSizeId)))
                {
                    return Ok(new MasterInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(masterManager.InsertUpdateContainerConfiguration(containerConfigurations));
                }
            }
            else
            {
                return Ok(new MasterInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        #endregion
    }
}
