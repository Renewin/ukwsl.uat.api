using System;
using System.Collections.Generic;
using System.Web.Http;
using UKWSL.WMES.Business.Customer;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    // [Authorize]
    public class CompanyController : ApiController
    {

        private ICustomerManager customerManager;
        public CompanyController(ICustomerManager manager)
        {
            customerManager = manager;
        }


        [HttpPost]
        [ActionName("CreateCompany")]
        public IHttpActionResult CreateCompany(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                if (string.IsNullOrEmpty(companyInfo.CompanyName) || FieldValidator.NumberValidatorWithZero(Convert.ToString(companyInfo.CompanyId)))
                {
                    return Ok(new Company
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    var result = customerManager.CreateCompany(companyInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Company
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }


        [HttpPost]
        [ActionName("UpdateCompany")]
        public IHttpActionResult UpdateCompany(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                if (string.IsNullOrEmpty(companyInfo.CompanyName) || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(companyInfo.CompanyId)) )
                {
                    return Ok(new Company
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    var result = customerManager.CreateCompany(companyInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Company
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }


        [HttpPost]
        [ActionName("GetAllCompany")]
        public IHttpActionResult GetAllCompany(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(companyInfo.CreatedBy)))
                {
                    return Ok(new Company
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    return Ok(customerManager.GetAllCompany(companyInfo));
                }
            }
            else
            {
                return Ok(new Company
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetCompanyById")]
        public IHttpActionResult GetCompanyById(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(companyInfo.CreatedBy)) || FieldValidator.NumberValidatorWithZero(Convert.ToString(companyInfo.CompanyId)))
                {
                    return Ok(new Company
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    var result = customerManager.GetCompanyById(companyInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Company
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetCompanyDeals")]
        public IHttpActionResult GetCompanyDeals(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(companyInfo.CreatedBy)) || FieldValidator.NumberValidatorWithZero(Convert.ToString(companyInfo.CompanyId)))
                {
                    return Ok(new Company
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    return Ok(customerManager.GetCompanyDeals(companyInfo));
                }
            }
            else
            {
                return Ok(new Company
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }


        [HttpPost]
        [ActionName("GetMultipleCompanyDeals")]
        public IHttpActionResult GetMultipleCompanyDeals(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(companyInfo.CreatedBy)))
                {
                    return Ok(new Company
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    return Ok(customerManager.GetMultipleCompanyDeals(companyInfo));
                }
            }
            else
            {
                return Ok(new Company
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }



        /// <summary>
        /// Changes as per story EUW-727
        /// </summary>
        /// <param name="companyInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetCompanySites")]
        public IHttpActionResult GetCompanySites(CompanyInfo companyInfo)
        {

            return Ok(customerManager.GetCompanySites(companyInfo));
        }

        [HttpPost]
        [ActionName("CheckCompany")]
        public IHttpActionResult CheckCompany(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                if (String.IsNullOrEmpty(companyInfo.CompanyName))
                {
                    return Ok(new Company
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    var result = customerManager.CheckCompany(companyInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Company
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
    }
}
