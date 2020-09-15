using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Contractors
{
   public interface IContractorRepository
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
        ContractorInfo GetAllContactsbyContractorId(ContractorContact contractor);
        ContractorInfo GetActiveContactstsByContractor(ContractorContact contractor);
        ContractorInfo GetContractorDepotsbyContactId(ContractorDepots contractor);
        ContractorInfo GetContractorContactsbyContactId(ContractorContact contractor);
        ContractorInfo GetContractorAllInfobyContractorId(ContractorBasicInfo contractor);
        ContractorInfo GetContractorDepotsbyDepotId(ContractorDepots contractor);
        ContractorContact CreateUpdateContractorContact(ContractorContact contractor);
        ContractorBasicInfo CreateUpdateContractorBasicInfo(ContractorBasicInfo contractor);
        ContractorAdminSetting CreateUpdateContractorAdminSetting(ContractorAdminSetting contractor);
        ContractorComments CreateUpdateContractorComments(ContractorComments contractorComments);
        ContractorBasicInfo CheckCompanyName(ContractorBasicInfo contractor);
        //ContractorContact DeleteContractorContacts(ContractorContact contractor);
        ContractorInfo DeleteContractorContacts(ContractorContact contractorContact);
        ContractorDepots CreateUpdateContractorDepots(ContractorInfo contractor);
        ContractorDepots DeleteContractorDepots(ContractorDepots contractor);
        ContractorContact BulkDeleteContractorContacts(List<ContractorContact> lstContractorContact);

        ContractorInfo GetAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor);
        ContractorInfo RemoveFacilityAllocation(ContractorBasicInfo contractor);
        ContractorInfo GetUnAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor);
        ContractorInfo InsertFacilityAllocation(ContractorBasicInfo contractor);

        ContractorInfo GetDocumentTypes();
        ContractorInfo GetAllDocumentsByContractor(ContractorBasicInfo contractorBasicInfo);
        DocumentInfo CreateUpdateDocumentInfo(DocumentInfo documentInfo);

        ContractorInfo GetPricingMatrixListByContractorId(ContractorBasicInfo contractor);

    }
}
