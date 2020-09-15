using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorSHEQArchiveDetails : Log
    {
        public int Id { get; set; }
        public int ContractorId { get; set; }
        public int SHEQDocument_TypeId { get; set; }
        public string LicenceNo { get; set; }
        public string DocDescription { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal PolicyValue { get; set; }
        public decimal CoverTotal { get; set; }
        public decimal CoverClaim { get; set; }
        public int SharepointId { get; set; }
        public string DocFileName { get; set; }
        public string SharepointFileReference { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }
        public string ArchivedBy { get; set; }
        public DateTime ArchivedOn { get; set; }

        public string MainSectionDescription { get; set; }
        public string SubSectionDescription { get; set; }
        public string SHEQDocument_TypeName { get; set; }
        public string ExpiringIn { get; set; }
    }
}
