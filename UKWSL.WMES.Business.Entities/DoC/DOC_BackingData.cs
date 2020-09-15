using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities.DoC
{
    public class DOC_BackingData
    {
        public int DOCBackingId { get; set; }
        public int DOCId { get; set; }
        public string SiteCode { get; set; }
        public string SICCode { get; set; }
        public string SiteName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string WasteType { get; set; }
        public string MaterialType { get; set; }
        public string EWCCode { get; set; }
        public string ContainerType { get; set; }
        public string ContainerSize { get; set; }
        public int Quantity { get; set; }
        public string Frequencyname { get; set; }
        public string ContractorName { get; set; }
        public string WasteCarriersLicenceNumber { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }

    }
}
