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
    public class CustomerController : ApiController
    {
        private ICustomerManager customerManager;

        public CustomerController(ICustomerManager manager)
        {
            customerManager = manager;
        }

        /// <summary>
        /// API to create and update customer basic info 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("CreateUpdateCustomerBasicInfo")]
        public IHttpActionResult CreateUpdateCustomerBasicInfo(CustomerBasicInfo customer)
        {
            if (customer != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customer.CompanyId)))
                {
                    return Ok(new CustomerBasicInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.CreateUpdateCustomerBasicInfo(customer);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerBasicInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }


        /// <summary>
        /// API to Check whether customer is already created or not 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("GetCustomerIdbyCompanyId")]
        public IHttpActionResult GetCustomerIdbyCompanyId(CustomerBasicInfo customer)
        {
            if (customer != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customer.CompanyId)))
                {
                    return Ok(new CustomerBasicInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    var result = customerManager.GetCustomerIdbyCompanyId(customer);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerBasicInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to add multiple contacts for customer 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("BulkInsertContactInfo")]
        public IHttpActionResult BulkInsertContactInfo(CustomerInfo customerInfo)
        {
            if (customerInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerInfo.customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerBasicInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.BulkInsertContactInfo(customerInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerBasicInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }



        /// <summary>
        /// API to get Customer basic info and contacts list 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("GetCustomerAllInfobyCustomerId")]
        public IHttpActionResult GetCustomerAllInfobyCustomerId(CustomerBasicInfo customer)
        {
            if (customer != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customer.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetCustomerAllInfobyCustomerId(customer);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to get Contact info by contact Id
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("GetContactInfoByContactId")]
        public IHttpActionResult GetContactInfoByContactId(CustomerContact customerContact)
        {
            if (customerContact != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerContact.ContactId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetContactInfoByContactId(customerContact);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to get customer type list 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("GetCustomerType")]
        public IHttpActionResult GetCustomerType()
        {
            return Ok(customerManager.GetCustomerType());
        }


        /// <summary>
        /// API to get contact type list 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("GetCustomerContactType")]
        public IHttpActionResult GetCustomerContactType()
        {
            return Ok(customerManager.GetCustomerContactType());
        }

        /// <summary>
        /// API to create and update customer contact details 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("CreateUpdateContactBasicInfo")]
        public IHttpActionResult CreateUpdateContactBasicInfo(CustomerInfo customerInfo)
        {
            if (customerInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerInfo.customerContact.TypeofContactId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(customerInfo.customerContact.CustomerID)))
                {
                    return Ok(new CustomerContact
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.CreateUpdateContactBasicInfo(customerInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerContact
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        /// <summary>
        /// API to delete contact details from customer 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("DeleteContactBasicInfo")]
        public IHttpActionResult DeleteContactBasicInfo(CustomerContact contact)
        {
            if (contact != null)
            {
                if (string.IsNullOrEmpty(contact.ContactIds)
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(contact.CustomerID)))
                {
                    return Ok(new CustomerContact
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.DeleteContactBasicInfo(contact);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerContact
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to check customer existing data 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3

        [HttpPost]
        [ActionName("CheckCustomerExistData")]
        public IHttpActionResult CheckCustomerExistData(CustomerInfo customerInfo)
        {
            if (customerInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerInfo.customerBasicInfo.CompanyId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.CheckCustomerExistData(customerInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }



        /// <summary>
        /// API to upodate customer info 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3

        [HttpPost]
        [ActionName("UpdateCustomerHubspotInfo")]
        public IHttpActionResult UpdateCustomerHubspotInfo(CustomerBasicInfo customer)
        {
            if (customer != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customer.CustomerId)))
                {
                    return Ok(new CustomerBasicInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.UpdateCustomerHubspotInfo(customer);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerBasicInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }


        /// <summary>
        /// API to bulk update customer contacts 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        [HttpPost]
        [ActionName("BulkUpdateContactHubspotInfo")]
        public IHttpActionResult BulkUpdateContactHubspotInfo(CustomerInfo customerInfo)
        {
            if (customerInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerInfo.customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerBasicInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.BulkUpdateContactHubspotInfo(customerInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerBasicInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        /// <summary>
        /// API to get Mobilization deals 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3

        [HttpPost]
        [ActionName("GetMobilizationDeals")]
        public IHttpActionResult GetMobilizationDeals(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(companyInfo.CompanyId)))
                {
                    return Ok(new Company
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetMobilizationDeals(companyInfo);
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

        /// <summary>
        /// API to get customer dashboard data 
        /// </summary>
        /// Delivery Point: Dp4.3
        [HttpPost]
        [ActionName("GetCustomerDashboardOverView")]
        public IHttpActionResult GetCustomerDashboardOverView(CompanyInfo companyInfo)
        {
            return Ok(customerManager.GetCustomerDashboardOverView(companyInfo));
        }

        /// <summary>
        /// API to get all customer list
        /// </summary>
        /// Delivery Point: Dp4.3
        [HttpPost]
        [ActionName("GetAllCustomerList")]
        public IHttpActionResult GetAllCustomerList(CompanyInfo companyInfo)
        {
            return Ok(customerManager.GetAllCustomerList(companyInfo));
        }
        /// <summary>
        /// API to get sector type
        /// </summary>
        /// Delivery Point: Dp4.3
        [HttpPost]
        [ActionName("GetSectorType")]
        public IHttpActionResult GetSectorType()
        {
            return Ok(customerManager.GetSectorType());
        }
        /// <summary>
        /// API to get legal basis
        /// </summary>
        /// Delivery Point: Dp4.3
        [HttpPost]
        [ActionName("GetLegalBasis")]
        public IHttpActionResult GetLegalBasis()
        {
            return Ok(customerManager.GetLegalBasis());
        }
        /// <summary>
        /// API to get internal contacts list by  contact type for company details 
        /// </summary>
        /// Delivery Point: Dp4.3

        [HttpPost]
        [ActionName("GetInternalContactsByType")]
        public IHttpActionResult GetInternalContactsByType(CustomerContactType customerContactType)
        {
            if (customerContactType != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerContactType.ContactTypeId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetInternalContactsByType(customerContactType);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        /// <summary>
        /// API to get customer status type for company information admin settings
        /// </summary>
        /// Delivery Point: Dp4.3
        [HttpPost]
        [ActionName("GetCustomerStatusType")]
        public IHttpActionResult GetCustomerStatusType()
        {
            return Ok(customerManager.GetCustomerStatusType());
        }


        /// <summary>
        /// API to get company information admin settings data by customer Id
        /// </summary>
        /// <param name="customerBasicInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetAdminSettingsbyCustomerId")]
        public IHttpActionResult GetAdminSettingsbyCustomerId(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetAdminSettingsbyCustomerId(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        /// <summary>
        /// API to update company information admin settings data for a customer Id
        /// </summary>
        /// Delivery Point: Dp4.3
        [HttpPost]
        [ActionName("CreateUpdateAdminSettingsData")]
        public IHttpActionResult CreateUpdateAdminSettingsData(CustomerAdminSettings customerAdminSettings)
        {
            if (customerAdminSettings != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerAdminSettings.CustomerId)))
                {
                    return Ok(new CustomerAdminSettings
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.CreateUpdateAdminSettingsData(customerAdminSettings);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerAdminSettings
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }


        /// <summary>
        /// API to get company information comments data by customer Id
        /// </summary>
        /// Delivery Point: Dp4.3
        [HttpPost]
        [ActionName("GetCommentsDatabyCustomerId")]
        public IHttpActionResult GetCommentsDatabyCustomerId(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetCommentsDatabyCustomerId(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        /// <summary>
        /// API to get company information comments data for customer Id
        /// </summary>
        /// Delivery Point: Dp4.3
        [HttpPost]
        [ActionName("CreateUpdateCommentsData")]
        public IHttpActionResult CreateUpdateCommentsData(CustomerComments customerComments)
        {
            if (customerComments != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerComments.CustomerId)))
                {
                    return Ok(new CustomerComments
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.CreateUpdateCommentsData(customerComments);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerComments
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("GetActiveAccountsByCustomer")]
        public IHttpActionResult GetActiveAccountsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetActiveAccountsByCustomer(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        [HttpPost]
        [ActionName("GetActiveGroupsByCustomer")]
        public IHttpActionResult GetActiveGroupsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetActiveGroupsByCustomer(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        [HttpPost]
        [ActionName("GetActiveSitesByCustomer")]
        public IHttpActionResult GetActiveSitesByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetActiveSitesByCustomer(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetAccountsByCustomer")]
        public IHttpActionResult GetAccountsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetAccountsByCustomer(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("CreateUpdateAccountsData")]
        public IHttpActionResult CreateUpdateAccountsData(AccountInfo accountInfo)
        {
            if (accountInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(accountInfo.CreatedBy))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(accountInfo.CustomerId)))
                {
                    return Ok(new AccountInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.CreateUpdateAccountsData(accountInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new AccountInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("DeleteAccountsInfo")]
        public IHttpActionResult DeleteAccountsInfo(AccountInfo accountInfo)
        {
            if (accountInfo != null)
            {
                if (string.IsNullOrEmpty(accountInfo.AccountIds)
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(accountInfo.CustomerId)))
                {
                    return Ok(new AccountInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.DeleteAccountsInfo(accountInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new AccountInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Array of the Groups</returns>
        [HttpPost]
        [ActionName("GetCustomerGroupType")]
        public IHttpActionResult GetCustomerGroupType()
        {
            return Ok(customerManager.GetCustomerGroupType());
        }

        [HttpPost]
        [ActionName("GetMonthlyPaymentType")]
        public IHttpActionResult GetMonthlyPaymentType()
        {
            return Ok(customerManager.GetMonthlyPaymentType());
        }

        [HttpPost]
        [ActionName("GetAllGroupsByCustomer")]
        public IHttpActionResult GetAllGroupsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetAllGroupsByCustomer(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("CreateUpdateGroupInfo")]
        public IHttpActionResult CreateUpdateGroupInfo(CustomerGroupInfo customerGroupInfo)
        {
            if (customerGroupInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerGroupInfo.CreatedBy))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(customerGroupInfo.CustomerId)))
                {
                    return Ok(new CustomerGroupInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.CreateUpdateGroupInfo(customerGroupInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerGroupInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("CreateUpdateSiteMappingByGroup")]
        public IHttpActionResult CreateUpdateSiteMappingByGroup(CustomerGroupInfo customerGroupInfo)
        {
            if (customerGroupInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerGroupInfo.CreatedBy))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(customerGroupInfo.Customer_GroupId)))
                {
                    return Ok(new CustomerGroupInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.CreateUpdateSiteMappingByGroup(customerGroupInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerGroupInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetAllSitesByCustomer")]
        public IHttpActionResult GetAllSitesByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetAllSitesByCustomer(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("CreateUpdateSiteInfo")]
        public IHttpActionResult CreateUpdateSiteInfo(CustomerSite customerSite)
        {
            if (customerSite != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerSite.CreatedBy))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(customerSite.AccountId)))
                {
                    return Ok(new CustomerSite
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.CreateUpdateSiteInfo(customerSite);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerSite
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetSitesByGroups")]
        public IHttpActionResult GetSitesByGroups(CustomerGroupInfo customerGroupInfo)
        {
            if (customerGroupInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerGroupInfo.Customer_GroupId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetSitesByGroups(customerGroupInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetSitesByAccounts")]
        public IHttpActionResult GetSitesByAccounts(AccountInfo accountInfo)
        {
            if (accountInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(accountInfo.AccountId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetSitesByAccounts(accountInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("DeleteGroupByGroupId")]
        public IHttpActionResult DeleteGroupByGroupId(CustomerGroupInfo customerGroupInfo)
        {
            if (customerGroupInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerGroupInfo.Customer_GroupId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.DeleteGroupByGroupId(customerGroupInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("BulkDeleteGroup")]
        public IHttpActionResult BulkDeleteGroup(CustomerGroupInfo customerGroupInfo)
        {
            if (customerGroupInfo != null)
            {
                if (string.IsNullOrEmpty(customerGroupInfo.GroupIds))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.BulkDeleteGroup(customerGroupInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("DeleteSiteBySiteId")]
        public IHttpActionResult DeleteSiteBySiteId(CustomerSite customerSite)
        {
            if (customerSite != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerSite.Customer_SiteId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.DeleteSiteBySiteId(customerSite);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("BulkDeleteSite")]
        public IHttpActionResult BulkDeleteSite(CustomerSite customerSite)
        {
            if (customerSite != null)
            {
                if (string.IsNullOrEmpty(customerSite.SiteIds))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.BulkDeleteSite(customerSite);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetDocumentType")]
        public IHttpActionResult GetDocumentType()
        {
            return Ok(customerManager.GetDocumentTypes());
        }

        [HttpPost]
        [ActionName("GetAllDocumentsByCustomer")]
        public IHttpActionResult GetAllDocumentsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerBasicInfo.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetAllDocumentsByCustomer(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

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
                    var result = customerManager.CreateUpdateDocumentInfo(documentInfo);
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

        [HttpPost]
        [ActionName("DeleteSiteMappingByGroup")]
        public IHttpActionResult DeleteSiteMappingByGroup(CustomerGroupInfo customerGroupInfo)
        {
            if (customerGroupInfo != null)
            {
                if (string.IsNullOrEmpty(customerGroupInfo.SiteIds)
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(customerGroupInfo.Customer_GroupId)))
                {
                    return Ok(new CustomerGroupInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.DeleteSiteMappingByGroup(customerGroupInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerGroupInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to get pricing matrix list by CustomerId
        /// </summary>
        /// Delivery Point: DP4.8
        [HttpPost]
        [ActionName("GetPricingMatrixListByCustomerId")]
        public IHttpActionResult GetPricingMatrixListByCustomerId(CustomerBasicInfo customer)
        {
            if (customer != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customer.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetPricingMatrixListByCustomerId(customer);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetServiceCommentsDataByCustomerId")]
        public IHttpActionResult GetServiceCommentsData(CustomerServiceComments customerServiceComments)
        {
            if (customerServiceComments != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(customerServiceComments.CustomerId)))
                {
                    return Ok(new CustomerInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.GetServiceCommentsData(customerServiceComments);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        [HttpPost]
        [ActionName("UpdateServiceCommentStatus")]
        public IHttpActionResult UpdateServiceCommentStatus(CustomerServiceComments customerServiceComments)
        {
            if (customerServiceComments != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerServiceComments.CusServiceCommentId)))
                {
                    return Ok(new CustomerServiceComments
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = customerManager.UpdateServiceCommentStatus(customerServiceComments);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new CustomerServiceComments
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
    }
}
