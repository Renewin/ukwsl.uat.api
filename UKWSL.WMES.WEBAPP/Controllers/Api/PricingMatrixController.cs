using System;
using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.PricingMatrix;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class PricingMatrixController : ApiController
    {
        private IPricingMatrixManager pricingMatrixManager;
        public PricingMatrixController(IPricingMatrixManager manager)
        {
            pricingMatrixManager = manager;
        }

        #region Area of Coverage

        /// <summary>
        /// API to Get PostCode list by ContractorId
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPostCodeListByContractorId")]
        public IHttpActionResult GetPostCodeListByContractorId(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetPostCodeListByContractorId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Insert and Update Area of Coverage
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("InsertandUpdateAreaofCoverage")]
        public IHttpActionResult InsertandUpdateAreaofCoverage(Contractor_Config_AreaofCoverage areaofCoverage)
        {
            if (areaofCoverage != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(areaofCoverage.ContractorId)) && string.IsNullOrEmpty(areaofCoverage.PostCode) && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(areaofCoverage.CreatedBy)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.InsertandUpdateAreaofCoverage(areaofCoverage);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Check Area of Coverage Exists or not
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("CheckAreaofCoverageExists")]
        public IHttpActionResult CheckAreaofCoverageExists(Contractor_Config_AreaofCoverage areaofCoverage)
        {
            if (areaofCoverage != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(areaofCoverage.ContractorId)) && string.IsNullOrEmpty(areaofCoverage.PostCode))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.CheckAreaofCoverageExists(areaofCoverage);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Delete Delete Area of Coverage
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("DeleteAreaofCoverage")]
        public IHttpActionResult DeleteAreaofCoverage(Contractor_Config_AreaofCoverage areaofCoverage)
        {
            if (areaofCoverage != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(areaofCoverage.ContractorId)) 
                    && string.IsNullOrEmpty(areaofCoverage.AOCIds))
                {
                    return Ok(new Contractor_Config_AreaofCoverage
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.DeleteAreaofCoverage(areaofCoverage);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Contractor_Config_AreaofCoverage
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to UpdateIsNationalSupplier
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("UpdateIsNationalSupplier")]
        public IHttpActionResult UpdateIsNationalSupplier(ContractorAdminSetting contractorAdminSetting)
        {
            if (contractorAdminSetting != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(contractorAdminSetting.ContractorId)))
                {
                    return Ok(new ContractorAdminSetting
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.UpdateIsNationalSupplier(contractorAdminSetting);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorAdminSetting
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        #endregion

        #region Potential Service

        /// <summary>
        /// API to Get Potential Service List By ContractorId
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPotentialServiceListByContractorId")]
        public IHttpActionResult GetPotentialServiceListByContractorId(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetPotentialServiceListByContractorId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Potential Service Info
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPotentialServiceInfo")]
        public IHttpActionResult GetPotentialServiceInfo(Contractor_Config_PotentialService potentialService)
        {
            if (potentialService != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.ContractorId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.PSId))
                    )
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetPotentialServiceInfo(potentialService);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Insert and Update Area of Coverage
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("InsertandUpdatePotentialService")]
        public IHttpActionResult InsertandUpdatePotentialService(Contractor_Config_PotentialService potentialService)
        {
            if (potentialService != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.PSId)) 
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.ContractorId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.WasteType.WasteTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.MaterialType.MaterialTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.ContainerType.ContainerTypeId))
                    && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(potentialService.CreatedBy)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.InsertandUpdatePotentialService(potentialService);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Check Potential Service Exists or not
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("CheckPotentialServiceExists")]
        public IHttpActionResult CheckPotentialServiceExists(Contractor_Config_PotentialService potentialService)
        {
            if (potentialService != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.ContractorId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.WasteType.WasteTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.MaterialType.MaterialTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(potentialService.ContainerType.ContainerTypeId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.CheckPotentialServiceExists(potentialService);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Delete Potential Service
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("DeletePotentialService")]
        public IHttpActionResult DeletePotentialService(Contractor_Config_PotentialService potentialService)
        {
            if (potentialService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(potentialService.ContractorId))&&
                    string.IsNullOrEmpty(Convert.ToString(potentialService.PSIds)))
                {
                    return Ok(new Contractor_Config_PotentialService
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.DeletePotentialService(potentialService);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Contractor_Config_PotentialService
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get WasteType List By Potential Service
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetWasteTypeByPotentialService")]
        public IHttpActionResult GetWasteTypeByPotentialService(Contractor_Config_PotentialService potentialService)
        {
            if (potentialService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(potentialService.ContractorId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetWasteTypeByPotentialService(potentialService);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get MaterialType List By Potential Service
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetMaterialTypeByPotentialService")]
        public IHttpActionResult GetMaterialTypeByPotentialService(Contractor_Config_PotentialService potentialService)
        {
            if (potentialService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(potentialService.ContractorId))                    
                    && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(potentialService.WasteType.WasteTypeId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetMaterialTypeByPotentialService(potentialService);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get ContainerType List By Potential Service
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetContainerTypeByPotentialService")]
        public IHttpActionResult GetContainerTypeByPotentialService(Contractor_Config_PotentialService potentialService)
        {
            if (potentialService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(potentialService.ContractorId))                    
                    && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(potentialService.WasteType.WasteTypeId))
                    && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(potentialService.MaterialType.MaterialTypeId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetContainerTypeByPotentialService(potentialService);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        #endregion

        #region Pricing Matrix for Contractor / Customer
        /// <summary>
        /// API to Get Customer List
        /// </summary>
        /// Delivery Point: DP4.8

        [HttpPost]
        [ActionName("GetCustomerList")]
        public IHttpActionResult GetCustomerList()
        {
            return Ok(pricingMatrixManager.GetCustomerList());
        }

        /// <summary>
        /// API to Get Contractor List
        /// </summary>
        /// Delivery Point: DP4.8

        [HttpPost]
        [ActionName("GetContractorList")]
        public IHttpActionResult GetContractorList()
        {
            return Ok(pricingMatrixManager.GetContractorList());
        }
        /// <summary>
        /// API to Get PostCodes By Area of Coverage
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPostCodesByAreaofCoverage")]
        public IHttpActionResult GetPostCodesByAreaofCoverage(Contractor_Config_PotentialService potentialService)
        {
            if (potentialService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(potentialService.ContractorId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetPostCodesByAreaofCoverage(potentialService);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Insert and Update Pricing Matrix Setup
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("InsertandUpdatePricingMatrixSetup")]
        public IHttpActionResult InsertandUpdatePricingMatrixSetup(PricingMatrixSetup pricingMatrixSetup)
        {
            if (pricingMatrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrixSetup.MatrixId))
                     && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixSetup.CreatedBy))
                     && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixSetup.MatrixTypeId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.InsertandUpdatePricingMatrixSetup(pricingMatrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        
        /// <summary>
        /// API to Insert and Update Pricing Matrix Setup
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("UpdateEndDatePricingMatrix")]
        public IHttpActionResult UpdateEndDatePricingMatrix(PricingMatrixSetup pricingMatrixSetup)
        {
            if (pricingMatrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrixSetup.MatrixId))
                     && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixSetup.CreatedBy))
                     )
                {
                    return Ok(new PricingMatrixSetup
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.UpdateEndDatePricingMatrix(pricingMatrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixSetup
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Insert and Update Pricing Matrix Detail
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("InsertandUpdatePricingMatrixDetail")]
        public IHttpActionResult InsertandUpdatePricingMatrixDetail(PricingMatrixDetail pricingMatrixDetail)
        {
            if (pricingMatrixDetail != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrixDetail.PMId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.MatrixId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.WasteType.WasteTypeId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.MaterialType.MaterialTypeId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.ContainerType.ContainerTypeId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.ContainerSize.ContainerSizeId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.CreatedBy)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.InsertandUpdatePricingMatrixDetail(pricingMatrixDetail);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Pricing Matrix By MatrixId
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPricingMatrixByMatrixId")]
        public IHttpActionResult GetPricingMatrixByMatrixId(PricingMatrixSetup pricingMatrixSetup)
        {
            if (pricingMatrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixSetup.MatrixId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetPricingMatrixByMatrixId(pricingMatrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Pricing Matrix Details By MatrixId
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPricingMatrixDetailsByMatrixId")]
        public IHttpActionResult GetPricingMatrixDetailsByMatrixId(PricingMatrixSetup pricingMatrixSetup)
        {
            if (pricingMatrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixSetup.MatrixId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetPricingMatrixDetailsByMatrixId(pricingMatrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Pricing Matrix Detail Info By PMId
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPricingMatrixDetailInfoByPMId")]
        public IHttpActionResult GetPricingMatrixDetailInfoByPMId(PricingMatrixDetail pricingMatrixDetail)
        {
            if (pricingMatrixDetail != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.PMId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetPricingMatrixDetailInfoByPMId(pricingMatrixDetail);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Delete Pricing Matrix By MatrixId
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("DeletePricingMatrixByMatrixId")]
        public IHttpActionResult DeletePricingMatrixByMatrixId(PricingMatrixSetup pricingMatrix)
        {
            if (pricingMatrix != null)
            {
                if (string.IsNullOrEmpty(Convert.ToString(pricingMatrix.MatrixIds)))
                {
                    return Ok(new PricingMatrixSetup
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.DeletePricingMatrixByMatrixId(pricingMatrix);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixSetup
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Delete Potential Service
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("DeleteMatrixDetailsByPMId")]
        public IHttpActionResult DeleteMatrixDetailsByPMId(PricingMatrixDetail pricingMatrixDetail)
        {
            if (pricingMatrixDetail != null)
            {
                if (string.IsNullOrEmpty(Convert.ToString(pricingMatrixDetail.PMIds)))
                {
                    return Ok(new PricingMatrixDetail
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.DeleteMatrixDetailsByPMId(pricingMatrixDetail);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixDetail
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to ValidateContractorPriceExist
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("ValidateContractorPriceExist")]
        public IHttpActionResult ValidateContractorPriceExist(PricingMatrixSetup matrixSetup)
        {
            if (matrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(matrixSetup.ContractorId)))
                {
                    return Ok(new PricingMatrixSetup
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.ValidateContractorPriceExist(matrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixSetup
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [ActionName("ValidateCustomerPriceExist")]
        public IHttpActionResult ValidateCustomerPriceExist(PricingMatrixSetup matrixSetup)
        {
            if (matrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(matrixSetup.CustomerId)))
                {
                    return Ok(new PricingMatrixSetup
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.ValidateCustomerPriceExist(matrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixSetup
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Insert and Update Pricing Matrix Detail
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("MatrixDetailsExistsornot")]
        public IHttpActionResult MatrixDetailsExistsornot(PricingMatrixDetail pricingMatrixDetail)
        {
            if (pricingMatrixDetail != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.MatrixId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.WasteType.WasteTypeId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.MaterialType.MaterialTypeId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.ContainerType.ContainerTypeId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixDetail.ContainerSize.ContainerSizeId)))
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.MatrixDetailsExistsornot(pricingMatrixDetail);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        #endregion

        #region Customer Price Update Restriction

        /// <summary>
        /// API to Get Customer Price Update Restriction List
        /// </summary>
        /// Delivery Point: DP4.8

        [HttpPost]
        [ActionName("GetCustomerPriceUpdateRestrictionList")]
        public IHttpActionResult GetCustomerPriceUpdateRestrictionList()
        {
            return Ok(pricingMatrixManager.GetCustomerPriceUpdateRestrictionList());
        }

        /// <summary>
        /// API to Get Customer Price Update Restriction History List
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetCustomerPriceUpdateRestrictionHistoryList")]
        public IHttpActionResult GetCustomerPriceUpdateRestrictionHistoryList(CustomerBasicInfo customerBasicInfo )
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerPriceUpdateRestrictionInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetCustomerPriceUpdateRestrictionHistoryList(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerPriceUpdateRestrictionInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Customer Price Update Restriction By Id
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetCustomerPriceUpdateRestrictionById")]
        public IHttpActionResult GetCustomerPriceUpdateRestrictionById(CustomerPriceUpdateRestriction customerPriceUpdateRestriction )
        {
            if (customerPriceUpdateRestriction != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerPriceUpdateRestriction.RestrictionId)))
                {
                    return Ok(new CustomerPriceUpdateRestrictionInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetCustomerPriceUpdateRestrictionById(customerPriceUpdateRestriction);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerPriceUpdateRestrictionInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Insert and Update Customer Price Update Restriction
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("InsertandUpdateCustomerPriceUpdateRestriction")]
        public IHttpActionResult InsertandUpdateCustomerPriceUpdateRestriction(CustomerPriceUpdateRestriction customerPriceUpdateRestriction)
        {
            if (customerPriceUpdateRestriction != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerPriceUpdateRestriction.RestrictionId))
                 && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerPriceUpdateRestriction.CreatedBy)))
                {
                    return Ok(new CustomerPriceUpdateRestrictionInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.InsertandUpdateCustomerPriceUpdateRestriction(customerPriceUpdateRestriction);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerPriceUpdateRestrictionInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        
        /// <summary>
        /// API to Insert and Update Customer Price Update Restriction
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("DeleteCustomerPriceUpdateRestriction")]
        public IHttpActionResult DeleteCustomerPriceUpdateRestriction(CustomerPriceUpdateRestriction customerPriceUpdateRestriction)
        {
            if (customerPriceUpdateRestriction != null)
            {
                if (string.IsNullOrEmpty(customerPriceUpdateRestriction.RestrictionIds))                
                {
                    return Ok(new CustomerPriceUpdateRestrictionInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.DeleteCustomerPriceUpdateRestriction(customerPriceUpdateRestriction);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerPriceUpdateRestrictionInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        #endregion

        #region Pricing Matrix Upload
        /// <summary>
        /// API to Upload Pricing Matrix Detail
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("UploadPricingMatrixDetail")]
        public IHttpActionResult UploadPricingMatrixDetail(PricingMatrixUploadInfo matrixUploadInfo)
        {
            var result = pricingMatrixManager.UploadPricingMatrixDetail(matrixUploadInfo);
            return Ok(result);
        }

        /// <summary>
        /// API to Pricing Matrix Upload Create Matrix
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("PricingMatrixUploadCreateMatrix")]
        public IHttpActionResult PricingMatrixUploadCreateMatrix(PricingMatrixUploadInfo matrixUploadInfo)
        {
            if (matrixUploadInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(matrixUploadInfo.MatrixHeaderId)))
                {
                    return Ok(new PricingMatrixUploadInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.PricingMatrixUploadCreateMatrix(matrixUploadInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixUploadInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Pricing Matrix Upload Cancel Upload Process
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("PricingMatrixUploadCancelUploadProcess")]
        public IHttpActionResult PricingMatrixUploadCancelUploadProcess(PricingMatrixUploadInfo matrixUploadInfo)
        {
            if (matrixUploadInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(matrixUploadInfo.MatrixHeaderId)))
                {
                    return Ok(new PricingMatrixUploadInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.PricingMatrixUploadCancelUploadProcess(matrixUploadInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixUploadInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Matrix Detail By MDid
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetMatrixDetailByMDid")]
        public IHttpActionResult GetMatrixDetailByMDid(PricingMatrix_MatrixDetails pricingMatrix_MatrixDetails)
        {
            if (pricingMatrix_MatrixDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrix_MatrixDetails.MDId)))
                {
                    return Ok(new PricingMatrix_MatrixDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetMatrixDetailByMDid(pricingMatrix_MatrixDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrix_MatrixDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Update Imported Matrix Prices By Id
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("UpdateImportedMatrixPricesById")]
        public IHttpActionResult UpdateImportedMatrixPricesById(PricingMatrix_MatrixDetails pricingMatrix_MatrixDetails)
        {
            if (pricingMatrix_MatrixDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrix_MatrixDetails.MDId)))
                {
                    return Ok(new PricingMatrix_MatrixDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.UpdateImportedMatrixPricesById(pricingMatrix_MatrixDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrix_MatrixDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        /// <summary>
        /// API to Process Data Pricing Matrix Detail
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("ProcessDataPricingMatrixDetail")]
        public IHttpActionResult ProcessDataPricingMatrixDetail(PricingMatrixUploadInfo matrixUploadInfo)
        {
            if (matrixUploadInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(matrixUploadInfo.MatrixHeaderId)))
                {
                    return Ok(new PricingMatrixUploadInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.ProcessDataPricingMatrixDetail(matrixUploadInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixUploadInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        #endregion

        #region Pricing Update Upload
        /// <summary>
        /// API to Upload Pricing Matrix Detail
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("UploadPricingUpdatePrices")]
        public IHttpActionResult UploadPricingUpdatePrices(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            var result = pricingMatrixManager.PricingUpdateUploadInsertRawData(pricingUpdateUploadInfo);
            return Ok(result);
        }

        /// <summary>
        /// API to Pricing Update Upload Update Prices
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("PricingUpdateUploadUpdatePrices")]
        public IHttpActionResult PricingUpdateUploadUpdatePrices(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            if (pricingUpdateUploadInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingUpdateUploadInfo.UploadHeaderId)))
                {
                    return Ok(new PriceUpdateUploadInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.PricingUpdateUploadUpdatePrices(pricingUpdateUploadInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PriceUpdateUploadInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Pricing Update Upload Cancel Upload Process
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("PricingUpdateUploadCancelUploadProcess")]
        public IHttpActionResult PricingUpdateUploadCancelUploadProcess(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            if (pricingUpdateUploadInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingUpdateUploadInfo.UploadHeaderId)))
                {
                    return Ok(new PriceUpdateUploadInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.PricingUpdateUploadCancelUploadProcess(pricingUpdateUploadInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PriceUpdateUploadInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get All Price Update Action
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetAllPriceUpdateAction")]
        public IHttpActionResult GetAllPriceUpdateAction()
        {
            return Ok(pricingMatrixManager.GetAllPriceUpdateAction());
        }

        /// <summary>
        /// API to Get Uploaded Data By udid
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetUploadedDataByUdid")]
        public IHttpActionResult GetUploadedDataByUdid(PriceUpdateUploadDetails priceUpdateUploadDetails)
        {
            if (priceUpdateUploadDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(priceUpdateUploadDetails.Udid)))
                {
                    return Ok(new PriceUpdateUploadDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetUploadedDataByUdid(priceUpdateUploadDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PriceUpdateUploadDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        /// <summary>
        /// API to Update Imported Price Update By Id
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("UpdateImportedPriceUpdateById")]
        public IHttpActionResult UpdateImportedPriceUpdateById(PriceUpdateUploadDetails priceUpdateUploadDetails)
        {
            if (priceUpdateUploadDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(priceUpdateUploadDetails.Udid)))
                {
                    return Ok(new PriceUpdateUploadDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.UpdateImportedPriceUpdateById(priceUpdateUploadDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PriceUpdateUploadDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to PricingUpdateProcessData
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("PricingUpdateProcessData")]
        public IHttpActionResult PricingUpdateProcessData(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            if (pricingUpdateUploadInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingUpdateUploadInfo.UploadHeaderId)))
                {
                    return Ok(new PriceUpdateUploadInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.PricingUpdateProcessData(pricingUpdateUploadInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PriceUpdateUploadInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        #endregion

        #region Update Price Contractor/Customer 
        /// <summary>
        /// API to UpdatePrice button 
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("UpdatePrice")]
        public IHttpActionResult UpdatePrice(PricingMatrixSetup pricingMatrixSetup)
        {
            if (pricingMatrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrixSetup.MatrixId))
                    && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingMatrixSetup.CreatedBy)))
                    
                {
                    return Ok(new PricingMatrixSetup
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.UpdatePrice(pricingMatrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixSetup
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to UpdatePrice button 
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("CheckMatrixHeaderForPriceUpdate")]
        public IHttpActionResult CheckMatrixHeaderForPriceUpdate(PricingMatrixSetup pricingMatrixSetup)
        {
            if (pricingMatrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrixSetup.MatrixId))
                   )

                {
                    return Ok(new PricingMatrixSetup
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.CheckMatrixHeaderForPriceUpdate(pricingMatrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixSetup
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to get price update report 
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPriceUpdate_UpdateReport")]
        public IHttpActionResult GetPriceUpdate_UpdateReport(PricingMatrixSetup pricingMatrixSetup)
        {
            if (pricingMatrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrixSetup.ActionHeaderId)))
                    
                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetPriceUpdate_UpdateReport(pricingMatrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to get price update exception report 
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPriceUpdate_ExceptionReport")]
        public IHttpActionResult GetPriceUpdate_ExceptionReport(PricingMatrixSetup pricingMatrixSetup)
        {
            if (pricingMatrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrixSetup.ActionHeaderId)))

                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetPriceUpdate_ExceptionReport(pricingMatrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to get both price update and exception report 
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetBoth_UpdateReportAndExceptionReport")]
        public IHttpActionResult GetBoth_UpdateReportAndExceptionReport(PricingMatrixSetup pricingMatrixSetup)
        {
            if (pricingMatrixSetup != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pricingMatrixSetup.ActionHeaderId)))

                {
                    return Ok(new PricingMatrixInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingMatrixManager.GetBoth_UpdateReportAndExceptionReport(pricingMatrixSetup);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingMatrixInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        #endregion
    }
}
