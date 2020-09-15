using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class FacilityInfo : Result
    {
        public FacilityBasicInfo facilityBasicInfo { get; set; }

        public List<FacilityType> lstFacilityType { get; set; }
        public List<MaterialType> lstMaterialType { get; set; }

        public List<FacilityBasicInfo> lstFacilityBasicInfo { get; set; }
        public List<FacilityBasicInfo> lstFacilityTypeCount { get; set; }

        public int TotalFacility { get; set; }
        public int ContractorWithoutFacilities { get; set; }
        public int FacilitiesWithoutContractor { get; set; }

        public List<FacilityWasteTypePercentageUDT> lstWasteTypePercentageUDT { get; set; }
        public List<FacilityMaterialTypePercentageUDT> lstMaterialTypePercentageUDT { get; set; }

        public List<FacilityWasteTypePercentage> lstWasteTypePercentage { get; set; }
        public List<FacilityMaterialTypePercentage> lstMaterialTypePercentage { get; set; }

        public FacilityAllocatedContractors FacilityAllocatedContractors { get; set; }
        public List<Contractor> lstContractors { get; set; }
        public List<FacilityAllocatedContractors> lstAllocatedContractors { get; set; }

        public ContractorDepots ContractorDepots { get; set; }
        public List<ContractorDepots> lstContractorDepots { get; set; }
        public List<ContractorDepots> lstAllocatedContractorDepots { get; set; }

        public DocumentType FacilityDocumentType { get; set; }
        public DocumentInfo FacilityDocumentInfo { get; set; }
        public List<DocumentInfo> lstFacilityDocumentTypes { get; set; }
        public List<DocumentInfo> lstFacilityDocuments { get; set; }
        public List<DocumentInfo> lstFacilityArchivedDocuments { get; set; }
        public List<ContractorRegionDetails> lstFacilityRegion { get; set; }

        public FacilityInfo()
        {
            facilityBasicInfo = new FacilityBasicInfo();
            lstMaterialType = new List<MaterialType>();
            lstFacilityBasicInfo = new List<FacilityBasicInfo>();
            lstFacilityTypeCount = new List<FacilityBasicInfo>();
            lstWasteTypePercentageUDT = new List<FacilityWasteTypePercentageUDT>();
            lstMaterialTypePercentageUDT = new List<FacilityMaterialTypePercentageUDT>();
            lstWasteTypePercentage = new List<FacilityWasteTypePercentage>();
            lstMaterialTypePercentage = new List<FacilityMaterialTypePercentage>();

            FacilityAllocatedContractors = new FacilityAllocatedContractors();
            lstContractors = new List<Contractor>();
            lstAllocatedContractors = new List<FacilityAllocatedContractors>();

            ContractorDepots = new ContractorDepots();
            lstContractorDepots = new List<ContractorDepots>();
            lstAllocatedContractorDepots = new List<ContractorDepots>();

            FacilityDocumentType = new DocumentType();
            FacilityDocumentInfo = new DocumentInfo();
            lstFacilityDocuments = new List<DocumentInfo>();
            lstFacilityArchivedDocuments = new List<DocumentInfo>();
            lstFacilityDocumentTypes = new List<DocumentInfo>();
            lstFacilityRegion = new List<ContractorRegionDetails>();
        }
    }   
}
