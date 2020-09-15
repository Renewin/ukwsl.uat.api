using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.ApprovedPricing;
using UKWSL.WMES.Repositories.ScheduleofServices;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Business.ApprovedPricing
{
    public class ApprovedPricingManager : IApprovedPricingManager
    {

        private IApprovedPricingRepository _approvedPricingRepository;

        public ApprovedPricingManager(IApprovedPricingRepository approvedPricingRepository)
        {
            _approvedPricingRepository = approvedPricingRepository;
        }
        
        public SOSInfo UploadApprovedPricingSolutionCSVRawData(SOSInfo sOSInfo)
        {

            DataTable _dtAPS = new DataTable();
            _dtAPS = ListtoDataTableConverter.ToDataTable(sOSInfo.lstApprovedPricingSolutionUDT);
            return _approvedPricingRepository.UploadApprovedPricingSolutionCSVRawData(sOSInfo, _dtAPS);

        }
        public ApprovedPricingSolution UpdateAPIdStatus(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.UpdateAPIdStatus(approvedPricingSolution);
        }
        public SOSInfo GetProcessedAPSData(SOSInfo sOSInfo)
        {
            return _approvedPricingRepository.GetProcessedAPSData(sOSInfo);
        }
        public SOSInfo InsertUploadedApprovedPricingSolutionData(SOSInfo sOSInfo)
        {
            return _approvedPricingRepository.InsertUploadedApprovedPricingSolutionData(sOSInfo);
        }

        public SOSInfo GetApprovedPricingDataByDealIdCompanyId(SOSInfo sOSInfo)
        {
            return _approvedPricingRepository.GetApprovedPricingDataByDealIdCompanyId(sOSInfo);
        }

        public SOSInfo AddUpdateApprovedPricingSolution(SOSInfo sOSInfo)
        {
            return _approvedPricingRepository.AddUpdateApprovedPricingSolution(sOSInfo);
        }

        public SOSInfo AddUpdateApprovedPricingSolutionByMobilization(SOSInfo sOSInfo)
        {
            return _approvedPricingRepository.AddUpdateApprovedPricingSolutionByMobilization(sOSInfo);
        }

        public SOSInfo DeleteApprovedPricingSolution(SOSInfo sOSInfo)
        {
            return _approvedPricingRepository.DeleteApprovedPricingSolution(sOSInfo);
        }

        public SOSInfo BulkDeleteApprovedPricingSolution(SOSInfo sOSInfo)
        {
            return _approvedPricingRepository.BulkDeleteApprovedPricingSolution(sOSInfo);
        }
        public ApprovedPricingSolution GetApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.GetApprovedPricingAccountbyAccountNumber(approvedPricingSolution);
        }
        public ApprovedPricingSolution GetApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.GetApprovedPricingSitesbySiteCode(approvedPricingSolution);
        }
        public ApprovedPricingSolution GetApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.GetApprovedPricingContactsByEmail(approvedPricingSolution);
        }

        public ApprovedPricingSolution UpdateApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.UpdateApprovedPricingAccountbyAccountNumber(approvedPricingSolution);
        }
        public ApprovedPricingSolution UpdateApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.UpdateApprovedPricingSitesbySiteCode(approvedPricingSolution);
        }
        public ApprovedPricingSolution UpdateApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.UpdateApprovedPricingContactsByEmail(approvedPricingSolution);
        }

        public ApprovedPricingSolution DeleteApprovedPricingAccountbyAccountNumber(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.DeleteApprovedPricingAccountbyAccountNumber(approvedPricingSolution);
        }
        public ApprovedPricingSolution DeleteApprovedPricingSitesbySiteCode(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.DeleteApprovedPricingSitesbySiteCode(approvedPricingSolution);
        }
        public ApprovedPricingSolution DeleteApprovedPricingContactsByEmail(ApprovedPricingSolution approvedPricingSolution)
        {
            return _approvedPricingRepository.DeleteApprovedPricingContactsByEmail(approvedPricingSolution);
        }

        public ApprovedPricingSolution BulkDeleteApprovedPricingAccountbyAccountNumber(List<ApprovedPricingSolution> lstApprovedPricingSolution)
        {
            return _approvedPricingRepository.BulkDeleteApprovedPricingAccountbyAccountNumber(lstApprovedPricingSolution);
        }
        public ApprovedPricingSolution BulkDeleteApprovedPricingSitesbySiteCode(List<ApprovedPricingSolution> lstApprovedPricingSolution)
        {
            return _approvedPricingRepository.BulkDeleteApprovedPricingSitesbySiteCode(lstApprovedPricingSolution);
        }
        public ApprovedPricingSolution BulkDeleteApprovedPricingContactsByEmail(List<ApprovedPricingSolution> lstApprovedPricingSolution)
        {
            return _approvedPricingRepository.BulkDeleteApprovedPricingContactsByEmail(lstApprovedPricingSolution);
        }
    }
}
