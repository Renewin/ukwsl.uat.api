using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Review_ContractorContacts : Log
    {
        public int CRFReviewId { get; set; }
        public int ExtLinkId { get; set; }
        public int Contractor_ContactId { get; set; }
        public string ReviewStatus { get; set; }
        public string ReviewComment { get; set; }
    }
}
