using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorSHEQDetails : Log
    {
        public int SHEQDocumentId { get; set; }
        public int ContractorId { get; set; }
        public int SHEQDocument_TypeId { get; set; }
        public string LicenceNo { get; set; }
        public string DocDescription { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? PolicyValue { get; set; }
        public decimal? CoverTotal { get; set; }
        public decimal? CoverClaim { get; set; }
        public int SharePointId { get; set; }
        public string DocFileName { get; set; }
        public string SharepointFileReference { get; set; }

        public string MainSectionDescription { get; set; }
        public string SubSectionDescription { get; set; }
        public string SHEQDocument_TypeName { get; set; }
        public string ExpiringIn { get; set; }
        public int ExtLinkId { get; set; }
        public int SDReviewId { get; set; }
        public string ReviewStatus { get; set; }
        public string ReviewComment { get; set; }
        public int ArchivedCount { get; set; }
    }
}
