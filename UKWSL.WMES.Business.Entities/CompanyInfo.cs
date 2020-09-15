using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class CompanyInfo:Log
    {
        public int CompanyId { get; set; }
        public string CompanyIds { get; set; }
        public string CompanyName { get; set; }
        public bool ApplyLFTIncrease { get; set; }
        public string PriceInflation_Name { get; set; }
        public int? PriceInflationId { get; set; }
        public string Comment { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
