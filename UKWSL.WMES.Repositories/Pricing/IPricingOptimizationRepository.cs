using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Pricing
{
  public  interface IPricingOptimizationRepository
    {

        PricingInfo GetPricingDeals(CompanyInfo companyInfo);

        PricingInfo GetContractorPrice(PricingInfo pricingInfo);

        PricingInfo UploadPricingCsv(PricingInfo pricingInfo, Filedetails filedetails, DataTable dataTable);

        PricingInfo GetPreferredContractorPrice(PricingInfo pricingInfo);

        PricingInfo UpdateContractorPrice(PreferredContractorPrice contractorPrice);

        SOSInfo UploadCSVRawData(ScheduleofService scheduleofService, SOSFileDetails sOSFileDetails, DataTable dataTable);

        SOSInfo InsertUploadedData(SOSInfo sOSInfo);
    }
}
