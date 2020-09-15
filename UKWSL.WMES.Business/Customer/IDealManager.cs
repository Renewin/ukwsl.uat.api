using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Customer
{
  public  interface IDealManager
    {

        Deal CreateDeal(Deal deal);

        Deal UpdateDeal(Deal deal);
        Deal CheckDeal(Deal deal);
        Deal GetDeal(Deal deal);
        Deal UpdateDealOwner(DealInfo dealInfo);
        DealInfo GetDealOwnerHistory(Deal deal);
        Deal DeleteDealInfo(Deal deal);
        Deal UpdateDealStatus(Deal deal);
    }
}
