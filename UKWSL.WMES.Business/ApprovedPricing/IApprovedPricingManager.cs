using System.Collections.Generic;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.ApprovedPricing
{
    public interface IApprovedPricingManager
    {   
        SOSInfo UploadApprovedPricingSolutionCSVRawData(SOSInfo sOSInfo);
        SOSInfo InsertUploadedApprovedPricingSolutionData(SOSInfo sOSInfo);
        SOSInfo GetProcessedAPSData(SOSInfo sOSInfo);
        ApprovedPricingSolution UpdateAPIdStatus(ApprovedPricingSolution approvedPricingSolution);

        SOSInfo GetApprovedPricingDataByDealIdCompanyId(SOSInfo sOSInfo);
        SOSInfo AddUpdateApprovedPricingSolution(SOSInfo sOSInfo);
        SOSInfo AddUpdateApprovedPricingSolutionByMobilization(SOSInfo sOSInfo);
        SOSInfo DeleteApprovedPricingSolution(SOSInfo sOSInfo);
        SOSInfo BulkDeleteApprovedPricingSolution(SOSInfo sOSInfo);

        ApprovedPricingSolution GetApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution);
        ApprovedPricingSolution GetApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution);
        ApprovedPricingSolution GetApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution);

        ApprovedPricingSolution UpdateApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution);
        ApprovedPricingSolution UpdateApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution);
        ApprovedPricingSolution UpdateApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution);

        ApprovedPricingSolution DeleteApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution);
        ApprovedPricingSolution DeleteApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution);
        ApprovedPricingSolution DeleteApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution);

        ApprovedPricingSolution BulkDeleteApprovedPricingAccountbyAccountNumber(List<ApprovedPricingSolution> lstApprovedPricingSolution);
        ApprovedPricingSolution BulkDeleteApprovedPricingSitesbySiteCode(List<ApprovedPricingSolution> lstApprovedPricingSolution);
        ApprovedPricingSolution BulkDeleteApprovedPricingContactsByEmail(List<ApprovedPricingSolution> lstApprovedPricingSolution);
    }
}
