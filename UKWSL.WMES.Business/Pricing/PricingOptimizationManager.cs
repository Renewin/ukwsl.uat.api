using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Pricing;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Business.Pricing
{
   public class PricingOptimizationManager :IPricingOptimizationManager
    {

        private IPricingOptimizationRepository _PricingOptimizationRepository;

        public PricingOptimizationManager(IPricingOptimizationRepository pricingOptimizationRepository)
        {
            _PricingOptimizationRepository = pricingOptimizationRepository;
        }

        public PricingInfo GetContractorPrice(PricingInfo pricingInfo)
        {
            return _PricingOptimizationRepository.GetContractorPrice(pricingInfo);
        }

        public PricingInfo GetPricingDeals(CompanyInfo companyInfo)
        {

           return _PricingOptimizationRepository.GetPricingDeals(companyInfo);
        }

        public PricingInfo UploadPricingCsv(PricingInfo pricingInfo)
        {

            DataTable _dtPricing = new DataTable();
            _dtPricing = ListtoDataTableConverter.ToDataTable(pricingInfo.lstpricingToolUDTFileData);
            return _PricingOptimizationRepository.UploadPricingCsv(pricingInfo, pricingInfo.filedetails, _dtPricing);
        }

        public PricingInfo GetPreferredContractorPrice(PricingInfo pricingInfo)
        {

            return _PricingOptimizationRepository.GetPreferredContractorPrice(pricingInfo);
        }

        public PricingInfo UpdateContractorPrice(PreferredContractorPrice contractorPrice)
        {

            return _PricingOptimizationRepository.UpdateContractorPrice(contractorPrice);
        }

        public SOSInfo UploadCSVRawData(ScheduleofService scheduleofService, SOSFileDetails sOSFileDetails, List<SOSUDTFileData> sOSUDTFileData)
        {

            DataTable _dtSOS = new DataTable();
            _dtSOS = ListtoDataTableConverter.ToDataTable(sOSUDTFileData);
            return _PricingOptimizationRepository.UploadCSVRawData(scheduleofService, sOSFileDetails, _dtSOS);

        }

        public SOSInfo InsertUploadedData(SOSInfo sOSInfo)
        {
            return _PricingOptimizationRepository.InsertUploadedData(sOSInfo);
        }


    }
}
