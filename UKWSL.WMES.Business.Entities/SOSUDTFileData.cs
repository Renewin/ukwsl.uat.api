using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class SOSUDTFileData
    {
        //public int id { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string Address_line1 { get; set; }
        public string Address_line2 { get; set;}
        public string Town { get; set; }
        public string County { get; set; }

        public string Region { get; set; }
        public string PostCode { get; set; }
        public string WasteType { get; set; }
        public string MaterialType { get; set; }
        public string ContainerType { get; set; }
        public string ContainerSize { get; set; }

        public string CustomerQuantityType { get; set; }

        public string AverageContainerWeight { get; set; }
        public string Quantity { get; set; }
        public string FrequencyType { get; set; }

        public string EstimatedFrequency { get; set; }
        //public string PricingMethod { get; set; }
        public string Comments { get; set; }
    }
}
