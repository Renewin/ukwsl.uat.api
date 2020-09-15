using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorWeightInfo: Result
    {
        public List<ServiceJobDetails> lstServiceJobDetails { get; set; }
        public ServiceJobDetails serviceJobDetails { get; set; }
        public List<ContractorPrice> lstContractorPrice { get; set; }
        public ContractorPrice contractorPrice { get; set; }
        public CustomerBasicInfo customerBasicInfo { get; set; }
        public List<CustomerBasicInfo> lstCustomerBasicInfos { get; set; }
        public ServiceSite serviceSite { get; set; }
        public List<ServiceSite> lstServiceSite { get; set; }
        public ContractorContact contractorContact { get; set; }
        public List<ContractorContact> lstContractorContacts { get; set; }

        public List<ImportActualWeight> lstPassedImportActualWeight { get; set; }
        public List<ImportActualWeight> lstFailedImportActualWeight { get; set; }
        public List<ImportActualWeight> lstImportActualWeight { get; set; }
        public List<ImportActualWeightUDT> lstImportActualWeightUDT { get; set; }

        public int CreatedBy { get; set; }
        public int ContractorId { get; set; }
        public int IWId { get; set; }
        public bool IMSStatus { get; set; }
        public int ReturnValue { get; set; }
    }
}
