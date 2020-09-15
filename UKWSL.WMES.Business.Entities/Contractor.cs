using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
  public  class Contractor :Log
    {
        public int ContractorId { get; set; }
        public string ContractorName { get; set; }
    }
}
