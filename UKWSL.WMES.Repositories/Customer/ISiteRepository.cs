using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Customer
{
  public  interface ISiteRepository
    {
        Sites CreateUpdateSite(Sites sites);
        Sites CheckSiteName(Sites sites);
        Sites CheckSiteCode(Sites sites);
        Sites GetSite(Sites sites);
        Sites DeleteSiteInfo(Sites sites);
    }
}
