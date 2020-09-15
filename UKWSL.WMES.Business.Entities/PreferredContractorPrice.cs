using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class PreferredContractorPrice : Log
    {
        public int PCId { get; set; }
        public int ContractorId { get; set; }
        public string ContractorName { get; set; }
        public decimal CostPerLift { get; set; }
        public int QuantityTypeId { get; set; }
        public string PreferredQuantityType { get; set; }
        public decimal CostQuantity { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public decimal ExcessCharge { get; set; }
        public decimal TransportCost { get; set; }
        public decimal RentalUnitDay { get; set; }
        public decimal ConsignmentNoteVisit { get; set; }
        public decimal Demurragehour { get; set; }
        public decimal CostWeek { get; set; }
        public int EndDestinationTypeId { get; set; }

        public string EndDestinationTypeName { get; set; }
        public string FacilityName1 { get; set; }
        public string FacilityName2 { get; set; }
        public string PricingComments { get; set; }
        public string QuantityTypeName { get; set; }
        public bool IsPreferred { get; set; }
        public int SOSId { get; set; }
        public int SOSHeaderId { get; set; }
        public string Comments { get; set; }
    }
}
