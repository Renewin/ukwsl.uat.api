using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.Customer;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    //  [Authorize]
    public class DealController : ApiController
    {

        private IDealManager dealManager;
        public DealController(IDealManager manager)
        {
            dealManager = manager;
        }


        [HttpPost]
        [ActionName("CreateDeal")]
        public IHttpActionResult CreateDeal(Deal deal)
        {
            if (deal != null)
            {
                if (string.IsNullOrEmpty(deal.DealId) || string.IsNullOrEmpty(deal.CompanyName) || string.IsNullOrEmpty(Convert.ToString(deal.ContractStartDate)) || string.IsNullOrEmpty(Convert.ToString(deal.ContractEndDate)) || FieldValidator.DecimalValidator(Convert.ToString(deal.DealAmount)) || FieldValidator.NumberValidatorWithZero(Convert.ToString(deal.SalesOwnerId)) || FieldValidator.NumberValidatorWithZero(Convert.ToString(deal.ContractDuration)))
                {
                    return Ok(new Deal
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = dealManager.CreateDeal(deal);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Deal
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }



        [HttpPost]
        [ActionName("CheckDeal")]
        public IHttpActionResult CheckDeal(Deal deal)
        {
            if (deal != null)
            {
                if (string.IsNullOrEmpty(deal.DealId) || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(deal.CompanyId)))
                {
                    return Ok(new Deal
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = dealManager.CheckDeal(deal);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Deal
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("UpdateDeal")]
        public IHttpActionResult UpdateDeal(Deal deal)
        {
            if (deal != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(deal.Did)) || string.IsNullOrEmpty(deal.DealId) || string.IsNullOrEmpty(deal.CompanyName) || string.IsNullOrEmpty(Convert.ToString(deal.ContractStartDate)) || string.IsNullOrEmpty(Convert.ToString(deal.ContractEndDate)) || FieldValidator.DecimalValidator(Convert.ToString(deal.DealAmount)) || FieldValidator.NumberValidatorWithZero(Convert.ToString(deal.SalesOwnerId)) || FieldValidator.NumberValidatorWithZero(Convert.ToString(deal.ContractDuration)))
                {
                    return Ok(new Deal
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    var result = dealManager.UpdateDeal(deal);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Deal
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }


        [HttpPost]
        [ActionName("DeleteDealInfo")]
        public IHttpActionResult DeleteDealInfo(Deal deal)
        {
            if (deal != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(deal.Did)) || FieldValidator.NumberValidatorWithZero(Convert.ToString(deal.CreatedBy)))
                {
                    return Ok(new Deal
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = dealManager.DeleteDealInfo(deal);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Deal
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("GetDeal")]
        public IHttpActionResult GetDeal(Deal deal)
        {
            if (deal != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(deal.Did)) || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(deal.CompanyId)))
                {
                    return Ok(new Deal
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = dealManager.GetDeal(deal);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Deal
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("UpdateDealOwner")]
        public IHttpActionResult UpdateDealOwner(DealInfo dealInfo)
        {
            if (dealInfo != null)
            {
                if (dealInfo.companyDealUDTs.Count == 0 || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(dealInfo.deal.SalesOwnerId)))
                {
                    return Ok(new Deal
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = dealManager.UpdateDealOwner(dealInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Deal
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetDealOwnerHistory")]
        public IHttpActionResult GetDealOwnerHistory(Deal deal)
        {
            if (deal != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(deal.CompanyId)) || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(deal.Did)))
                {
                    return Ok(new DealInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = dealManager.GetDealOwnerHistory(deal);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DealInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("UpdateDealStatus")]
        public IHttpActionResult UpdateDealStatus(Deal deal)
        {
            if (deal != null)
            {
                if ( string.IsNullOrEmpty(deal.DealId) || string.IsNullOrEmpty(deal.DealPipeline) )
                {
                    return Ok(new Deal
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    var result = dealManager.UpdateDealStatus(deal);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Deal
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

    }
}
