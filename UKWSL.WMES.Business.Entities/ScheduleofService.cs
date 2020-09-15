using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
  public  class ScheduleofService
    {

        public int SOSId { get; set; }

        public int SOSHeaderId { get; set; }

        public int DealId { get; set; }
        public int SiteId { get; set; }
        public int WasteTypeId { get; set; }
        public string WasteType { get; set; }
        public int MaterialTypeId { get; set; }
        public string MaterialType { get; set; }
        public int ContainerTypeId { get; set; }
        public string ContainerType { get; set; }
        public int ContainerSizeId { get; set;}
        public string ContainerSize { get; set; }
        public int QuantityTypeId { get; set; }
        public string QuantityTypeName { get; set; }
        public string EWCCode { get; set; }
        public string Quantity { get; set; }

        public int FrequencyTypeId { get; set; }
        public int FrequencyId { get; set; }

        public string FrequencyTypeName { get; set; }
        public string Frequency { get; set; }
        public decimal AverageContainerWeightTonnes { get; set; }

        public int PricingMethodId { get; set; }

        public string PricingMethod { get; set; } 
        public int CreatedBy { get; set; }

        public int IsSOSExist { get; set; }
        public string Comments { get; set; }
        public string SOSIds { get; set; }

    }
}
