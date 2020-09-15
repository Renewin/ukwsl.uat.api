using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Customer
{
   public interface ICustomerRepository
    {
        Company CreateCompany(CompanyInfo companyInfo);
        Company GetAllCompany(CompanyInfo companyInfo);
        Company GetCompanyDeals(CompanyInfo companyInfo);

        Company GetCompanySites(CompanyInfo companyInfo);
        Company GetCompanyById(CompanyInfo companyInfo);

        Company CheckCompany(CompanyInfo companyInfo);

        Company GetMultipleCompanyDeals(CompanyInfo companyInfo);

        CustomerBasicInfo CreateUpdateCustomerBasicInfo(CustomerBasicInfo customer);
        CustomerBasicInfo GetCustomerIdbyCompanyId(CustomerBasicInfo customer);
        CustomerBasicInfo BulkInsertContactInfo(CustomerBasicInfo customer,DataTable _dtContacts);
        CustomerInfo GetCustomerAllInfobyCustomerId(CustomerBasicInfo customer);

        CustomerInfo GetCustomerType();
        CustomerInfo GetCustomerContactType();
        CustomerContact CreateUpdateContactBasicInfo(CustomerContact contact, DataTable dataTable);
        CustomerInfo GetContactInfoByContactId(CustomerContact customerContact);
        CustomerContact DeleteContactBasicInfo(CustomerContact contact);
        CustomerInfo CheckCustomerExistData(CustomerBasicInfo customer, DataTable dataTable);
        CustomerBasicInfo UpdateCustomerHubspotInfo(CustomerBasicInfo customer);
        CustomerBasicInfo BulkUpdateContactHubspotInfo(CustomerBasicInfo customer, DataTable dataTable);
        Company GetMobilizationDeals(CompanyInfo companyInfo);

        CustomerInfo GetCustomerDashboardOverView(CompanyInfo companyInfo);
        CustomerInfo GetAllCustomerList(CompanyInfo companyInfo);
        CustomerInfo GetSectorType();
        CustomerInfo GetLegalBasis();
        CustomerInfo GetInternalContactsByType(CustomerContactType customerContactType);
        CustomerInfo GetCustomerStatusType();
        CustomerInfo GetAdminSettingsbyCustomerId(CustomerBasicInfo customer);
        CustomerAdminSettings CreateUpdateAdminSettingsData(CustomerAdminSettings customerAdminSettings);
        CustomerInfo GetCommentsDatabyCustomerId(CustomerBasicInfo customer);
        CustomerComments CreateUpdateCommentsData(CustomerComments customerComments);
        CustomerInfo GetActiveAccountsByCustomer(CustomerBasicInfo customerBasicInfo);
        CustomerInfo GetActiveGroupsByCustomer(CustomerBasicInfo customerBasicInfo);
        CustomerInfo GetActiveSitesByCustomer(CustomerBasicInfo customerBasicInfo);

        CustomerInfo GetAccountsByCustomer(CustomerBasicInfo customerBasicInfo);
        AccountInfo CreateUpdateAccountsData(AccountInfo accountInfo);
        AccountInfo DeleteAccountsInfo(AccountInfo accountInfo);

        CustomerInfo GetAllGroupsByCustomer(CustomerBasicInfo customerBasicInfo);
        CustomerGroupInfo CreateUpdateGroupInfo(CustomerGroupInfo customerGroupInfo);
        CustomerInfo GetCustomerGroupType();
        CustomerInfo GetMonthlyPaymentType();
        CustomerInfo DeleteGroupByGroupId(CustomerGroupInfo customerGroupInfo);
        CustomerInfo BulkDeleteGroup(CustomerGroupInfo customerGroupInfo);
        CustomerGroupInfo CreateUpdateSiteMappingByGroup(CustomerGroupInfo customerGroupInfo);

        CustomerInfo GetAllSitesByCustomer(CustomerBasicInfo customerBasicInfo);
        CustomerSite CreateUpdateSiteInfo(CustomerSite customerSite);
        CustomerInfo DeleteSiteBySiteId(CustomerSite customerSite);
        CustomerInfo BulkDeleteSite(CustomerSite customerSite);
        
        CustomerInfo GetSitesByAccounts(AccountInfo accountInfo);
        CustomerInfo GetSitesByGroups(CustomerGroupInfo customerGroupInfo);

        CustomerInfo GetDocumentTypes();
        CustomerInfo GetAllDocumentsByCustomer(CustomerBasicInfo customerBasicInfo);
        DocumentInfo CreateUpdateDocumentInfo(DocumentInfo documentInfo);
        CustomerGroupInfo DeleteSiteMappingByGroup(CustomerGroupInfo customerGroupInfo);

        CustomerInfo GetPricingMatrixListByCustomerId(CustomerBasicInfo customer);

        CustomerInfo GetServiceCommentsData(CustomerServiceComments customerServiceComments);
        CustomerServiceComments UpdateServiceCommentStatus(CustomerServiceComments customerServiceComments);

    }
}
