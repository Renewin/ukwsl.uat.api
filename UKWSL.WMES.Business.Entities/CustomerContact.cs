using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerContact : Log
    {
        public int Vid { get; set; }
        public int CustomerID { get; set; }
        public int SiteId { get; set; }
        public string AccountName { get; set; }
        public string SiteName { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string AdditionalEmailAddress { get; set; }
        public string MainEmailAddress { get; set; }
        public string FirstName { get; set; }
        public string JobTitle { get; set; }
        public string SurName { get; set; }
        public string LegalBasisData { get; set; }
        public string MobileNo { get; set; }
        public string ContactNo { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public int TypeofContactId { get; set; }
        public string TypeofContact { get; set; }
        public string LastUpdatedBy { get; set; }
        public int ContactId { get; set; }


        public string H_FirstName { get; set; }
        public string H_SurName { get; set; }
        public string H_JobTitle { get; set; }
        public string H_LegalBasisProcessing { get; set; }
        public string H_MainEmailAddress { get; set; }
        public string H_AdditionalEmailAddress { get; set; }
        public string H_MobileNo { get; set; }
        public string H_ContactNo { get; set; }
        public string H_AddressLine1 { get; set; }
        public string H_Town { get; set; }
        public string H_County { get; set; }
        public string H_Region { get; set; }
        public string H_Country { get; set; }
        public bool H_IsActive { get; set; }

        public int IsFirstNameDiffer { get; set; }
        public int IsSurNameDiffer { get; set; }
        public int IsJobTitleDiffer { get; set; }
        public int IslegalDiffer { get; set; }
        public int IsMainEmailDiffer { get; set; }
        public int IsAdditionalEmailDiffer { get; set; }
        public int IsMobileNoDiffer { get; set; }
        public int IsContactNoDiffer { get; set; }
        public int IsAddress1Differ { get; set; }
        public int IsTownDiffer { get; set; }
        public int IsCountyDiffer { get; set; }
        public int IsRegionDiffer { get; set; }
        public int IsCountryDiffer { get; set; }
        public int IsActiveDiffer { get; set; }
        public string LegalBasisProcessing { get; set; }
        public int LegalBasisId { get; set; }
        public string ContactTypeName { get; set; }
        public int AccountId { get; set; }
        public int GroupId { get; set; }
        public string ContactIds { get; set; }
    }
}
