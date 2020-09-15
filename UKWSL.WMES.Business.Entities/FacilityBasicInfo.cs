using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class FacilityBasicInfo : Log
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int FacilityTypeId { get; set; }
        public string FacilityOperator { get; set; }
        public string PermitNumber { get; set; }
        public string WasteManagementLicenceNumber { get; set; }
        public string ExemptionNumber { get; set; }
        public string ScrapMetalLicenceNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public int? RegionId { get; set; }
        public string Country { get; set; }
        public int IsFacilityExist { get; set; }

        public string FacilityType_Name { get; set; }
        public string FacilityStatus { get; set; }
        public int NoofContractor { get; set; }
        public int TotalFacilities { get; set; }
        public decimal Percentage { get; set; }

        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

    }
}
