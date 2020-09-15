using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
namespace UKWSL.WMES.Business.Facility
{
    public interface IFacilityManager
    {
        //APIs For Add and Edit Facility Page APIs
        FacilityBasicInfo CheckFacilityName(FacilityBasicInfo facilityBasicInfo);

        FacilityInfo GetFacilityType();        
        FacilityInfo GetFacilityInfobyFacilityId(FacilityBasicInfo facilityBasicInfo);
        FacilityWasteTypeHistory GetWasteTypeHistorybyWasteTypeId(FacilityWasteTypeHistory facilityWasteTypeHistory);
        FacilityMaterialTypeHistory GetMaterialTypeHistorybyMaterialTypeId(FacilityMaterialTypeHistory facilityMaterialTypeHistory);

        FacilityBasicInfo AddFacilityInfo(FacilityBasicInfo facility);
        FacilityInfo AddUpdateWasteTypePercentage(FacilityInfo facilityInfo);
        FacilityInfo InsertUpdateMaterialTypePercentage(FacilityInfo facilityInfo);  
        
        //Facility Dashboard APIs
        FacilityInfo GetAllFacilityList();
        FacilityInfo GetOverviewDetails();
        FacilityInfo GetCountbyFacilityType();  
       
        //Contractor Allocation to Facility APIs
        FacilityInfo GetNonAllocatedContractorsByFacilityId(FacilityAllocatedContractors allocatedContractors);
        FacilityInfo GetAllocatedContractorsByFacilityId(FacilityAllocatedContractors allocatedContractors);
        FacilityInfo InsertContractorAllocation(FacilityAllocatedContractors allocatedContractors);
        FacilityInfo RemoveContractorAllocation(FacilityAllocatedContractors allocatedContractors);

        //Contractor-Depot Allocation to Facility APIs
        FacilityInfo GetNonAllocatedDepotsByContractorId(ContractorDepots contractorDepots);
        FacilityInfo GetAllocatedDepotsByContractorId(ContractorDepots contractorDepots);
        FacilityInfo InsertDepotAllocation(ContractorDepots contractorDepots);
        FacilityInfo RemoveDepotAllocation(ContractorDepots contractorDepots);

        //Facility Licence Document APIs
        FacilityInfo GetDocumentTypesByFacilityId(DocumentInfo documentInfo);
        FacilityInfo GetLicenceDocumentsByDocumentTypeId(DocumentInfo documentInfo);
        FacilityInfo GetLicenceDocumentsArchivedByDocumentTypeId(DocumentInfo documentInfo);
        FacilityInfo InsertFacilityDocument(DocumentInfo documentInfo);
        FacilityInfo DeleteLicenceDocumentById(DocumentInfo documentInfo);
        FacilityInfo DeleteLicenceDocumentsByDocumentTypeId(DocumentInfo documentInfo);

    }
}
