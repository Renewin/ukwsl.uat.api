using System.Data;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Facility;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Business.Facility
{
    public class FacilityManager : IFacilityManager
    {
        private IFacilityRepository _facilityRepository;

        public FacilityManager(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public FacilityBasicInfo CheckFacilityName(FacilityBasicInfo facilityBasicInfo)
        {
            return _facilityRepository.CheckFacilityName(facilityBasicInfo);
        }

        public FacilityInfo GetFacilityType()
        {
            return _facilityRepository.GetFacilityType();
        }

        public FacilityInfo GetFacilityInfobyFacilityId(FacilityBasicInfo facilityBasicInfo)
        {
            return _facilityRepository.GetFacilityInfobyFacilityId(facilityBasicInfo);
        }

        public FacilityWasteTypeHistory GetWasteTypeHistorybyWasteTypeId(FacilityWasteTypeHistory facilityWasteTypeHistory)
        {
            return _facilityRepository.GetWasteTypeHistorybyWasteTypeId(facilityWasteTypeHistory);
        }

        public FacilityMaterialTypeHistory GetMaterialTypeHistorybyMaterialTypeId(FacilityMaterialTypeHistory facilityMaterialTypeHistory)
        {
            return _facilityRepository.GetMaterialTypeHistorybyMaterialTypeId(facilityMaterialTypeHistory);
        }

        public FacilityBasicInfo AddFacilityInfo(FacilityBasicInfo facilityBasicInfo)
        {
            return _facilityRepository.AddFacilityInfo(facilityBasicInfo);
        }

        public FacilityInfo AddUpdateWasteTypePercentage(FacilityInfo facilityInfo)
        {
            DataTable _dtFWTP = new DataTable();
            _dtFWTP = ListtoDataTableConverter.ToDataTable(facilityInfo.lstWasteTypePercentageUDT);
            return _facilityRepository.AddUpdateWasteTypePercentage(facilityInfo, _dtFWTP);
        }

        public FacilityInfo InsertUpdateMaterialTypePercentage(FacilityInfo facilityInfo)
        {
            DataTable _dtFMTP = new DataTable();
            _dtFMTP = ListtoDataTableConverter.ToDataTable(facilityInfo.lstMaterialTypePercentageUDT);
            return _facilityRepository.InsertUpdateMaterialTypePercentage(facilityInfo, _dtFMTP);
        }

        public FacilityInfo GetAllFacilityList()
        {
            return _facilityRepository.GetAllFacilityList();
        }

        public FacilityInfo GetOverviewDetails()
        {
            return _facilityRepository.GetOverviewDetails();
        }

        public FacilityInfo GetCountbyFacilityType()
        {
            return _facilityRepository.GetCountbyFacilityType();
        }

        public FacilityInfo GetNonAllocatedContractorsByFacilityId(FacilityAllocatedContractors allocatedContractors)
        {
            return _facilityRepository.GetNonAllocatedContractorsByFacilityId(allocatedContractors);
        }

        public FacilityInfo GetAllocatedContractorsByFacilityId(FacilityAllocatedContractors allocatedContractors)
        {
            return _facilityRepository.GetAllocatedContractorsByFacilityId(allocatedContractors);
        }

        public FacilityInfo InsertContractorAllocation(FacilityAllocatedContractors allocatedContractors)
        {
            return _facilityRepository.InsertContractorAllocation(allocatedContractors);
        }

        public FacilityInfo RemoveContractorAllocation(FacilityAllocatedContractors allocatedContractors)
        {
            return _facilityRepository.RemoveContractorAllocation(allocatedContractors);
        }

        public FacilityInfo GetNonAllocatedDepotsByContractorId(ContractorDepots contractorDepots)
        {
            return _facilityRepository.GetNonAllocatedDepotsByContractorId(contractorDepots);
        }

        public FacilityInfo GetAllocatedDepotsByContractorId(ContractorDepots contractorDepots)
        {
            return _facilityRepository.GetAllocatedDepotsByContractorId(contractorDepots);
        }

        public FacilityInfo InsertDepotAllocation(ContractorDepots contractorDepots)
        {
            return _facilityRepository.InsertDepotAllocation(contractorDepots);
        }

        public FacilityInfo RemoveDepotAllocation(ContractorDepots contractorDepots)
        {
            return _facilityRepository.RemoveDepotAllocation(contractorDepots);
        }

        public FacilityInfo GetDocumentTypesByFacilityId(DocumentInfo documentInfo)
        {
            return _facilityRepository.GetDocumentTypesByFacilityId(documentInfo);
        }

        public FacilityInfo GetLicenceDocumentsByDocumentTypeId(DocumentInfo documentInfo)
        {
            return _facilityRepository.GetLicenceDocumentsByDocumentTypeId(documentInfo);
        }

        public FacilityInfo GetLicenceDocumentsArchivedByDocumentTypeId(DocumentInfo documentInfo)
        {
            return _facilityRepository.GetLicenceDocumentsArchivedByDocumentTypeId(documentInfo);
        }

        public FacilityInfo InsertFacilityDocument(DocumentInfo documentInfo)
        {
            return _facilityRepository.InsertFacilityDocument(documentInfo);
        }

        public FacilityInfo DeleteLicenceDocumentById(DocumentInfo documentInfo)
        {
            return _facilityRepository.DeleteLicenceDocumentById(documentInfo);
        }

        public FacilityInfo DeleteLicenceDocumentsByDocumentTypeId(DocumentInfo documentInfo)
        {
            return _facilityRepository.DeleteLicenceDocumentsByDocumentTypeId(documentInfo);
        }


    }
}