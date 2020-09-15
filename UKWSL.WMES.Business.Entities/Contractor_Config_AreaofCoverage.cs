using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Contractor_Config_AreaofCoverage: Log
    {
        public int AOCId { get; set; }
        public int ContractorId { get; set; }
        public string PostCode { get; set; }
        public string AOCIds { get; set; }

    }
}
