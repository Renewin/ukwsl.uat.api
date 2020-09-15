using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class WasteType:Log
    {
        public int WasteTypeId { get; set; }
        public string WasteTypeName { get; set; }
        public string WasteTypeDesc { get; set; }

    }
}
