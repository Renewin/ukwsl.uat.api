using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class CustomerAdminSettings:Log
    {
        public int CAId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SystemStartDate { get; set; }
        public int DateReportsAvailablefrom { get; set; }
        public bool DisplayHazOnReports { get; set; }
        public bool TicketRefRequired { get; set; }
        public string EndDestination { get; set; }
        public bool FacilityUsage { get; set; }
        public bool ExactLifts { get; set; }
        public bool DOCBackingData { get; set; }
        public decimal ServiceSuccessReportSLA { get; set; }
        public decimal WasteCarrierReportSLA { get; set; }
        public decimal LandfieldDiversionReportSLA { get; set; }
        public decimal CustomerSuccessReportSLA { get; set; }
        public bool CustomField1_IsRequired { get; set; }
        public string CustomField1_Label { get; set; }
        public bool CustomField2_IsRequired { get; set; }
        public string CustomField2_Label { get; set; }
        public bool CustomField3_IsRequired { get; set; }
        public string CustomField3_Label { get; set; }
        public bool CustomField4_IsRequired { get; set; }
        public string CustomField4_Label { get; set; }
        public bool CustomField5_IsRequired { get; set; }
        public string CustomField5_Label { get; set; }
        public int CustomerStatusId { get; set; }
        public string CustomerStatusName { get; set; }
    }
}
