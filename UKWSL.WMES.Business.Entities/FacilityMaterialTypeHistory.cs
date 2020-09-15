using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class FacilityMaterialTypeHistory : Result
    {
        public MaterialType MaterialTypeInfo { get; set; }
        public FacilityBasicInfo FacilityBasicInfo { get; set; }
        public List<FacilityPercentage> lstMaterialTypePercentages { get; set; }
        public FacilityMaterialTypeHistory()
        {
            MaterialTypeInfo = new MaterialType();
            FacilityBasicInfo = new FacilityBasicInfo();
            lstMaterialTypePercentages = new List<FacilityPercentage>();
        }
    }
}
