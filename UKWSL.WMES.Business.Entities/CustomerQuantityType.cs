using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class CustomerQuantityType:Log
    {

        public int QuantityTypeId { get; set; }
        public string QuantityTypeName { get; set; }
        public int IsDefault { get; set; }
        public decimal Minvalue { get; set; }
        public decimal MaxValue { get; set; }
        public string Units { get; set; }
    }
}
