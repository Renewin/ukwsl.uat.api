using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Customer
{
   public interface IDealRepository
    {
        Deal CreateUpdateDeal(Deal deal);
        Deal CheckDeal(Deal deal);

        Deal UpdateDeal(Deal deal);
        Deal GetDeal(Deal deal);

        Deal UpdateDealOwner(Deal deal, DataTable dtDeals);

        DealInfo GetDealOwnerHistory(Deal deal);

        Deal DeleteDealInfo(Deal deal);

        Deal UpdateDealStatus(Deal deal);
    }
}
