using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorDepots: Log
    {
        public int Contractor_DepotID { get; set; }
        public int ContractorId { get; set; }
        public int? Contractor_ContactId { get; set; }
        public string DepotName { get; set; }
        public string AccountCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string ContractorContact { get; set; }
        public string Contractor_DepotIDs { get; set; }

        public int ContractorDepotAllocationId { get; set; }
        public int FacilityId { get; set; }
        public int CanDelete { get; set; }

        //Contact Details fields
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string JobTitle { get; set; }
        public int LegalBasisId { get; set; }
        public string Contact_AddressLine1 { get; set; }
        public string Contact_AddressLine2 { get; set; }
        public string Contact_Town { get; set; }
        public string Contact_County { get; set; }
        public string Contact_Postcode { get; set; }
        public string Contact_Country { get; set; }
        public string Contact_ContactNumber { get; set; }
        public string Contact_MobileNumber { get; set; }
        public string Contact_MainEmailAddress { get; set; }
        public string Contact_AdditionalEmailAddress { get; set; }

        public string Contact_JobTitle { get; set; }
        public IEnumerable<int> Contractor_ContactTypeIdList { get; set; }
        public string Contractor_ContactTypeIds { get; set; }
    }
}
