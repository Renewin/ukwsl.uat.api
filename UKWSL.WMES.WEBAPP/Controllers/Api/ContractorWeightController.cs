using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.ContractorWeight;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;
namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class ContractorWeightController : ApiController
    {
        private IContractorWeightManager contractorWeightManager;

        public ContractorWeightController(IContractorWeightManager manager)
        {
            contractorWeightManager = manager;
        }

        /// <summary>
        /// API to Get all Service Weights by ContractorId
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("GetAllServiceWeightsbyContractorId")]
        public IHttpActionResult GetAllServiceWeightsbyContractorId(ServiceJobDetails serviceJobDetails)
        {
            if (serviceJobDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(serviceJobDetails.ContractorId)))
                {
                    return Ok(new ContractorWeightInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.GetAllServiceWeightsbyContractorId(serviceJobDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorWeightInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get all Customers by ContractorId
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("GetAllCustomersbyContractorId")]
        public IHttpActionResult GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerBasicInfo.ContractorId)))
                {
                    return Ok(new ContractorWeightInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.GetAllCustomersbyContractorId(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorWeightInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get all Service Weights by ContractorId
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("GetAllServiceSitesbyContractorId")]
        public IHttpActionResult GetAllServiceSitesbyContractorId(ServiceSite serviceSite)
        {
            if (serviceSite != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(serviceSite.ContractorId)))
                {
                    return Ok(new ContractorWeightInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.GetAllServiceSitesbyContractorId(serviceSite);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorWeightInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get all Actual Weights by Job Id and ServiceType Id
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("GetActualWeightDetailsByJobId")]
        public IHttpActionResult GetActualWeightDetailsByJobId(ServiceBasicInfo serviceBasicInfo)
        {
            if (serviceBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(serviceBasicInfo.JobId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(serviceBasicInfo.ServiceTypeId)))
                {
                    return Ok(new ContractorWeightInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.GetActualWeightDetailsByJobId(serviceBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorWeightInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to create and update contractor Admin Setting 
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("CreateUpdateServiceActualWeight")]
        public IHttpActionResult CreateUpdateServiceActualWeight(ServiceJobDetails serviceJobDetails)
        {
            if (serviceJobDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(serviceJobDetails.AWId)))
                {
                    return Ok(new ServiceJobDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.CreateUpdateServiceActualWeight(serviceJobDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceJobDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to Upload Import Actual Weight CSV Raw Data
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("UploadImportActualWeightCSVRawData")]
        public IHttpActionResult UploadImportActualWeightCSVRawData(ContractorWeightInfo contractorWeightInfo)
        {
            var result = contractorWeightManager.UploadImportActualWeightCSVRawData(contractorWeightInfo);
            return Ok(result);
        }

        /// <summary>
        /// API to get all Import Actual Weight list
        /// </summary>
        /// Delivery Point: Dp4.9
        [HttpPost]
        [ActionName("GetAllImportActualWeights")]
        public IHttpActionResult GetAllImportActualWeights(ImportActualWeight importActualWeight)
        {
            return Ok(contractorWeightManager.GetAllImportActualWeights(importActualWeight));
        }

        /// <summary>
        /// API to insert Import actual weight excel
        /// Delivery Point: DP 4.9
        /// </summary>
        [HttpPost]
        [ActionName("InsertUploadedImportActualWeightData")]
        public IHttpActionResult InsertUploadedImportActualWeightData(ContractorWeightInfo contractorWeightInfo)
        {
            var result = contractorWeightManager.InsertUploadedImportActualWeightData(contractorWeightInfo);
            return Ok(result);
        }

        /// <summary>
        /// API to Cancel Inserting Import Actual Weight Data
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("CancelInsertUploadedImportActualWeightData")]
        public IHttpActionResult CancelInsertUploadedImportActualWeightData(ContractorWeightInfo contractorWeightInfo)
        {
            var result = contractorWeightManager.CancelInsertUploadedImportActualWeightData(contractorWeightInfo);
            return Ok(result);
        }

        /// <summary>
        /// API to Get All Service Pending Report
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("GetAllServicePendingReport")]
        public IHttpActionResult GetAllServicePendingReport(ImportActualWeight importActualWeight)
        {
            if (importActualWeight != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(importActualWeight.ContractorId)))
                {
                    return Ok(new ContractorWeightInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.GetAllServicePendingReport(importActualWeight);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorWeightInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get all Service Affected Report from Import
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("GetAllServiceAffectedFromImport")]
        public IHttpActionResult GetAllServiceAffectedFromImport(ImportActualWeight importActualWeight)
        {
            if (importActualWeight != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(importActualWeight.ContractorId)))
                {
                    return Ok(new ContractorWeightInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.GetAllServiceAffectedFromImport(importActualWeight);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorWeightInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Imported Weight by Id
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("GetImportedWeightById")]
        public IHttpActionResult GetImportedWeightById(ImportActualWeight importActualWeight)
        {
            if (importActualWeight != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(importActualWeight.Id)))
                {
                    return Ok(new ImportActualWeight
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.GetImportedWeightById(importActualWeight);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ImportActualWeight
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to update Import Weight by Id
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("UpdateImportedWeightById")]
        public IHttpActionResult UpdateImportedWeightById(ImportActualWeight importActualWeight)
        {
            if (importActualWeight != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(importActualWeight.Id)))
                {
                    return Ok(new ImportActualWeight
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.UpdateImportedWeightById(importActualWeight);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ImportActualWeight
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to Process Import Actual Weight 
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("ProcessImportActualWeight")]
        public IHttpActionResult ProcessImportActualWeight(ContractorWeightInfo contractorWeightInfo)
        {
            var result = contractorWeightManager.ProcessImportActualWeight(contractorWeightInfo);
            return Ok(result);
        }

        /// <summary>
        /// API to Confirm Pending Services
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("PendingServiceConfirmed")]
        public IHttpActionResult PendingServiceConfirmed(ImportActualWeight importActualWeight)
        {
            if (importActualWeight != null)
            {
                if (string.IsNullOrEmpty(importActualWeight.JobIds)
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(importActualWeight.JobId)))
                {
                    return Ok(new ImportActualWeight
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.PendingServiceConfirmed(importActualWeight);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ImportActualWeight
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get all office contacts from Contractor Contacts
        /// </summary>
        /// Delivery Point: DP4.9
        [HttpPost]
        [ActionName("GetContractorOfficeContact")]
        public IHttpActionResult GetContractorOfficeContact(ContractorContact contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorWeightInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorWeightManager.GetContractorOfficeContact(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorWeightInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
    }
}
