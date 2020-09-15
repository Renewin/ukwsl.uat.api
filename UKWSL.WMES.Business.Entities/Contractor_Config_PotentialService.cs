using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class Contractor_Config_PotentialService : Log
    {
        public int PSId { get; set; }
        public int ContractorId { get; set; }
        public WasteType WasteType { get; set; }
        public MaterialType MaterialType { get; set; }
        public ContainerType ContainerType { get; set; }
        public string PostCode { get; set; }
        public string PSIds { get; set; }

        public Contractor_Config_PotentialService()
        {
            WasteType = new WasteType();
            MaterialType = new MaterialType();
            ContainerType = new ContainerType();
        }
    }
}
