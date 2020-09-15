using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class FacilityMaterialTypePercentage : FacilityMaterialTypePercentageUDT
    {
        public string MaterialTypeName { get; set; }
        public string EWCCode { get; set; }
    }

}
