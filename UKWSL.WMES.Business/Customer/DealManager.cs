using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Customer;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Business.Customer
{
    public class DealManager : IDealManager
    {
        private IDealRepository _dealRepository;

        public DealManager(IDealRepository dealRepository)
        {
            _dealRepository = dealRepository;
        }
        public Deal CreateDeal(Deal deal)
        {
            return _dealRepository.CreateUpdateDeal(deal);
        }
        public Deal UpdateDeal(Deal deal)
        {
            return _dealRepository.UpdateDeal(deal);
        }

        public Deal CheckDeal(Deal deal)
        {
            return _dealRepository.CheckDeal(deal);
        }

        public Deal GetDeal(Deal deal)
        {
            return _dealRepository.GetDeal(deal);
        }

        public Deal UpdateDealOwner(DealInfo dealInfo)
        {
            DataTable _dtDeals = new DataTable();
            _dtDeals = ListtoDataTableConverter.ToDataTable(dealInfo.companyDealUDTs);
            return _dealRepository.UpdateDealOwner(dealInfo.deal, _dtDeals);

        }
        public DealInfo GetDealOwnerHistory(Deal deal)
        {
            return _dealRepository.GetDealOwnerHistory(deal);

        }

        public Deal DeleteDealInfo(Deal deal)
        {
            return _dealRepository.DeleteDealInfo(deal);
        }

        public Deal UpdateDealStatus(Deal deal)
        {
            return _dealRepository.UpdateDealStatus(deal);
        }
    }
}
