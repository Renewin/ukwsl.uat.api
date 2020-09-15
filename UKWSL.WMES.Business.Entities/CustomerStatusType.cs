using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerStatusType:Log
    {
        public int CustomerStatusId { get; set; }
        public string CustomerStatusName { get; set; }
    }
}
