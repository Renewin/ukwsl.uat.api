using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class DocumentInfo : Log
    {
        public int Customer_DocumentId { get; set; }
        public int SharePointId { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string DocumentName { get; set; }
        public string DocDescription { get; set; }
        public string ExpiringIn { get; set; }
        public string FileReference { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int CustomerId { get; set; }
        public int ContractorId { get; set; }
        public int Contractor_DocumentId { get; set; }

        public int Facility_LicenceDocumentId { get; set; }
        public int FacilityId { get; set; }
        public string LicenceNo { get; set; }
        public string WebSiteURL { get; set; }
        public string FacilityDocumentStatus { get; set; }
        public int NoofDocuments { get; set; }

    }
}
