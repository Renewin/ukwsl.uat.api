using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class PriceUpdate_ExceptionReport
    {

        public int ActionHeaderId { get; set; }
        public string PriceUpdateStatus { get; set; }
        public string ReasonforRejection { get; set; }
        public string ContractorPONumber { get; set; }
        public string JobType { get; set; }
        public string CustomerName { get; set; }
        public string SiteName { get; set; }
        public string Postcode { get; set; }
        public string WasteType { get; set; }
        public string MaterialType { get; set; }
        public string EWCCode { get; set; }
        public string ContainerType{ get; set; }
        public string ContainerSize{ get; set; }
        public int Quantity { get; set; }
        public string EstimatedFrequency { get; set; }
        public string WeightUsage { get; set; }
        public decimal CustPrice_PricePerlift { get; set; }
        public decimal CustPrice_AdditionalCharge { get; set; }
        public decimal CustPrice_AdditionalChargeFrequency { get; set; }
        public decimal CustPrice_TransportCost { get; set; }
        public decimal CustPrice_TransportPerQuantity { get; set; }
        public decimal CustPrice_MinimumTransportCharge { get; set; }
        public decimal CustPrice_PricePerQuantity { get; set; }
        public string CustPrice_QtyType { get; set; }
        public int CustPrice_MinimumQuantity { get; set; }
        public int CustPrice_MaxQuantity { get; set; }
        public decimal CustPrice_ExcessWeightCharge { get; set; }
        public decimal CustPrice_RentalPerUnit_PerDay { get; set; }
        public decimal CustPrice_DemurragePerHour { get; set; }
        public decimal CustPrice_ActualDemurrage { get; set; }
        public decimal CustPrice_ConsignmentNoteCharge_PerVisit { get; set; }
        public decimal ContPrice_CostPerlift { get; set; }
        public decimal ContPrice_AdditionalCharge { get; set; }
        public decimal ContPrice_AdditionalChargeFrequency { get; set; }
        public decimal ContrPrice_TransportCost { get; set; }
        public decimal ContrPrice_TransportPerQuantity { get; set; }
        public decimal ContrPrice_MinimumTransportCharge { get; set; }
        public decimal ContrPrice_CostPerQuantity { get; set; }
        public string ContrPrice_QtyType { get; set; }
        public int ContrPrice_MinimumQuantity { get; set; }
        public int ContrPrice_MaxQuantity { get; set; }
        public decimal ContrPrice_ExcessWeightCharge { get; set; }
        public decimal ContrPrice_RentalPerUnit_PerDay { get; set; }
        public decimal ContrPrice_DemurragePerHour { get; set; }
        public decimal ContrPrice_ActualDemurrage { get; set; }
        public decimal ContrPrice_ConsignmentNoteCharge_PerVisit { get; set; }
        public DateTime PlannedCollectionDate { get; set; }
        public string PeriodofCollection { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
