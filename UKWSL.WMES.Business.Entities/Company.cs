using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class Company : Result
    {
        public CompanyInfo companyInfo { get; set; }
        public List<CompanyInfo> lstCompanyInfo { get; set; }
        public Deal deal { get; set; }
        public List<Deal> lstDeals { get; set; }
        public List<Sites> lstSites { get; set; }

        public int IsCompanyExist { get; set; }
    }
}
