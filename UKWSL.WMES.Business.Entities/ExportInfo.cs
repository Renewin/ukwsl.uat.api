using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class ExportInfo :Result
    {
        public List<SOSExports> lstSOSExports { get; set; }

        public int DealId { get; set; }
        public int SOSHeaderId { get; set; }
    }
}
