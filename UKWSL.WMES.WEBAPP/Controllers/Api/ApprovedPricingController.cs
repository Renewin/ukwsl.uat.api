using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.ApprovedPricing;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class ApprovedPricingController : ApiController
    {
        private IApprovedPricingManager approvedPricingManager;

        public ApprovedPricingController(IApprovedPricingManager manager)
        {
            approvedPricingManager = manager;
        }


        /// <summary>
        /// API to upload approved pricing excel
        /// Delivery Point: DP3.2. DP4.3 & DP4.4 Changes
        /// </summary>
        [HttpPost]
        [ActionName("UploadApprovedPricingSolution")]
        public IHttpActionResult UploadApprovedPricingSolution(SOSInfo sOSInfo)
        {
            var result = approvedPricingManager.UploadApprovedPricingSolutionCSVRawData(sOSInfo);
            return Ok(result);
        }
        /// <summary>
        /// API to insert approved pricing excel
        /// Delivery Point: DP3.2. DP4.3 & DP4.4 Changes
        /// </summary>
        [HttpPost]
        [ActionName("InsertUploadedApprovedPricingSolution")]
        public IHttpActionResult InsertUploadedApprovedPricingSolution(SOSInfo sOSInfo)
        {
            var result = approvedPricingManager.InsertUploadedApprovedPricingSolutionData(sOSInfo);
            return Ok(result);
        }
        /// <summary>
        /// API to insert approved pricing excel
        /// Delivery Point: DP3.2. DP4.3 & DP4.4 Changes
        /// </summary>
        [HttpPost]
        [ActionName("UpdateAPIdStatus")]
        public IHttpActionResult UpdateAPIdStatus(ApprovedPricingSolution approvedPricingSolution)
        {
            var result = approvedPricingManager.UpdateAPIdStatus(approvedPricingSolution);
            return Ok(result);
        }

        /// <summary>
        /// API to insert approved pricing excel
        /// Delivery Point: DP3.2. DP4.3 & DP4.4 Changes
        /// </summary>
        [HttpPost]
        [ActionName("GetProcessedAPSData")]
        public IHttpActionResult GetProcessedAPSData(SOSInfo sOSInfo)
        {
            var result = approvedPricingManager.GetProcessedAPSData(sOSInfo);
            return Ok(result);
        }
        /// <summary>
        /// API to get approved pricing 
        /// Delivery Point: DP3.2. DP4.3 & DP4.4 Changes
        /// </summary>
        [HttpPost]
        [ActionName("GetApprovedPricingDataByDealIdCompanyId")]
        public IHttpActionResult GetApprovedPricingDataByDealIdCompanyId(SOSInfo sOSInfo)
        {
            if (sOSInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.DealId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.CompanyId)))
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.GetApprovedPricingDataByDealIdCompanyId(sOSInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to add/update approved pricing for sales
        /// Delivery Point: DP3.2. DP4.3 & DP4.4 Changes
        /// </summary>
        [HttpPost]
        [ActionName("AddUpdateApprovedPricingSolution")]
        public IHttpActionResult AddUpdateApprovedPricingSolution(SOSInfo sOSInfo)
        {
            if (sOSInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.ApprovedPricingId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.DealId))
                     || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.CompanyId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.CreatedBy))
                    )
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.AddUpdateApprovedPricingSolution(sOSInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to add/update approved pricing for mobilization
        /// Delivery Point: DP3.2. DP4.3 & DP4.4 Changes
        /// </summary>
        [HttpPost]
        [ActionName("AddUpdateApprovedPricingSolutionByMobilization")]
        public IHttpActionResult AddUpdateApprovedPricingSolutionByMobilization(SOSInfo sOSInfo)
        {
            if (sOSInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.ApprovedPricingId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.DealId))
                     || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.CompanyId))
                    )
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.AddUpdateApprovedPricingSolutionByMobilization(sOSInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to delete approved pricing
        /// Delivery Point: DP3.2. DP4.3 & DP4.4 Changes
        /// </summary>
        [HttpPost]
        [ActionName("DeleteApprovedPricingSolution")]
        public IHttpActionResult DeleteApprovedPricingSolution(SOSInfo sOSInfo)
        {
            if (sOSInfo.ApprovedPricingSolution != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(sOSInfo.ApprovedPricingSolution.Id)))
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.DeleteApprovedPricingSolution(sOSInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }
        /// <summary>
        /// API to get Account details for edit functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("GetApprovedPricingAccountbyAccountNumber")]
        public IHttpActionResult GetApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution)
        {
            if (approvedPricingSolution != null)
            {
                if (string.IsNullOrEmpty(approvedPricingSolution.AccountNumber))
                {
                    return Ok(new ApprovedPricingSolution
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.GetApprovedPricingAccountbyAccountNumber(approvedPricingSolution);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to get Sites details for edit functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("GetApprovedPricingSitesbySiteCode")]
        public IHttpActionResult GetApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution)
        {
            if (approvedPricingSolution != null)
            {
                if (string.IsNullOrEmpty(approvedPricingSolution.Sitecode)
                    || string.IsNullOrEmpty(approvedPricingSolution.Sitename))
                {
                    return Ok(new ApprovedPricingSolution
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.GetApprovedPricingSitesbySiteCode(approvedPricingSolution);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to get Contact details for edit functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("GetApprovedPricingContactsByEmail")]
        public IHttpActionResult GetApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution)
        {
            if (approvedPricingSolution != null)
            {
                if (string.IsNullOrEmpty(approvedPricingSolution.MainEmailAddress)
                    || string.IsNullOrEmpty(approvedPricingSolution.ContactNumber))
                {
                    return Ok(new ApprovedPricingSolution
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.GetApprovedPricingContactsByEmail(approvedPricingSolution);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to update Account details for update functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("UpdateApprovedPricingAccount")]
        public IHttpActionResult UpdateApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution)
        {
            if (approvedPricingSolution != null)
            {
                if (string.IsNullOrEmpty(approvedPricingSolution.AccountNumber))
                {
                    return Ok(new ApprovedPricingSolution
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.UpdateApprovedPricingAccountbyAccountNumber(approvedPricingSolution);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to update Contact details for update functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("UpdateApprovedPricingSites")]
        public IHttpActionResult UpdateApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution)
        {
            if (approvedPricingSolution != null)
            {
                if (string.IsNullOrEmpty(approvedPricingSolution.Sitecode)
                    || string.IsNullOrEmpty(approvedPricingSolution.Sitename))
                {
                    return Ok(new ApprovedPricingSolution
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.UpdateApprovedPricingSitesbySiteCode(approvedPricingSolution);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to update Contact details for update functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("UpdateApprovedPricingContacts")]
        public IHttpActionResult UpdateApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution)
        {
            if (approvedPricingSolution != null)
            {
                if (string.IsNullOrEmpty(approvedPricingSolution.MainEmailAddress)
                    || string.IsNullOrEmpty(approvedPricingSolution.ContactNumber)
                    )
                {
                    return Ok(new ApprovedPricingSolution
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.UpdateApprovedPricingContactsByEmail(approvedPricingSolution);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to delete Account details for delete functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("DeleteApprovedPricingAccount")]
        public IHttpActionResult DeleteApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution)
        {
            if (approvedPricingSolution != null)
            {
                if (string.IsNullOrEmpty(approvedPricingSolution.AccountNumber))
                {
                    return Ok(new ApprovedPricingSolution
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.DeleteApprovedPricingAccountbyAccountNumber(approvedPricingSolution);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to delete Site details for delete functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("DeleteApprovedPricingSite")]
        public IHttpActionResult DeleteApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution)
        {
            if (approvedPricingSolution != null)
            {
                if (string.IsNullOrEmpty(approvedPricingSolution.Sitecode)
                    || string.IsNullOrEmpty(approvedPricingSolution.Sitename))
                {
                    return Ok(new ApprovedPricingSolution
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.DeleteApprovedPricingSitesbySiteCode(approvedPricingSolution);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to delete Contact details for delete functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("DeleteApprovedPricingContact")]
        public IHttpActionResult DeleteApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution)
        {
            if (approvedPricingSolution != null)
            {
                if (string.IsNullOrEmpty(approvedPricingSolution.MainEmailAddress)
                    || string.IsNullOrEmpty(approvedPricingSolution.ContactNumber))
                {
                    return Ok(new ApprovedPricingSolution
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = approvedPricingManager.DeleteApprovedPricingContactsByEmail(approvedPricingSolution);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to delete approved pricing
        /// Delivery Point: Dp3.2
        /// </summary>
        [HttpPost]
        [ActionName("BulkDeleteApprovedPricingSolution")]
        public IHttpActionResult BulkDeleteApprovedPricingSolution(SOSInfo sOSInfo)
        {
            if (sOSInfo.lstApprovedPricingSolution != null)
            {
                var result = approvedPricingManager.BulkDeleteApprovedPricingSolution(sOSInfo);
                return Ok(result);
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to delete Account details for delete functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("BulkDeleteApprovedPricingAccountbyAccountNumber")]
        public IHttpActionResult BulkDeleteApprovedPricingAccountbyAccountNumber(List<ApprovedPricingSolution>  lstApprovedPricingSolution)
        {

            if (lstApprovedPricingSolution != null)
            {
                var result = approvedPricingManager.BulkDeleteApprovedPricingAccountbyAccountNumber(lstApprovedPricingSolution);
                result.Status = Status.Success;
                return Ok(result);
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to delete Site details for delete functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("BulkDeleteApprovedPricingSitesbySiteCode")]
        public IHttpActionResult BulkDeleteApprovedPricingSitesbySiteCode(List<ApprovedPricingSolution> lstApprovedPricingSolution)
        {
            if (lstApprovedPricingSolution != null)
            {
                var result = approvedPricingManager.BulkDeleteApprovedPricingSitesbySiteCode(lstApprovedPricingSolution);
                result.Status = Status.Success;
                return Ok(result);
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to delete Contact details for delete functionality
        /// Delivery Point: Dp4.2
        /// </summary>
        [HttpPost]
        [ActionName("BulkDeleteApprovedPricingContact")]
        public IHttpActionResult BulkDeleteApprovedPricingContactsByEmail(List<ApprovedPricingSolution> lstApprovedPricingSolution)
        {
            if (lstApprovedPricingSolution != null)
            {
                var result = approvedPricingManager.BulkDeleteApprovedPricingContactsByEmail(lstApprovedPricingSolution);
                result.Status = Status.Success;
                return Ok(result);
            }
            else
            {
                return Ok(new ApprovedPricingSolution
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
    }
}
