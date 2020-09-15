using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Container : Log
    {
        public int WasteTypeId { get; set; }
        public int MaterialTypeId { get; set; }
        public int ContainerTypeId { get; set; }
        public int ContainerSizeId { get; set; }
        public string AverageContainerWeightTonnes { get; set; }
        public string WasteTypeIds { get; set; }
    }
}
