using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Review_ContractorSHEQ : Log
    {
        public int SDReviewId { get; set; }
        public int ExtLinkId { get; set; }
        public int SHEQDocument_TypeId { get; set; }
        public string ReviewStatus { get; set; }
        public string ReviewComment { get; set; }
    }
}
