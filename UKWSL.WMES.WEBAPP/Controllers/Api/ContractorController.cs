using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.Contractors;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class ContractorController : ApiController
    {
        private IContractorManager contractorManager;

        public ContractorController(IContractorManager manager)
        {
            contractorManager = manager;
        }
        /// <summary>
        /// API to get contractor dashboard data 
        /// </summary>
        /// Delivery Point: Dp4.1
        [HttpPost]
        [ActionName("GetContractorDashboardOverView")]
        public IHttpActionResult GetContractorDashboardOverView(CompanyInfo companyInfo)
        {
            return Ok(contractorManager.GetContractorDashboardOverView(companyInfo));
        }

        /// <summary>
        /// API to get all contractor list
        /// </summary>
        /// Delivery Point: Dp4.1
        [HttpPost]
        [ActionName("GetAllContractorList")]
        public IHttpActionResult GetAllContractorList(CompanyInfo companyInfo)
        {
            return Ok(contractorManager.GetAllContractorList(companyInfo));
        }


        /// <summary>
        /// API to get contractor type list 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorType")]
        public IHttpActionResult GetContractorType()
        {
            return Ok(contractorManager.GetContractorType());
        }

        /// <summary>
        /// API to get AnnualTurnOver list 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorAnnualTurnOver")]
        public IHttpActionResult GetContractorAnnualTurnOver()
        {
            return Ok(contractorManager.GetContractorAnnualTurnOver());
        }

        /// <summary>
        /// API to get Approval Status list 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorApprovalStatus")]
        public IHttpActionResult GetContractorApprovalStatus()
        {
            return Ok(contractorManager.GetContractorApprovalStatus());
        }

        /// <summary>
        /// API to get contractor Status list 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorStatus")]
        public IHttpActionResult GetContractorStatus()
        {
            return Ok(contractorManager.GetContractorStatus());
        }

        /// <summary>
        /// API to get WeightResponsibility list 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetWeightResponsibility")]
        public IHttpActionResult GetWeightResponsibility()
        {
            return Ok(contractorManager.GetWeightResponsibility());
        }

        /// <summary>
        /// API to get Company Type
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetCompanyType")]
        public IHttpActionResult GetCompanyType()
        {
            return Ok(contractorManager.GetCompanyType());
        }

        /// <summary>
        /// API to get regions list 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetRegionDetails")]
        public IHttpActionResult GetRegionDetails()
        {
            return Ok(contractorManager.GetRegionDetails());
        }

        /// <summary>
        /// API to get Contractor All Info by ContractorID
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorAllInfobyContractorId")]
        public IHttpActionResult GetContractorAllInfobyContractorId(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetContractorAllInfobyContractorId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to create and update contractor basic info 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("CreateUpdateContractorBasicInfo")]
        public IHttpActionResult CreateUpdateContractorBasicInfo(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorBasicInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.CreateUpdateContractorBasicInfo(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorBasicInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to create and update contractor Admin Setting 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("CreateUpdateContractorAdminSetting")]
        public IHttpActionResult CreateUpdateContractorAdminSetting(ContractorAdminSetting contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.Contractor_AdminSettingsId)))
                {
                    return Ok(new ContractorAdminSetting
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.CreateUpdateContractorAdminSetting(contractor);
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

        /// <summary>
        /// API to create and update contractor Comments Details 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("CreateUpdateContractorComments")]
        public IHttpActionResult CreateUpdateContractorComments(ContractorComments contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ConCommentId)))
                {
                    return Ok(new ContractorAdminSetting
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.CreateUpdateContractorComments(contractor);
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

        /// <summary>
        /// API to Get Contractor Contact Type
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorContactType")]
        public IHttpActionResult GetContractorContactType()
        {
            return Ok(contractorManager.GetContractorContactType());
        }

        /// <summary>
        /// API to get Contractor Legal Basis
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorLegalBasis")]
        public IHttpActionResult GetContractorLegalBasis()
        {
            return Ok(contractorManager.GetContractorLegalBasis());
        }

        /// <summary>
        /// API to Get all COntacts by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetAllContactsbyContractorId")]
        public IHttpActionResult GetAllContactsbyContractorId(ContractorContact contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetAllContactsbyContractorId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Contractor Contacts by ContactId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorContactsbyContactId")]
        public IHttpActionResult GetContractorContactsbyContactId(ContractorContact contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetContractorContactsbyContactId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to create and update contractor Contact
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("CreateUpdateContractorContact")]
        public IHttpActionResult CreateUpdateContractorContact(ContractorContact contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorContact
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.CreateUpdateContractorContact(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorContact
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to get Active Contacts by Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetActiveContactstsByContractor")]
        public IHttpActionResult GetActiveContactstsByContractor(ContractorContact contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetActiveContactstsByContractor(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to get COntractor Depots by ContactId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorDepotsbyContactId")]
        public IHttpActionResult GetContractorDepotsbyContactId(ContractorDepots contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetContractorDepotsbyContactId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to create and update contractor Depots 
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("CreateUpdateContractorDepots")]
        public IHttpActionResult CreateUpdateContractorDepots(ContractorInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.contractorDepots.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.CreateUpdateContractorDepots(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to Check Company Name
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("CheckCompanyName")]
        public IHttpActionResult CheckCompanyName(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (string.IsNullOrEmpty(contractor.CompanyName))
                {
                    return Ok(new Sites
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.CheckCompanyName(contractor);
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


        //[HttpPost]
        //[ActionName("DeleteContractorContacts")]
        //public IHttpActionResult DeleteContractorContacts(ContractorContact contractor)
        //{
        //    if (contractor != null)
        //    {
        //        if (string.IsNullOrEmpty(contractor.Contractor_ContactIds)
        //            || FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
        //        {
        //            return Ok(new ContractorContact
        //            {
        //                Status = Status.Failed,
        //                Message = Messages.MissingFields
        //            }); ;
        //        }
        //        else
        //        {
        //            var result = contractorManager.DeleteContractorContacts(contractor);
        //            return Ok(result);
        //        }
        //    }
        //    else
        //    {
        //        return Ok(new ContractorContact
        //        {
        //            Status = Status.Failed,
        //            Message = Messages.MissingFields
        //        });
        //    }
        //}

        /// <summary>
        /// API to Delete Contractor Contacts
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("DeleteContractorContacts")]
        public IHttpActionResult DeleteContractorContacts(ContractorContact contractorContact)
        {
            if (contractorContact != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorContact.Contractor_ContactId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.DeleteContractorContacts(contractorContact);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Bulk Delete Contractor COntacts
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("BulkDeleteContractorContacts")]
        public IHttpActionResult BulkDeleteContractorContacts(List<ContractorContact> lstContractorContact)
        {

            if (lstContractorContact != null)
            {
                var result = contractorManager.BulkDeleteContractorContacts(lstContractorContact);
                result.Status = Status.Success;
                return Ok(result);
            }
            else
            {
                return Ok(new ContractorContact
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Contractor Depots by DepotId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorDepotsbyDepotId")]
        public IHttpActionResult GetContractorDepotsbyDepotId(ContractorDepots contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetContractorDepotsbyDepotId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        /// <summary>
        /// API to Delete Contractor Depots
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("DeleteContractorDepots")]
        public IHttpActionResult DeleteContractorDepots(ContractorDepots contractor)
        {
            if (contractor != null)
            {
                if (string.IsNullOrEmpty(contractor.Contractor_DepotIDs)
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorDepots
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.DeleteContractorDepots(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorDepots
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to get Allocated Facilities by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetAllocatedFacilitiesByContractorId")]
        public IHttpActionResult GetAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetAllocatedFacilitiesByContractorId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Remove Ficility Allocation
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("RemoveFacilityAllocation")]
        public IHttpActionResult RemoveFacilityAllocation(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.RemoveFacilityAllocation(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Insert Facility Allocation
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("InsertFacilityAllocation")]
        public IHttpActionResult InsertFacilityAllocation(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)) &&
                    FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.CreatedBy)) &&
                    string.IsNullOrEmpty(contractor.FacilityIds))
                {
                    return Ok(new FacilityInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.InsertFacilityAllocation(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to get Document Type
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetDocumentType")]
        public IHttpActionResult GetDocumentType()
        {
            return Ok(contractorManager.GetDocumentTypes());
        }

        /// <summary>
        /// API to get all Documents by Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetAllDocumentsByContractor")]
        public IHttpActionResult GetAllDocumentsByContractor(ContractorBasicInfo contractorBasicInfo)
        {
            if (contractorBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(contractorBasicInfo.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetAllDocumentsByContractor(contractorBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to create and update Document Information
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("CreateUpdateDocumentInfo")]
        public IHttpActionResult CreateUpdateDocumentInfo(DocumentInfo documentInfo)
        {
            if (documentInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.DocumentTypeId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(documentInfo.CustomerId)))
                {
                    return Ok(new DocumentInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.CreateUpdateDocumentInfo(documentInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DocumentInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get UnAlloated Facility by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetUnAllocatedFacilitiesByContractorId")]
        public IHttpActionResult GetUnAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetUnAllocatedFacilitiesByContractorId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to get pricing matrix list by contractorId
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPricingMatrixListByContractorId")]
        public IHttpActionResult GetPricingMatrixListByContractorId(ContractorBasicInfo contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorManager.GetPricingMatrixListByContractorId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
    }

}
