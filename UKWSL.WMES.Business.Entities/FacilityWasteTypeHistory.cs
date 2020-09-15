using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class FacilityWasteTypeHistory : Result
    {
        public WasteType WasteTypeInfo { get; set; }
        public FacilityBasicInfo FacilityBasicInfo { get; set; }
        public List<FacilityPercentage> lstWasteTypePercentages { get; set; }
        public FacilityWasteTypeHistory()
        {
            WasteTypeInfo = new WasteType();
            FacilityBasicInfo = new FacilityBasicInfo();
            lstWasteTypePercentages = new List<FacilityPercentage>();
        }
    }
}
