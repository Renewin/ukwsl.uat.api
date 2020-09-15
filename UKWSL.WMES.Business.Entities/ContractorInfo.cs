using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ContractorInfo : Result
    {
        public List<ContractorType> lstContractorType { get; set; }
        public List<ContractorAnnualTurnOver> lstContractorAnnualTurnOver { get; set; }
        public List<ContractorApprovalStatus> lstContractorApprovalStatus { get; set; }
        public List<ContractorStatus> lstContractorStatus { get; set; }
        public List<ContractorBasicInfo> lstContractorBasicInfo { get; set; }
        public List<ContractorAdminSetting> lstContractorAdminSetting { get; set; }
        public List<ContractorComments> lstContractorComments { get; set; }
        public List<ContractorWeightsResponsibility> lstContractorWeight { get; set; }
        public List<ContractorRegionDetails> lstContractorRegion { get; set; }
        public List<ContractorCompanyType> lstContractorCompanytype { get; set; }
        public List<ContractorContact> lstContractorContact { get; set; }
        public List<ContractorLegalBasisData> lstContractorLegalBasisData { get; set; }
        public List<ContractorContactType> lstContractorContactType { get; set; }
        public List<ContractorDepots> lstContractorDepots { get; set; }
        public List<FacilityBasicInfo> lstAllocatedFacilitiesList { get; set; }
        public List<FacilityBasicInfo> lstUnAllocatedFacilitiesList { get; set; }
        public ContractorContact contractorContact { get; set; }
        public ContractorBasicInfo contractorBasicInfo { get; set; }
        public ContractorAdminSetting contractorAdminSetting { get; set; }
        public ContractorComments contractorComments { get; set; }
        public ContractorDepots contractorDepots { get; set; }
        public List<DocumentType> lstDocumentType { get; set; }
        public List<DocumentInfo> lstDocumentInfos { get; set; }
        public List<ContractorCRFArchive> lstContractorCRFArchive { get; set; }
        public List<ContractorCRFDetails> lstContractorCRFDetails { get; set; }
        public ContractorCRFDetails contractorCRFDetails { get; set; }
        public ContractorCRFArchive contractorCRFArchive { get; set; }
        public CustomerBasicInfo customerBasicInfo { get; set; }
        public List<CustomerBasicInfo> lstCustomerBasicInfo { get; set; }
        public Contractor_CustomerRequirementForm contractor_CustomerRequirementForm { get; set; }
        public List<Contractor_CustomerRequirementForm> lstContractor_CustomerRequirememntForm { get; set; }
        public Contractor_CRFContacts contractor_CRFContacts { get; set; }
        public List<Contractor_CRFContacts> lstContractor_CRFContacts { get; set; }

        public Review_ContractorContacts review_ContractorContacts { get; set; }
        public List<Review_ContractorContacts> lstreview_ContractorContacts { get; set; }

        public Review_CustomerRequirementForm review_CustomerRequirementForm { get; set; }
        public List<Review_CustomerRequirementForm> lstreview_CustomerRequirementForm { get; set; }


        public Review_ContractorSHEQ review_ContractorSHEQ { get; set; }
        public List<Review_ContractorSHEQ> lstreview_ContractorSHEQ { get; set; }
        public Contractor_ExternalLinks contractor_ExternalLinks { get; set; }
        public List<Contractor_ExternalLinks> lstContractor_ExternalLinks { get; set; }


        public int ReturnId { get; set; }
        public int TotalContractors { get; set; }
        public int Pending { get; set; }
        public int Approved { get; set; }
        public int ActiveServices{get; set;}
        public List<ContractorSHEQDetails> lstContractorSHEQDetails { get; set; }
        public List<ContractorSHEQArchiveDetails> lstContractorSHEQArchiveDetails { get; set; }

        public ContractorSHEQArchiveDetails contractorSHEQArchiveDetails { get; set; }

        public List<PricingMatrixSetup> lstpricingMatrices { get; set; }
        public List<ContractorSHEQDetails> lstArchivedSHEQCount { get; set; }
    }
}
