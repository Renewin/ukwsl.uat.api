using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Contractors;

namespace UKWSL.WMES.Business.Contractors
{
    public class ContractorManager: IContractorManager
    {
        private IContractorRepository _contractorRepository;

        public ContractorManager(IContractorRepository contractorRepository)
        {
            _contractorRepository = contractorRepository;
        }

        /// <summary>
        /// business method to get contractor dashboard data 
        /// </summary>
        /// Delivery Point: Dp4.1
        public ContractorInfo GetContractorDashboardOverView(CompanyInfo companyInfo)
        {
            return _contractorRepository.GetContractorDashboardOverView(companyInfo);
        }
        /// <summary>
        /// business method to get all contractor list
        /// </summary>
        /// Delivery Point: Dp4.1
        public ContractorInfo GetAllContractorList(CompanyInfo companyInfo)
        {
            return _contractorRepository.GetAllContractorList(companyInfo);
        }

        /// <summary>
        /// business method to get contractor type list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorType()
        {
            return _contractorRepository.GetContractorType();
        }

        /// <summary>
        /// business method to get AnnualTurnOver list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorAnnualTurnOver()
        {
            return _contractorRepository.GetContractorAnnualTurnOver();
        }

        /// <summary>
        /// business method to get Approval status list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorApprovalStatus()
        {
            return _contractorRepository.GetContractorApprovalStatus();
        }

        /// <summary>
        /// business method to get Contractor status list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorStatus()
        {
            return _contractorRepository.GetContractorStatus();
        }

        /// <summary>
        /// business method to get WeightResponsibility list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetWeightResponsibility()
        {
            return _contractorRepository.GetWeightResponsibility();
        }

        /// <summary>
        /// business method to get Region list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetRegionDetails()
        {
            return _contractorRepository.GetRegionDetails();
        }

        /// <summary>
        /// business method to get Company Type 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetCompanyType()
        {
            return _contractorRepository.GetCompanyType();
        }

        /// <summary>
        /// business method to get Contractor All Info by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorAllInfobyContractorId(ContractorBasicInfo contractor)
        {
            return _contractorRepository.GetContractorAllInfobyContractorId(contractor);
        }

        /// <summary>
        /// business method to create and update contractor basic info 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorBasicInfo CreateUpdateContractorBasicInfo(ContractorBasicInfo contractor)
        {
            return _contractorRepository.CreateUpdateContractorBasicInfo(contractor);
        }

        /// <summary>
        /// business method to Create and update Contractor Admin Setting
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorAdminSetting CreateUpdateContractorAdminSetting(ContractorAdminSetting contractor)
        {
            return _contractorRepository.CreateUpdateContractorAdminSetting(contractor);
        }

        /// <summary>
        /// business method to Create and Update Contractor comments
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorComments CreateUpdateContractorComments(ContractorComments contractor)
        {
            return _contractorRepository.CreateUpdateContractorComments(contractor);
        }

        /// <summary>
        /// business method to get Contractor Contact Type
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorContactType()
        {
            return _contractorRepository.GetContractorContactType();
        }

        /// <summary>
        /// business method to get Contractor Legal Basis
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorLegalBasis()
        {
            return _contractorRepository.GetContractorLegalBasis();
        }

        /// <summary>
        /// business method to get All Contacts by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllContactsbyContractorId(ContractorContact contractor)
        {
            return _contractorRepository.GetAllContactsbyContractorId(contractor);
        }

        /// <summary>
        /// business method to get Contractor Contacts by ContactIDd
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorContactsbyContactId(ContractorContact contractor)
        {
            return _contractorRepository.GetContractorContactsbyContactId(contractor);
        }

        /// <summary>
        /// business method to get Active Contacts list  by Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetActiveContactstsByContractor(ContractorContact contractor)
        {
            return _contractorRepository.GetActiveContactstsByContractor(contractor);
        }

        /// <summary>
        /// business method to get Contractor Depots by Contact Id
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorDepotsbyContactId(ContractorDepots contractor)
        {
            return _contractorRepository.GetContractorDepotsbyContactId(contractor);
        }

        /// <summary>
        /// business method to create Update Contractor Contact
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorContact CreateUpdateContractorContact(ContractorContact contractor)
        {
            return _contractorRepository.CreateUpdateContractorContact(contractor);
        }

        /// <summary>
        /// business method to Create Update Contractor Depots
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorDepots CreateUpdateContractorDepots(ContractorInfo contractor)
        {
            return _contractorRepository.CreateUpdateContractorDepots(contractor);
        }

        /// <summary>
        /// business method to Check Company Name
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorBasicInfo CheckCompanyName(ContractorBasicInfo contractor)
        {
            return _contractorRepository.CheckCompanyName(contractor);
        }

        //public ContractorContact DeleteContractorContacts(ContractorContact contractor)
        //{
        //    return _contractorRepository.DeleteContractorContacts(contractor);
        //}

        /// <summary>
        /// business method to Delete Contractor Contacts
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo DeleteContractorContacts(ContractorContact contractorContact)
        {
            return _contractorRepository.DeleteContractorContacts(contractorContact);
        }

        /// <summary>
        /// business method to Bulk Delete Contractor Contacts
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorContact BulkDeleteContractorContacts(List<ContractorContact> lstContractorContact)
        {
            return _contractorRepository.BulkDeleteContractorContacts(lstContractorContact);
        }

        /// <summary>
        /// business method to get Contractor Depots by DepotId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorDepotsbyDepotId(ContractorDepots contractor)
        {
            return _contractorRepository.GetContractorDepotsbyDepotId(contractor);
        }

        /// <summary>
        /// business method to Delete Contractor Depots
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorDepots DeleteContractorDepots(ContractorDepots contractor)
        {
            return _contractorRepository.DeleteContractorDepots(contractor);
        }


        /// <summary>
        /// business method to get Allocated Facilities by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor)
        {
            return _contractorRepository.GetAllocatedFacilitiesByContractorId(contractor);
        }

        /// <summary>
        /// business method to get Document Types
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetDocumentTypes()
        {
            return _contractorRepository.GetDocumentTypes();
        }

        /// <summary>
        /// business method to get All Documents by Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllDocumentsByContractor(ContractorBasicInfo contractorBasicInfo)
        {
            return _contractorRepository.GetAllDocumentsByContractor(contractorBasicInfo);
        }

        /// <summary>
        /// business method to Create Update Document Info
        /// </summary>
        /// Delivery Point: DP4.1
        public DocumentInfo CreateUpdateDocumentInfo(DocumentInfo documentInfo)
        {
            return _contractorRepository.CreateUpdateDocumentInfo(documentInfo);
        }

        /// <summary>
        /// business method to Remove Facility Allocation
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo RemoveFacilityAllocation(ContractorBasicInfo contractor)
        {
            return _contractorRepository.RemoveFacilityAllocation(contractor);
        }

        /// <summary>
        /// business method to get UnAllocated Facilities by ContractorID
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetUnAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor)
        {
            return _contractorRepository.GetUnAllocatedFacilitiesByContractorId(contractor);
        }

        /// <summary>
        /// business method to Insert Facility Allocation
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo InsertFacilityAllocation(ContractorBasicInfo contractor)
        {
            return _contractorRepository.InsertFacilityAllocation(contractor);
        }

        /// <summary>
        /// business method to get Pricing Matrix List by Contractor Id
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetPricingMatrixListByContractorId(ContractorBasicInfo contractor)
        {
            return _contractorRepository.GetPricingMatrixListByContractorId(contractor);
        }

    }
}
