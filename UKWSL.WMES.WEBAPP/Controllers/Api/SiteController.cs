using System;
using System.Web.Http;
using UKWSL.WMES.Business.Customer;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class SiteController : ApiController
    {


        private ISiteManager siteManager;
        public SiteController(ISiteManager manager)
        {
            siteManager = manager;
        }


        [HttpPost]
        [ActionName("CheckSiteName")]
        public IHttpActionResult CheckSiteName(Sites sites)
        {
            if (sites != null)
            {
                if (string.IsNullOrEmpty(sites.SiteName))
                {
                    return Ok(new Sites
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = siteManager.CheckSiteName(sites);
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
        [ActionName("CheckSiteCode")]
        public IHttpActionResult CheckSiteCode(Sites sites)
        {
            if (sites != null)
            {
                if (string.IsNullOrEmpty(sites.SiteCode))
                {
                    return Ok(new Sites
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = siteManager.CheckSiteCode(sites);
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
        [ActionName("CreateSite")]
        public IHttpActionResult CreateSite(Sites sites)
        {
            if (sites != null)
            {
                if (string.IsNullOrEmpty(sites.SiteName) || FieldValidator.NumberValidatorWithZero(Convert.ToString(sites.CompanyId)) || string.IsNullOrEmpty(Convert.ToString(sites.PostCode)))
                {
                    return Ok(new Sites
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = siteManager.CreateUpdateSite(sites);
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

        /// <summary>
        /// Changes as per Story EUW-727
        /// </summary>
        /// <param name="sites"></param>
        /// <returns>Sites</returns>
        [HttpPost]
        [ActionName("GetSite")]
        public IHttpActionResult GetSite(Sites sites)
        {
            if (sites != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(sites.SiteId)) || FieldValidator.NumberValidatorWithZero(Convert.ToString(sites.CompanyId)))
                {
                    return Ok(new Sites
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = siteManager.GetSite(sites);
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
        [ActionName("DeleteSiteInfo")]
        public IHttpActionResult DeleteSiteInfo(Sites sites)
        {

            if (sites != null)
            {
                if (string.IsNullOrEmpty(Convert.ToString(sites.SiteIds)) || FieldValidator.NumberValidatorWithZero(Convert.ToString(sites.CreatedBy)))
                {
                    return Ok(new Sites
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = siteManager.DeleteSiteInfo(sites);
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
    }
}
