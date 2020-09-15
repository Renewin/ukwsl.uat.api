using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerInfo : Result
    {
        public List<ContactsAdditionMappingUDT> lstContactsAdditionMappingUDT { get; set; }
        public List<ContactsAdditionMapping> lstContactsAdditionMapping { get; set; }
        public List<CustomerContactUDT> lstCustomerContactUDT { get; set; }
        public List<CustomerContact> lstCustomerContact { get; set; }
        public CustomerBasicInfo customerBasicInfo { get; set; }
        public CompanyInfo companyInfo { get; set; }
        public CustomerContact customerContact { get; set; }
        public List<CustomerType> lstCustomerType { get; set; }
        public List<CustomerContactType> lstCustomerContactType { get; set; }
        public int ReturnId { get; set; }
        public int TotalCustomers { get; set; }
        public int SetupInProgress { get; set; }
        public int SetupCompleted { get; set; }
        public List<CustomerBasicInfo> lstCustomerBasicInfo { get; set; }
        public List<LegalBasis> lstLegalBasis { get; set; }
        public List<SectorType> lstSectorType { get; set; }
        public List<User> lstUser { get; set; }
        public CustomerAdminSettings customerAdminSettings { get; set; }
        public List<CustomerStatusType> lstCustomerStatusTypes { get; set; }
        public CustomerComments customerComments { get; set; }
        public List<AccountInfo> lstAccountInfos { get; set; }
        public List<CustomerGroupInfo> lstCustomerGroupInfos { get; set; }
        public List<CustomerSite> lstCustomerSites { get; set; }
        public List<GroupType> lstGroupType { get; set; }
        public List<MonthlyPaymentType> lstMonthlyPaymentType { get; set; }
        public List<DocumentType> lstDocumentType { get; set; }
        public List<DocumentInfo> lstDocumentInfos { get; set; }
        public List<PricingMatrixSetup> lstpricingMatrices { get; set; }
        public List<CustomerServiceComments> lstCustomerServiceComments { get; set; }
    }
}
