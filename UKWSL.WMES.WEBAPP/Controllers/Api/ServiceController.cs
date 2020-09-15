using System;
using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.Service;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class ServiceController : ApiController
    {
        private IServiceManager serviceManager;

        public ServiceController(IServiceManager manager)
        {
            serviceManager = manager;
        }

        /// <summary>
        /// API to get Service dashboard data 
        /// </summary>
        /// Delivery Point: Dp4.4
        [HttpPost]
        [ActionName("GetServiceDashboardOverView")]
        public IHttpActionResult GetServiceDashboardOverView(CompanyInfo companyInfo)
        {
            return Ok(serviceManager.GetServiceDashboardOverView(companyInfo));
        }

        /// <summary>
        /// API to get Service dashboard table data 
        /// </summary>
        /// Delivery Point: Dp4.4
        [HttpPost]
        [ActionName("GetAllCustomerListForServiceDashboard")]
        public IHttpActionResult GetAllCustomerListForServiceDashboard(CompanyInfo companyInfo)
        {
            return Ok(serviceManager.GetAllCustomerListForServiceDashboard(companyInfo));
        }

        [HttpPost]
        [ActionName("GetAllServicebySite")]
        public IHttpActionResult GetAllServicebySite(CustomerSite customerSite)
        {
            if (customerSite != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerSite.Customer_SiteId)))
                {
                    return Ok(new ServiceInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetAllServicebySite(customerSite);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetServiceDetailsByJobId")]
        public IHttpActionResult GetServiceDetailsByJobId(ServiceBasicInfo serviceBasicInfo)
        {
            if (serviceBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceBasicInfo.JobId)))
                {
                    return Ok(new ServiceJobDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetServiceDetailsByJobId(serviceBasicInfo);
                    result.Status = Status.Success;
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

        [HttpPost]
        [ActionName("GetServiceHistoryByServiceId")]
        public IHttpActionResult GetServiceHistoryByServiceId(ServiceBasicInfo serviceBasicInfo)
        {

            if (serviceBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceBasicInfo.ServiceId)))
                {
                    return Ok(new ServiceJobDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetServiceHistoryByServiceId(serviceBasicInfo);
                    result.Status = Status.Success;
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

        [HttpPost]
        [ActionName("AddNewService")]
        public IHttpActionResult AddNewService(ServiceJobDetails serviceJobDetails)
        {
            if (serviceJobDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.CustomerId)) ||
                    FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.Customer_SiteId)))
                    //||
                    //FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.ServiceStatusId)) ||
                    //FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.ServiceTypeId)))
                {
                    return Ok(new ServiceJobDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.AddNewService(serviceJobDetails);
                    result.Status = Status.Success;
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

        [HttpPost]
        [ActionName("UpdateService")]
        public IHttpActionResult UpdateService(ServiceJobDetails serviceJobDetails)
        {
            if (serviceJobDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.ServiceId)) ||
                    FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.JobId)))
                //||
                //FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.ServiceStatusId)) ||
                //FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.ServiceTypeId)))
                {
                    return Ok(new ServiceJobDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.UpdateService(serviceJobDetails);
                    result.Status = Status.Success;
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

        [HttpPost]
        [ActionName("AddNewJob")]
        public IHttpActionResult AddNewJob(ServiceJobDetails serviceJobDetails)
        {
            if (serviceJobDetails != null)
            {
                if(FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.CustomerId)) ||
                    FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.ServiceId)) ||
                     FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.Customer_SiteId)) //||
                     //FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.ServiceStatusId)) ||
                     //FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.ServiceTypeId))
                     )
                {
                    return Ok(new ServiceJobDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.AddNewJob(serviceJobDetails);
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
        [ActionName("UpdateJobConfirmation")]
        public IHttpActionResult UpdateJobConfirmation(ServiceJobDetails serviceJobDetails)
        {
            if (serviceJobDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.JobId)) )    {
                    return Ok(new ServiceJobDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.UpdateJobConfirmation(serviceJobDetails);
                    result.Status = Status.Success;
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

        [HttpPost]
        [ActionName("GetAllServiceSitesByCustomer")]
        public IHttpActionResult GetAllServiceSitesByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new ServiceInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetAllServiceSitesByCustomer(customerBasicInfo);
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
        [ActionName("GetServiceSitesByAccountId")]
        public IHttpActionResult GetServiceSitesByAccountId(AccountInfo accountInfo)
        {
            if (accountInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(accountInfo.AccountId)))
                {
                    return Ok(new ServiceInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetServiceSitesByAccountId(accountInfo);
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

        /// <summary>
        /// API to get Service dashboard data 
        /// </summary>
        /// Delivery Point: Dp4.4
        [HttpPost]
        [ActionName("GetServiceReportServiceTracker")]
        public IHttpActionResult GetServiceReportServiceTracker()
        {
            return Ok(serviceManager.GetServiceReportServiceTracker());
        }

        [HttpPost]
        [ActionName("GetProcessAccountDetails")]
        public SettingUpViewModel GetProcessAccountDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUpViewModel models = new SettingUpViewModel();
            try
            {
                models.settingUp = serviceManager.GetProcessAccountDetails(approvedPricingSolution);

            }
            catch (Exception ex)
            {

            }
            return models;
        }

        [HttpPost]
        [ActionName("GetProcessSiteDetails")]
        public SettingUpViewModel GetProcessSiteDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUpViewModel models = new SettingUpViewModel();
            try
            {
                models.settingUp = serviceManager.GetProcessSiteDetails(approvedPricingSolution);

            }
            catch (Exception ex)
            {

            }
            return models;
        }

        [HttpPost]
        [ActionName("GetProcessContactDetails")]
        public SettingUpViewModel GetProcessContactDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUpViewModel models = new SettingUpViewModel();
            try
            {
                models.settingUp = serviceManager.GetProcessContactDetails(approvedPricingSolution);

            }
            catch (Exception ex)
            {

            }
            return models;
        }

        [HttpPost]
        [ActionName("GetProcessServiceDetails")]
        public SettingUpViewModel GetProcessServiceDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUpViewModel models = new SettingUpViewModel();
            try
            {
                models.settingUp = serviceManager.GetProcessServiceDetails(approvedPricingSolution);

            }
            catch (Exception ex)
            {

            }
            return models;
        }

        [HttpPost]
        [ActionName("CreateServices")]
        public SettingUpViewModel CreateServices(ApprovedPricingSolution approvedPricingSolution)
        {
            SettingUpViewModel models = new SettingUpViewModel();
            try
            {
                models.settingUp = serviceManager.GetCreateServices(approvedPricingSolution);

            }
            catch (Exception ex)
            {

            }
            return models;
        }

        [HttpPost]
        [ActionName("GetOrderEmailTemplate")]
        public IHttpActionResult GetOrderEmailTemplate(CompanyInfo companyInfo)
        {
            return Ok(serviceManager.GetOrderEmailTemplate());
        }

        [HttpPost]
        [ActionName("CreateNewOrder")]
        public IHttpActionResult CreateNewOrder(ServiceOrderDetails serviceOrderDetails)
        {
            if (serviceOrderDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.JobId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.ContractorId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.SiteId)))
                {
                    return Ok(new ServiceOrderDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.CreateNewOrder(serviceOrderDetails);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceOrderDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        [HttpPost]
        [ActionName("GetDetailsforSingleOrder")]
        public IHttpActionResult GetDetailsforSingleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            if (serviceOrderDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.OrderId)))
                {
                    return Ok(new ServiceOrderDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetDetailsforSingleOrder(serviceOrderDetails);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceOrderDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetDetailsforAmendmentOrder")]
        public IHttpActionResult GetDetailsforAmendmentOrder(ServiceOrderDetails serviceOrderDetails)
        {
            if (serviceOrderDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.OrderId)))
                {
                    return Ok(new ServiceOrderDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetDetailsforAmendmentOrder(serviceOrderDetails);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceOrderDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        [HttpPost]
        [ActionName("GetDetailsforMultipleOrder")]
        public IHttpActionResult GetDetailsforMultipleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            if (serviceOrderDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.ContractorId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.CreatedBy)))
                {
                    return Ok(new ServiceOrderDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetDetailsforMultipleOrder(serviceOrderDetails);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceOrderDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        [HttpPost]
        [ActionName("GetMyOrderDetails")]
        public IHttpActionResult GetMyOrderDetails(ServiceOrderDetails serviceOrderDetails)
        {
            if (serviceOrderDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.CreatedBy)))
                {
                    return Ok(new ServiceOrderDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetMyOrderDetails(serviceOrderDetails);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceOrderDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        [HttpPost]
        [ActionName("ClearMultipleOrder")]
        public IHttpActionResult ClearMultipleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            if (serviceOrderDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.ContractorId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.CreatedBy)))
                {
                    return Ok(new ServiceOrderDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.ClearMultipleOrder(serviceOrderDetails);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceOrderDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        [HttpPost]
        [ActionName("CreateMultipleOrder")]
        public IHttpActionResult CreateMultipleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            if (serviceOrderDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.JobId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.ContractorId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderDetails.SiteId)))
                {
                    return Ok(new ServiceOrderDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.CreateMultipleOrder(serviceOrderDetails);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceOrderDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
		
		 [ActionName("GetCustomFieldsByCustomer")]
        public IHttpActionResult GetCustomFieldsByCustomer(ServiceJobDetails serviceJobDetails)
        {
            if (serviceJobDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceJobDetails.CustomerId)))
                {
                    return Ok(new ServiceJobDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetCustomFieldsByCustomer(serviceJobDetails);
                    result.Status = Status.Success;
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

        [HttpPost]
        [ActionName("BulkConfirmDeliveryDate")]
        public IHttpActionResult BulkConfirmDeliveryDate(ServiceInfo serviceInfo)
        {
            if (serviceInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceInfo.CreatedBy)))
                {
                    return Ok(new ServiceInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.BulkConfirmDeliveryDate(serviceInfo);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        //API to Insert Order Email Details to table
        [HttpPost]
        [ActionName("InsertOrderEmailDetails")]
        public IHttpActionResult InsertOrderEmailDetails(ServiceOrderEmailDetails serviceOrderEmailDetails)
        {
            if (serviceOrderEmailDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderEmailDetails.OrderId)))
                {
                    return Ok(new ServiceOrderEmailDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.InsertOrderEmailDetails(serviceOrderEmailDetails);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ServiceOrderEmailDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetEmailDetailsByJobId")]
        public IHttpActionResult GetEmailDetailsByJobId(ServiceOrderEmailDetails serviceOrderEmailDetails)
        {
            if (serviceOrderEmailDetails != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(serviceOrderEmailDetails.JobId)))
                {
                    return Ok(new ServiceJobDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = serviceManager.GetEmailTemplate(serviceOrderEmailDetails);
                    result.Status = Status.Success;
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

    }
}
