using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Review_CustomerRequirementForm : Log
    {
        public int CRFReviewId { get; set; }
        public int ExtLinkId { get; set; }
        public int CustomerId { get; set; }
        public int Customer_DocumentId { get; set; }
        public string ReviewStatus { get; set; }
        public string ReviewComment { get; set; }
    }
}
