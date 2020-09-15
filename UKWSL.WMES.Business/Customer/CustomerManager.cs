using System.Collections.Generic;
using System.Data;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Customer;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Business.Customer
{
    public class CustomerManager : ICustomerManager
    {

        private ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Company CreateCompany(CompanyInfo companyInfo)
        {
            return _customerRepository.CreateCompany(companyInfo);
        }


        public Company GetAllCompany(CompanyInfo companyInfo)
        {

            return _customerRepository.GetAllCompany(companyInfo);
        }

        public Company GetCompanyDeals(CompanyInfo companyInfo)
        {
            return _customerRepository.GetCompanyDeals(companyInfo);
        }


        public Company GetCompanySites(CompanyInfo companyInfo)
        {
            return _customerRepository.GetCompanySites(companyInfo);
        }

        public Company GetCompanyById(CompanyInfo companyInfo)
        {
            return _customerRepository.GetCompanyById(companyInfo);
        }

        public Company CheckCompany(CompanyInfo companyInfo)
        {
            return _customerRepository.CheckCompany(companyInfo);
        }


        public Company GetMultipleCompanyDeals(CompanyInfo companyInfo)
        {
            return _customerRepository.GetMultipleCompanyDeals(companyInfo);
        }
        /// <summary>
        /// business method to create and update customer basic info 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo CreateUpdateCustomerBasicInfo(CustomerBasicInfo customer)
        {
            return _customerRepository.CreateUpdateCustomerBasicInfo(customer);
        }

        /// <summary>
        /// business method to Check whether customer is already created or not 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo GetCustomerIdbyCompanyId(CustomerBasicInfo customer)
        {
            return _customerRepository.GetCustomerIdbyCompanyId(customer);
        }
        /// <summary>
        /// business method to add multiple contacts for customer 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo BulkInsertContactInfo(CustomerInfo customerInfo)
        {
            DataTable _dtContacts = new DataTable();
            _dtContacts = ListtoDataTableConverter.ToDataTable(customerInfo.lstCustomerContactUDT);
            return _customerRepository.BulkInsertContactInfo(customerInfo.customerBasicInfo, _dtContacts);
        }
        /// <summary>
        /// business method to get Customer basic info and contacts list 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo GetCustomerAllInfobyCustomerId(CustomerBasicInfo customer)
        {
            return _customerRepository.GetCustomerAllInfobyCustomerId(customer);
        }
        /// <summary>
        /// business method to get Contact info by contact Id 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo GetContactInfoByContactId(CustomerContact customerContact)
        {
            return _customerRepository.GetContactInfoByContactId(customerContact);
        }
        /// <summary>
        /// business method to get customer type list 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo GetCustomerType()
        {
            return _customerRepository.GetCustomerType();
        }
        /// <summary>
        ///  business method to get contact type list 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo GetCustomerContactType()
        {
            return _customerRepository.GetCustomerContactType();
        }
        /// <summary>
        /// business method to create and update customer contact details 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerContact CreateUpdateContactBasicInfo(CustomerInfo customerInfo)
        {
            DataTable _dtCAM = new DataTable();
            _dtCAM = ListtoDataTableConverter.ToDataTable(customerInfo.lstContactsAdditionMappingUDT);
            return _customerRepository.CreateUpdateContactBasicInfo(customerInfo.customerContact, _dtCAM);
        }
        /// <summary>
        /// business method to delete contact details from customer 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerContact DeleteContactBasicInfo(CustomerContact contact)
        {
            return _customerRepository.DeleteContactBasicInfo(contact);
        }
        /// <summary>
        /// business method to check customer existing data 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo CheckCustomerExistData(CustomerInfo customerInfo)
        {
            DataTable _dtContacts = new DataTable();
            _dtContacts = ListtoDataTableConverter.ToDataTable(customerInfo.lstCustomerContactUDT);
            return _customerRepository.CheckCustomerExistData(customerInfo.customerBasicInfo, _dtContacts);
        }
        /// <summary>
        /// business method to upodate customer info 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo UpdateCustomerHubspotInfo(CustomerBasicInfo customer)
        {
            return _customerRepository.UpdateCustomerHubspotInfo(customer);
        }
        /// <summary>
        /// business method to bulk update customer contacts 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo BulkUpdateContactHubspotInfo(CustomerInfo customerInfo)
        {
            DataTable _dtContacts = new DataTable();
            _dtContacts = ListtoDataTableConverter.ToDataTable(customerInfo.lstCustomerContactUDT);
            return _customerRepository.BulkUpdateContactHubspotInfo(customerInfo.customerBasicInfo, _dtContacts);
        }
        /// <summary>
        /// business method to get Mobilization deals 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public Company GetMobilizationDeals(CompanyInfo companyInfo)
        {

            return _customerRepository.GetMobilizationDeals(companyInfo);
        }
        /// <summary>
        /// business method to get customer dashboard data 
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetCustomerDashboardOverView(CompanyInfo companyInfo)
        {
            return _customerRepository.GetCustomerDashboardOverView(companyInfo);
        }
        /// <summary>
        /// business method to get all customer list
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetAllCustomerList(CompanyInfo companyInfo)
        {
            return _customerRepository.GetAllCustomerList(companyInfo);
        }
        /// <summary>
        /// business method to get sector type
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetSectorType()
        {
            return _customerRepository.GetSectorType();
        }

        public CustomerInfo GetLegalBasis()
        {
            return _customerRepository.GetLegalBasis();
        }
        /// <summary>
        /// business method to get internal contacts list by  contact type for company details 
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetInternalContactsByType(CustomerContactType customerContactType)
        {
            return _customerRepository.GetInternalContactsByType(customerContactType);
        }
        /// <summary>
        /// business method to get customer status type for company information admin settings
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetCustomerStatusType()
        {
            return _customerRepository.GetCustomerStatusType();
        }
        /// <summary>
        /// business method to get company information admin settings data by customer Id
        /// </summary>
        /// <param name="customerBasicInfo"></param>
        /// <returns></returns>
        public CustomerInfo GetAdminSettingsbyCustomerId(CustomerBasicInfo customer)
        {
            return _customerRepository.GetAdminSettingsbyCustomerId(customer);
        }
        /// <summary>
        /// business method to update company information admin settings data for a customer Id
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerAdminSettings CreateUpdateAdminSettingsData(CustomerAdminSettings customerAdminSettings)
        {
            return _customerRepository.CreateUpdateAdminSettingsData(customerAdminSettings);
        }
        /// <summary>
        ///business method to get company information comments data by customer Id
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetCommentsDatabyCustomerId(CustomerBasicInfo customer)
        {
            return _customerRepository.GetCommentsDatabyCustomerId(customer);
        }
        /// <summary>
        /// business method to get company information comments data for customer Id
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerComments CreateUpdateCommentsData(CustomerComments customerComments)
        {
            return _customerRepository.CreateUpdateCommentsData(customerComments);
        }
        public CustomerInfo GetActiveAccountsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            return _customerRepository.GetActiveAccountsByCustomer(customerBasicInfo);
        }
        public CustomerInfo GetActiveGroupsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            return _customerRepository.GetActiveGroupsByCustomer(customerBasicInfo);
        }
        public CustomerInfo GetActiveSitesByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            return _customerRepository.GetActiveSitesByCustomer(customerBasicInfo);
        }
        public CustomerInfo GetAccountsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            return _customerRepository.GetAccountsByCustomer(customerBasicInfo);
        }
        public AccountInfo CreateUpdateAccountsData(AccountInfo accountInfo)
        {
            return _customerRepository.CreateUpdateAccountsData(accountInfo);
        }
        public AccountInfo DeleteAccountsInfo(AccountInfo accountInfo)
        {
            return _customerRepository.DeleteAccountsInfo(accountInfo);
        }        
		
        /// <summary>
        /// Business Layer method to retrive the Groups details
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetCustomerGroupType()
        {
            return _customerRepository.GetCustomerGroupType();
        }
        public CustomerInfo GetMonthlyPaymentType()
        {
            return _customerRepository.GetMonthlyPaymentType();
        }
        public CustomerInfo GetAllGroupsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            return _customerRepository.GetAllGroupsByCustomer(customerBasicInfo);
        }
        public CustomerGroupInfo CreateUpdateGroupInfo(CustomerGroupInfo customerGroupInfo)
        {
            return _customerRepository.CreateUpdateGroupInfo(customerGroupInfo);
        }
        public CustomerGroupInfo CreateUpdateSiteMappingByGroup(CustomerGroupInfo customerGroupInfo)
        {
            return _customerRepository.CreateUpdateSiteMappingByGroup(customerGroupInfo);
        }
        public CustomerInfo GetAllSitesByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            return _customerRepository.GetAllSitesByCustomer(customerBasicInfo);
        }

        public CustomerSite CreateUpdateSiteInfo(CustomerSite customerSite)
        {
            return _customerRepository.CreateUpdateSiteInfo(customerSite);
        }

        public CustomerInfo GetSitesByAccounts(AccountInfo accountInfo)
        {
            return _customerRepository.GetSitesByAccounts(accountInfo);
        }

        public CustomerInfo GetSitesByGroups(CustomerGroupInfo customerGroupInfo)
        {
            return _customerRepository.GetSitesByGroups(customerGroupInfo);
        }

        public CustomerInfo DeleteGroupByGroupId(CustomerGroupInfo customerGroupInfo)
        {
            return _customerRepository.DeleteGroupByGroupId(customerGroupInfo);
        }
        public CustomerInfo BulkDeleteGroup(CustomerGroupInfo customerGroupInfo)
        {
            return _customerRepository.BulkDeleteGroup(customerGroupInfo);
        }

        public CustomerInfo DeleteSiteBySiteId(CustomerSite customerSite)
        {
            return _customerRepository.DeleteSiteBySiteId(customerSite);
        }
        public CustomerInfo BulkDeleteSite(CustomerSite customerSite)
        {
            return _customerRepository.BulkDeleteSite(customerSite);
        }
        public CustomerInfo GetDocumentTypes()
        {
            return _customerRepository.GetDocumentTypes();
        }

        public CustomerInfo GetAllDocumentsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            return _customerRepository.GetAllDocumentsByCustomer(customerBasicInfo);
        }

        public DocumentInfo CreateUpdateDocumentInfo(DocumentInfo documentInfo)
        {
            return _customerRepository.CreateUpdateDocumentInfo(documentInfo);
        }

        public CustomerGroupInfo DeleteSiteMappingByGroup(CustomerGroupInfo customerGroupInfo)
        {
            return _customerRepository.DeleteSiteMappingByGroup(customerGroupInfo);
        }

        public CustomerInfo GetPricingMatrixListByCustomerId(CustomerBasicInfo customer)
        {
            return _customerRepository.GetPricingMatrixListByCustomerId(customer);
        }

        public CustomerInfo GetServiceCommentsData(CustomerServiceComments customerServiceComments)
        {
            return _customerRepository.GetServiceCommentsData(customerServiceComments);
        }
        public CustomerServiceComments UpdateServiceCommentStatus(CustomerServiceComments customerServiceComments)
        {
            return _customerRepository.UpdateServiceCommentStatus(customerServiceComments);
        }

    }
}
