using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ServiceBasicInfo
    {
        public int JobId { get; set; }
        public int Customer_SiteId { get; set; }
        public int ServiceId { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int ServiceStatusId { get; set; }
        public string ServiceStatusName { get; set; }
        public int WasteTypeId { get; set; }
        public string WasteType_Name { get; set; }
        public string MaterialType_Name { get; set; }
        public string ContainerType_Name { get; set; }
        public string ContainerSize_Name { get; set; }
        public int Quantity { get; set; }
        public string VisitsPerWeek { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string CollectionDays { get; set; }
        public string ContractorName { get; set; }
    }
}
