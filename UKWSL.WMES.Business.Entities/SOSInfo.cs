using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class SOSInfo : Result
    {
        public ScheduleofService scheduleofServices { get; set; }
        public List<ScheduleService> lstScheduleService { get; set; }

        public List<ScheduleService> lstPassedScheduleService { get; set; }
        public List<ScheduleService> lstFailedScheduleService { get; set; }

        public List<SOSHeader> lstSOSHeader { get; set; }
        public SOSFileDetails sOSFileDetails { get; set; }

        public int SOSUploadId { get; set; }
        public int SOSHeaderId { get; set; }

        public int CompanyId { get; set; }
        public int DealId { get; set; }
        public int ApprovedPricingId { get; set; }
        public int DataTypeId { get; set; }
        public bool APSStatus { get; set; }
        public int CreatedBy { get; set; }

        public ApprovedPricingSolution ApprovedPricingSolution { get; set; }
        public List<SOSUDTFileData> sOSUDTFileData { get; set; }

        public List<ApprovedPricingSolution> lstPassedApprovedPricingSolution { get; set; }
        public List<ApprovedPricingSolution> lstFailedApprovedPricingSolution { get; set; }
        public List<ApprovedPricingSolution> lstApprovedPricingSolution { get; set; }
        public List<ApprovedPricingSolutionUDT> lstApprovedPricingSolutionUDT { get; set; }
        public int ReturnValue { get; set; }
        public List<ApprovedPricingSolution> lstAPSAccounts { get; set; }
        public List<ApprovedPricingSolution> lstAPSSites { get; set; }
        public List<ApprovedPricingSolution> lstAPSContacts { get; set; }
    }
}
