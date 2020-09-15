using System;
using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.ScheduleOfService;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;
using System.Web;
using System.Net.Http;
using System.Net;
using UKWSL.WMES.Business.Pricing;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class PricingController : ApiController
    {

        private IPricingOptimizationManager pricingOptimizationManager;

        public PricingController(IPricingOptimizationManager manager)
        {
            pricingOptimizationManager = manager;
        }


        [HttpPost]
        [ActionName("GetContractorPrice")]
        public IHttpActionResult GetContractorPrice(PricingInfo pricingInfo)
        {

            if (pricingInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingInfo.DealId)) || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingInfo.SOSHeaderId)))
                {
                    return Ok(new PricingInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingOptimizationManager.GetContractorPrice(pricingInfo);
                   return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetPricingDeals")]
        public IHttpActionResult GetPricingDeals(CompanyInfo companyInfo)
        {

            if (companyInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(companyInfo.CompanyId)) )
                {
                    return Ok(new PricingInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingOptimizationManager.GetPricingDeals(companyInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("UploadPricingCsv")]
        public IHttpActionResult UploadPricingCsv(PricingInfo pricingInfo)
        {
            if (pricingInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingInfo.SOSHeaderId)))
                {
                    return Ok(new PricingInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingOptimizationManager.UploadPricingCsv(pricingInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetPreferredContractorPrice")]
        public IHttpActionResult  GetPreferredContractorPrice(PricingInfo pricingInfo)
        {
            if (pricingInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(pricingInfo.PCId)))
                {
                    return Ok(new PricingInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingOptimizationManager.GetPreferredContractorPrice(pricingInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("UpdateContractorPrice")]
        public IHttpActionResult UpdateContractorPrice(PreferredContractorPrice contractorPrice)
        {

            if (contractorPrice != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(contractorPrice.PCId)))
                {
                    return Ok(new PricingInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = pricingOptimizationManager.UpdateContractorPrice(contractorPrice); 
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new PricingInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        [HttpPost]
        [ActionName("UploadOptimalSOS")]
        public IHttpActionResult UploadOptimalSOS(SOSInfo sOSInfo)
        {
            var result = pricingOptimizationManager.UploadCSVRawData(sOSInfo.scheduleofServices, sOSInfo.sOSFileDetails, sOSInfo.sOSUDTFileData);

            return Ok(result);
        }

        [HttpPost]
        [ActionName("InsertUploadedData")]
        public IHttpActionResult InsertUploadedData(SOSInfo sOSInfo)
        {
            var result = pricingOptimizationManager.InsertUploadedData(sOSInfo);
            return Ok(result);
        }
    }
}
