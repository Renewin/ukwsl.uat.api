using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorContact : Log
    {
       public int Contractor_ContactId { get; set; }
        public string Contractor_ContactTypeIds { get; set; }
        public string Contactor_ContactTypeName { get; set; }
        public string Contact_LegalBasisData { get; set; }
        public int ContractorId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string JobTitle { get; set; }
        public int LegalBasisId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string MobileNumber { get; set; }
        public string ContactNumber { get; set; }
        public string AdditionalEmailAddress { get; set; }
        public string MainEmailAddress { get; set; }
        public string Contractor_ContactIds { get; set; }
        public string ContractorContacts { get; set; }
        public string Description { get; set; }

        public int ReturnId { get; set; }

    }
}
 