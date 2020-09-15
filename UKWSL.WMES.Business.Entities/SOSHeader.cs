using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
  public  class SOSHeader :Log
    {
        public string SOSHeaderName { get; set; }
        public int SOSHeaderId { get; set; }

        public int SOSHeaderTypeId { get; set; }

        public int DealId { get; set; }

    }
}
