using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerContactUDT
    {
        public int Vid { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string ContactNo { get; set; }
        public string MobileNo { get; set; }        
        public string MainEmailAddress { get; set; }
        public string AdditionalEmailAddress { get; set; }
        public string JobTitle { get; set; }
        public string LegalBasisProcessing { get; set; }        
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public bool Active { get; set; }
    }
}
