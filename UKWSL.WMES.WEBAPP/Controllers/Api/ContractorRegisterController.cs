using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.ContractorRegister;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class ContractorRegisterController : ApiController
    {
        private IContractorRegisterManager contractorRegisterManager;

        public ContractorRegisterController(IContractorRegisterManager manager)
        {
            contractorRegisterManager = manager;
        }

        /// <summary>
        /// API to get all customers by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetAllCustomersbyContractorId")]
        public IHttpActionResult GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerBasicInfo.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.GetAllCustomersbyContractorId(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get All Documents by ContractorId CustomerId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetAllDocumentsbyContractorIdCustomerId")]
        public IHttpActionResult GetAllDocumentsbyContractorIdCustomerId(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerBasicInfo.CustomerId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(customerBasicInfo.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.GetAllDocumentsbyContractorIdCustomerId(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get All Archive Documents by CustomerDocument Id
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetAllArchiveDocumentsByCustomerDocId")]
        public IHttpActionResult GetAllArchiveDocumentsByCustomerDocId(ContractorCRFArchive contractorCRFArchive)
        {
            if (contractorCRFArchive != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorCRFArchive.Customer_DocumentId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.GetAllArchiveDocumentsByCustomerDocId(contractorCRFArchive);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Upload CRF Documents
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("UploadCRFDocument")]
        public IHttpActionResult UploadCRFDocument(ContractorCRFDetails contractorCRFDetails)
        {
            if (contractorCRFDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorCRFDetails.Customer_DocumentId)))
                {
                    return Ok(new ContractorCRFDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.UploadCRFDocument(contractorCRFDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorCRFDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to Delete CRF Document
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("DeleteCRFDocument")]
        public IHttpActionResult DeleteCRFDocument(ContractorCRFDetails contractorCRFDetails)
        {
            if (contractorCRFDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorCRFDetails.Customer_DocumentId)))
                {
                    return Ok(new ContractorCRFDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.DeleteCRFDocument(contractorCRFDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorCRFDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get all SHEQ Document by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetAllSHEQDocumentsByContractorId")]
        public IHttpActionResult GetAllSHEQDocumentsByContractorId(ContractorSHEQDetails contractorSHEQDetails)
        {
            if (contractorSHEQDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.GetAllSHEQDocumentsByContractorId(contractorSHEQDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get All Archiv SHEQ Documents by ContractorId and SHEQ DOcuemt Type ID
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetAllArchiveSHEQDocumentsByContractorIdSHEQDocTypeId")]
        public IHttpActionResult GetAllArchiveSHEQDocumentsByContractorIdSHEQDocTypeId(ContractorSHEQDetails contractorSHEQDetails)
        {
            if (contractorSHEQDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.ContractorId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.SHEQDocument_TypeId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.GetAllArchiveSHEQDocumentsByContractorIdSHEQDocTypeId(contractorSHEQDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Delete SHEQ Document
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("DeleteSHEQDocument")]
        public IHttpActionResult DeleteSHEQDocument(ContractorSHEQDetails contractorSHEQDetails)
        {
            if (contractorSHEQDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.ContractorId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.SHEQDocument_TypeId)))
                {
                    return Ok(new ContractorSHEQDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.DeleteSHEQDocument(contractorSHEQDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorCRFDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Upload SHEQ Docuemnt
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("UploadSHEQDocument")]
        public IHttpActionResult UploadSHEQDocument(ContractorSHEQDetails contractorSHEQDetails)
        {
            if (contractorSHEQDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.ContractorId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.SHEQDocument_TypeId)))
                {
                    return Ok(new ContractorSHEQDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.UploadSHEQDocument(contractorSHEQDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorCRFDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get all Customers by ContractorId for Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("Contractor_GetAllCustomersbyContractorId")]
        public IHttpActionResult Contractor_GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerBasicInfo.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.Contractor_GetAllCustomersbyContractorId(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get All Document by ContractorId and CustomerId for Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("Contractor_GetAllDocumentsbyContractorIdCustomerId")]
        public IHttpActionResult Contractor_GetAllDocumentsbyContractorIdCustomerId(CustomerBasicInfo customerBasicInfo)
        {
            if (customerBasicInfo != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(customerBasicInfo.CustomerId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(customerBasicInfo.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.Contractor_GetAllDocumentsbyContractorIdCustomerId(customerBasicInfo);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Upload Document for Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("Contractor_UploadDocument")]
        public IHttpActionResult Contractor_UploadDocument(Contractor_CustomerRequirementForm contractor_CustomerRequirementForm)
        {
            if (contractor_CustomerRequirementForm != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor_CustomerRequirementForm.Customer_DocumentId)))
                {
                    return Ok(new ContractorCRFDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.Contractor_UploadDocument(contractor_CustomerRequirementForm);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorCRFDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to Get all SHEQ Documents by ContractorId for Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("Contractor_GetAllSHEQDocumentsByContractorId")]
        public IHttpActionResult Contractor_GetAllSHEQDocumentsByContractorId(ContractorSHEQDetails contractorSHEQDetails)
        {
            if (contractorSHEQDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    });
                }
                else
                {
                    var result = contractorRegisterManager.Contractor_GetAllSHEQDocumentsByContractorId(contractorSHEQDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Upload SHEQ Document for Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        [ActionName("Contractor_UploadSHEQDocument")]
        public IHttpActionResult Contractor_UploadSHEQDocument(ContractorSHEQDetails contractorSHEQDetails)
        {
            if (contractorSHEQDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.ContractorId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(contractorSHEQDetails.SHEQDocument_TypeId)))
                {
                    return Ok(new ContractorSHEQDetails
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.Contractor_UploadSHEQDocument(contractorSHEQDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorCRFDetails
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to create and update contractor Contact
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("CreateUpdateContractorContact")]
        public IHttpActionResult CreateUpdateContractorContact(Contractor_CRFContacts contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new Contractor_CRFContacts
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.CreateUpdateContractorContact(contractor);

                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Contractor_CRFContacts
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Delete Contractor Contact
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("DeleteContractorContacts")]
        public IHttpActionResult DeleteContractorContacts(Contractor_CRFContacts contractor_CRFContacts)
        {
            if (contractor_CRFContacts != null)
            {
                if (string.IsNullOrEmpty(contractor_CRFContacts.Contractor_ContactIds)
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor_CRFContacts.ContractorId)))
                {
                    return Ok(new Contractor_CRFContacts

                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.DeleteContractorContacts(contractor_CRFContacts);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Contractor_CRFContacts
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to get all Contacts by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetAllContactsbyContractorId")]
        public IHttpActionResult GetAllContactsbyContractorId(Contractor_CRFContacts contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.GetAllContactsbyContractorId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to get Contractor Contacts by ContactId
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorContactsbyContactId")]
        public IHttpActionResult GetContractorContactsbyContactId(Contractor_CRFContacts contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.GetContractorContactsbyContactId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        /// <summary>
        /// API to InsertUpdate Review CRF
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("InsertUpdateReviewCRF")]
        public IHttpActionResult InsertUpdateReviewCRF(Review_CustomerRequirementForm contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.Customer_DocumentId)))
                {
                    return Ok(new Review_CustomerRequirementForm
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.InsertUpdateReviewCRF(contractor);

                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Review_CustomerRequirementForm
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to create and update Review Contacts
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("InsertUpdateReviewContacs")]
        public IHttpActionResult InsertUpdateReviewContacs(Review_ContractorContacts contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.Contractor_ContactId)))
                {
                    return Ok(new Review_ContractorContacts
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.InsertUpdateReviewContacs(contractor);

                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Review_ContractorContacts
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to create and update Review SHEQ
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("InsertUpdateReviewSHEQ")]
        public IHttpActionResult InsertUpdateReviewSHEQ(Review_ContractorSHEQ contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.SHEQDocument_TypeId)))
                {
                    return Ok(new Review_ContractorSHEQ
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.InsertUpdateReviewSHEQ(contractor);

                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Review_ContractorSHEQ
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to create and update External Link
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("InsertUpdateExternalLink")]
        public IHttpActionResult InsertUpdateExternalLink(Contractor_ExternalLinks contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ExtLinkId)))
                {
                    return Ok(new Contractor_ExternalLinks
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.InsertUpdateExternalLink(contractor);

                    return Ok(result);
                }
            }
            else
            {
                return Ok(new Contractor_ExternalLinks
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to Get Contractor External Details by ContractorID
        /// </summary>
        /// Delivery Point: DP4.1
        [HttpPost]
        [ActionName("GetContractorExternalDetailsbyContractorId")]
        public IHttpActionResult GetContractorExternalDetailsbyContractorId(Contractor_ExternalLinks contractor)
        {
            if (contractor != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(contractor.ContractorId)))
                {
                    return Ok(new ContractorInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = contractorRegisterManager.GetContractorExternalDetailsbyContractorId(contractor);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new ContractorInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }
    }
}
