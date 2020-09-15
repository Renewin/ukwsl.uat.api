using System;
using System.Collections.Generic;

namespace UKWSL.WMES.Business.Entities
{
    public class ServiceJobDetails : Log
    {
        public int JobId { get; set; }
        public int ServiceId { get; set; }
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public int JobStatusId { get; set; }
        public string JobStatusName { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int ServiceStatusId { get; set; }
        public string ServiceStatusName { get; set; }
        public string ContractorPOnumber { get; set; }
        public int SalesContactId { get; set; }
        public string ServiceComments { get; set; }
        public string InternalComments { get; set; }
        public int WasteTypeId { get; set; }
        public string WasteType_Name { get; set; }
        public string MaterialType_Name { get; set; }
        public string EWCCode { get; set; }
        public string ContainerType_Name { get; set; }
        public string ContainerSize_Name { get; set; }
        public decimal? AssumedContainerWeight { get; set; }
        public int? BagTypeId { get; set; }
        public int? Quantity { get; set; }
        public string VisitsPerWeek { get; set; }
        public string WeightType { get; set; }
        public string WeightUsage { get; set; }
        public string Extra_CustomerPONumber { get; set; }
        public string Extra_TicketNo { get; set; }
        public bool Extra_Monday { get; set; }
        public bool Extra_Tuesday { get; set; }
        public bool Extra_Wednesday { get; set; }
        public bool Extra_Thursday { get; set; }
        public bool Extra_Friday { get; set; }
        public bool Extra_Saturday { get; set; }
        public bool Extra_Sunday { get; set; }
        public string Extra_CustomField1 { get; set; }
        public string Extra_CustomField2 { get; set; }
        public string Extra_CustomField3 { get; set; }
        public string Extra_CustomField4 { get; set; }
        public string Extra_CustomField5 { get; set; }

        public decimal? CustPrice_price_per_lift { get; set; }
        public decimal? CustPrice_additional_charge { get; set; }
        public decimal? CustPrice_additional_charge_frequency { get; set; }
        public string CustPrice_reason_for_additional_charge { get; set; }
        public decimal? CustPrice_transport { get; set; }
        public decimal? CustPrice_transport_per_quantity { get; set; }
        public decimal? CustPrice_minimum_transport_charge { get; set; }
        public decimal? CustPrice_price_per_quantity { get; set; }
        public int? CustPrice_QtyTypeId { get; set; }
        public decimal? CustPrice_minimum_quantity { get; set; }
        public decimal? CustPrice_max_quantity { get; set; }
        public decimal? CustPrice_excess_weight_charge { get; set; }
        public decimal? CustPrice_rental_day_per_container { get; set; }
        public decimal? CustPrice_demurrage_charge_per_hour { get; set; }
        public decimal? CustPrice_actual_demurrage { get; set; }
        public decimal? CustPrice_consignment_note_Charge_vist { get; set; }

        public string ContractorName { get; set; }
        public string ContractorContact { get; set; }
        public int? DepotId { get; set; }
        public int? FacilityTypeId { get; set; }
        public int? FacilityId { get; set; }
        public int? EndDestinationTypeId { get; set; }
        public string EndDestination { get; set; }
        public decimal? ContrPrice_Cost_per_lift { get; set; }
        public decimal? ContrPrice_additional_charge { get; set; }
        public decimal? ContrPrice_additional_charge_frequency { get; set; }
        public string ContrPrice_reason_for_additional_charge { get; set; }
        public decimal? ContrPrice_transportcost { get; set; }
        public decimal? ContrPrice_transport_per_quantity { get; set; }
        public decimal? ContrPrice_minimum_transport_charge { get; set; }
        public decimal? ContrPrice_Cost_per_quantity { get; set; }
        public int? ContrPrice_QtyTypeId { get; set; }
        public decimal? ContrPrice_minimum_quantity { get; set; }
        public decimal? ContrPrice_max_quantity { get; set; }
        public decimal? ContrPrice_excess_weight_charge { get; set; }
        public decimal? ContrPrice_rental_day_per_container { get; set; }
        public decimal? ContrPrice_demurrage_charge_per_hour { get; set; }
        public decimal? ContrPrice_actual_demurrage { get; set; }
        public decimal? ContrPrice_consignment_note_visit { get; set; }

        public DateTime? Confirmation_PlannedDeliveryDate { get; set; }
        public string Confirmation_PeriodofDelivery { get; set; }
        public DateTime? Confirmation_ActualDateofDelivery { get; set; }
        public int? Confirmation_DeliveryFailureReason { get; set; }
        public DateTime? Confirmation_PlannedCollectionDate { get; set; }
        public string Confirmation_PeriodofCollection { get; set; }
        public DateTime? Confirmation_ActualCollectionDate { get; set; }

        public string IncumbentContractorName { get; set; }
        public string IncumbentContactName { get; set; }
        public string IncumbentTelephoneNumber { get; set; }
        public DateTime? RemovalDategivenbyIncumbentContractor { get; set; }
        public DateTime? ActualRemovalDategivenbyContractor { get; set; }
        public string CancelletterPointofContact { get; set; }
        public string TelephoneAuditReq { get; set; }
        public string RoomforDualBins { get; set; }
        public string WelcomePackSenttoSite { get; set; }
        public string MobilisationComments { get; set; }
        public decimal? ExpectedAnnualTurnover { get; set; }
        public decimal? ExpectedAnnualCoS { get; set; }
        public decimal? ExpectedAnnualMargin { get; set; }
        public decimal? Post_MobilisationAnnualTurnover { get; set; }
        public decimal? Post_MobilisationAnnualCoS { get; set; }
        public decimal? Post_MobilisationAnnualMargin { get; set; }
        public decimal? AnnualTurnoverDifference { get; set; }
        public decimal? AnnualCoSDifference { get; set; }
        public decimal? AnnualMarginDifference { get; set; }
        public List<ServiceJobDetails> lstServiceHistory { get; set; }
        public List<ServiceJobDetails> lstServiceReportServiceTracker { get; set; }

        public int CustomerId { get; set; }
        public int Customer_SiteId { get; set; }
        public int MaterialTypeId { get; set; }
        public int ContainerTypeId { get; set; }
        public int ContainerSizeId { get; set; }
        public int FrequencyTypeId { get; set; }
        public int FrequencyId { get; set; }
        public bool IncludeCommentInInvoice { get; set; }

        public string CustomerName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public int AccountId { get; set; }
        public int ContractorId { get; set; }
		public int IsExist { get; set; }

        public bool IsConfirmed { get; set; }
        public bool IsCancelled { get; set; }
         public string FrequencyType_Name { get; set; }
        public decimal? ActualWeight { get; set; }
        public string Comment { get; set; }
        public string ConfirmationName { get; set; }
        public DateTime CollectionDate { get; set; }
        public int AWCount { get; set; }
        public int AWId { get; set; }
        public string JobConfirmedBy { get; set; }
    }
}
