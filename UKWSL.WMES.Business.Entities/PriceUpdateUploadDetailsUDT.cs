using System;

namespace UKWSL.WMES.Business.Entities
{
    public class PriceUpdateUploadDetailsUDT
    {
        public string ContractorPONumber { get; set; }
        public string CustomerName { get; set; }
        public string SalesContact { get; set; }
        public string ServiceComments { get; set; }
        public string InternalComments { get; set; }
        public string CustomerPONumber { get; set; }
        public string SiteName { get; set; }
        public string SitePostCode { get; set; }
        public string SiteAccessComments { get; set; }
        public string WasteType { get; set; }
        public string MaterialType { get; set; }
        public string ContainerType { get; set; }
        public string ContainerSize { get; set; }
        public string Quantity { get; set; }
        public string EstimatedFrequency { get; set; }
        public string WeightUsage { get; set; }
        public string PriceUpdateStatus { get; set; }
        public decimal CustPrice_PricePerlift { get; set; }
        public decimal CustPrice_AdditionalCharge { get; set; }
        public decimal CustPrice_AdditionalChargeFrequency { get; set; }
        public decimal CustPrice_TransportCost { get; set; }
        public decimal CustPrice_TransportPerQuantity { get; set; }
        public decimal CustPrice_MinimumTransportCharge { get; set; }
        public decimal CustPrice_PricePerQuantity { get; set; }
        public string CustPrice_QuantityType { get; set; }
        public int CustPrice_MinimumQuantity { get; set; }
        public int CustPrice_MaxQuantity { get; set; }
        public decimal CustPrice_ExcessWeightCharge { get; set; }
        public decimal CustPrice_RentalPerUnit_PerDay { get; set; }
        public decimal CustPrice_DemurragePerHour { get; set; }
        public decimal CustPrice_ActualDemurrage { get; set; }
        public decimal CustPrice_ConsignmentNoteCharge_PerVisit { get; set; }
        public string ContractorName { get; set; }
        public decimal ContrPrice_CostPerlift { get; set; }
        public decimal ContrPrice_AdditionalCharge { get; set; }
        public decimal ContrPrice_AdditionalChargeFrequency { get; set; }
        public decimal ContrPrice_TransportCost { get; set; }
        public decimal ContrPrice_TransportPerQuantity { get; set; }
        public decimal ContrPrice_MinimumTransportCharge { get; set; }
        public decimal ContrPrice_CostPerQuantity { get; set; }
        public string ContrPrice_QuantityType { get; set; }
        public int ContrPrice_MinimumQuantity { get; set; }
        public int ContrPrice_MaxQuantity { get; set; }
        public decimal ContrPrice_ExcessWeightCharge { get; set; }
        public decimal ContrPrice_RentalPerUnit_PerDay { get; set; }
        public decimal ContrPrice_DemurragePerHour { get; set; }
        public decimal ContrPrice_ActualDemurrage { get; set; }
        public decimal ContrPrice_ConsignmentNoteCharge_PerVisit { get; set; }
        public DateTime PlannedCollectionDate { get; set; }
        public string PeriodofCollection { get; set; }
        public DateTime ActualCollectionDate { get; set; }
    }
}
