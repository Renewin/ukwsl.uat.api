using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorType: Log
    {
        public int ContractorTypeId { get; set; }
        public string ContractorTypeName { get; set; }
        public int TotalContractors { get; set; }
        public decimal Percentage { get; set; }
    }
}
