using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
  public  class Sites :Log
    {
        public int SiteId { get; set; }
        public string SiteIds { get; set; }
        public int CompanyId { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }

        public string Address { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        /// <summary>
        /// Changes as per Euw-727
        /// </summary>
        public string Region { get; set; }
        public int RegionId { get; set; }
        public int IsSiteExist { get; set; }
        public string Site { get; set; }
        public int ActionType { get; set; }
        public string Country { get; set; }
    }
}
