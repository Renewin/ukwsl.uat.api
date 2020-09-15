using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Contractors
{
    public class ContractorRepository : IContractorRepository
    {
        private string _connectionString;
        public ContractorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// Database layer to get contractor dashboard data 
        /// </summary>
        /// Delivery Point: Dp4.1
        public ContractorInfo GetContractorDashboardOverView(CompanyInfo companyInfo)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorType> lstEntity = new List<ContractorType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_Dashboard_GetOverviewInfo]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", companyInfo.FromDate);
                        cmd.Parameters.AddWithValue("@ToDate", companyInfo.ToDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contractorInfo.TotalContractors = string.IsNullOrEmpty(Convert.ToString(reader["Total Contactors"])) ? 0 : Convert.ToInt32(reader["Total Contactors"]);
                                contractorInfo.Pending = string.IsNullOrEmpty(Convert.ToString(reader["Pending"])) ? 0 : Convert.ToInt32(reader["Pending"]);
                                contractorInfo.Approved = string.IsNullOrEmpty(Convert.ToString(reader["Approved"])) ? 0 : Convert.ToInt32(reader["Approved"]);
                                contractorInfo.ActiveServices = string.IsNullOrEmpty(Convert.ToString(reader["ActiveServices"])) ? 0 : Convert.ToInt32(reader["ActiveServices"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ContractorType objEntity = new ContractorType();
                                objEntity.ContractorTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorTypeId"])) ? 0 : Convert.ToInt32(reader["ContractorTypeId"]);
                                objEntity.ContractorTypeName = Convert.ToString(reader["ContractorTypeName"]);
                                objEntity.TotalContractors = string.IsNullOrEmpty(Convert.ToString(reader["TotalContractors"])) ? 0 : Convert.ToInt32(reader["TotalContractors"]);
                                objEntity.Percentage = string.IsNullOrEmpty(Convert.ToString(reader["Percentage"])) ? 0 : Convert.ToDecimal(reader["Percentage"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorType = lstEntity;
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
        /// Database layer to get all Contractor list
        /// </summary>
        /// Delivery Point: Dp4.1
        public ContractorInfo GetAllContractorList(CompanyInfo companyInfo)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorBasicInfo> lstEntity = new List<ContractorBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetAllContractorrList]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", companyInfo.FromDate);
                        cmd.Parameters.AddWithValue("@ToDate", companyInfo.ToDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorBasicInfo objEntity = new ContractorBasicInfo();
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.ContractorStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorStatusId"])) ? 0 : Convert.ToInt32(reader["ContractorStatusId"]);
                                objEntity.ActiveServices = string.IsNullOrEmpty(Convert.ToString(reader["ActiveServices"])) ? 0 : Convert.ToInt32(reader["ActiveServices"]);
                                objEntity.ContractorStatusName = Convert.ToString(reader["ContractorStatusName"]);
                                objEntity.ApprovalStatusName = Convert.ToString(reader["ApprovalStatusName"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.ContractorTypeName = Convert.ToString(reader["ContractorTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorBasicInfo = lstEntity;
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
        /// Database layer to get contractor type list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorType()
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorType> lstEntity = new List<ContractorType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetContractorType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorType objEntity = new ContractorType();
                                objEntity.ContractorTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorTypeId"])) ? 0 : Convert.ToInt32(reader["ContractorTypeId"]);
                                objEntity.ContractorTypeName = Convert.ToString(reader["ContractorTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorType = lstEntity;
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
        /// Database layer to get Company type list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetCompanyType()
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorCompanyType> lstEntity = new List<ContractorCompanyType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetCompanyType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorCompanyType objEntity = new ContractorCompanyType();
                                objEntity.CompanyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyTypeId"])) ? 0 : Convert.ToInt32(reader["CompanyTypeId"]);
                                objEntity.CompanyTypeName = Convert.ToString(reader["CompanyTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorCompanytype = lstEntity;
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
        /// Database layer to get Annualturnover  list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorAnnualTurnOver()
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorAnnualTurnOver> lstEntity = new List<ContractorAnnualTurnOver>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetAnnualTurnOver]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorAnnualTurnOver objEntity = new ContractorAnnualTurnOver();
                                objEntity.AnnualTurnOverId = string.IsNullOrEmpty(Convert.ToString(reader["AnnualTurnOverId"])) ? 0 : Convert.ToInt32(reader["AnnualTurnOverId"]);
                                objEntity.AnnualTurnOverName = Convert.ToString(reader["AnnualTurnOverName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorAnnualTurnOver = lstEntity;
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
        /// Database layer to get ApprovalStatus  list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorApprovalStatus()
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorApprovalStatus> lstEntity = new List<ContractorApprovalStatus>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetApprovalStatus]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorApprovalStatus objEntity = new ContractorApprovalStatus();
                                objEntity.ApprovalStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ApprovalStatusId"])) ? 0 : Convert.ToInt32(reader["ApprovalStatusId"]);
                                objEntity.ApprovalStatusName = Convert.ToString(reader["ApprovalStatusName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorApprovalStatus = lstEntity;
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
        /// Database layer to get contractorStatus  list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorStatus()
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorStatus> lstEntity = new List<ContractorStatus>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetContractorStatus]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorStatus objEntity = new ContractorStatus();
                                objEntity.ContractorStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorStatusId"])) ? 0 : Convert.ToInt32(reader["ContractorStatusId"]);
                                objEntity.ContractorStatusName = Convert.ToString(reader["ContractorStatusName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorStatus = lstEntity;
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
        /// Database layer to get WeightResponsibility  list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetWeightResponsibility()
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorWeightsResponsibility> lstEntity = new List<ContractorWeightsResponsibility>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetWeightsResponsibility]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorWeightsResponsibility objEntity = new ContractorWeightsResponsibility();
                                objEntity.WeightsResponsibilityId = string.IsNullOrEmpty(Convert.ToString(reader["WeightsResponsibilityId"])) ? 0 : Convert.ToInt32(reader["WeightsResponsibilityId"]);
                                objEntity.WeightsResponsibility_Name = Convert.ToString(reader["WeightsResponsibility_Name"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorWeight = lstEntity;
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
        /// Database layer to get Region  list 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetRegionDetails()
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorRegionDetails> lstEntity = new List<ContractorRegionDetails>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetRegionDetails]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorRegionDetails objEntity = new ContractorRegionDetails();
                                objEntity.RegionId = string.IsNullOrEmpty(Convert.ToString(reader["RegionId"])) ? 0 : Convert.ToInt32(reader["RegionId"]);
                                objEntity.RegionName = Convert.ToString(reader["RegionName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorRegion = lstEntity;
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
        /// Database layer to get contractor all information by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorAllInfobyContractorId(ContractorBasicInfo contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetAllInfobyContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorBasicInfo objEntity = new ContractorBasicInfo();
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.SystemStartDate = string.IsNullOrEmpty(Convert.ToString(reader["SystemStartDate"])) ? new DateTime() : Convert.ToDateTime(reader["SystemStartDate"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.CompanyVATNumber = Convert.ToString(reader["CompanyVATNumber"]);
                                objEntity.CompanyRegistrationNumber = Convert.ToString(reader["CompanyRegistrationNumber"]);
                                objEntity.CountryofRegistrations = Convert.ToString(reader["CountryofRegistration"]);
                                objEntity.AnnualTurnoverId = string.IsNullOrEmpty(Convert.ToString(reader["AnnualTurnoverId"])) ? 0 : Convert.ToInt32(reader["AnnualTurnoverId"]);
                                objEntity.AnnualTurnOverName = Convert.ToString(reader["AnnualTurnOverName"]);
                                objEntity.CompanySIC = Convert.ToString(reader["CompanySIC"]);
                                objEntity.CompanyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyTypeId"])) ? 0 : Convert.ToInt32(reader["CompanyTypeId"]);
                                objEntity.CompanyTypeName = Convert.ToString(reader["CompanyTypeName"]);
                                objEntity.NumberofEmployees = Convert.ToString(reader["NumberofEmployees"]);
                                objEntity.ContractorTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorTypeId"])) ? 0 : Convert.ToInt32(reader["ContractorTypeId"]);
                                objEntity.OtherContractorType = Convert.ToString(reader["OtherContractorType"]);
                                objEntity.ContractorTypeName = Convert.ToString(reader["ContractorTypeName"]);
                                objEntity.ParentHoldingCompany = Convert.ToString(reader["ParentHoldingCompany"]);
                                objEntity.CompanyPhoneNumber = Convert.ToString(reader["CompanyPhoneNumber"]);
                                objEntity.CompanyEmail = Convert.ToString(reader["CompanyEmail"]);
                                objEntity.WebsiteURL = Convert.ToString(reader["WebsiteURL"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objEntity.Town = Convert.ToString(reader["Town"]);
                                objEntity.County = Convert.ToString(reader["County"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.RegionId = string.IsNullOrEmpty(Convert.ToString(reader["RegionId"])) ? 0 : Convert.ToInt32(reader["RegionId"]);
                                objEntity.RegionName = Convert.ToString(reader["RegionName"]);
                                objEntity.Country = Convert.ToString(reader["Country"]);
                                contractorInfo.contractorBasicInfo = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ContractorAdminSetting objEntity = new ContractorAdminSetting();
                                objEntity.SystemStartDate = Convert.ToDateTime(reader["SystemStartDate"]);
                                objEntity.ApprovalStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ApprovalStatusId"])) ? 0 : Convert.ToInt32(reader["ApprovalStatusId"]);
                                objEntity.ApprovalStatusName = Convert.ToString(reader["ApprovalStatusName"]);
                                objEntity.ContractorStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorStatusId"])) ? (int?)null : Convert.ToInt32(reader["ContractorStatusId"]);
                                objEntity.ContractorStatusName = Convert.ToString(reader["ContractorStatusName"]);
                                objEntity.WeightsResponsibilityId = string.IsNullOrEmpty(Convert.ToString(reader["WeightsResponsibilityId"])) ? (int?)null : Convert.ToInt32(reader["WeightsResponsibilityId"]);
                                objEntity.WeightsResponsibility_Name = Convert.ToString(reader["WeightsResponsibility_Name"]);
                                objEntity.ServiceSuccessSLA = string.IsNullOrEmpty(Convert.ToString(reader["ServiceSuccessSLA"])) ? (decimal?)null : Convert.ToDecimal(reader["ServiceSuccessSLA"]);
                                objEntity.IsArchived = string.IsNullOrEmpty(Convert.ToString(reader["IsArchived"])) ? false : Convert.ToBoolean(reader["IsArchived"]);
                                objEntity.ReasonofRejection = Convert.ToString(reader["ReasonofRejection"]);
                                contractorInfo.contractorAdminSetting = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ContractorComments objEntity = new ContractorComments();
                                objEntity.GeneralComments = Convert.ToString(reader["GeneralComments"]);
                                objEntity.InvoicingComments = Convert.ToString(reader["InvoicingComments"]);
                                contractorInfo.contractorComments = objEntity;
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
        /// Database layer method to create and update Contractor basic info 
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorBasicInfo CreateUpdateContractorBasicInfo(ContractorBasicInfo contractor)
        {
            ContractorBasicInfo objCustomer = new ContractorBasicInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_InsertUpdateCompany";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@SystemStartDate", (contractor.SystemStartDate == null || contractor.SystemStartDate == new DateTime()) ? SqlDateTime.MinValue.Value : contractor.SystemStartDate);
                        cmd.Parameters.AddWithValue("@CompanyId", contractor.CompanyId);
                        cmd.Parameters.AddWithValue("@CompanyName", contractor.CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyRegistrationNumber", contractor.CompanyRegistrationNumber);
                        cmd.Parameters.AddWithValue("@CompanyVATNumber", contractor.CompanyVATNumber);
                        cmd.Parameters.AddWithValue("@CountryofRegistration", contractor.CountryofRegistrations);
                        cmd.Parameters.AddWithValue("@CompanyTypeId", contractor.CompanyTypeId);
                        cmd.Parameters.AddWithValue("@AnnualTurnoverId", contractor.AnnualTurnoverId);
                        cmd.Parameters.AddWithValue("@CompanySIC", contractor.CompanySIC);
                        cmd.Parameters.AddWithValue("@NumberofEmployees", contractor.NumberofEmployees);
                        cmd.Parameters.AddWithValue("@ContractorTypeId", contractor.ContractorTypeId);
                        cmd.Parameters.AddWithValue("@OtherContractorType", contractor.OtherContractorType);
                        cmd.Parameters.AddWithValue("@ParentHoldingCompany", contractor.ParentHoldingCompany);
                        cmd.Parameters.AddWithValue("@CompanyPhoneNumber", contractor.CompanyPhoneNumber);
                        cmd.Parameters.AddWithValue("@CompanyEmail", contractor.CompanyEmail);
                        cmd.Parameters.AddWithValue("@WebsiteURL", contractor.WebsiteURL);
                        cmd.Parameters.AddWithValue("@AddressLine1", contractor.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", contractor.AddressLine2);
                        cmd.Parameters.AddWithValue("@Town", contractor.Town);
                        cmd.Parameters.AddWithValue("@County", contractor.County);
                        cmd.Parameters.AddWithValue("@Postcode", contractor.Postcode);
                        cmd.Parameters.AddWithValue("@RegionId", contractor.RegionId);
                        cmd.Parameters.AddWithValue("@Country", contractor.Country);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.ContractorId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
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
        /// Database layer method to create and update Contractor Admin settings
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorAdminSetting CreateUpdateContractorAdminSetting(ContractorAdminSetting contractor)
        {
            ContractorAdminSetting objCustomer = new ContractorAdminSetting();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_InsertUpdateAdminSetting";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@SystemStartDate", contractor.SystemStartDate);
                        cmd.Parameters.AddWithValue("@ApprovalStatusId", contractor.ApprovalStatusId);
                        cmd.Parameters.AddWithValue("@ReasonofRejection", contractor.ReasonofRejection);
                        cmd.Parameters.AddWithValue("@ContractorStatusId", contractor.ContractorStatusId);
                        cmd.Parameters.AddWithValue("@WeightsResponsibilityId", contractor.WeightsResponsibilityId);
                        cmd.Parameters.AddWithValue("@ServiceSuccessSLA", contractor.ServiceSuccessSLA);
                        cmd.Parameters.AddWithValue("@IsArchived", contractor.IsArchived);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.Contractor_AdminSettingsId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
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
        /// Database layer method to create and update Contractor Comments
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorComments CreateUpdateContractorComments(ContractorComments contractor)
        {
            ContractorComments objCustomer = new ContractorComments();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_InsertUpdateComments";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@GeneralComments", contractor.GeneralComments);
                        cmd.Parameters.AddWithValue("@InvoicingComments", contractor.InvoicingComments);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.ConCommentId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
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
        /// Database layer method to get Contractor Contact Type
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorContactType()
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorContactType> lstEntity = new List<ContractorContactType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetContactType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorContactType objEntity = new ContractorContactType();
                                objEntity.Contactor_ContactTypeId = string.IsNullOrEmpty(Convert.ToString(reader["Contactor_ContactTypeId"])) ? 0 : Convert.ToInt32(reader["Contactor_ContactTypeId"]);
                                objEntity.Contactor_ContactTypeName = Convert.ToString(reader["Contactor_ContactTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorContactType = lstEntity;
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
        /// Database layer method to get Contractor LegalBasis Details
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorLegalBasis()
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorLegalBasisData> lstEntity = new List<ContractorLegalBasisData>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contact_GetLegalBasisMaster]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorLegalBasisData objEntity = new ContractorLegalBasisData();
                                objEntity.LegalBasisId = string.IsNullOrEmpty(Convert.ToString(reader["LegalBasisId"])) ? 0 : Convert.ToInt32(reader["LegalBasisId"]);
                                objEntity.Contact_LegalBasisData = Convert.ToString(reader["Contact_LegalBasisData"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorLegalBasisData = lstEntity;
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
        /// Database layer method to Get All Contacts by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllContactsbyContractorId(ContractorContact contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorContact> lstEntity = new List<ContractorContact>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetAllContactsbyContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorContact objEntity = new ContractorContact();
                                objEntity.Contractor_ContactId = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_ContactId"])) ? 0 : Convert.ToInt32(reader["Contractor_ContactId"]);
                                objEntity.Contractor_ContactTypeIds = Convert.ToString(reader["Contractor_ContactTypeIds"]);
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
                                objEntity.AdditionalEmailAddress = Convert.ToString(reader["AdditionalEmailAddress"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstContractorContact = lstEntity;

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
        /// Database layer method to create and update Contractor Contact
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorContact CreateUpdateContractorContact(ContractorContact contractor)
        {
            ContractorContact objCustomer = new ContractorContact();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_InsertUpdateContacts";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Contractor_ContactId", contractor.Contractor_ContactId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@Contractor_ContactTypeIds", contractor.Contractor_ContactTypeIds);
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
                        cmd.Parameters.AddWithValue("@Description", contractor.Description);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", contractor.IsActive);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.Contractor_ContactId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
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


        //public ContractorContact DeleteContractorContacts(ContractorContact contractor)
        //{
        //    ContractorContact objContact = new ContractorContact();
        //    try
        //    {
        //        using (var conn = new SqlConnection(_connectionString))
        //        {
        //            conn.Open();
        //            using (var cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = "sp_Contractor_DeleteContact";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
        //                cmd.Parameters.AddWithValue("@Contractor_ContactIds", contractor.Contractor_ContactIds);
        //                cmd.ExecuteNonQuery();
        //                objContact.Contractor_ContactIds = contractor.Contractor_ContactIds;
        //            }
        //        }
        //        objContact.Status = Status.Success;
        //    }
        //    catch (Exception ex)
        //    {
        //        objContact.Status = Status.Failed;
        //        objContact.Message = ex.Message;
        //        throw ex;
        //    }
        //    return objContact;
        //}


        /// <summary>
        /// Database layer method to Delete Contractor Contacts
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo DeleteContractorContacts(ContractorContact contractorContact)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_DeleteContact";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractorContact.ContractorId);
                        cmd.Parameters.AddWithValue("@Contractor_ContactId", contractorContact.Contractor_ContactId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contractorInfo.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                contractorInfo.Message = Convert.ToString(reader["ReturnMsg"]);
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
                throw ex;
            }
            return contractorInfo;
        }


        /// <summary>
        /// Database layer method to Bulk Delete Contractor Contacts
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorContact BulkDeleteContractorContacts(List<ContractorContact> lstContractorContact)
        {
            ContractorContact contractorInfo = new ContractorContact();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    bool returnId = true;
                    foreach (var contractorContact in lstContractorContact)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "sp_Contractor_DeleteContact";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ContractorId", contractorContact.ContractorId);
                            cmd.Parameters.AddWithValue("@Contractor_ContactId", contractorContact.Contractor_ContactId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    contractorInfo.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                    contractorInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                                    if (contractorInfo.ReturnId == 0)
                                    {
                                        returnId = false;
                                    }
                                }
                            }
                        }
                    }
                    if (returnId)
                    {
                        contractorInfo.ReturnId = 1;
                        contractorInfo.Message = "Success! All selected Contacts are deleted and cannot be recovered";
                    }
                    else
                    {
                        contractorInfo.ReturnId = 0;
                        contractorInfo.Message = "Contacts which are  mapped with Depots are not deleted.";
                    }

                }
            }
            catch (Exception ex)
            {
                contractorInfo.Status = Status.Failed;
                contractorInfo.Message = ex.Message;
                throw ex;
            }
            return contractorInfo;
        }

        /// <summary>
        /// Database layer method to check company Name
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorBasicInfo CheckCompanyName(ContractorBasicInfo contractor)
        {
            ContractorBasicInfo objCompany = new ContractorBasicInfo();
            try
            {
                objCompany.IsCompanyExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_CheckCompanyName";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyName", contractor.CompanyName);
                        //cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCompany.IsCompanyExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objCompany.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCompany.Status = Status.Failed;
                objCompany.Message = ex.Message;
                throw ex;
            }
            return objCompany;
        }

        /// <summary>
        /// Database layer method to get Contractor contact by contactId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorContactsbyContactId(ContractorContact contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetContactsbyContractor_ContactId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Contractor_ContactId", Convert.ToString(contractor.Contractor_ContactId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorContact objEntity = new ContractorContact();
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.Title = Convert.ToString(reader["Title"]);
                                objEntity.Contactor_ContactTypeName = Convert.ToString(reader["Contactor_ContactTypeName"]);
                                objEntity.Contractor_ContactTypeIds = Convert.ToString(reader["Contractor_ContactTypeIds"]);
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
                                objEntity.AdditionalEmailAddress = Convert.ToString(reader["AdditionalEmailAddress"]);
                                objEntity.Description = Convert.ToString(reader["Description"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                contractorInfo.contractorContact = objEntity;
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
        /// Database layer method to get Active Contacts by contractor
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetActiveContactstsByContractor(ContractorContact contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorContact> lstEntity = new List<ContractorContact>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetActiveContactstsByContractor]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorContact objEntity = new ContractorContact();
                                objEntity.Contractor_ContactId = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_ContactId"])) ? 0 : Convert.ToInt32(reader["Contractor_ContactId"]);
                                objEntity.ContractorContacts = Convert.ToString(reader["ContractorContact"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorContact = lstEntity;
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
        /// Database layer method to get Contractor Depots by ContactId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorDepotsbyContactId(ContractorDepots contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorDepots> lstEntity = new List<ContractorDepots>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetAllDepotsbyContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorDepots objEntity = new ContractorDepots();
                                objEntity.Contractor_DepotID = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_DepotID"])) ? 0 : Convert.ToInt32(reader["Contractor_DepotID"]);
                                objEntity.DepotName = Convert.ToString(reader["DepotName"]);
                                objEntity.Contractor_ContactId = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_ContactId"])) ? 0 : Convert.ToInt32(reader["Contractor_ContactId"]);
                                objEntity.AccountCode = Convert.ToString(reader["AccountCode"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstContractorDepots = lstEntity;
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
        /// Database layer method to create and update Contractor Depots
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorDepots CreateUpdateContractorDepots(ContractorInfo contractor)
        {
            ContractorDepots objCustomer = new ContractorDepots();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_InsertUpdateDepots";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepotName", contractor.contractorDepots.DepotName);
                        cmd.Parameters.AddWithValue("@AccountCode", contractor.contractorDepots.AccountCode);
                        cmd.Parameters.AddWithValue("@AddressLine1", contractor.contractorDepots.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", contractor.contractorDepots.AddressLine2);
                        cmd.Parameters.AddWithValue("@Town", contractor.contractorDepots.Town);
                        cmd.Parameters.AddWithValue("@County", contractor.contractorDepots.County);
                        cmd.Parameters.AddWithValue("@Postcode", contractor.contractorDepots.Postcode);
                        cmd.Parameters.AddWithValue("@Country", contractor.contractorDepots.Country);
                        cmd.Parameters.AddWithValue("@Contractor_DepotID", contractor.contractorDepots.Contractor_DepotID);
                        cmd.Parameters.AddWithValue("@Contractor_ContactId", contractor.contractorDepots.Contractor_ContactId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.contractorDepots.ContractorId);
                        cmd.Parameters.AddWithValue("@Contractor_ContactTypeIds", contractor.contractorContact.Contractor_ContactTypeIds);
                        cmd.Parameters.AddWithValue("@Title", contractor.contractorContact.Title);
                        cmd.Parameters.AddWithValue("@FirstName", contractor.contractorContact.FirstName);
                        cmd.Parameters.AddWithValue("@Surname", contractor.contractorContact.Surname);
                        cmd.Parameters.AddWithValue("@JobTitle", contractor.contractorContact.JobTitle);
                        cmd.Parameters.AddWithValue("@LegalBasisId", contractor.contractorContact.LegalBasisId);
                        cmd.Parameters.AddWithValue("@Contact_AddressLine1", contractor.contractorContact.AddressLine1);
                        cmd.Parameters.AddWithValue("@Contact_AddressLine2", contractor.contractorContact.AddressLine2);
                        cmd.Parameters.AddWithValue("@Contact_Town", contractor.contractorContact.Town);
                        cmd.Parameters.AddWithValue("@Contact_County", contractor.contractorContact.County);
                        cmd.Parameters.AddWithValue("@Contact_Postcode", contractor.contractorContact.Postcode);
                        cmd.Parameters.AddWithValue("@Contact_Country", contractor.contractorContact.Country);
                        cmd.Parameters.AddWithValue("@MobileNumber", contractor.contractorContact.MobileNumber);
                        cmd.Parameters.AddWithValue("@ContactNumber", contractor.contractorContact.ContactNumber);
                        cmd.Parameters.AddWithValue("@AdditionalEmailAddress", contractor.contractorContact.AdditionalEmailAddress);
                        cmd.Parameters.AddWithValue("@MainEmailAddress", contractor.contractorContact.MainEmailAddress);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.contractorContact.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.Contractor_DepotID = Convert.ToInt32(cmd.Parameters["@Result"].Value);
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
        /// Database layer method to get contractor depots by depotid
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetContractorDepotsbyDepotId(ContractorDepots contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetDepotsbyContractor_DepotId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Contractor_DepotID", Convert.ToString(contractor.Contractor_DepotID));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorDepots objEntity = new ContractorDepots();
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.Contractor_DepotID = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_DepotID"])) ? 0 : Convert.ToInt32(reader["Contractor_DepotID"]);
                                objEntity.DepotName = Convert.ToString(reader["DepotName"]);
                                objEntity.AccountCode = Convert.ToString(reader["AccountCode"]);
                                objEntity.Contractor_ContactId = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_ContactId"])) ? 0 : Convert.ToInt32(reader["Contractor_ContactId"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objEntity.Town = Convert.ToString(reader["Town"]);
                                objEntity.County = Convert.ToString(reader["County"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.Country = Convert.ToString(reader["Country"]);
                                contractorInfo.contractorDepots = objEntity;
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
        /// Database layer method to Delete Contractor Depot
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorDepots DeleteContractorDepots(ContractorDepots contractor)
        {
            ContractorDepots objContact = new ContractorDepots();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contractor_DeleteDepot";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@Contractor_DepotIDs", contractor.Contractor_DepotIDs);
                        cmd.ExecuteNonQuery();
                        objContact.Contractor_DepotIDs = contractor.Contractor_DepotIDs;
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
        /// Database layer method to get allocated facilitieas by ContractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FacilityBasicInfo> lstEntity = new List<FacilityBasicInfo>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetAllocatedFacilitiesByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FacilityBasicInfo objEntity = new FacilityBasicInfo();
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.FacilityTypeId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityTypeId"])) ? 0 : Convert.ToInt32(reader["FacilityTypeId"]);
                                objEntity.FacilityName = Convert.ToString(reader["FacilityName"]);
                                objEntity.FacilityType_Name = Convert.ToString(reader["FacilityType_Name"]);
                                objEntity.WasteManagementLicenceNumber = Convert.ToString(reader["WasteManagementLicenceNumber"]);
                                objEntity.PermitNumber = Convert.ToString(reader["PermitNumber"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["Address"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.Longitude = string.IsNullOrEmpty(Convert.ToString(reader["Longitude"])) ? 0 : Convert.ToDecimal(reader["Longitude"]);
                                objEntity.Latitude = string.IsNullOrEmpty(Convert.ToString(reader["Latitude"])) ? 0 : Convert.ToDecimal(reader["Latitude"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstAllocatedFacilitiesList = lstEntity;
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
        /// Database layer method to get Document Types
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetDocumentTypes()
        {
            ContractorInfo customerInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<DocumentType> lstEntity = new List<DocumentType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetContractorDocumentType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DocumentType objEntity = new DocumentType();
                                objEntity.DocumentTypeId = string.IsNullOrEmpty(Convert.ToString(reader["DocumentTypeId"])) ? 0 : Convert.ToInt32(reader["DocumentTypeId"]);
                                objEntity.DocumentTypeName = Convert.ToString(reader["DocumentTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstDocumentType = lstEntity;
                }
                customerInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                customerInfo.Status = Status.Failed;
                customerInfo.Message = ex.Message;
            }
            return customerInfo;
        }

        /// <summary>
        /// Database layer method to get all documents by Contractor
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetAllDocumentsByContractor(ContractorBasicInfo contractorBasicInfo)

        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    List<DocumentInfo> lstEntity = new List<DocumentInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetAllDocumentsByContractor]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractorBasicInfo.ContractorId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                DocumentInfo objEntity = new DocumentInfo();
                                objEntity.Contractor_DocumentId = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_DocumentId"])) ? 0 : Convert.ToInt32(reader["Contractor_DocumentId"]);
                                objEntity.SharePointId = string.IsNullOrEmpty(Convert.ToString(reader["SharePointId"])) ? 0 : Convert.ToInt32(reader["SharePointId"]);
                                objEntity.DocumentTypeId = string.IsNullOrEmpty(Convert.ToString(reader["DocumentTypeId"])) ? 0 : Convert.ToInt32(reader["DocumentTypeId"]);
                                objEntity.DocumentTypeName = Convert.ToString(reader["DocumentTypeName"]);
                                objEntity.DocumentName = Convert.ToString(reader["DocumentName"]);
                                objEntity.DocDescription = Convert.ToString(reader["DocDescription"]);
                                objEntity.ExpiringIn = Convert.ToString(reader["ExpiringIn"]);
                                objEntity.ExpiryDate = string.IsNullOrEmpty(Convert.ToString(reader["ExpiryDate"])) ? (DateTime?)null : Convert.ToDateTime(reader["ExpiryDate"]);
                                objEntity.FileReference = Convert.ToString(reader["FileReference"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstDocumentInfos = lstEntity;
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
        /// Database layer method to create and update document Information
        /// </summary>
        /// Delivery Point: DP4.1
        public DocumentInfo CreateUpdateDocumentInfo(DocumentInfo documentInfo)
        {
            DocumentInfo objDocumentInfo = new DocumentInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Contractor_InsertUpdateDocumentInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", documentInfo.ContractorId);
                        cmd.Parameters.AddWithValue("@Contractor_DocumentId", documentInfo.Contractor_DocumentId);
                        cmd.Parameters.AddWithValue("@SharePointId", documentInfo.SharePointId);
                        cmd.Parameters.AddWithValue("@DocumentTypeId", documentInfo.DocumentTypeId);
                        cmd.Parameters.AddWithValue("@DocumentName", documentInfo.DocumentName);
                        cmd.Parameters.AddWithValue("@DocDescription", documentInfo.DocDescription);
                        cmd.Parameters.AddWithValue("@ExpiryDate", documentInfo.ExpiryDate);
                        //cmd.Parameters.AddWithValue("@ExpiryDate", (documentInfo.ExpiryDate == null || documentInfo.ExpiryDate == new DateTime()) ? SqlDateTime.MaxValue.Value.AddDays(-1) : documentInfo.ExpiryDate);
                        cmd.Parameters.AddWithValue("@FileReference", documentInfo.FileReference);
                        cmd.Parameters.AddWithValue("@CreatedBy", documentInfo.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", documentInfo.IsActive);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objDocumentInfo.Contractor_DocumentId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
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
        /// Database layer method to Remove Facility Allocation
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo RemoveFacilityAllocation(ContractorBasicInfo contractor)
        {
            ContractorInfo objContractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_RemoveFacilityAllocation]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@FacilityIds", contractor.FacilityIds);
                        cmd.ExecuteNonQuery();
                    }
                }
                objContractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objContractorInfo.Status = Status.Failed;
                objContractorInfo.Message = ex.Message;
                throw ex;
            }
            return objContractorInfo;
        }

        /// <summary>
        /// Database layer method to get unallocated Facilities by contractorId
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo GetUnAllocatedFacilitiesByContractorId(ContractorBasicInfo contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FacilityBasicInfo> lstEntity = new List<FacilityBasicInfo>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetUnallocatedFacilitiesByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FacilityBasicInfo objEntity = new FacilityBasicInfo();
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.FacilityName = Convert.ToString(reader["FacilityName"]); lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstUnAllocatedFacilitiesList = lstEntity;
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
        /// Database layer method to Insert Facility Allocation
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorInfo InsertFacilityAllocation(ContractorBasicInfo contractor)
        {
            ContractorInfo objContractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_InsertFacilityAllocation]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityIds", contractor.FacilityIds);
                        cmd.Parameters.AddWithValue("@ContractorId", contractor.ContractorId);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractor.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                objContractorInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objContractorInfo.Status = Status.Failed;
                objContractorInfo.Message = ex.Message;
                throw ex;
            }
            return objContractorInfo;
        }

        /// <summary>
        /// Database layer method to get pricing matrix list by contractorId
        /// </summary>
        /// Delivery Point: DP4.8
        public ContractorInfo GetPricingMatrixListByContractorId(ContractorBasicInfo contractor)
        {
            ContractorInfo contractorInfo = new ContractorInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<PricingMatrixSetup> lstEntity = new List<PricingMatrixSetup>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetPricingMatrixListByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PricingMatrixSetup objEntity = new PricingMatrixSetup();
                                objEntity.MatrixId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixId"])) ? 0 : Convert.ToInt32(reader["MatrixId"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                                objEntity.StartDate = string.IsNullOrEmpty(Convert.ToString(reader["StartDate"])) ? new DateTime() : Convert.ToDateTime(reader["StartDate"]);
                                objEntity.EndDate = string.IsNullOrEmpty(Convert.ToString(reader["EndDate"])) ? new DateTime() : Convert.ToDateTime(reader["EndDate"]);
                                objEntity.CanDelete = string.IsNullOrEmpty(Convert.ToString(reader["CanDelete"])) ? 0 : Convert.ToInt32(reader["CanDelete"]);
                                objEntity.ActionHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["ActionHeaderId"])) ? 0 : Convert.ToInt32(reader["ActionHeaderId"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstpricingMatrices = lstEntity;
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
