using System;
using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.Facility;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class FacilityController : ApiController
    {
        private IFacilityManager facilityManager;
        public FacilityController(IFacilityManager manager)
        {
            facilityManager = manager;
        }

        #region Add and Edit FacilityAPIs
        //APIs For Add and Edit Facility Page APIs

        [HttpPost]
        [ActionName("CheckFacilityName")]
        public IHttpActionResult CheckFacilityName(FacilityBasicInfo facilityBasicInfo)
        {
            if (facilityBasicInfo != null)
            {
                if (string.IsNullOrEmpty(facilityBasicInfo.FacilityName))
                {
                    return Ok(new FacilityBasicInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.CheckFacilityName(facilityBasicInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityBasicInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetFacilityType")]
        public IHttpActionResult GetFacilityType()
        {
            return Ok(facilityManager.GetFacilityType());
        }

        [HttpPost]
        [ActionName("GetFacilityInfobyFacilityId")]
        public IHttpActionResult GetFacilityInfobyFacilityId(FacilityBasicInfo facilityBasicInfo)
        {
            if (facilityBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(facilityBasicInfo.FacilityId)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetFacilityInfobyFacilityId(facilityBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetWasteTypeHistorybyWasteTypeId")]
        public IHttpActionResult GetWasteTypeHistorybyWasteTypeId(FacilityWasteTypeHistory facilityWasteTypeHistory)
        {
            if (facilityWasteTypeHistory != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(facilityWasteTypeHistory.WasteTypeInfo.WasteTypeId)) && FieldValidator.NumberValidatorWithZero(Convert.ToString(facilityWasteTypeHistory.FacilityBasicInfo.FacilityId)))
                {
                    return Ok(new FacilityWasteTypeHistory
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetWasteTypeHistorybyWasteTypeId(facilityWasteTypeHistory);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityWasteTypeHistory
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetMaterialTypeHistorybyMaterialTypeId")]
        public IHttpActionResult GetMaterialTypeHistorybyMaterialTypeId(FacilityMaterialTypeHistory facilityMaterialTypeHistory)
        {
            if (facilityMaterialTypeHistory != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(facilityMaterialTypeHistory.MaterialTypeInfo.MaterialTypeId)) && FieldValidator.NumberValidatorWithZero(Convert.ToString(facilityMaterialTypeHistory.FacilityBasicInfo.FacilityId)))
                {
                    return Ok(new FacilityMaterialTypeHistory
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetMaterialTypeHistorybyMaterialTypeId(facilityMaterialTypeHistory);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityMaterialTypeHistory
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("AddFacilityInfo")]
        public IHttpActionResult AddFacilityInfo(FacilityBasicInfo facility)
        {
            if (facility != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(facility.FacilityId)))
                {
                    return Ok(new FacilityBasicInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.AddFacilityInfo(facility);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityBasicInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("AddUpdateWasteTypePercentage")]
        public IHttpActionResult AddUpdateWasteTypePercentage(FacilityInfo facilityInfo)
        {
            if (facilityInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(facilityInfo.facilityBasicInfo.CreatedBy)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.AddUpdateWasteTypePercentage(facilityInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("InsertUpdateMaterialTypePercentage")]
        public IHttpActionResult InsertUpdateMaterialTypePercentage(FacilityInfo facilityInfo)
        {
            if (facilityInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(facilityInfo.facilityBasicInfo.CreatedBy)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.InsertUpdateMaterialTypePercentage(facilityInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        #endregion

        #region Facility Dashboard APIs
        //Facility Dashboard APIs
        [HttpPost]
        [ActionName("GetAllFacilityList")]
        public IHttpActionResult GetAllFacilityList()
        {
            return Ok(facilityManager.GetAllFacilityList());
        }

        [HttpPost]
        [ActionName("GetOverviewDetails")]
        public IHttpActionResult GetOverviewDetails()
        {
            return Ok(facilityManager.GetOverviewDetails());
        }

        [HttpPost]
        [ActionName("GetCountbyFacilityType")]
        public IHttpActionResult GetCountbyFacilityType()
        {
            return Ok(facilityManager.GetCountbyFacilityType());
        }

        #endregion

        #region Contractor Allocation to Facility APIs
        //Contractor Allocation to Facility APIs
        [HttpPost]
        [ActionName("GetNonAllocatedContractorsByFacilityId")]
        public IHttpActionResult GetNonAllocatedContractorsByFacilityId(FacilityAllocatedContractors allocatedContractors)
        {
            if (allocatedContractors != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(allocatedContractors.FacilityId)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetNonAllocatedContractorsByFacilityId(allocatedContractors);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetAllocatedContractorsByFacilityId")]
        public IHttpActionResult GetAllocatedContractorsByFacilityId(FacilityAllocatedContractors allocatedContractors)
        {
            if (allocatedContractors != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(allocatedContractors.FacilityId)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetAllocatedContractorsByFacilityId(allocatedContractors);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("InsertContractorAllocation")]
        public IHttpActionResult InsertContractorAllocation(FacilityAllocatedContractors allocatedContractors)
        {
            if (allocatedContractors != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(allocatedContractors.FacilityId)) &&
                    FieldValidator.NumberValidatorWithZero(Convert.ToString(allocatedContractors.CreatedBy)) &&
                    string.IsNullOrEmpty(allocatedContractors.ContractorIds))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.InsertContractorAllocation(allocatedContractors);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("RemoveContractorAllocation")]
        public IHttpActionResult RemoveContractorAllocation(FacilityAllocatedContractors allocatedContractors)
        {

            if (allocatedContractors != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(allocatedContractors.FacilityId)) &&
                    string.IsNullOrEmpty(allocatedContractors.ContractorIds))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.RemoveContractorAllocation(allocatedContractors);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        #endregion

        #region Contractor-Depot Allocation to Facility APIs
        //Contractor-Depot Allocation to Facility APIs
        [HttpPost]
        [ActionName("GetNonAllocatedDepotsByContractorId")]
        public IHttpActionResult GetNonAllocatedDepotsByContractorId(ContractorDepots contractorDepots)
        {
            if (contractorDepots != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorDepots.FacilityId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorDepots.ContractorId)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetNonAllocatedDepotsByContractorId(contractorDepots);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetAllocatedDepotsByContractorId")]
        public IHttpActionResult GetAllocatedDepotsByContractorId(ContractorDepots contractorDepots)
        {
            if (contractorDepots != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorDepots.FacilityId)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetAllocatedDepotsByContractorId(contractorDepots);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("InsertDepotAllocation")]
        public IHttpActionResult InsertDepotAllocation(ContractorDepots contractorDepots)
        {
            if (contractorDepots != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorDepots.FacilityId)) &&
                FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorDepots.FacilityId)) &&
                    FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorDepots.CreatedBy)) &&
                    string.IsNullOrEmpty(contractorDepots.Contractor_DepotIDs))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.InsertDepotAllocation(contractorDepots);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("RemoveDepotAllocation")]
        public IHttpActionResult RemoveDepotAllocation(ContractorDepots contractorDepots)
        {

            if (contractorDepots != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorDepots.FacilityId)) &&
                FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorDepots.ContractorId)) &&
                   string.IsNullOrEmpty(contractorDepots.Contractor_DepotIDs))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.RemoveDepotAllocation(contractorDepots);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        #endregion

        #region Facility Licence Document APIs 
        //Facility Licence Document APIs
        [HttpPost]
        [ActionName("GetDocumentTypesByFacilityId")]
        public IHttpActionResult GetDocumentTypesByFacilityId(DocumentInfo documentInfo)
        {
            if (documentInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.FacilityId)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetDocumentTypesByFacilityId(documentInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetLicenceDocumentsByDocumentTypeId")]
        public IHttpActionResult GetLicenceDocumentsByDocumentTypeId(DocumentInfo documentInfo)
        {
            if (documentInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.DocumentTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.FacilityId)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetLicenceDocumentsByDocumentTypeId(documentInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetLicenceDocumentsArchivedByDocumentTypeId")]
        public IHttpActionResult GetLicenceDocumentsArchivedByDocumentTypeId(DocumentInfo documentInfo)
        {
            if (documentInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.DocumentTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.FacilityId)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.GetLicenceDocumentsArchivedByDocumentTypeId(documentInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("InsertFacilityDocument")]
        public IHttpActionResult InsertFacilityDocument(DocumentInfo documentInfo)
        {
            if (documentInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.FacilityId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.Facility_LicenceDocumentId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.DocumentTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.CreatedBy)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.InsertFacilityDocument(documentInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("DeleteLicenceDocumentById")]
        public IHttpActionResult DeleteLicenceDocumentById(DocumentInfo documentInfo)
        {
            if (documentInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.DocumentTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.FacilityId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.CreatedBy)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.DeleteLicenceDocumentById(documentInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("DeleteLicenceDocumentsByDocumentTypeId")]
        public IHttpActionResult DeleteLicenceDocumentsByDocumentTypeId(DocumentInfo documentInfo)
        {
            if (documentInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.DocumentTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.FacilityId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.CreatedBy)))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = facilityManager.DeleteLicenceDocumentsByDocumentTypeId(documentInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new FacilityInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        #endregion


    }
}