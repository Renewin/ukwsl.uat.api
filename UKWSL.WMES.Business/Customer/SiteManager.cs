using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Customer;

namespace UKWSL.WMES.Business.Customer
{
  public  class SiteManager :ISiteManager
    {

        private ISiteRepository _siteRepository;

        public SiteManager(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }
        public Sites CreateUpdateSite(Sites sites)
        {
            return _siteRepository.CreateUpdateSite(sites);
        }

        public Sites CheckSiteName(Sites sites)
        {
            return _siteRepository.CheckSiteName(sites);
        }

        public Sites CheckSiteCode(Sites sites)
        {
            return _siteRepository.CheckSiteCode(sites);
        }

        public Sites GetSite(Sites sites)
        {
            return _siteRepository.GetSite(sites);
        }

        public Sites DeleteSiteInfo(Sites sites)
        {
            return _siteRepository.DeleteSiteInfo(sites);
        }
    }
}
