using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class EndDestinationType :Log
    {
        public int EdTypeId { get; set; }
        public string EndDestinationTypeName { get; set; }
        public string EndDestinationTypeDesc { get; set; }

    }
}
