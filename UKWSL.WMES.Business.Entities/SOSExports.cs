using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class SOSExports
    {

        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }

        public string Region { get; set; }

        public string WasteTypeName { get; set; }

        public string MaterialTypeName { get; set; }

        public string EWCCode { get; set; }

        public  string ContainerTypeName { get; set; } 
        public string ContainerSizeName { get; set; }
        public string QuantityTypeName { get; set; }
        public decimal AssumedContainerWeight { get; set; }
        public int Quantity { get; set; }

        public string FrequencyTypeName { get; set; }
        public string FrequencyName { get; set; }
        public string Visits { get; set; }

        public string Comments { get; set; }

    }
}
