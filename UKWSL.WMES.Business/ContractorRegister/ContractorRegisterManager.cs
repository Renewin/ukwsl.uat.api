using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.ContractorRegister;

namespace UKWSL.WMES.Business.ContractorRegister
{
    public class ContractorRegisterManager: IContractorRegisterManager
    {
        private IContractorRegisterRepository _contractorRegisterRepository;

        /// <summary>
        /// business method to get contractor data 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorRegisterManager(IContractorRegisterRepository contractorRegisterRepository)
        {
            _contractorRegisterRepository = contractorRegisterRepository;
        }

        /// <summary>
        /// business method to get all customers list by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo)
        {
            return _contractorRegisterRepository.GetAllCustomersbyContractorId(customerBasicInfo);
        }

        /// <summary>
        /// business method to get all Documents by ContractorId and CustomerId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllDocumentsbyContractorIdCustomerId(CustomerBasicInfo customerBasicInfo)
        {
            return _contractorRegisterRepository.GetAllDocumentsbyContractorIdCustomerId(customerBasicInfo);
        }

        /// <summary>
        /// business method to get all Archived Documents by CustomerDocId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllArchiveDocumentsByCustomerDocId(ContractorCRFArchive contractorCRFArchive)
        {
            return _contractorRegisterRepository.GetAllArchiveDocumentsByCustomerDocId(contractorCRFArchive);
        }

        /// <summary>
        /// business method to  Upload CRF Document
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorCRFDetails UploadCRFDocument(ContractorCRFDetails contractorCRFDetails)
        {
            return _contractorRegisterRepository.UploadCRFDocument(contractorCRFDetails);
        }

        /// <summary>
        /// business method to Delete CRF Document
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorCRFDetails DeleteCRFDocument(ContractorCRFDetails contractorCRFDetails)
        {
            return _contractorRegisterRepository.DeleteCRFDocument(contractorCRFDetails);
        }

        /// <summary>
        /// business method to Get all SHEQ Documents by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllSHEQDocumentsByContractorId(ContractorSHEQDetails contractorSHEQDetails)
        {
            return _contractorRegisterRepository.GetAllSHEQDocumentsByContractorId(contractorSHEQDetails);
        }

        /// <summary>
        /// business method to Get All Archive SHEQ Documents By ContractorId and SHEQ DocTypeId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllArchiveSHEQDocumentsByContractorIdSHEQDocTypeId(ContractorSHEQDetails contractorSHEQDetails)
        {
            return _contractorRegisterRepository.GetAllArchiveSHEQDocumentsByContractorIdSHEQDocTypeId(contractorSHEQDetails);
        }

        /// <summary>
        /// business method to Delete SHEQ Document
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorSHEQDetails DeleteSHEQDocument(ContractorSHEQDetails contractorSHEQDetails)
        {
            return _contractorRegisterRepository.DeleteSHEQDocument(contractorSHEQDetails);
        }

        /// <summary>
        /// business method to Upload SHEQ Document
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorSHEQDetails UploadSHEQDocument(ContractorSHEQDetails contractorSHEQDetails)
        {
            return _contractorRegisterRepository.UploadSHEQDocument(contractorSHEQDetails);
        }

        /// <summary>
        /// business method to ContractoApplication Get all customers by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo Contractor_GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo)
        {
            return _contractorRegisterRepository.Contractor_GetAllCustomersbyContractorId(customerBasicInfo);
        }

        /// <summary>
        /// business method to ContractoApplication Get all Documents by ContractorId and CustomerId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo Contractor_GetAllDocumentsbyContractorIdCustomerId(CustomerBasicInfo customerBasicInfo)
        {
            return _contractorRegisterRepository.Contractor_GetAllDocumentsbyContractorIdCustomerId(customerBasicInfo);
        }

        /// <summary>
        /// business method to ContractoApplication Upload Document
        /// </summary>
        /// Delivery Point: DP4.1
        public Contractor_CustomerRequirementForm Contractor_UploadDocument(Contractor_CustomerRequirementForm contractor_CustomerRequirementForm)
        {
            return _contractorRegisterRepository.Contractor_UploadDocument(contractor_CustomerRequirementForm);
        }

        /// <summary>
        /// business method to ContractoApplication Get all SHEQ Documents by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo Contractor_GetAllSHEQDocumentsByContractorId(ContractorSHEQDetails contractorSHEQDetails)
        {
            return _contractorRegisterRepository.Contractor_GetAllSHEQDocumentsByContractorId(contractorSHEQDetails);
        }

        /// <summary>
        /// business method to ContractoApplication Upload SHEQ Document
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorSHEQDetails Contractor_UploadSHEQDocument(ContractorSHEQDetails contractorSHEQDetails)
        {
            return _contractorRegisterRepository.Contractor_UploadSHEQDocument(contractorSHEQDetails);
        }

        /// <summary>
        /// business method to ContractoApplication Create Update Contractor Contact
        /// </summary>
        /// Delivery Point: DP4.1
        public Contractor_CRFContacts CreateUpdateContractorContact(Contractor_CRFContacts contractor_CRFContacts)
        {
            return _contractorRegisterRepository.CreateUpdateContractorContact(contractor_CRFContacts);
        }

        /// <summary>
        /// business method to ContractoApplication Delete Contractor Contact
        /// </summary>
        /// Delivery Point: DP4.1
        public Contractor_CRFContacts DeleteContractorContacts(Contractor_CRFContacts contractor)
        {
            return _contractorRegisterRepository.DeleteContractorContacts(contractor);
        }

        /// <summary>
        /// business method to Get All COntacts by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllContactsbyContractorId(Contractor_CRFContacts contractor)
        {
            return _contractorRegisterRepository.GetAllContactsbyContractorId(contractor);
        }

        /// <summary>
        /// business method to Get Contractor Contacts by ContactId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorContactsbyContactId(Contractor_CRFContacts contractor)
        {
            return _contractorRegisterRepository.GetContractorContactsbyContactId(contractor);
        }

        /// <summary>
        /// business method to Insert Update Reviewed CRF
        /// </summary>
        /// Delivery Point: DP4.1
        public Review_CustomerRequirementForm InsertUpdateReviewCRF(Review_CustomerRequirementForm review_CustomerRequirementForm)
        {
            return _contractorRegisterRepository.InsertUpdateReviewCRF(review_CustomerRequirementForm);
        }

        /// <summary>
        /// business method to Insert Update Reviewed CRF_Contacts
        /// </summary>
        /// Delivery Point: DP4.1
        public Review_ContractorContacts InsertUpdateReviewContacs(Review_ContractorContacts review_ContractorContacts)
        {
            return _contractorRegisterRepository.InsertUpdateReviewContacs(review_ContractorContacts);
        }


        /// <summary>
        /// business method to Insert Update Reviewed SHEQ
        /// </summary>
        /// Delivery Point: DP4.1
        public Review_ContractorSHEQ InsertUpdateReviewSHEQ(Review_ContractorSHEQ review_ContractorSHEQ)
        {
            return _contractorRegisterRepository.InsertUpdateReviewSHEQ(review_ContractorSHEQ);
        }


        /// <summary>
        /// business method to Insert Update External Link
        /// </summary>
        /// Delivery Point: DP4.1
        public Contractor_ExternalLinks InsertUpdateExternalLink(Contractor_ExternalLinks contractor_ExternalLinks)
        {
            return _contractorRegisterRepository.InsertUpdateExternalLink(contractor_ExternalLinks);
        }


        /// <summary>
        /// business method to Get Contractor External Details by Contractor Id
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorExternalDetailsbyContractorId(Contractor_ExternalLinks contractor)
        {
            return _contractorRegisterRepository.GetContractorExternalDetailsbyContractorId(contractor);
        }
    }
}
