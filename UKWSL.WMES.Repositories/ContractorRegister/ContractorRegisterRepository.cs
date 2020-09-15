using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;


namespace UKWSL.WMES.Repositories.ContractorRegister
{
    public class ContractorRegisterRepository : IContractorRegisterRepository
    {
        private string _connectionString;
        public ContractorRegisterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Database layer method to get all customers by contractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerBasicInfo> lstEntity = new List<CustomerBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_CRF_GetAllCustomersByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(customerBasicInfo.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerBasicInfo objEntity = new CustomerBasicInfo();
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.NoRequirementForm = string.IsNullOrEmpty(Convert.ToString(reader["NoRequirementForm"])) ? 0 : Convert.ToInt32(reader["NoRequirementForm"]);
                                objEntity.NoDocumentUploaded = string.IsNullOrEmpty(Convert.ToString(reader["NoDocumentUploaded"])) ? 0 : Convert.ToInt32(reader["NoDocumentUploaded"]);
                                //objEntity.ReviewStatus = Convert.ToString(reader["ReviewStatus"]);
                                //objEntity.ReviewComment = Convert.ToString(reader["ReviewComment"]);
                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstCustomerBasicInfo = lstEntity;

                }

                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to get all documents by contractorId customerId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllDocumentsbyContractorIdCustomerId(CustomerBasicInfo customerBasicInfo)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerBasicInfo> lstEntity = new List<CustomerBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_CRF_GetAllDocumentsByContractorIdCustomerId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(customerBasicInfo.ContractorId));
                        cmd.Parameters.AddWithValue("@CustomerId", Convert.ToString(customerBasicInfo.CustomerId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerBasicInfo objEntity = new CustomerBasicInfo();
                                objEntity.Customer_DocumentId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_DocumentId"])) ? 0 : Convert.ToInt32(reader["Customer_DocumentId"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.DocumentName = Convert.ToString(reader["DocumentName"]);
                                objEntity.FileReference = Convert.ToString(reader["FileReference"]);
                                objEntity.SharepointFileReference = Convert.ToString(reader["SharepointFileReference"]);

                                objEntity.IsUploaded = string.IsNullOrEmpty(Convert.ToString(reader["IsUploaded"])) ? false : Convert.ToBoolean(reader["IsUploaded"]);
                                objEntity.DocDescription = Convert.ToString(reader["DocDescription"]);
                                objEntity.UploadedBy = Convert.ToString(reader["UploadedBy"]);
                                objEntity.UploadedOn = string.IsNullOrEmpty(Convert.ToString(reader["UploadedOn"])) ? new DateTime() : Convert.ToDateTime(reader["UploadedOn"]);
                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstCustomerBasicInfo = lstEntity;

                }

                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to get all archive documents by CustomerDocumentId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllArchiveDocumentsByCustomerDocId(ContractorCRFArchive contractorCRFArchive)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorCRFArchive> lstEntity = new List<ContractorCRFArchive>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_CRF_GetAllArchiveDocumentsByCustomerDocId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Customer_DocumentId", Convert.ToString(contractorCRFArchive.Customer_DocumentId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorCRFArchive objEntity = new ContractorCRFArchive();
                                objEntity.DocFileName = Convert.ToString(reader["DocFileName"]);
                                objEntity.UploadedBy = Convert.ToString(reader["UploadedBy"]);
                                objEntity.UploadedOn = string.IsNullOrEmpty(Convert.ToString(reader["UploadedOn"])) ? new DateTime() : Convert.ToDateTime(reader["UploadedOn"]);
                                objEntity.ArchivedBy = Convert.ToString(reader["ArchivedBy"]);
                                objEntity.ArchivedOn = string.IsNullOrEmpty(Convert.ToString(reader["ArchivedOn"])) ? new DateTime() : Convert.ToDateTime(reader["ArchivedOn"]);
                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstContractorCRFArchive = lstEntity;

                }

                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to Upload CRF Documents
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorCRFDetails UploadCRFDocument(ContractorCRFDetails contractor)
        {
            ContractorCRFDetails objCustomer = new ContractorCRFDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_CRF_DeleteUploadCRFDocument";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Customer_DocumentId", contractor.Customer_DocumentId);
                        cmd.Parameters.AddWithValue("@CustomerId", contractor.CustomerId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@DocDescription", contractor.DocDescription);
                        cmd.Parameters.AddWithValue("@SharepointId", contractor.SharepointId);
                        cmd.Parameters.AddWithValue("@DocFileName", contractor.DocFileName);
                        cmd.Parameters.AddWithValue("@SharepointFileReference", contractor.SharepointFileReference);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.AddWithValue("@ActionFlag", "ADD");


                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.Customer_DocumentId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objCustomer.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomer.Status = Status.Failed;
                objCustomer.Message = ex.Message;
                throw ex;
            }
            return objCustomer;
        }

        /// <summary>
        /// Database layer method to Delete CRF Document
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorCRFDetails DeleteCRFDocument(ContractorCRFDetails contractor)
        {
            ContractorCRFDetails objCustomer = new ContractorCRFDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_CRF_DeleteUploadCRFDocument";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Customer_DocumentId", contractor.Customer_DocumentId);
                        cmd.Parameters.AddWithValue("@CustomerId", contractor.CustomerId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@DocDescription", contractor.DocDescription);
                        cmd.Parameters.AddWithValue("@SharepointId", contractor.SharepointId);
                        cmd.Parameters.AddWithValue("@DocFileName", contractor.DocFileName);
                        cmd.Parameters.AddWithValue("@SharepointFileReference", contractor.SharepointFileReference);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.AddWithValue("@ActionFlag", "DELETE");


                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.Customer_DocumentId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objCustomer.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomer.Status = Status.Failed;
                objCustomer.Message = ex.Message;
                throw ex;
            }
            return objCustomer;
        }

        /// <summary>
        /// Database layer method to get all SHEQ Docuemnts by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllSHEQDocumentsByContractorId(ContractorSHEQDetails contractorSHEQDetails)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorSHEQDetails> lstEntity = new List<ContractorSHEQDetails>();
                    List<ContractorSHEQDetails> lstEntity1 = new List<ContractorSHEQDetails>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetAllSHEQDocumentsByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractorSHEQDetails.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorSHEQDetails objEntity = new ContractorSHEQDetails();

                                objEntity.SHEQDocumentId = string.IsNullOrEmpty(Convert.ToString(reader["SHEQDocumentId"])) ? 0 : Convert.ToInt32(reader["SHEQDocumentId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.SHEQDocument_TypeId = string.IsNullOrEmpty(Convert.ToString(reader["SHEQDocument_TypeId"])) ? 0 : Convert.ToInt32(reader["SHEQDocument_TypeId"]);
                                objEntity.LicenceNo = Convert.ToString(reader["LicenceNo"]);
                                objEntity.DocDescription = Convert.ToString(reader["DocDescription"]);
                                objEntity.ExpiryDate = string.IsNullOrEmpty(Convert.ToString(reader["ExpiryDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["ExpiryDate"]);
                                objEntity.PolicyValue = string.IsNullOrEmpty(Convert.ToString(reader["PolicyValue"])) ? 0 : Convert.ToDecimal(reader["PolicyValue"]);
                                objEntity.CoverTotal = string.IsNullOrEmpty(Convert.ToString(reader["CoverTotal"])) ? 0 : Convert.ToDecimal(reader["CoverTotal"]);
                                objEntity.CoverClaim = string.IsNullOrEmpty(Convert.ToString(reader["CoverClaim"])) ? 0 : Convert.ToDecimal(reader["CoverClaim"]);
                                objEntity.SharePointId = string.IsNullOrEmpty(Convert.ToString(reader["SharepointId"])) ? 0 : Convert.ToInt32(reader["SharepointId"]);
                                objEntity.DocFileName = Convert.ToString(reader["DocFileName"]);
                                objEntity.ExpiringIn = Convert.ToString(reader["ExpiringIn"]);
                                objEntity.SharepointFileReference = Convert.ToString(reader["SharepointFileReference"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.CreatedBy = string.IsNullOrEmpty(Convert.ToString(reader["CreatedBy"])) ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                                objEntity.CreatedOn = string.IsNullOrEmpty(Convert.ToString(reader["CreatedOn"])) ? new DateTime() : Convert.ToDateTime(reader["CreatedOn"]);
                                lstEntity.Add(objEntity);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ContractorSHEQDetails objEntity = new ContractorSHEQDetails();
                                objEntity.ArchivedCount = string.IsNullOrEmpty(Convert.ToString(reader["ArchivedCount"])) ? 0 : Convert.ToInt32(reader["ArchivedCount"]);
                                objEntity.SHEQDocument_TypeId = string.IsNullOrEmpty(Convert.ToString(reader["SHEQDocument_TypeId"])) ? 0 : Convert.ToInt32(reader["SHEQDocument_TypeId"]);
                                lstEntity1.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorSHEQDetails = lstEntity;
                    contractorInfo.lstArchivedSHEQCount = lstEntity1;
                }
                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to Get all Archive SHEQ Documents by ContractorId by SHEQ DocumentTypeId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllArchiveSHEQDocumentsByContractorIdSHEQDocTypeId(ContractorSHEQDetails contractorSHEQDetails)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorSHEQArchiveDetails> lstEntity = new List<ContractorSHEQArchiveDetails>();
                    ContractorSHEQArchiveDetails contractorSHEQArchiveDetails = new ContractorSHEQArchiveDetails();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetAllArchiveSHEQDocumentsByContractorIdSHEQDocTypeId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractorSHEQDetails.ContractorId));
                        cmd.Parameters.AddWithValue("@SHEQDocument_TypeId", Convert.ToString(contractorSHEQDetails.SHEQDocument_TypeId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contractorSHEQArchiveDetails.MainSectionDescription = Convert.ToString(reader["MainSectionDescription"]);
                                contractorSHEQArchiveDetails.SubSectionDescription = Convert.ToString(reader["SubSectionDescription"]);
                                contractorSHEQArchiveDetails.SHEQDocument_TypeName = Convert.ToString(reader["SHEQDocument_TypeName"]);
                                contractorSHEQArchiveDetails.ExpiringIn = Convert.ToString(reader["ExpiringIn"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ContractorSHEQArchiveDetails objEntity = new ContractorSHEQArchiveDetails();
                                objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.SHEQDocument_TypeId = string.IsNullOrEmpty(Convert.ToString(reader["SHEQDocument_TypeId"])) ? 0 : Convert.ToInt32(reader["SHEQDocument_TypeId"]);
                                objEntity.LicenceNo = Convert.ToString(reader["LicenceNo"]);
                                objEntity.DocDescription = Convert.ToString(reader["DocDescription"]);
                                objEntity.ExpiryDate = string.IsNullOrEmpty(Convert.ToString(reader["ExpiryDate"])) ? new DateTime() : Convert.ToDateTime(reader["ExpiryDate"]);
                                objEntity.PolicyValue = string.IsNullOrEmpty(Convert.ToString(reader["PolicyValue"])) ? 0 : Convert.ToDecimal(reader["PolicyValue"]);
                                objEntity.CoverTotal = string.IsNullOrEmpty(Convert.ToString(reader["CoverTotal"])) ? 0 : Convert.ToDecimal(reader["CoverTotal"]);
                                objEntity.CoverClaim = string.IsNullOrEmpty(Convert.ToString(reader["CoverClaim"])) ? 0 : Convert.ToDecimal(reader["CoverClaim"]);
                                objEntity.SharepointId = string.IsNullOrEmpty(Convert.ToString(reader["SharepointId"])) ? 0 : Convert.ToInt32(reader["SharepointId"]);
                                objEntity.DocFileName = Convert.ToString(reader["DocFileName"]);
                                objEntity.SharepointFileReference = Convert.ToString(reader["SharepointFileReference"]);
                                objEntity.UploadedBy = Convert.ToString(reader["UploadedBy"]);
                                objEntity.UploadedOn = string.IsNullOrEmpty(Convert.ToString(reader["UploadedOn"])) ? new DateTime() : Convert.ToDateTime(reader["UploadedOn"]);
                                objEntity.ArchivedBy = Convert.ToString(reader["ArchivedBy"]);
                                objEntity.ArchivedOn = string.IsNullOrEmpty(Convert.ToString(reader["ArchivedOn"])) ? new DateTime() : Convert.ToDateTime(reader["ArchivedOn"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorSHEQArchiveDetails = lstEntity;
                    contractorInfo.contractorSHEQArchiveDetails = contractorSHEQArchiveDetails;
                }
                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to Delete SHEQ Document
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorSHEQDetails DeleteSHEQDocument(ContractorSHEQDetails contractorSHEQDetails)
        {
            ContractorSHEQDetails objContractorSHEQDetails = new ContractorSHEQDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_DeleteUploadSHEQDocument";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractorSHEQDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@SHEQDocument_TypeId", contractorSHEQDetails.SHEQDocument_TypeId);
                        cmd.Parameters.AddWithValue("@LicenceNo", contractorSHEQDetails.LicenceNo);
                        cmd.Parameters.AddWithValue("@DocDescription", contractorSHEQDetails.DocDescription);
                        cmd.Parameters.AddWithValue("@ExpiryDate", contractorSHEQDetails.ExpiryDate);
                        cmd.Parameters.AddWithValue("@PolicyValue", contractorSHEQDetails.PolicyValue);
                        cmd.Parameters.AddWithValue("@CoverTotal", contractorSHEQDetails.CoverTotal);
                        cmd.Parameters.AddWithValue("@CoverClaim", contractorSHEQDetails.CoverClaim);
                        cmd.Parameters.AddWithValue("@SharepointId", contractorSHEQDetails.SharePointId);
                        cmd.Parameters.AddWithValue("@DocFileName", contractorSHEQDetails.DocFileName);
                        cmd.Parameters.AddWithValue("@SharepointFileReference", contractorSHEQDetails.SharepointFileReference);
                        cmd.Parameters.AddWithValue("@ActionFlag", "DELETE");
                        cmd.Parameters.AddWithValue("@CreatedBy", contractorSHEQDetails.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objContractorSHEQDetails.SHEQDocumentId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objContractorSHEQDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objContractorSHEQDetails.Status = Status.Failed;
                objContractorSHEQDetails.Message = ex.Message;
                throw ex;
            }
            return objContractorSHEQDetails;
        }

        /// <summary>
        /// Database layer method to Upload SHEQ Document
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorSHEQDetails UploadSHEQDocument(ContractorSHEQDetails contractorSHEQDetails)
        {
            ContractorSHEQDetails objContractorSHEQDetails = new ContractorSHEQDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_DeleteUploadSHEQDocument";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractorSHEQDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@SHEQDocument_TypeId", contractorSHEQDetails.SHEQDocument_TypeId);
                        cmd.Parameters.AddWithValue("@LicenceNo", contractorSHEQDetails.LicenceNo);
                        cmd.Parameters.AddWithValue("@DocDescription", contractorSHEQDetails.DocDescription);
                        cmd.Parameters.AddWithValue("@ExpiryDate", contractorSHEQDetails.ExpiryDate);
                        cmd.Parameters.AddWithValue("@PolicyValue", contractorSHEQDetails.PolicyValue);
                        cmd.Parameters.AddWithValue("@CoverTotal", contractorSHEQDetails.CoverTotal);
                        cmd.Parameters.AddWithValue("@CoverClaim", contractorSHEQDetails.CoverClaim);
                        cmd.Parameters.AddWithValue("@SharepointId", contractorSHEQDetails.SharePointId);
                        cmd.Parameters.AddWithValue("@DocFileName", contractorSHEQDetails.DocFileName);
                        cmd.Parameters.AddWithValue("@SharepointFileReference", contractorSHEQDetails.SharepointFileReference);
                        cmd.Parameters.AddWithValue("@ActionFlag", "ADD");
                        cmd.Parameters.AddWithValue("@CreatedBy", contractorSHEQDetails.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objContractorSHEQDetails.SHEQDocumentId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objContractorSHEQDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objContractorSHEQDetails.Status = Status.Failed;
                objContractorSHEQDetails.Message = ex.Message;
                throw ex;
            }
            return objContractorSHEQDetails;
        }

        /// <summary>
        /// Database layer method to Get all Customers by Contractor Id for Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo Contractor_GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerBasicInfo> lstEntity = new List<CustomerBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[ext_sp_CRF_GetAllCustomersByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(customerBasicInfo.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerBasicInfo objEntity = new CustomerBasicInfo();
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.NoRequirementForm = string.IsNullOrEmpty(Convert.ToString(reader["NoRequirementForm"])) ? 0 : Convert.ToInt32(reader["NoRequirementForm"]);
                                objEntity.NoDocumentUploaded = string.IsNullOrEmpty(Convert.ToString(reader["NoDocumentUploaded"])) ? 0 : Convert.ToInt32(reader["NoDocumentUploaded"]);
                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstCustomerBasicInfo = lstEntity;

                }

                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to get all Documents by ContractorId CustomerId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo Contractor_GetAllDocumentsbyContractorIdCustomerId(CustomerBasicInfo customerBasicInfo)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerBasicInfo> lstEntity = new List<CustomerBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[ext_sp_CRF_GetAllDocumentsByContractorIdCustomerId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(customerBasicInfo.ContractorId));
                        cmd.Parameters.AddWithValue("@CustomerId", Convert.ToString(customerBasicInfo.CustomerId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerBasicInfo objEntity = new CustomerBasicInfo();
                                objEntity.Customer_DocumentId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_DocumentId"])) ? 0 : Convert.ToInt32(reader["Customer_DocumentId"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.DocumentName = Convert.ToString(reader["DocumentName"]);
                                objEntity.FileReference = Convert.ToString(reader["FileReference"]);
                                objEntity.SharepointFileReference = Convert.ToString(reader["SharepointFileReference"]);

                                objEntity.IsUploaded = string.IsNullOrEmpty(Convert.ToString(reader["IsUploaded"])) ? false : Convert.ToBoolean(reader["IsUploaded"]);
                                objEntity.DocDescription = Convert.ToString(reader["DocDescription"]);
                                objEntity.UploadedBy = Convert.ToString(reader["UploadedBy"]);
                                objEntity.UploadedOn = string.IsNullOrEmpty(Convert.ToString(reader["UploadedOn"])) ? new DateTime() : Convert.ToDateTime(reader["UploadedOn"]);
                                objEntity.ExtLinkId = string.IsNullOrEmpty(Convert.ToString(reader["ExtLinkId"])) ? 0 : Convert.ToInt32(reader["ExtLinkId"]);
                                objEntity.CRFReviewId = string.IsNullOrEmpty(Convert.ToString(reader["CRFReviewId"])) ? 0 : Convert.ToInt32(reader["CRFReviewId"]);
                                objEntity.ReviewStatus = Convert.ToString(reader["ReviewStatus"]);
                                objEntity.ReviewComment = Convert.ToString(reader["ReviewComment"]);

                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstCustomerBasicInfo = lstEntity;

                }

                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to Upload Document for Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        public Contractor_CustomerRequirementForm Contractor_UploadDocument(Contractor_CustomerRequirementForm contractor_CustomerRequirementForm)
        {
            Contractor_CustomerRequirementForm objDocumentInfo = new Contractor_CustomerRequirementForm();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "ext_sp_CRF_UploadCRFDocument";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Customer_DocumentId", contractor_CustomerRequirementForm.Customer_DocumentId);
                        cmd.Parameters.AddWithValue("@CustomerId", contractor_CustomerRequirementForm.CustomerId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractor_CustomerRequirementForm.ContractorId);
                        cmd.Parameters.AddWithValue("@DocDescription", contractor_CustomerRequirementForm.DocDescription);
                        cmd.Parameters.AddWithValue("@SharepointId", contractor_CustomerRequirementForm.SharepointId);
                        cmd.Parameters.AddWithValue("@DocFileName", contractor_CustomerRequirementForm.DocFileName);
                        cmd.Parameters.AddWithValue("@SharepointFileReference", contractor_CustomerRequirementForm.SharepointFileReference);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor_CustomerRequirementForm.CreatedBy);


                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objDocumentInfo.Customer_DocumentId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objDocumentInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objDocumentInfo.Status = Status.Failed;
                objDocumentInfo.Message = ex.Message;
                throw ex;
            }
            return objDocumentInfo;
        }

        /// <summary>
        /// Database layer method to get all SHEQ documents by ContractorId for Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo Contractor_GetAllSHEQDocumentsByContractorId(ContractorSHEQDetails contractorSHEQDetails)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorSHEQDetails> lstEntity = new List<ContractorSHEQDetails>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_ExtContractor_GetAllSHEQDocumentsByContractorId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractorSHEQDetails.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorSHEQDetails objEntity = new ContractorSHEQDetails();

                                objEntity.SHEQDocumentId = string.IsNullOrEmpty(Convert.ToString(reader["SHEQDocumentId"])) ? 0 : Convert.ToInt32(reader["SHEQDocumentId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.SHEQDocument_TypeId = string.IsNullOrEmpty(Convert.ToString(reader["SHEQDocument_TypeId"])) ? 0 : Convert.ToInt32(reader["SHEQDocument_TypeId"]);
                                objEntity.LicenceNo = Convert.ToString(reader["LicenceNo"]);
                                objEntity.DocDescription = Convert.ToString(reader["DocDescription"]);
                                objEntity.ExpiryDate = string.IsNullOrEmpty(Convert.ToString(reader["ExpiryDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["ExpiryDate"]);
                                objEntity.PolicyValue = string.IsNullOrEmpty(Convert.ToString(reader["PolicyValue"])) ? 0 : Convert.ToDecimal(reader["PolicyValue"]);
                                objEntity.CoverTotal = string.IsNullOrEmpty(Convert.ToString(reader["CoverTotal"])) ? 0 : Convert.ToDecimal(reader["CoverTotal"]);
                                objEntity.CoverClaim = string.IsNullOrEmpty(Convert.ToString(reader["CoverClaim"])) ? 0 : Convert.ToDecimal(reader["CoverClaim"]);
                                objEntity.SharePointId = string.IsNullOrEmpty(Convert.ToString(reader["SharepointId"])) ? 0 : Convert.ToInt32(reader["SharepointId"]);
                                objEntity.DocFileName = Convert.ToString(reader["DocFileName"]);
                                objEntity.ExpiringIn = Convert.ToString(reader["ExpiringIn"]);
                                objEntity.SharepointFileReference = Convert.ToString(reader["SharepointFileReference"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.CreatedBy = string.IsNullOrEmpty(Convert.ToString(reader["CreatedBy"])) ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                                objEntity.CreatedOn = string.IsNullOrEmpty(Convert.ToString(reader["CreatedOn"])) ? new DateTime() : Convert.ToDateTime(reader["CreatedOn"]);
                                objEntity.ExtLinkId = string.IsNullOrEmpty(Convert.ToString(reader["ExtLinkId"])) ? 0 : Convert.ToInt32(reader["ExtLinkId"]);
                                objEntity.SDReviewId = string.IsNullOrEmpty(Convert.ToString(reader["SDReviewId"])) ? 0 : Convert.ToInt32(reader["SDReviewId"]);
                                objEntity.ReviewStatus = Convert.ToString(reader["ReviewStatus"]);
                                objEntity.ReviewComment = Convert.ToString(reader["ReviewComment"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorSHEQDetails = lstEntity;
                }
                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to Upload SHEQ Document for Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorSHEQDetails Contractor_UploadSHEQDocument(ContractorSHEQDetails contractorSHEQDetails)
        {
            ContractorSHEQDetails objContractorSHEQDetails = new ContractorSHEQDetails();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_ExtContractor_UploadSHEQDocument";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractorSHEQDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@SHEQDocument_TypeId", contractorSHEQDetails.SHEQDocument_TypeId);
                        cmd.Parameters.AddWithValue("@LicenceNo", contractorSHEQDetails.LicenceNo);
                        cmd.Parameters.AddWithValue("@DocDescription", contractorSHEQDetails.DocDescription);
                        cmd.Parameters.AddWithValue("@ExpiryDate", contractorSHEQDetails.ExpiryDate);
                        cmd.Parameters.AddWithValue("@PolicyValue", contractorSHEQDetails.PolicyValue);
                        cmd.Parameters.AddWithValue("@CoverTotal", contractorSHEQDetails.CoverTotal);
                        cmd.Parameters.AddWithValue("@CoverClaim", contractorSHEQDetails.CoverClaim);
                        cmd.Parameters.AddWithValue("@SharepointId", contractorSHEQDetails.SharePointId);
                        cmd.Parameters.AddWithValue("@DocFileName", contractorSHEQDetails.DocFileName);
                        cmd.Parameters.AddWithValue("@SharepointFileReference", contractorSHEQDetails.SharepointFileReference);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractorSHEQDetails.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objContractorSHEQDetails.SHEQDocumentId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objContractorSHEQDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objContractorSHEQDetails.Status = Status.Failed;
                objContractorSHEQDetails.Message = ex.Message;
                throw ex;
            }
            return objContractorSHEQDetails;
        }

        /// <summary>
        /// Database layer method to create and update Contractor Contact
        /// </summary>
        /// Delivery Point: DP4.1
        public Contractor_CRFContacts CreateUpdateContractorContact(Contractor_CRFContacts contractor)
        {
            Contractor_CRFContacts objCustomer = new Contractor_CRFContacts();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "ext_sp_Contractor_InsertUpdateContacts";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Contractor_ContactId", contractor.Contractor_ContactId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@Contractor_ContactTypeId", contractor.Contractor_ContactTypeId);
                        cmd.Parameters.AddWithValue("@Title", contractor.Title);
                        cmd.Parameters.AddWithValue("@FirstName", contractor.FirstName);
                        cmd.Parameters.AddWithValue("@Surname", contractor.Surname);
                        cmd.Parameters.AddWithValue("@JobTitle", contractor.JobTitle);
                        cmd.Parameters.AddWithValue("@LegalBasisId", contractor.LegalBasisId);
                        cmd.Parameters.AddWithValue("@AddressLine1", contractor.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", contractor.AddressLine2);
                        cmd.Parameters.AddWithValue("@Town", contractor.Town);
                        cmd.Parameters.AddWithValue("@County", contractor.County);
                        cmd.Parameters.AddWithValue("@Postcode", contractor.Postcode);
                        cmd.Parameters.AddWithValue("@Country", contractor.Country);
                        cmd.Parameters.AddWithValue("@MobileNumber", contractor.MobileNumber);
                        cmd.Parameters.AddWithValue("@ContactNumber", contractor.ContactNumber);
                        cmd.Parameters.AddWithValue("@AdditionalEmailAddress", contractor.AdditionalEmailAddress);
                        cmd.Parameters.AddWithValue("@MainEmailAddress", contractor.MainEmailAddress);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.Contractor_ContactId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }

                    objCustomer.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                objCustomer.Status = Status.Failed;
                objCustomer.Message = ex.Message;
                throw ex;
            }
            return objCustomer;
        }

        /// <summary>
        /// Database layer method to Delete Contractor Contacts
        /// </summary>
        /// Delivery Point: DP4.1
        public Contractor_CRFContacts DeleteContractorContacts(Contractor_CRFContacts contractor)
        {
            Contractor_CRFContacts objContact = new Contractor_CRFContacts();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "ext_sp_Contractor_DeleteContact";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@Contractor_ContactIds", contractor.Contractor_ContactIds);
                        cmd.ExecuteNonQuery();
                        objContact.Contractor_ContactIds = contractor.Contractor_ContactIds;
                    }
                }
                objContact.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objContact.Status = Status.Failed;
                objContact.Message = ex.Message;
                throw ex;
            }
            return objContact;
        }

        /// <summary>
        /// Database layer method to Get all Contacts by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllContactsbyContractorId(Contractor_CRFContacts contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Contractor_CRFContacts> lstEntity = new List<Contractor_CRFContacts>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[ext_sp_Contractor_GetAllContactsbyContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contractor_CRFContacts objEntity = new Contractor_CRFContacts();
                                objEntity.Contractor_ContactId = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_ContactId"])) ? 0 : Convert.ToInt32(reader["Contractor_ContactId"]);
                                objEntity.Contractor_ContactTypeId = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_ContactTypeId"])) ? 0 : Convert.ToInt32(reader["Contractor_ContactTypeId"]);
                                //objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.Title = Convert.ToString(reader["Title"]);
                                objEntity.Contact_LegalBasisData = Convert.ToString(reader["Contact_LegalBasisData"]);
                                objEntity.Contactor_ContactTypeName = Convert.ToString(reader["Contactor_ContactTypeName"]);
                                objEntity.FirstName = Convert.ToString(reader["FirstName"]);
                                objEntity.Surname = Convert.ToString(reader["Surname"]);
                                objEntity.JobTitle = Convert.ToString(reader["JobTitle"]);
                                objEntity.LegalBasisId = string.IsNullOrEmpty(Convert.ToString(reader["LegalBasisId"])) ? 0 : Convert.ToInt32(reader["LegalBasisId"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objEntity.Town = Convert.ToString(reader["Town"]);
                                objEntity.County = Convert.ToString(reader["County"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.Country = Convert.ToString(reader["Country"]);
                                objEntity.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                                objEntity.ContactNumber = Convert.ToString(reader["ContactNumber"]);
                                objEntity.MainEmailAddress = Convert.ToString(reader["MainEmailAddress"]);
                                objEntity.ExtLinkId = string.IsNullOrEmpty(Convert.ToString(reader["ExtLinkId"])) ? 0 : Convert.ToInt32(reader["ExtLinkId"]);
                                objEntity.CRFReviewId = string.IsNullOrEmpty(Convert.ToString(reader["CRFReviewId"])) ? 0 : Convert.ToInt32(reader["CRFReviewId"]);
                                objEntity.ReviewStatus = Convert.ToString(reader["ReviewStatus"]);
                                objEntity.ReviewComment = Convert.ToString(reader["ReviewComment"]);
                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstContractor_CRFContacts = lstEntity;

                }

                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to Get Contractor Contacts by ContactId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorContactsbyContactId(Contractor_CRFContacts contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[ext_sp_Contractor_GetContactsbyContractor_ContactId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Contractor_ContactId", Convert.ToString(contractor.Contractor_ContactId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contractor_CRFContacts objEntity = new Contractor_CRFContacts();
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.Title = Convert.ToString(reader["Title"]);
                                objEntity.Contactor_ContactTypeName = Convert.ToString(reader["Contactor_ContactTypeName"]);
                                objEntity.Contractor_ContactTypeId = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_ContactTypeId"])) ? 0 : Convert.ToInt32(reader["Contractor_ContactTypeId"]);
                                objEntity.FirstName = Convert.ToString(reader["FirstName"]);
                                objEntity.Surname = Convert.ToString(reader["Surname"]);
                                objEntity.Contact_LegalBasisData = Convert.ToString(reader["Contact_LegalBasisData"]);
                                objEntity.LegalBasisId = string.IsNullOrEmpty(Convert.ToString(reader["LegalBasisId"])) ? 0 : Convert.ToInt32(reader["LegalBasisId"]);
                                objEntity.JobTitle = Convert.ToString(reader["JobTitle"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objEntity.Town = Convert.ToString(reader["Town"]);
                                objEntity.County = Convert.ToString(reader["County"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.Country = Convert.ToString(reader["Country"]);
                                objEntity.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                                objEntity.ContactNumber = Convert.ToString(reader["ContactNumber"]);
                                objEntity.MainEmailAddress = Convert.ToString(reader["MainEmailAddress"]);
                                contractorInfo.contractor_CRFContacts = objEntity;
                            }
                        }
                    }

                }

                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to create and update Review CRF
        /// </summary>
        /// Delivery Point: DP4.1
        public Review_CustomerRequirementForm InsertUpdateReviewCRF(Review_CustomerRequirementForm contractor)
        {
            Review_CustomerRequirementForm objCustomer = new Review_CustomerRequirementForm();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "ext_sp_ReviewContractor_CRF";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExtLinkId", contractor.ExtLinkId);
                        cmd.Parameters.AddWithValue("@CustomerId", contractor.CustomerId);
                        cmd.Parameters.AddWithValue("@Customer_DocumentId", contractor.Customer_DocumentId);
                        cmd.Parameters.AddWithValue("@ReviewStatus", contractor.ReviewStatus);
                        cmd.Parameters.AddWithValue("@ReviewComment", contractor.ReviewComment);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.CRFReviewId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }

                    objCustomer.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                objCustomer.Status = Status.Failed;
                objCustomer.Message = ex.Message;
                throw ex;
            }
            return objCustomer;
        }

        /// <summary>
        /// Database layer method to create and update Review Contacts
        /// </summary>
        /// Delivery Point: DP4.1
        public Review_ContractorContacts InsertUpdateReviewContacs(Review_ContractorContacts contractor)
        {
            Review_ContractorContacts objCustomer = new Review_ContractorContacts();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "ext_sp_ReviewContractor_Contact";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExtLinkId", contractor.ExtLinkId);
                        cmd.Parameters.AddWithValue("@Contractor_ContactId", contractor.Contractor_ContactId);
                        cmd.Parameters.AddWithValue("@ReviewStatus", contractor.ReviewStatus);
                        cmd.Parameters.AddWithValue("@ReviewComment", contractor.ReviewComment);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.CRFReviewId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }

                    objCustomer.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                objCustomer.Status = Status.Failed;
                objCustomer.Message = ex.Message;
                throw ex;
            }
            return objCustomer;
        }

        /// <summary>
        /// Database layer method to create and update Contractor Review SHEQ
        /// </summary>
        /// Delivery Point: DP4.1
        public Review_ContractorSHEQ InsertUpdateReviewSHEQ(Review_ContractorSHEQ contractor)
        {
            Review_ContractorSHEQ objCustomer = new Review_ContractorSHEQ();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "ext_sp_ReviewContractor_SHEQ";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExtLinkId", contractor.ExtLinkId);
                        cmd.Parameters.AddWithValue("@SHEQDocument_TypeId", contractor.SHEQDocument_TypeId);
                        cmd.Parameters.AddWithValue("@ReviewStatus", contractor.ReviewStatus);
                        cmd.Parameters.AddWithValue("@ReviewComment", contractor.ReviewComment);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.SDReviewId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }

                    objCustomer.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                objCustomer.Status = Status.Failed;
                objCustomer.Message = ex.Message;
                throw ex;
            }
            return objCustomer;
        }

        /// <summary>
        /// Database layer method to create and update Contractor Admin settingsExternal Links
        /// </summary>
        /// Delivery Point: DP4.1
        public Contractor_ExternalLinks InsertUpdateExternalLink(Contractor_ExternalLinks contractor)
        {
            Contractor_ExternalLinks objCustomer = new Contractor_ExternalLinks();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "ext_sp_InsertUpdateExternalLinks";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ActionFlag", contractor.ActionFlag);
                        cmd.Parameters.AddWithValue("@ExtLinkId", contractor.ExtLinkId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@ExternalLink", contractor.ExternalLink);
                        cmd.Parameters.AddWithValue("@ExternalComments", contractor.ExternalComments);
                        cmd.Parameters.AddWithValue("@UKWSLComments", contractor.UKWSLComments);
                        cmd.Parameters.AddWithValue("@IsLinkOpened", contractor.IsLinkOpened);
                        cmd.Parameters.AddWithValue("@IsAuthenticated", contractor.IsAuthenticated);
                        cmd.Parameters.AddWithValue("@IsSubmitted", contractor.IsSubmitted);
                        cmd.Parameters.AddWithValue("@IsApproved", contractor.IsApproved);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.ExtLinkId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                    objCustomer.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                objCustomer.Status = Status.Failed;
                objCustomer.Message = ex.Message;
                throw ex;
            }
            return objCustomer;
        }

        /// <summary>
        /// Database layer method to Get contractor External Link Details
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorExternalDetailsbyContractorId(Contractor_ExternalLinks contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[ext_sp_GetExternalLinkDetails]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        cmd.Parameters.AddWithValue("@ExlinkId", Convert.ToString(contractor.ExtLinkId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contractor_ExternalLinks objEntity = new Contractor_ExternalLinks();
                                objEntity.ExtLinkId = string.IsNullOrEmpty(Convert.ToString(reader["ExtLinkId"])) ? 0 : Convert.ToInt32(reader["ExtLinkId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.ExternalLink = Convert.ToString(reader["ExternalLink"]);
                                objEntity.ExternalComments = Convert.ToString(reader["ExternalComments"]);
                                objEntity.UKWSLComments = Convert.ToString(reader["UKWSLComments"]);
                                objEntity.LinkSentOn = Convert.ToDateTime(reader["LinkSentOn"]);
                                objEntity.LinkExpiresOn = Convert.ToDateTime(reader["LinkExpiresOn"]);
                                objEntity.IsLinkOpened = string.IsNullOrEmpty(Convert.ToString(reader["IsLinkOpened"])) ? false : Convert.ToBoolean(reader["IsLinkOpened"]);
                                objEntity.IsAuthenticated = string.IsNullOrEmpty(Convert.ToString(reader["IsAuthenticated"])) ? false : Convert.ToBoolean(reader["IsAuthenticated"]);
                                objEntity.IsSubmitted = string.IsNullOrEmpty(Convert.ToString(reader["IsSubmitted"])) ? false : Convert.ToBoolean(reader["IsSubmitted"]);
                                objEntity.IsArchived = string.IsNullOrEmpty(Convert.ToString(reader["IsArchived"])) ? false : Convert.ToBoolean(reader["IsArchived"]);
                                objEntity.IsApproved = string.IsNullOrEmpty(Convert.ToString(reader["IsApproved"])) ? false : Convert.ToBoolean(reader["IsApproved"]);
                                contractorInfo.contractor_ExternalLinks = objEntity;
                            }
                        }
                    }

                }

                contractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
            }
            return contractorInfo;
        }
    }
}
