using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.ContractorRegister
{
    public interface IContractorRegisterManager
    {
        ContractorInfo GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo);
        ContractorInfo GetAllDocumentsbyContractorIdCustomerId(CustomerBasicInfo customerBasicInfo);
        ContractorInfo GetAllArchiveDocumentsByCustomerDocId(ContractorCRFArchive contractorCRFArchive);
        ContractorCRFDetails UploadCRFDocument(ContractorCRFDetails contractorCRFDetails);
        ContractorCRFDetails DeleteCRFDocument(ContractorCRFDetails contractorCRFDetails);

        ContractorInfo GetAllSHEQDocumentsByContractorId(ContractorSHEQDetails contractorSHEQDetails);
        ContractorInfo GetAllArchiveSHEQDocumentsByContractorIdSHEQDocTypeId(ContractorSHEQDetails contractorSHEQDetails);
        ContractorSHEQDetails DeleteSHEQDocument(ContractorSHEQDetails contractorSHEQDetails);
        ContractorSHEQDetails UploadSHEQDocument(ContractorSHEQDetails contractorSHEQDetails);
        ContractorInfo Contractor_GetAllSHEQDocumentsByContractorId(ContractorSHEQDetails contractorSHEQDetails);
        ContractorSHEQDetails Contractor_UploadSHEQDocument(ContractorSHEQDetails contractorSHEQDetails);

        ContractorInfo Contractor_GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo);
        ContractorInfo Contractor_GetAllDocumentsbyContractorIdCustomerId(CustomerBasicInfo customerBasicInfo);
        Contractor_CustomerRequirementForm Contractor_UploadDocument(Contractor_CustomerRequirementForm contractor_CustomerRequirementForm);
        Contractor_CRFContacts CreateUpdateContractorContact(Contractor_CRFContacts contractor_CRFContacts);
        Contractor_CRFContacts DeleteContractorContacts(Contractor_CRFContacts contractor);
        ContractorInfo GetAllContactsbyContractorId(Contractor_CRFContacts contractor);
        ContractorInfo GetContractorContactsbyContactId(Contractor_CRFContacts contractor);


        Review_CustomerRequirementForm InsertUpdateReviewCRF(Review_CustomerRequirementForm review_CustomerRequirementForm);
        Review_ContractorContacts InsertUpdateReviewContacs(Review_ContractorContacts review_ContractorContacts);
        Review_ContractorSHEQ InsertUpdateReviewSHEQ(Review_ContractorSHEQ review_ContractorSHEQ);

        Contractor_ExternalLinks InsertUpdateExternalLink(Contractor_ExternalLinks contractor_ExternalLinks);
        ContractorInfo GetContractorExternalDetailsbyContractorId(Contractor_ExternalLinks contractor);


    }
}
