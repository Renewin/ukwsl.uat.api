using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Contractors
{
    public interface IContractorManager
    {

        ContractorInfo GetContractorDashboardOverView(CompanyInfo companyInfo);
        ContractorInfo GetAllContractorList(CompanyInfo companyInfo);
        ContractorInfo GetContractorType();
        ContractorInfo GetContractorAnnualTurnOver();
        ContractorInfo GetContractorApprovalStatus();
        ContractorInfo GetContractorStatus();
        ContractorInfo GetWeightResponsibility();
        ContractorInfo GetRegionDetails();
        ContractorInfo GetCompanyType();
        ContractorInfo GetContractorContactType();
        ContractorInfo GetContractorLegalBasis();
        ContractorInfo GetActiveContactstsByContractor(ContractorContact contractor);
        ContractorInfo GetContractorDepotsbyContactId(ContractorDepots contractor);
        ContractorInfo GetContractorAllInfobyContractorId(ContractorBasicInfo contractor);
        ContractorInfo GetContractorContactsbyContactId(ContractorContact contractor);
        ContractorInfo GetAllContactsbyContractorId(ContractorContact contractor);
        ContractorInfo GetContractorDepotsbyDepotId(ContractorDepots contractor);
        ContractorContact CreateUpdateContractorContact(ContractorContact contractor);
        ContractorBasicInfo CreateUpdateContractorBasicInfo(ContractorBasicInfo contractor);
        ContractorAdminSetting CreateUpdateContractorAdminSetting(ContractorAdminSetting contractorAdminSetting);
        ContractorComments CreateUpdateContractorComments(ContractorComments contractorComments);
        ContractorBasicInfo CheckCompanyName(ContractorBasicInfo contractor);
        //ContractorContact DeleteContractorContacts(ContractorContact contractor);
        ContractorInfo DeleteContractorContacts(ContractorContact contractorContact);
        ContractorDepots CreateUpdateContractorDepots(ContractorInfo contractor);
        ContractorDepots DeleteContractorDepots(ContractorDepots contractor);
        ContractorContact BulkDeleteContractorContacts(List<ContractorContact> lstContractorContact);

        ContractorInfo GetAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor);
        ContractorInfo GetDocumentTypes();
        ContractorInfo GetAllDocumentsByContractor(ContractorBasicInfo contractorBasicInfo);
        DocumentInfo CreateUpdateDocumentInfo(DocumentInfo documentInfo);
        ContractorInfo RemoveFacilityAllocation(ContractorBasicInfo contractor);
        ContractorInfo GetUnAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor);
        ContractorInfo InsertFacilityAllocation(ContractorBasicInfo contractor);

        ContractorInfo GetPricingMatrixListByContractorId(ContractorBasicInfo contractor);
    }
}
