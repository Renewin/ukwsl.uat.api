using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class CustomerPriceUpdateRestriction : Log
    {
        public int RestrictionId { get; set; }
        public string RestrictionIds { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<DateTime> ActionDate { get; set; }
    }
}
