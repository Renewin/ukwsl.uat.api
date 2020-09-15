using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public  class DealInfo : Result
    {

        public List<CompanyDealUDT> companyDealUDTs { get; set; }
        public Deal deal { get; set; }
        public List<DealHistory> lstdealHistories { get; set; }
    }
}
