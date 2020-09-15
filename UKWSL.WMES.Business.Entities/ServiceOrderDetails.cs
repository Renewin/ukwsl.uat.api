using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ServiceOrderDetails:Log
    {
        public int JobId { get; set; }
        public int ContractorId { get; set; }
        public int SiteId { get; set; }

        public int OrderId { get; set; }
        public int OrderTypeId { get; set; }

        //contractor information for the order
        public string OrderType { get; set; }
        public DateTime TodayDate { get; set; }
        public string CompanyName { get; set; }
        public string AttentionOf { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhoneNumber { get; set; }
        //Order details
        public string ContractorPONumber { get; set; }
        public string BusinessName { get; set; }
        public string CompanySICCode { get; set; }
        public string SiteName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string SiteContactName { get; set; }
        public string SiteContactTelephone { get; set; }
        public string AccessComments { get; set; }
        public DateTime ActionDate { get; set; }
        public string MaterialType_Name { get; set; }
        public string EWCCode { get; set; }
        public string ContainerType_Name { get; set; }
        public string ContainerSize_Name { get; set; }
        public int Quantity { get; set; }
        public string Frequency_Name { get; set; }
        public decimal PricePerlift { get; set; }
        public decimal Transport { get; set; }
        public string QuantityType { get; set; }
        public decimal PricePerQuantity { get; set; }
        public decimal RentalPerDay { get; set; }

        public ServiceDetails CurrentServiceDetails { get; set; }
        public ServiceDetails NewServiceDetails { get; set; }
        public List<ServiceOrderDetails> lstServiceOrderDetails { get; set; }
        public string VisitsPerWeek { get; set; }
        public decimal AdditionalCharge { get; set; }
        public string ChargeReason { get; set; }
        public int ReturnId { get; set; }
        public string ContractorName { get; set; }
        public int ServiceStatusId { get; set; }
        public string ServiceStatusName { get; set; }
        public string JobTypeName { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int WasteTypeId { get; set; }
        public string WasteType_Name { get; set; }
        public DateTime? Confirmation_ActualDateOfDelivery { get; set; }
        public DateTime? Confirmation_ActualCollectionDate { get; set; }
    }

    public class ServiceDetails
    {
        public string MaterialType { get; set; }
        public string EWCCode { get; set; }
        public string ContainerType { get; set; }
        public string ContainerSize { get; set; }
        public int? Quantity { get; set; }
        public string VisitsperWeek { get; set; }
        public decimal? PricePerLift { get; set; }
       
    }
}
