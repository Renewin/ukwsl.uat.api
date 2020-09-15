using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerType:Log
    {
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public int TotalCustomers { get; set; }
        public decimal Percentage { get; set; }
    }
}
