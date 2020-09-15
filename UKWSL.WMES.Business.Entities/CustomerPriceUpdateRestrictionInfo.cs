using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class CustomerPriceUpdateRestrictionInfo : Result
    {
        public List<CustomerPriceUpdateRestriction> lstCustomerPriceUpdateRestriction { get; set; }
        public CustomerPriceUpdateRestriction CustomerPriceUpdateRestriction { get; set; }
        public List<CustomerPriceUpdateRestrictionHistory> lstCustomerPriceUpdateRestrictionHistory { get; set; }
        public CustomerPriceUpdateRestrictionHistory CustomerPriceUpdateRestrictionHistory { get; set; }

        public CustomerPriceUpdateRestrictionInfo()
        {
            lstCustomerPriceUpdateRestriction = new List<CustomerPriceUpdateRestriction>();
            CustomerPriceUpdateRestriction = new CustomerPriceUpdateRestriction();
            lstCustomerPriceUpdateRestrictionHistory = new List<CustomerPriceUpdateRestrictionHistory>();
            CustomerPriceUpdateRestrictionHistory = new CustomerPriceUpdateRestrictionHistory();
        }
    }
}
