using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorAdminSetting : Log
    {
        public int Contractor_AdminSettingsId { get; set; }
        public int ContractorId { get; set; }
        public DateTime SystemStartDate { get; set; }
        public int ApprovalStatusId { get; set; }
        public string ApprovalStatusName { get; set; }
        public string ReasonofRejection { get; set; }
        public int? ContractorStatusId { get; set; }
        public string ContractorStatusName { get; set; }
        public int? WeightsResponsibilityId { get; set; }
        public string WeightsResponsibility_Name { get; set; }
        public decimal? ServiceSuccessSLA { get; set; }
        public bool IsArchived { get; set; }
        public bool IsNationalSupplier { get; set; }
    }
}
