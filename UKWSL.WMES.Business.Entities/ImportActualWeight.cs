using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ImportActualWeight : Log
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string JobIds { get; set; }
        public int IWID { get; set; }
        public int ContractorId { get; set; }
        public string CompanyName { get; set; }
        public string UploadStatus { get; set; }
        public string ReportStatus { get; set; }
        public string UploadComment { get; set; }

        public string ContractorPONumber { get; set; }
        public string JobTypeName{ get; set;}
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string SiteTown { get; set; }
        public string PostCode { get; set; }
        public int Customer_SiteId { get; set; }
        public string WasteType { get; set; }
        public int WasteTypeId { get; set; }
        public string MaterialType { get; set; }
        public int MaterialTypeId { get; set; }
        public string EWCCode { get; set; }
        public string ContainerType { get; set; }
        public int ContainerTypeId { get; set; }
        public string ContainerSize { get; set; }
        public int ContainerSizeId { get; set; }
        public string ContractorQuantityType { get; set; }
        public int QtyTypeId { get; set; }
        public decimal? ActualWeight { get; set; }
        public DateTime ActualCollectionDate { get; set; }
        public DateTime ActualDeliveryDate { get; set; }
        public int ServiceStatusId { get; set; }
        public string ServiceStatusName { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string AccountName { get; set; }
        public decimal? AssumedContainerWeight { get; set; }
        public DateTime Confirmation_ActualCollectionDate { get; set; }
        public string AccountNumber { get; set; }
        public string Address { get; set; }
        public string VisitsPerWeek { get; set; }
        public string ContractorName { get; set; }
        public DateTime Confirmation_ActualDateofDelivery { get; set; }
        public string SiteCode { get; set; }
        public bool IsConfirmed { get; set; }
        public decimal CustPrice_price_per_lift { get; set; }
        public decimal ContrPrice_cost_per_lift { get; set; }
        
    }
}
