using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Pricing
{
  public interface IPricingOptimizationManager
    {

        PricingInfo GetContractorPrice(PricingInfo pricingInfo);
        PricingInfo GetPricingDeals(CompanyInfo companyInfo);
        PricingInfo UploadPricingCsv(PricingInfo pricingInfo);

        PricingInfo GetPreferredContractorPrice(PricingInfo pricingInfo);

        PricingInfo UpdateContractorPrice(PreferredContractorPrice contractorPrice);
        SOSInfo UploadCSVRawData(ScheduleofService scheduleofService, SOSFileDetails sOSFileDetails, List<SOSUDTFileData> sOSUDTFileData);

        SOSInfo InsertUploadedData(SOSInfo sOSInfo);

    }
}
