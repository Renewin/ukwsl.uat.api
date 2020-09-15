using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorBasicInfo:Log
    {
      public int ContractorId { get; set; }
        public int CompanyId { get; set; }
        public int ContractorStatusId { get; set; }
        public string ContractorStatusName { get; set; }
        public string ContractorTypeName { get; set; }
        public string ApprovalStatusName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public int CompanyTypeId { get; set; }
        public string CompanyTypeName { get; set; }
        public string CompanyVATNumber { get; set; }
        public DateTime SystemStartDate { get; set; }
        public int CountryofRegistration { get; set; }
        public string CountryofRegistrations { get; set; }
        public int AnnualTurnoverId { get; set; }
        public string AnnualTurnOverName { get; set; }
        public string NumberofEmployees { get; set; }
        public string CompanySIC { get; set; }
        public int ContractorTypeId { get; set; }
        public string OtherContractorType { get; set; }
        public string ParentHoldingCompany { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string WebsiteURL { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public int? RegionId { get; set; }
        public string RegionName { get; set; }
        public string Country { get; set; }
        public int IsCompanyExist { get; set; }

        public string FacilityIds { get; set; }
        public int ActiveServices { get; set; }
    }
}

