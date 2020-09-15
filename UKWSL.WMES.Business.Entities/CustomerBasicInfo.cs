using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerBasicInfo : Log
    {
        public string Town { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string CompanyDomainName { get; set; }
        public string SalesContact { get; set; }
        public string Country { get; set; }
        public string CreditRating { get; set; }
        public string CustomerType { get; set; }
        public string Sector { get; set; }
        public bool IsPublic { get; set; }
        public bool IsManagedAccount { get; set; }
        public string CompanyName { get; set; }
        public string PostCode { get; set; }
        public string CompanySICCode { get; set; }
        public string County { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string WebsiteURL { get; set; }
        public DateTime SystemStartDate { get; set; }
        public string CompanyShortName { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public int SectorId { get; set; }
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public string Email { get; set; }
        public string LastUpdatedBy { get; set; }

        public string H_CompanyName { get; set; }
        public string H_CompanyDomainName { get; set; }
        public string H_CompanySICCode { get; set; }
        public string H_CompanyRegistrationNumber { get; set; }
        public string H_CreditRating { get; set; }




        public bool? H_IsPublic { get; set; }
        public string H_StreetAddress1 { get; set; }
        public string H_PostCode { get; set; }
        public string H_StreetAddress2 { get; set; }
        public string H_Town { get; set; }
        public string H_County { get; set; }
        public string H_Country { get; set; }
        public string H_WebsiteURL { get; set; }

        public int IsCompanyDiffer { get; set; }
        public int IsDomainDiffer { get; set; }
        public int IsSICdiffer { get; set; }
        public int IsRegNoDiffer { get; set; }
        public int IsCreditRaDiffer { get; set; }
        public int IsPublicDiffer { get; set; }
        public int IsPostcodeDiffer { get; set; }
        public int IsSAdd1Differ { get; set; }
        public int IsSAdd2Differ { get; set; }
        public int IsTownDiffer { get; set; }
        public int IsCountyDiffer { get; set; }
        public int IsCountryDiffer { get; set; }
        public int IsWebsiteDiffer { get; set; }
        public string HubspotOwner { get; set; }
        public string CustomerStatusName { get; set; }
        public int CustomerStatusId { get; set; }
        public string H_HubspotOwner { get; set; }
        public int IsHubspotOwnerDiffer { get; set; }
        public string SectorName { get; set; }

        public string SalesContactId { get; set; }
        public string AccountManagerContactId { get; set; }
        public string CustomerServiceContactId { get; set; }
        public string FinanceContactId { get; set; }
        public int PendingMobilisationDoc { get; set; }


        public int ContractorId { get; set; }
        public int NoRequirementForm { get; set; }
        public int NoDocumentUploaded { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }
        public bool IsUploaded { get; set; }
        public string DocDescription { get; set; }
        public string DocumentName { get; set; }
        public int Customer_DocumentId { get; set; }
        public string SharepointFileReference { get; set; }
        public string FileReference { get; set; }


        public int CRFReviewId { get; set; }
        public int ExtLinkId { get; set; }
        public string ReviewStatus { get; set; }
        public string ReviewComment { get; set; }
    }
}
