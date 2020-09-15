using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Repositories.Customer
{
    public class CustomerRepository : ICustomerRepository
    {

        /// <summary>
        /// Parmeter for dependency injection Connection String
        /// </summary>
        private string _connectionString;
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Company CreateCompany(CompanyInfo companyInfo)
        {
            Company objCompany = new Company();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_InsertUpdateCompany";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", companyInfo.CompanyId);
                        cmd.Parameters.AddWithValue("@CompanyName", companyInfo.CompanyName);
                        cmd.Parameters.AddWithValue("@ApplyLFT", companyInfo.ApplyLFTIncrease);
                        cmd.Parameters.AddWithValue("@PriceInflationId", companyInfo.PriceInflationId);
                        cmd.Parameters.AddWithValue("@Comment", companyInfo.Comment);
                        cmd.Parameters.AddWithValue("@CreatedBy", companyInfo.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCompany.companyInfo = new CompanyInfo();
                        objCompany.companyInfo.CompanyId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
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



        public Company GetAllCompany(CompanyInfo companyInfo)
        {
            Company company = new Company();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CompanyInfo> lstEntity = new List<CompanyInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetAllDetailsByCompanyId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToString(companyInfo.CompanyId));
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToString(companyInfo.CreatedBy));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CompanyInfo objEntity = new CompanyInfo();
                            objEntity.CompanyId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyId"])) ? 0 : Convert.ToInt32(reader["CompanyId"]);
                            objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                            objEntity.ApplyLFTIncrease = string.IsNullOrEmpty(Convert.ToString(reader["ApplyLFTIncrease"])) ? false : Convert.ToBoolean(reader["ApplyLFTIncrease"]);
                            objEntity.PriceInflationId = string.IsNullOrEmpty(Convert.ToString(reader["PriceInflationId"])) ? 0 : Convert.ToInt32(reader["PriceInflationId"]);
                            objEntity.PriceInflation_Name = Convert.ToString(reader["PriceInflation_Name"]);
                            objEntity.Comment = Convert.ToString(reader["Comment"]);
                            lstEntity.Add(objEntity);
                        }
                        reader.Close();


                    }
                    company.lstCompanyInfo = lstEntity;
                }
                company.Status = Status.Success;
            }
            catch (Exception ex)
            {
                company.Status = Status.Failed;
                company.Message = ex.Message;
            }

            return company;
        }

        /// <summary>
        /// Chnages related to EUW-727
        /// </summary>
        public Company GetCompanyById(CompanyInfo companyInfo)
        {
            Company company = new Company();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    CompanyInfo objEntity = new CompanyInfo();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetAllDetailsByCompanyId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToString(companyInfo.CompanyId));
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToString(companyInfo.CreatedBy));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            objEntity.CompanyId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyId"])) ? 0 : Convert.ToInt32(reader["CompanyId"]);
                            objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                            objEntity.ApplyLFTIncrease = string.IsNullOrEmpty(Convert.ToString(reader["ApplyLFTIncrease"])) ? false : Convert.ToBoolean(reader["ApplyLFTIncrease"]);
                            objEntity.PriceInflationId = string.IsNullOrEmpty(Convert.ToString(reader["PriceInflationId"])) ? 0 : Convert.ToInt32(reader["PriceInflationId"]);
                            objEntity.PriceInflation_Name = Convert.ToString(reader["PriceInflation_Name"]);
                            objEntity.Comment = Convert.ToString(reader["Comment"]);
                            objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                            objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);

                        }
                        reader.Close();


                    }
                    company.companyInfo = objEntity;
                }
                company.Status = Status.Success;
            }
            catch (Exception ex)
            {
                company.Status = Status.Failed;
                company.Message = ex.Message;
            }

            return company;
        }


        /// <summary>
        /// Chnages related to EUW-727
        /// </summary>

        public Company GetCompanyDeals(CompanyInfo companyInfo)
        {
            Company company = new Company();
            try
            {
                List<CompanyInfo> lstEntity = new List<CompanyInfo>();
                List<Deal> lstEntity1 = new List<Deal>();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetAllDetailsByCompanyId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToString(companyInfo.CompanyId));
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToString(companyInfo.CreatedBy));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CompanyInfo objEntity = new CompanyInfo();
                                objEntity.CompanyId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyId"])) ? 0 : Convert.ToInt32(reader["CompanyId"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.ApplyLFTIncrease = string.IsNullOrEmpty(Convert.ToString(reader["ApplyLFTIncrease"])) ? false : Convert.ToBoolean(reader["ApplyLFTIncrease"]);
                                objEntity.PriceInflationId = string.IsNullOrEmpty(Convert.ToString(reader["PriceInflationId"])) ? 0 : Convert.ToInt32(reader["PriceInflationId"]);
                                objEntity.PriceInflation_Name = Convert.ToString(reader["PriceInflation_Name"]);
                                objEntity.Comment = Convert.ToString(reader["Comment"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                Deal objEntity = new Deal();
                                objEntity.Did = string.IsNullOrEmpty(Convert.ToString(reader["DId"])) ? 0 : Convert.ToInt32(reader["DId"]);
                                objEntity.DealId = Convert.ToString(reader["DealId"]);
                                objEntity.ContractDuration = string.IsNullOrEmpty(Convert.ToString(reader["ContractDuration"])) ? 0 : Convert.ToInt32(reader["ContractDuration"]);
                                objEntity.ContractStartDate = Convert.ToDateTime(reader["ContractStartDate"]);
                                objEntity.ContractEndDate = Convert.ToDateTime(reader["ContractEndDate"]);
                                objEntity.DealAmount = Convert.ToDecimal(reader["DealAmount"]);
                                objEntity.SalesOwnerId = string.IsNullOrEmpty(Convert.ToString(reader["SalesOwnerId"])) ? 0 : Convert.ToInt32(reader["SalesOwnerId"]);
                                objEntity.SOSStatus = string.IsNullOrEmpty(Convert.ToString(reader["Status"])) ? 0 : Convert.ToInt32(reader["Status"]);
                                objEntity.DealStatusId = string.IsNullOrEmpty(Convert.ToString(reader["DealStatusId"])) ? 0 : Convert.ToInt32(reader["DealStatusId"]);
                                objEntity.DealStatusName = Convert.ToString(reader["DealStatusName"]);
                                objEntity.SalesOwnerName = Convert.ToString(reader["SalesOwnerName"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity1.Add(objEntity);
                            }
                        }
                    }

                }
                company.lstCompanyInfo = lstEntity;
                company.lstDeals = lstEntity1;
                company.Status = Status.Success;
            }
            catch (Exception ex)
            {
                company.Status = Status.Failed;
                company.Message = ex.Message;
            }
            return company;
        }
        public Company GetMultipleCompanyDeals(CompanyInfo companyInfo)
        {
            Company company = new Company();
            try
            {
                List<Deal> lstEntity = new List<Deal>();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetAllDetailsByMultipleCompanyId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToString(companyInfo.CompanyIds));
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToString(companyInfo.CreatedBy));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Deal objEntity = new Deal();
                                objEntity.Did = string.IsNullOrEmpty(Convert.ToString(reader["DId"])) ? 0 : Convert.ToInt32(reader["DId"]);
                                objEntity.DealId = Convert.ToString(reader["DealId"]);
                                objEntity.CompanyId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyId"])) ? 0 : Convert.ToInt32(reader["CompanyId"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.ContractDuration = string.IsNullOrEmpty(Convert.ToString(reader["ContractDuration"])) ? 0 : Convert.ToInt32(reader["ContractDuration"]);
                                objEntity.ContractStartDate = Convert.ToDateTime(reader["ContractStartDate"]);
                                objEntity.ContractEndDate = Convert.ToDateTime(reader["ContractEndDate"]);
                                objEntity.DealAmount = Convert.ToDecimal(reader["DealAmount"]);
                                objEntity.SalesOwnerName = Convert.ToString(reader["SalesOwnerName"]);
                                objEntity.SOSStatus = string.IsNullOrEmpty(Convert.ToString(reader["IsSOSCreated"])) ? 0 : Convert.ToInt32(reader["IsSOSCreated"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }

                }
                company.lstDeals = lstEntity;
                company.Status = Status.Success;
            }
            catch (Exception ex)
            {
                company.Status = Status.Failed;
                company.Message = ex.Message;
            }

            return company;
        }

        /// <summary>   
        /// Changes as per story EUW-727
        /// </summary>
        public Company GetCompanySites(CompanyInfo companyInfo)
        {
            Company company = new Company();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CompanyInfo> lstEntity = new List<CompanyInfo>();
                    List<Sites> lstEntity1 = new List<Sites>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetSitesByCompanyId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToString(companyInfo.CompanyId));
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToString(companyInfo.CreatedBy));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CompanyInfo objEntity = new CompanyInfo();
                                objEntity.CompanyId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyId"])) ? 0 : Convert.ToInt32(reader["CompanyId"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.ApplyLFTIncrease = string.IsNullOrEmpty(Convert.ToString(reader["ApplyLFTIncrease"])) ? false : Convert.ToBoolean(reader["ApplyLFTIncrease"]);
                                objEntity.PriceInflationId = string.IsNullOrEmpty(Convert.ToString(reader["PriceInflationId"])) ? 0 : Convert.ToInt32(reader["PriceInflationId"]);
                                objEntity.PriceInflation_Name = Convert.ToString(reader["PriceInflation_Name"]);
                                objEntity.Comment = Convert.ToString(reader["Comment"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                            while (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    Sites objEntity = new Sites();
                                    objEntity.SiteId = string.IsNullOrEmpty(Convert.ToString(reader["SiteId"])) ? 0 : Convert.ToInt32(reader["SiteId"]);
                                    objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                    objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                    objEntity.Address = Convert.ToString(reader["Address_line1"]) + " " + Convert.ToString(reader["Address_line2"]);
                                    objEntity.AddressLine1 = Convert.ToString(reader["Address_line1"]);
                                    objEntity.AddressLine2 = Convert.ToString(reader["Address_line2"]);
                                    objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                                    objEntity.Town = Convert.ToString(reader["Town"]);
                                    objEntity.County = Convert.ToString(reader["County"]);
                                    objEntity.Region = Convert.ToString(reader["Region"]);
                                    objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                    objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                    lstEntity1.Add(objEntity);
                                }
                            }
                        }
                    }
                    company.lstCompanyInfo = lstEntity;
                    company.lstSites = lstEntity1;
                }
                company.Status = Status.Success;
            }
            catch (Exception ex)
            {
                company.Status = Status.Failed;
                company.Message = ex.Message;
            }

            return company;
        }

        public Company CheckCompany(CompanyInfo companyInfo)
        {

            Company objCompany = new Company();
            try
            {
                objCompany.IsCompanyExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_CheckCompanyName";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyName", companyInfo.CompanyName);
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
        /// Database layer method to create and update customer basic info 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo CreateUpdateCustomerBasicInfo(CustomerBasicInfo customer)
        {
            CustomerBasicInfo objCustomer = new CustomerBasicInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Customer_InsertUpdateBasicInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@CompanyId", customer.CompanyId);
                        cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyDomainName", customer.CompanyDomainName);
                        cmd.Parameters.AddWithValue("@CompanyShortName", customer.CompanyShortName);
                        cmd.Parameters.AddWithValue("@CompanySICCode", customer.CompanySICCode);
                        cmd.Parameters.AddWithValue("@CompanyRegistrationNumber", customer.CompanyRegistrationNumber);
                        cmd.Parameters.AddWithValue("@CreditRating", customer.CreditRating);
                        cmd.Parameters.AddWithValue("@CustomerTypeId", customer.CustomerTypeId);
                        cmd.Parameters.AddWithValue("@SectorId", customer.SectorId);
                        cmd.Parameters.AddWithValue("@IsPublic", customer.IsPublic);
                        cmd.Parameters.AddWithValue("@IsManagedAccount", customer.IsManagedAccount);
                        cmd.Parameters.AddWithValue("@HubSpotOwner", customer.HubspotOwner);
                        cmd.Parameters.AddWithValue("@PostCode", customer.PostCode);
                        cmd.Parameters.AddWithValue("@StreetAddress1", customer.StreetAddress1);
                        cmd.Parameters.AddWithValue("@StreetAddress2", customer.StreetAddress2);
                        cmd.Parameters.AddWithValue("@Town", customer.Town);
                        cmd.Parameters.AddWithValue("@County", customer.County);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@WebsiteURL", customer.WebsiteURL);
                        cmd.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                        cmd.Parameters.AddWithValue("@SalesContactId", customer.SalesContactId);
                        cmd.Parameters.AddWithValue("@AccountManagerContactId", customer.AccountManagerContactId);
                        cmd.Parameters.AddWithValue("@CustomerServiceContactId", customer.CustomerServiceContactId);
                        cmd.Parameters.AddWithValue("@FinanceContactId", customer.FinanceContactId);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.CustomerId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
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
        ///  Database layer to check customer existing data 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo CheckCustomerExistData(CustomerBasicInfo customer, DataTable dataTable)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            CustomerBasicInfo customerBasicInfo = new CustomerBasicInfo();
            List<CustomerContact> lstEntity = new List<CustomerContact>();
            int returnId = 0;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Customer_CheckCustomerExistDataByCompanyId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@NewContacts", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_HubspotNewContacts",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@CompanyId", customer.CompanyId);
                        cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyDomainName", customer.CompanyDomainName);
                        cmd.Parameters.AddWithValue("@CompanyShortName", customer.CompanyShortName);
                        cmd.Parameters.AddWithValue("@CompanySICCode", customer.CompanySICCode);
                        cmd.Parameters.AddWithValue("@CompanyRegistrationNumber", customer.CompanyRegistrationNumber);
                        cmd.Parameters.AddWithValue("@HubspotOwner", customer.HubspotOwner);
                        cmd.Parameters.AddWithValue("@CreditRating", customer.CreditRating);
                        cmd.Parameters.AddWithValue("@CustomerTypeId", customer.CustomerTypeId);
                        cmd.Parameters.AddWithValue("@SectorId", customer.SectorId);
                        cmd.Parameters.AddWithValue("@IsPublic", customer.IsPublic);
                        cmd.Parameters.AddWithValue("@PostCode", customer.PostCode);
                        cmd.Parameters.AddWithValue("@StreetAddress1", customer.StreetAddress1);
                        cmd.Parameters.AddWithValue("@StreetAddress2", customer.StreetAddress2);
                        cmd.Parameters.AddWithValue("@Town", customer.Town);
                        cmd.Parameters.AddWithValue("@County", customer.County);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@WebsiteURL", customer.WebsiteURL);
                        cmd.Parameters.AddWithValue("@SystemStartDate", customer.SystemStartDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //returnId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                            while (reader.Read())
                            {
                                returnId = string.IsNullOrEmpty(Convert.ToString(reader["returnId"])) ? 0 : Convert.ToInt32(reader["returnId"]);
                            }
                            if (returnId == 1 || returnId == 2 || returnId == 3)
                            {
                                if (returnId == 1 || returnId == 2)
                                {
                                    reader.NextResult();
                                    while (reader.Read())
                                    {
                                        customerBasicInfo.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                                        customerBasicInfo.CompanyName = Convert.ToString(reader["CompanyName"]);
                                        customerBasicInfo.CompanyDomainName = Convert.ToString(reader["CompanyDomainName"]);
                                        customerBasicInfo.CompanySICCode = Convert.ToString(reader["CompanySICCode"]);
                                        customerBasicInfo.CompanyRegistrationNumber = Convert.ToString(reader["CompanyRegistrationNumber"]);
                                        customerBasicInfo.HubspotOwner = Convert.ToString(reader["HubspotOwner"]);
                                        customerBasicInfo.CreditRating = Convert.ToString(reader["CreditRating"]);
                                        customerBasicInfo.IsPublic = string.IsNullOrEmpty(Convert.ToString(reader["IsPublic"])) ? false : Convert.ToBoolean(reader["IsPublic"]);
                                        customerBasicInfo.PostCode = Convert.ToString(reader["PostCode"]);
                                        customerBasicInfo.StreetAddress1 = Convert.ToString(reader["StreetAddress1"]);
                                        customerBasicInfo.StreetAddress2 = Convert.ToString(reader["StreetAddress2"]);
                                        customerBasicInfo.Town = Convert.ToString(reader["Town"]);
                                        customerBasicInfo.County = Convert.ToString(reader["County"]);
                                        customerBasicInfo.Country = Convert.ToString(reader["Country"]);
                                        customerBasicInfo.WebsiteURL = Convert.ToString(reader["WebsiteURL"]);

                                        customerBasicInfo.H_CompanyName = Convert.ToString(reader["H_CompanyName"]);
                                        customerBasicInfo.H_CompanyDomainName = Convert.ToString(reader["H_CompanyDomainName"]);
                                        customerBasicInfo.H_CompanySICCode = Convert.ToString(reader["H_CompanySICCode"]);
                                        customerBasicInfo.H_CompanyRegistrationNumber = Convert.ToString(reader["H_CompanyRegistrationNumber"]);
                                        customerBasicInfo.H_CreditRating = Convert.ToString(reader["H_CreditRating"]);
                                        customerBasicInfo.H_HubspotOwner = Convert.ToString(reader["H_HubspotOwner"]);
                                        customerBasicInfo.H_IsPublic = string.IsNullOrEmpty(Convert.ToString(reader["H_IsPublic"])) ? false : Convert.ToBoolean(reader["H_IsPublic"]);
                                        customerBasicInfo.H_PostCode = Convert.ToString(reader["H_PostCode"]);
                                        customerBasicInfo.H_StreetAddress1 = Convert.ToString(reader["H_StreetAddress1"]);
                                        customerBasicInfo.H_StreetAddress2 = Convert.ToString(reader["H_StreetAddress2"]);
                                        customerBasicInfo.H_Town = Convert.ToString(reader["H_Town"]);
                                        customerBasicInfo.H_County = Convert.ToString(reader["H_County"]);
                                        customerBasicInfo.H_Country = Convert.ToString(reader["H_Country"]);
                                        customerBasicInfo.H_WebsiteURL = Convert.ToString(reader["H_WebsiteURL"]);

                                        customerBasicInfo.IsCompanyDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsCompanyDiffer"])) ? 0 : Convert.ToInt32(reader["IsCompanyDiffer"]);
                                        customerBasicInfo.IsDomainDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsDomainDiffer"])) ? 0 : Convert.ToInt32(reader["IsDomainDiffer"]);
                                        customerBasicInfo.IsSICdiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsSICdiffer"])) ? 0 : Convert.ToInt32(reader["IsSICdiffer"]);
                                        customerBasicInfo.IsRegNoDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsRegNoDiffer"])) ? 0 : Convert.ToInt32(reader["IsRegNoDiffer"]);
                                        customerBasicInfo.IsHubspotOwnerDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsHubspotOwnerDiffer"])) ? 0 : Convert.ToInt32(reader["IsHubspotOwnerDiffer"]);
                                        customerBasicInfo.IsCreditRaDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsCreditRaDiffer"])) ? 0 : Convert.ToInt32(reader["IsCreditRaDiffer"]);
                                        customerBasicInfo.IsPublicDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsPublicDiffer"])) ? 0 : Convert.ToInt32(reader["IsPublicDiffer"]);
                                        customerBasicInfo.IsPostcodeDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsPostcodeDiffer"])) ? 0 : Convert.ToInt32(reader["IsPostcodeDiffer"]);
                                        customerBasicInfo.IsSAdd1Differ = string.IsNullOrEmpty(Convert.ToString(reader["IsSAdd1Differ"])) ? 0 : Convert.ToInt32(reader["IsSAdd1Differ"]);
                                        customerBasicInfo.IsSAdd2Differ = string.IsNullOrEmpty(Convert.ToString(reader["IsSAdd2Differ"])) ? 0 : Convert.ToInt32(reader["IsSAdd2Differ"]);
                                        customerBasicInfo.IsTownDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsTownDiffer"])) ? 0 : Convert.ToInt32(reader["IsTownDiffer"]);
                                        customerBasicInfo.IsCountyDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsCountyDiffer"])) ? 0 : Convert.ToInt32(reader["IsCountyDiffer"]);
                                        customerBasicInfo.IsCountryDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsCountryDiffer"])) ? 0 : Convert.ToInt32(reader["IsCountryDiffer"]);
                                        customerBasicInfo.IsWebsiteDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsWebsiteDiffer"])) ? 0 : Convert.ToInt32(reader["IsWebsiteDiffer"]);
                                    }
                                    customerInfo.customerBasicInfo = customerBasicInfo;
                                }
                                if (returnId == 1 || returnId == 3)
                                {
                                    reader.NextResult();
                                    while (reader.Read())
                                    {
                                        CustomerContact objEntity = new CustomerContact();
                                        objEntity.ContactId = string.IsNullOrEmpty(Convert.ToString(reader["ContactId"])) ? 0 : Convert.ToInt32(reader["ContactId"]);
                                        objEntity.Vid = string.IsNullOrEmpty(Convert.ToString(reader["Vid"])) ? 0 : Convert.ToInt32(reader["Vid"]);
                                        objEntity.FirstName = Convert.ToString(reader["FirstName"]);
                                        objEntity.SurName = Convert.ToString(reader["SurName"]);
                                        objEntity.JobTitle = Convert.ToString(reader["JobTitle"]);
                                        objEntity.MainEmailAddress = Convert.ToString(reader["MainEmailAddress"]);
                                        objEntity.AdditionalEmailAddress = Convert.ToString(reader["AdditionalEmailAddress"]);
                                        objEntity.LegalBasisData = Convert.ToString(reader["LegalBasisData"]);
                                        objEntity.MobileNo = Convert.ToString(reader["MobileNo"]);
                                        objEntity.ContactNo = Convert.ToString(reader["ContactNo"]);
                                        objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                        objEntity.Town = Convert.ToString(reader["Town"]);
                                        objEntity.County = Convert.ToString(reader["County"]);
                                        objEntity.Region = Convert.ToString(reader["Region"]);
                                        objEntity.Country = Convert.ToString(reader["Country"]);
                                        //objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                                        objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);

                                        objEntity.H_FirstName = Convert.ToString(reader["H_FirstName"]);
                                        objEntity.H_SurName = Convert.ToString(reader["H_SurName"]);
                                        objEntity.H_JobTitle = Convert.ToString(reader["H_JobTitle"]);
                                        objEntity.H_LegalBasisProcessing = Convert.ToString(reader["H_LegalBasisProcessing"]);
                                        objEntity.H_MainEmailAddress = Convert.ToString(reader["H_MainEmailAddress"]);
                                        objEntity.H_AdditionalEmailAddress = Convert.ToString(reader["H_AdditionalEmailAddress"]);
                                        objEntity.H_MobileNo = Convert.ToString(reader["H_MobileNo"]);
                                        objEntity.H_ContactNo = Convert.ToString(reader["H_ContactNo"]);
                                        objEntity.H_AddressLine1 = Convert.ToString(reader["H_AddressLine1"]);
                                        objEntity.H_Town = Convert.ToString(reader["H_Town"]);
                                        objEntity.H_County = Convert.ToString(reader["H_County"]);
                                        objEntity.H_Region = Convert.ToString(reader["H_Region"]);
                                        objEntity.H_Country = Convert.ToString(reader["H_Country"]);
                                        objEntity.H_IsActive = string.IsNullOrEmpty(Convert.ToString(reader["H_IsActive"])) ? false : Convert.ToBoolean(reader["H_IsActive"]);

                                        objEntity.IsFirstNameDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsFirstNameDiffer"])) ? 0 : Convert.ToInt32(reader["IsFirstNameDiffer"]);
                                        objEntity.IsSurNameDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsSurNameDiffer"])) ? 0 : Convert.ToInt32(reader["IsSurNameDiffer"]);
                                        objEntity.IsJobTitleDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsJobTitleDiffer"])) ? 0 : Convert.ToInt32(reader["IsJobTitleDiffer"]);
                                        objEntity.IslegalDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IslegalDiffer"])) ? 0 : Convert.ToInt32(reader["IslegalDiffer"]);
                                        objEntity.IsMainEmailDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsMainEmailDiffer"])) ? 0 : Convert.ToInt32(reader["IsMainEmailDiffer"]);
                                        objEntity.IsAdditionalEmailDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsAdditionalEmailDiffer"])) ? 0 : Convert.ToInt32(reader["IsAdditionalEmailDiffer"]);
                                        objEntity.IsMobileNoDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsMobileNoDiffer"])) ? 0 : Convert.ToInt32(reader["IsMobileNoDiffer"]);
                                        objEntity.IsContactNoDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsContactNoDiffer"])) ? 0 : Convert.ToInt32(reader["IsContactNoDiffer"]);
                                        objEntity.IsAddress1Differ = string.IsNullOrEmpty(Convert.ToString(reader["IsAddress1Differ"])) ? 0 : Convert.ToInt32(reader["IsAddress1Differ"]);
                                        objEntity.IsTownDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsTownDiffer"])) ? 0 : Convert.ToInt32(reader["IsTownDiffer"]);
                                        objEntity.IsCountyDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsCountyDiffer"])) ? 0 : Convert.ToInt32(reader["IsCountyDiffer"]);
                                        objEntity.IsRegionDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsRegionDiffer"])) ? 0 : Convert.ToInt32(reader["IsRegionDiffer"]);
                                        objEntity.IsCountryDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsCountryDiffer"])) ? 0 : Convert.ToInt32(reader["IsCountryDiffer"]);
                                        objEntity.IsActiveDiffer = string.IsNullOrEmpty(Convert.ToString(reader["IsActiveDiffer"])) ? 0 : Convert.ToInt32(reader["IsActiveDiffer"]);
                                        lstEntity.Add(objEntity);
                                    }
                                }
                                customerInfo.lstCustomerContact = lstEntity;
                            }
                        }
                    }
                }
                customerInfo.ReturnId = returnId;
                customerInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                customerInfo.Status = Status.Failed;
                customerInfo.Message = ex.Message;
                throw ex;
            }
            return customerInfo;
        }
        /// <summary>
        /// Database layer method to upodate customer info 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo UpdateCustomerHubspotInfo(CustomerBasicInfo customer)
        {
            CustomerBasicInfo objCustomer = new CustomerBasicInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Customer_UpdateHubspotInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@CompanyName", customer.H_CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyDomainName", customer.H_CompanyDomainName);
                        cmd.Parameters.AddWithValue("@CompanySICCode", customer.H_CompanySICCode);
                        cmd.Parameters.AddWithValue("@CompanyRegistrationNumber", customer.H_CompanyRegistrationNumber);
                        cmd.Parameters.AddWithValue("@CreditRating", customer.H_CreditRating);
                        cmd.Parameters.AddWithValue("@HubspotOwner", customer.H_HubspotOwner);
                        cmd.Parameters.AddWithValue("@IsPublic", customer.H_IsPublic);
                        cmd.Parameters.AddWithValue("@PostCode", customer.H_PostCode);
                        cmd.Parameters.AddWithValue("@StreetAddress1", customer.H_StreetAddress1);
                        cmd.Parameters.AddWithValue("@StreetAddress2", customer.H_StreetAddress2);
                        cmd.Parameters.AddWithValue("@Town", customer.H_Town);
                        cmd.Parameters.AddWithValue("@County", customer.H_County);
                        cmd.Parameters.AddWithValue("@Country", customer.H_Country);
                        cmd.Parameters.AddWithValue("@WebsiteURL", customer.H_WebsiteURL);
                        cmd.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.CustomerId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
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
        /// Database layer method to Check whether customer is already created or not 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo GetCustomerIdbyCompanyId(CustomerBasicInfo customer)
        {
            CustomerBasicInfo objCustomer = new CustomerBasicInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Customer_GetCustomerIdbyCompanyId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", customer.CompanyId);
                        cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomer.CustomerId = Convert.ToInt32(cmd.Parameters["@CustomerId"].Value);
                    }
                    objCustomer.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                objCustomer.Status = Status.Failed;
                objCustomer.Message = ex.Message;
            }

            return objCustomer;
        }
        /// <summary>
        /// Database layer to add multiple contacts for customer 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo BulkInsertContactInfo(CustomerBasicInfo customer, DataTable dataTable)
        {
            CustomerBasicInfo customerBasicInfo = new CustomerBasicInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contact_BulkInsertBasicInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@NewContacts", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_HubspotNewContacts",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                        cmd.ExecuteNonQuery();
                        customerBasicInfo.CustomerId = customer.CustomerId;
                        customerBasicInfo.Status = Status.Success;
                    }
                }

            }
            catch (Exception ex)
            {
                customerBasicInfo.Status = Status.Failed;
                customerBasicInfo.Message = ex.Message;
            }
            return customerBasicInfo;
        }
        /// <summary>
        /// Database layer to get Customer basic info and contacts list 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo GetCustomerAllInfobyCustomerId(CustomerBasicInfo customer)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                List<CustomerContact> lstEntity = new List<CustomerContact>();
                CustomerBasicInfo customerBasicInfo = new CustomerBasicInfo();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Customer_GetAllInfobyCustomerId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", Convert.ToString(customer.CustomerId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerBasicInfo.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                customerBasicInfo.CustomerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerTypeId"])) ? 0 : Convert.ToInt32(reader["CustomerTypeId"]);
                                customerBasicInfo.CompanyId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyId"])) ? 0 : Convert.ToInt32(reader["CompanyId"]);
                                customerBasicInfo.CustomerTypeName = Convert.ToString(reader["CustomerTypeName"]);
                                customerBasicInfo.CustomerStatusId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerStatusId"])) ? 0 : Convert.ToInt32(reader["CustomerStatusId"]);
                                customerBasicInfo.CustomerStatusName = Convert.ToString(reader["CustomerStatusName"]);
                                customerBasicInfo.CompanyName = Convert.ToString(reader["CompanyName"]);
                                customerBasicInfo.CompanyDomainName = Convert.ToString(reader["CompanyDomainName"]);
                                customerBasicInfo.CompanyShortName = Convert.ToString(reader["CompanyShortName"]);
                                customerBasicInfo.CompanySICCode = Convert.ToString(reader["CompanySICCode"]);
                                customerBasicInfo.CompanyRegistrationNumber = Convert.ToString(reader["CompanyRegistrationNumber"]);
                                customerBasicInfo.CreditRating = Convert.ToString(reader["CreditRating"]);
                                customerBasicInfo.HubspotOwner = Convert.ToString(reader["HubspotOwner"]);
                                customerBasicInfo.SectorId = string.IsNullOrEmpty(Convert.ToString(reader["SectorId"])) ? 0 : Convert.ToInt32(reader["SectorId"]);
                                customerBasicInfo.SectorName = Convert.ToString(reader["SectorName"]);
                                customerBasicInfo.IsPublic = string.IsNullOrEmpty(Convert.ToString(reader["IsPublic"])) ? false : Convert.ToBoolean(reader["IsPublic"]);
                                customerBasicInfo.PostCode = Convert.ToString(reader["PostCode"]);
                                customerBasicInfo.StreetAddress1 = Convert.ToString(reader["StreetAddress1"]);
                                customerBasicInfo.StreetAddress2 = Convert.ToString(reader["StreetAddress2"]);
                                customerBasicInfo.Town = Convert.ToString(reader["Town"]);
                                customerBasicInfo.County = Convert.ToString(reader["County"]);
                                customerBasicInfo.Country = Convert.ToString(reader["Country"]);
                                customerBasicInfo.WebsiteURL = Convert.ToString(reader["WebsiteURL"]);
                                customerBasicInfo.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                customerBasicInfo.LastUpdatedBy = Convert.ToString(reader["LastUpdatedBy"]);
                                customerBasicInfo.ModifiedOn = string.IsNullOrEmpty(Convert.ToString(reader["LastModifiedOn"])) ? new DateTime() : Convert.ToDateTime(reader["LastModifiedOn"]);
                                customerBasicInfo.SalesContactId = Convert.ToString(reader["SalesUsers"]);
                                customerBasicInfo.AccountManagerContactId = Convert.ToString(reader["AccountManagementUsers"]);
                                customerBasicInfo.CustomerServiceContactId = Convert.ToString(reader["CustomerServiceUsers"]);
                                customerBasicInfo.FinanceContactId = Convert.ToString(reader["FinanceUsers"]);
                                customerBasicInfo.PendingMobilisationDoc = string.IsNullOrEmpty(Convert.ToString(reader["PendingMobilisationDoc"])) ? 0 : Convert.ToInt32(reader["PendingMobilisationDoc"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                CustomerContact objEntity = new CustomerContact();
                                objEntity.ContactId = string.IsNullOrEmpty(Convert.ToString(reader["ContactId"])) ? 0 : Convert.ToInt32(reader["ContactId"]);
                                objEntity.TypeofContactId = string.IsNullOrEmpty(Convert.ToString(reader["ContactTypeId"])) ? 0 : Convert.ToInt32(reader["ContactTypeId"]);
                                objEntity.ContactTypeName = Convert.ToString(reader["ContactTypeName"]);
                                //objEntity.AccountId = string.IsNullOrEmpty(Convert.ToString(reader["AccontId"])) ? 0 : Convert.ToInt32(reader["AccontId"]);
                                //objEntity.SiteId = string.IsNullOrEmpty(Convert.ToString(reader["SiteId"])) ? 0 : Convert.ToInt32(reader["SiteId"]);
                                //objEntity.GroupId = string.IsNullOrEmpty(Convert.ToString(reader["GroupId"])) ? 0 : Convert.ToInt32(reader["GroupId"]);
                                objEntity.Title = Convert.ToString(reader["Title"]);
                                objEntity.FirstName = Convert.ToString(reader["FirstName"]);
                                objEntity.SurName = Convert.ToString(reader["SurName"]);
                                objEntity.ContactNo = Convert.ToString(reader["ContactNo"]);
                                objEntity.MobileNo = Convert.ToString(reader["MobileNo"]);
                                objEntity.MainEmailAddress = Convert.ToString(reader["MainEmailAddress"]);
                                objEntity.AdditionalEmailAddress = Convert.ToString(reader["AdditionalEmailAddress"]);
                                objEntity.JobTitle = Convert.ToString(reader["JobTitle"]);
                                objEntity.LegalBasisId = string.IsNullOrEmpty(Convert.ToString(reader["LegalBasisId"])) ? 0 : Convert.ToInt32(reader["LegalBasisId"]);
                                objEntity.LegalBasisProcessing = Convert.ToString(reader["LegalBasisProcessing"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objEntity.Town = Convert.ToString(reader["Town"]);
                                objEntity.County = Convert.ToString(reader["County"]);
                                objEntity.Region = Convert.ToString(reader["Region"]);
                                objEntity.Country = Convert.ToString(reader["Country"]);
                                objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.LastUpdatedBy = Convert.ToString(reader["LastUpdatedBy"]);
                                objEntity.ModifiedOn = string.IsNullOrEmpty(Convert.ToString(reader["LastModifiedOn"])) ? new DateTime() : Convert.ToDateTime(reader["LastModifiedOn"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }

                }
                customerInfo.lstCustomerContact = lstEntity;
                customerInfo.customerBasicInfo = customerBasicInfo;
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
        /// Database layer to get customer type list 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo GetCustomerType()
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerType> lstEntity = new List<CustomerType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Customer_GetCustomerType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerType objEntity = new CustomerType();
                                objEntity.CustomerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerTypeId"])) ? 0 : Convert.ToInt32(reader["CustomerTypeId"]);
                                objEntity.CustomerTypeName = Convert.ToString(reader["CustomerTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerType = lstEntity;
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
        ///  Database layer to get contact type list 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo GetCustomerContactType()
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerContactType> lstEntity = new List<CustomerContactType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Customer_GetContactType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerContactType objEntity = new CustomerContactType();
                                objEntity.ContactTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContactTypeId"])) ? 0 : Convert.ToInt32(reader["ContactTypeId"]);
                                objEntity.ContactTypeName = Convert.ToString(reader["ContactTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerContactType = lstEntity;
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
        /// Database layer to get Contact info by Contact Id
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerInfo GetContactInfoByContactId(CustomerContact customerContact)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                List<ContactsAdditionMapping> lstEntity = new List<ContactsAdditionMapping>();
                CustomerContact objCustomerContact = new CustomerContact();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Customer_GetContactInfoByContactId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContactId", customerContact.ContactId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objCustomerContact.ContactId = string.IsNullOrEmpty(Convert.ToString(reader["ContactId"])) ? 0 : Convert.ToInt32(reader["ContactId"]);
                                objCustomerContact.Title = Convert.ToString(reader["Title"]);
                                objCustomerContact.FirstName = Convert.ToString(reader["FirstName"]);
                                objCustomerContact.SurName = Convert.ToString(reader["SurName"]);
                                objCustomerContact.ContactNo = Convert.ToString(reader["ContactNo"]);
                                objCustomerContact.MobileNo = Convert.ToString(reader["MobileNo"]);
                                objCustomerContact.MainEmailAddress = Convert.ToString(reader["MainEmailAddress"]);
                                objCustomerContact.AdditionalEmailAddress = Convert.ToString(reader["AdditionalEmailAddress"]);
                                objCustomerContact.JobTitle = Convert.ToString(reader["JobTitle"]);
                                objCustomerContact.LegalBasisId = string.IsNullOrEmpty(Convert.ToString(reader["LegalBasisId"])) ? 0 : Convert.ToInt32(reader["LegalBasisId"]);
                                objCustomerContact.LegalBasisProcessing = Convert.ToString(reader["LegalBasisProcessing"]);
                                objCustomerContact.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objCustomerContact.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objCustomerContact.Town = Convert.ToString(reader["Town"]);
                                objCustomerContact.County = Convert.ToString(reader["County"]);
                                objCustomerContact.Region = Convert.ToString(reader["Region"]);
                                objCustomerContact.Country = Convert.ToString(reader["Country"]);
                                objCustomerContact.PostCode = Convert.ToString(reader["PostCode"]);
                                objCustomerContact.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ContactsAdditionMapping objEntity = new ContactsAdditionMapping();
                                objEntity.ContactMappingId = string.IsNullOrEmpty(Convert.ToString(reader["ContactMappingId"])) ? 0 : Convert.ToInt32(reader["ContactMappingId"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.ContactTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContactTypeId"])) ? 0 : Convert.ToInt32(reader["ContactTypeId"]);
                                objEntity.ContactTypeName = Convert.ToString(reader["ContactTypeName"]);
                                objEntity.GroupIds = Convert.ToString(reader["GroupIds"]);
                                objEntity.SiteIds = Convert.ToString(reader["SiteIds"]);
                                objEntity.AccountIds = Convert.ToString(reader["AccontIds"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }

                }
                customerInfo.customerContact = objCustomerContact;
                customerInfo.lstContactsAdditionMapping = lstEntity;
                customerInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                customerInfo.Status = Status.Failed;
                customerInfo.Message = ex.Message;
            }

            return customerInfo;
        }
        public CustomerContact CreateUpdateContactBasicInfo(CustomerContact contact, DataTable dataTable)
        {
            CustomerContact objContact = new CustomerContact();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contact_InsertUpdateBasicInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@ContactAdditionalMapping", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_ContactsAdditionMapping",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@CustomerId", contact.CustomerID);
                        cmd.Parameters.AddWithValue("@ContactId", contact.ContactId);
                        cmd.Parameters.AddWithValue("@Title", contact.Title);
                        cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                        cmd.Parameters.AddWithValue("@SurName", contact.SurName);
                        cmd.Parameters.AddWithValue("@ContactNo", contact.ContactNo);
                        cmd.Parameters.AddWithValue("@MobileNo", contact.MobileNo);
                        cmd.Parameters.AddWithValue("@MainEmailAddress", contact.MainEmailAddress);
                        cmd.Parameters.AddWithValue("@AdditionalEmailAddress", contact.AdditionalEmailAddress);
                        cmd.Parameters.AddWithValue("@JobTitle", contact.JobTitle);
                        cmd.Parameters.AddWithValue("@LegalBasisId", contact.LegalBasisId);
                        cmd.Parameters.AddWithValue("@AddressLine1", contact.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", contact.AddressLine2);
                        cmd.Parameters.AddWithValue("@Town", contact.Town);
                        cmd.Parameters.AddWithValue("@County", contact.County);
                        cmd.Parameters.AddWithValue("@Region", contact.Region);
                        cmd.Parameters.AddWithValue("@Country", contact.Country);
                        cmd.Parameters.AddWithValue("@PostCode", contact.PostCode);
                        cmd.Parameters.AddWithValue("@CreatedBy", contact.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", contact.IsActive);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objContact.ContactId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
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
        /// Database layer to delete contact details from customer 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerContact DeleteContactBasicInfo(CustomerContact contact)
        {
            CustomerContact objContact = new CustomerContact();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contact_DeleteCustomerMapping";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", contact.CustomerID);
                        cmd.Parameters.AddWithValue("@ContactIds", contact.ContactIds);
                        cmd.ExecuteNonQuery();
                        objContact.ContactIds = contact.ContactIds;
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
        /// Database layer to bulk update customer contacts 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public CustomerBasicInfo BulkUpdateContactHubspotInfo(CustomerBasicInfo customer, DataTable dataTable)
        {
            CustomerBasicInfo customerBasicInfo = new CustomerBasicInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Contact_BulkUpdateHubspotInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@NewContacts", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_HubspotNewContacts",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                        cmd.ExecuteNonQuery();
                        customerBasicInfo.CustomerId = customer.CustomerId;
                        customerBasicInfo.Status = Status.Success;
                    }
                }

            }
            catch (Exception ex)
            {
                customerBasicInfo.Status = Status.Failed;
                customerBasicInfo.Message = ex.Message;
            }
            return customerBasicInfo;
        }
        /// <summary>
        /// Database layer to get Mobilization deals 
        /// (Modified to support DP 4.3 Customer management)
        /// </summary>
        /// Delivery Point: DP3.2,Dp4.3
        public Company GetMobilizationDeals(CompanyInfo companyInfo)
        {

            Company company = new Company();
            try
            {
                List<Deal> lstEntity = new List<Deal>();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetDealsByStatus]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToString(companyInfo.CompanyId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Deal objEntity = new Deal();
                                objEntity.Did = string.IsNullOrEmpty(Convert.ToString(reader["DId"])) ? 0 : Convert.ToInt32(reader["DId"]);
                                objEntity.DealId = Convert.ToString(reader["DealId"]);
                                objEntity.ContractDuration = string.IsNullOrEmpty(Convert.ToString(reader["ContractDuration"])) ? 0 : Convert.ToInt32(reader["ContractDuration"]);
                                objEntity.ContractStartDate = Convert.ToDateTime(reader["ContractStartDate"]);
                                objEntity.ContractEndDate = Convert.ToDateTime(reader["ContractEndDate"]);
                                objEntity.DealAmount = Convert.ToDecimal(reader["DealAmount"]);
                                objEntity.SalesOwnerId = string.IsNullOrEmpty(Convert.ToString(reader["SalesOwnerId"])) ? 0 : Convert.ToInt32(reader["SalesOwnerId"]);
                                objEntity.DealStatusId = string.IsNullOrEmpty(Convert.ToString(reader["DealStatusId"])) ? 0 : Convert.ToInt32(reader["DealStatusId"]);
                                objEntity.DealStatusName = Convert.ToString(reader["DealStatusName"]);
                                objEntity.SalesOwnerName = Convert.ToString(reader["SalesOwnerName"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                objEntity.SetupStatus = string.IsNullOrEmpty(Convert.ToString(reader["SetupStatus"])) ? 0 : Convert.ToInt32(reader["SetupStatus"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }

                }
                company.lstDeals = lstEntity;
                company.Status = Status.Success;
            }
            catch (Exception ex)
            {
                company.Status = Status.Failed;
                company.Message = ex.Message;
            }

            return company;
        }
        /// <summary>
        /// Database layer to get customer dashboard data 
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetCustomerDashboardOverView(CompanyInfo companyInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerType> lstEntity = new List<CustomerType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_Dashboard_GetOverviewInfo]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", companyInfo.FromDate);
                        cmd.Parameters.AddWithValue("@ToDate", companyInfo.ToDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerInfo.TotalCustomers = string.IsNullOrEmpty(Convert.ToString(reader["Total Customers"])) ? 0 : Convert.ToInt32(reader["Total Customers"]);
                                customerInfo.SetupInProgress = string.IsNullOrEmpty(Convert.ToString(reader["Setup In-Process"])) ? 0 : Convert.ToInt32(reader["Setup In-Process"]);
                                customerInfo.SetupCompleted = string.IsNullOrEmpty(Convert.ToString(reader["Setup Completed"])) ? 0 : Convert.ToInt32(reader["Setup Completed"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                CustomerType objEntity = new CustomerType();
                                objEntity.CustomerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerTypeId"])) ? 0 : Convert.ToInt32(reader["CustomerTypeId"]);
                                objEntity.CustomerTypeName = Convert.ToString(reader["CustomerTypeName"]);
                                objEntity.TotalCustomers = string.IsNullOrEmpty(Convert.ToString(reader["TotalCustomers"])) ? 0 : Convert.ToInt32(reader["TotalCustomers"]);
                                objEntity.Percentage = string.IsNullOrEmpty(Convert.ToString(reader["Percentage"])) ? 0 : Convert.ToDecimal(reader["Percentage"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerType = lstEntity;
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
        /// Database layer to get all customer list
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetAllCustomerList(CompanyInfo companyInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerBasicInfo> lstEntity = new List<CustomerBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetAllCustomerList]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", companyInfo.FromDate);
                        cmd.Parameters.AddWithValue("@ToDate", companyInfo.ToDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerBasicInfo objEntity = new CustomerBasicInfo();
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.CustomerStatusId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerStatusId"])) ? 0 : Convert.ToInt32(reader["CustomerStatusId"]);
                                objEntity.CustomerStatusName = Convert.ToString(reader["CustomerStatusName"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.CustomerTypeName = Convert.ToString(reader["CustomerTypeName"]);
                                objEntity.HubspotOwner = Convert.ToString(reader["HubspotOwner"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerBasicInfo = lstEntity;
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
        ///Database layer to get sector type
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetSectorType()
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<SectorType> lstEntity = new List<SectorType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Customer_GetSectorType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SectorType objEntity = new SectorType();
                                objEntity.SectorId = string.IsNullOrEmpty(Convert.ToString(reader["SectorId"])) ? 0 : Convert.ToInt32(reader["SectorId"]);
                                objEntity.SectorName = Convert.ToString(reader["SectorName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstSectorType = lstEntity;
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

        public CustomerInfo GetLegalBasis()
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<LegalBasis> lstEntity = new List<LegalBasis>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contact_GetLegalBasisMaster]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LegalBasis objEntity = new LegalBasis();
                                objEntity.LegalBasisId = string.IsNullOrEmpty(Convert.ToString(reader["LegalBasisId"])) ? 0 : Convert.ToInt32(reader["LegalBasisId"]);
                                objEntity.Contact_LegalBasisData = Convert.ToString(reader["Contact_LegalBasisData"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstLegalBasis = lstEntity;
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
        /// Database layer to get internal contacts list by  contact type for company details 
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetInternalContactsByType(CustomerContactType customerContactType)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<User> lstEntity = new List<User>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetInternalContactsByType]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InternalContactType", customerContactType.ContactTypeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User objEntity = new User();
                                objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["UserId"])) ? 0 : Convert.ToInt32(reader["UserId"]);
                                objEntity.UserName = Convert.ToString(reader["Name"]);
                                objEntity.EmailAddress = Convert.ToString(reader["Email"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstUser = lstEntity;
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
        /// Database layer method to get company information admin settings data by customer Id
        /// </summary>
        /// <param name="customerBasicInfo"></param>
        /// <returns></returns>
        public CustomerInfo GetAdminSettingsbyCustomerId(CustomerBasicInfo customer)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                CustomerAdminSettings customerAdminSettings = new CustomerAdminSettings();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetAdminSettingsData]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", Convert.ToString(customer.CustomerId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerAdminSettings.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                customerAdminSettings.CAId = string.IsNullOrEmpty(Convert.ToString(reader["CAId"])) ? 0 : Convert.ToInt32(reader["CAId"]);
                                customerAdminSettings.SystemStartDate = string.IsNullOrEmpty(Convert.ToString(reader["SystemStartDate"])) ? new DateTime() : Convert.ToDateTime(reader["SystemStartDate"]);
                                customerAdminSettings.DateReportsAvailablefrom = string.IsNullOrEmpty(Convert.ToString(reader["DateReportsAvailablefrom"])) ? 0 : Convert.ToInt32(reader["DateReportsAvailablefrom"]);
                                customerAdminSettings.DisplayHazOnReports = string.IsNullOrEmpty(Convert.ToString(reader["DisplayHazOnReports"])) ? false : Convert.ToBoolean(reader["DisplayHazOnReports"]);
                                customerAdminSettings.TicketRefRequired = string.IsNullOrEmpty(Convert.ToString(reader["TicketRefRequired"])) ? false : Convert.ToBoolean(reader["TicketRefRequired"]);
                                customerAdminSettings.EndDestination = Convert.ToString(reader["EndDestination"]);
                                customerAdminSettings.FacilityUsage = string.IsNullOrEmpty(Convert.ToString(reader["FacilityUsage"])) ? false : Convert.ToBoolean(reader["FacilityUsage"]);
                                customerAdminSettings.ExactLifts = string.IsNullOrEmpty(Convert.ToString(reader["ExactLifts"])) ? false : Convert.ToBoolean(reader["ExactLifts"]);
                                customerAdminSettings.DOCBackingData = string.IsNullOrEmpty(Convert.ToString(reader["DOCBackingData"])) ? false : Convert.ToBoolean(reader["DOCBackingData"]);
                                customerAdminSettings.ServiceSuccessReportSLA = string.IsNullOrEmpty(Convert.ToString(reader["ServiceSuccessReportSLA"])) ? 0 : Convert.ToDecimal(reader["ServiceSuccessReportSLA"]);
                                customerAdminSettings.WasteCarrierReportSLA = string.IsNullOrEmpty(Convert.ToString(reader["WasteCarrierReportSLA"])) ? 0 : Convert.ToDecimal(reader["WasteCarrierReportSLA"]);
                                customerAdminSettings.LandfieldDiversionReportSLA = string.IsNullOrEmpty(Convert.ToString(reader["LandfieldDiversionReportSLA"])) ? 0 : Convert.ToDecimal(reader["LandfieldDiversionReportSLA"]);
                                customerAdminSettings.CustomerSuccessReportSLA = string.IsNullOrEmpty(Convert.ToString(reader["CustomerSuccessReportSLA"])) ? 0 : Convert.ToDecimal(reader["CustomerSuccessReportSLA"]);
                                customerAdminSettings.CustomField1_IsRequired = string.IsNullOrEmpty(Convert.ToString(reader["CustomField1_IsRequired"])) ? false : Convert.ToBoolean(reader["CustomField1_IsRequired"]);
                                customerAdminSettings.CustomField1_Label = Convert.ToString(reader["CustomField1_Label"]);
                                customerAdminSettings.CustomField2_IsRequired = string.IsNullOrEmpty(Convert.ToString(reader["CustomField2_IsRequired"])) ? false : Convert.ToBoolean(reader["CustomField2_IsRequired"]);
                                customerAdminSettings.CustomField2_Label = Convert.ToString(reader["CustomField2_Label"]);
                                customerAdminSettings.CustomField3_IsRequired = string.IsNullOrEmpty(Convert.ToString(reader["CustomField3_IsRequired"])) ? false : Convert.ToBoolean(reader["CustomField3_IsRequired"]);
                                customerAdminSettings.CustomField3_Label = Convert.ToString(reader["CustomField3_Label"]);
                                customerAdminSettings.CustomField4_IsRequired = string.IsNullOrEmpty(Convert.ToString(reader["CustomField4_IsRequired"])) ? false : Convert.ToBoolean(reader["CustomField4_IsRequired"]);
                                customerAdminSettings.CustomField4_Label = Convert.ToString(reader["CustomField4_Label"]);
                                customerAdminSettings.CustomField5_IsRequired = string.IsNullOrEmpty(Convert.ToString(reader["CustomField5_IsRequired"])) ? false : Convert.ToBoolean(reader["CustomField5_IsRequired"]);
                                customerAdminSettings.CustomField5_Label = Convert.ToString(reader["CustomField5_Label"]);
                                customerAdminSettings.CustomerStatusId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerStatusId"])) ? 0 : Convert.ToInt32(reader["CustomerStatusId"]);
                                customerAdminSettings.CustomerStatusName = Convert.ToString(reader["CustomerStatusName"]);
                            }

                        }
                    }
                }
                customerInfo.customerAdminSettings = customerAdminSettings;
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
        /// Database layer to get customer status type for company information admin settings
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetCustomerStatusType()
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerStatusType> lstEntity = new List<CustomerStatusType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetCustomerStatusType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerStatusType objEntity = new CustomerStatusType();
                                objEntity.CustomerStatusId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerStatusId"])) ? 0 : Convert.ToInt32(reader["CustomerStatusId"]);
                                objEntity.CustomerStatusName = Convert.ToString(reader["CustomerStatusName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerStatusTypes = lstEntity;
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
        /// Database layer to update company information admin settings data for a customer Id
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerAdminSettings CreateUpdateAdminSettingsData(CustomerAdminSettings customerAdminSettings)
        {
            CustomerAdminSettings objCustomerAdminSettings = new CustomerAdminSettings();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_InsertUpdateAdminSettingsData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerAdminSettings.CustomerId);
                        cmd.Parameters.AddWithValue("@SystemStartDate", (customerAdminSettings.SystemStartDate == null || customerAdminSettings.SystemStartDate < SqlDateTime.MinValue.Value) ? SqlDateTime.MinValue.Value : customerAdminSettings.SystemStartDate);
                        cmd.Parameters.AddWithValue("@DateReportsAvailablefrom", customerAdminSettings.DateReportsAvailablefrom);
                        cmd.Parameters.AddWithValue("@DisplayHazOnReports", customerAdminSettings.DisplayHazOnReports);
                        cmd.Parameters.AddWithValue("@TicketRefRequired", customerAdminSettings.TicketRefRequired);
                        cmd.Parameters.AddWithValue("@EndDestination", customerAdminSettings.EndDestination);
                        cmd.Parameters.AddWithValue("@FacilityUsage", customerAdminSettings.FacilityUsage);
                        cmd.Parameters.AddWithValue("@ExactLifts", customerAdminSettings.ExactLifts);
                        cmd.Parameters.AddWithValue("@DOCBackingData", customerAdminSettings.DOCBackingData);
                        cmd.Parameters.AddWithValue("@ServiceSuccessReportSLA", customerAdminSettings.ServiceSuccessReportSLA);
                        cmd.Parameters.AddWithValue("@WasteCarrierReportSLA", customerAdminSettings.WasteCarrierReportSLA);
                        cmd.Parameters.AddWithValue("@LandfieldDiversionReportSLA", customerAdminSettings.LandfieldDiversionReportSLA);
                        cmd.Parameters.AddWithValue("@CustomerSuccessReportSLA", customerAdminSettings.CustomerSuccessReportSLA);
                        cmd.Parameters.AddWithValue("@CustomField1_IsRequired", customerAdminSettings.CustomField1_IsRequired);
                        cmd.Parameters.AddWithValue("@CustomField1_Label", customerAdminSettings.CustomField1_Label);
                        cmd.Parameters.AddWithValue("@CustomField2_IsRequired", customerAdminSettings.CustomField2_IsRequired);
                        cmd.Parameters.AddWithValue("@CustomField2_Label", customerAdminSettings.CustomField2_Label);
                        cmd.Parameters.AddWithValue("@CustomField3_IsRequired", customerAdminSettings.CustomField3_IsRequired);
                        cmd.Parameters.AddWithValue("@CustomField3_Label", customerAdminSettings.CustomField3_Label);
                        cmd.Parameters.AddWithValue("@CustomField4_IsRequired", customerAdminSettings.CustomField4_IsRequired);
                        cmd.Parameters.AddWithValue("@CustomField4_Label", customerAdminSettings.CustomField4_Label);
                        cmd.Parameters.AddWithValue("@CustomField5_IsRequired", customerAdminSettings.CustomField5_IsRequired);
                        cmd.Parameters.AddWithValue("@CustomField5_Label", customerAdminSettings.CustomField5_Label);
                        cmd.Parameters.AddWithValue("@CustomerStatusId", customerAdminSettings.CustomerStatusId);
                        cmd.Parameters.AddWithValue("@CreatedBy", customerAdminSettings.CreatedBy);
                        cmd.ExecuteNonQuery();
                        objCustomerAdminSettings.CustomerId = customerAdminSettings.CustomerId;
                    }
                }
                objCustomerAdminSettings.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomerAdminSettings.Status = Status.Failed;
                objCustomerAdminSettings.Message = ex.Message;
                throw ex;
            }
            return objCustomerAdminSettings;
        }
        /// <summary>
        ///Database layer to get company information comments data by customer Id
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerInfo GetCommentsDatabyCustomerId(CustomerBasicInfo customer)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                CustomerComments customerComments = new CustomerComments();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetCommentsData]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", Convert.ToString(customer.CustomerId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerComments.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                customerComments.CusCommentId = string.IsNullOrEmpty(Convert.ToString(reader["CusCommentId"])) ? 0 : Convert.ToInt32(reader["CusCommentId"]);
                                customerComments.GeneralComment = Convert.ToString(reader["GeneralComment"]);
                                customerComments.InvoicingComment = Convert.ToString(reader["InvoicingComment"]);
                                customerComments.ServiceComment = Convert.ToString(reader["ServiceComment"]);
                            }
                        }
                    }
                }
                customerInfo.customerComments = customerComments;
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
        /// Database layer to get company information comments data for customer Id
        /// </summary>
        /// Delivery Point: Dp4.3
        public CustomerComments CreateUpdateCommentsData(CustomerComments customerComments)
        {
            CustomerComments objCustomerComments = new CustomerComments();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_InsertUpdateCommentsData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerComments.CustomerId);
                        cmd.Parameters.AddWithValue("@GeneralComment", customerComments.GeneralComment);
                        cmd.Parameters.AddWithValue("@InvoicingComment", customerComments.InvoicingComment);
                        cmd.Parameters.AddWithValue("@ServiceComment", customerComments.ServiceComment);
                        cmd.Parameters.AddWithValue("@CreatedBy", customerComments.CreatedBy);
                        cmd.ExecuteNonQuery();
                        objCustomerComments.CustomerId = customerComments.CustomerId;
                    }
                }
                objCustomerComments.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomerComments.Status = Status.Failed;
                objCustomerComments.Message = ex.Message;
                throw ex;
            }
            return objCustomerComments;
        }

        public CustomerInfo GetActiveAccountsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<AccountInfo> lstEntity = new List<AccountInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetActiveAccountsByCustomer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerBasicInfo.CustomerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AccountInfo objEntity = new AccountInfo();
                                objEntity.AccountId = string.IsNullOrEmpty(Convert.ToString(reader["AccountId"])) ? 0 : Convert.ToInt32(reader["AccountId"]);
                                objEntity.CustomerAccount = Convert.ToString(reader["CustomerAccount"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstAccountInfos = lstEntity;
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

        public CustomerInfo GetActiveGroupsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerGroupInfo> lstEntity = new List<CustomerGroupInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetActiveGroupsByCustomer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerBasicInfo.CustomerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerGroupInfo objEntity = new CustomerGroupInfo();
                                objEntity.Customer_GroupId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_GroupId"])) ? 0 : Convert.ToInt32(reader["Customer_GroupId"]);
                                objEntity.GroupName = Convert.ToString(reader["GroupName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerGroupInfos = lstEntity;
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

        public CustomerInfo GetActiveSitesByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerSite> lstEntity = new List<CustomerSite>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetActiveSitesByCustomer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerBasicInfo.CustomerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSite objEntity = new CustomerSite();
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.Sites = Convert.ToString(reader["Sites"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerSites = lstEntity;
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

        public CustomerInfo GetAccountsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<AccountInfo> lstEntity = new List<AccountInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetAccountsByCustomer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerBasicInfo.CustomerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AccountInfo objEntity = new AccountInfo();
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.AccountId = string.IsNullOrEmpty(Convert.ToString(reader["AccountId"])) ? 0 : Convert.ToInt32(reader["AccountId"]);
                                objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                                objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                                objEntity.AccountDescription = Convert.ToString(reader["AccountDescription"]);
                                objEntity.PaymentType = Convert.ToString(reader["PaymentType"]);
                                objEntity.DOCSendingPreferences = Convert.ToString(reader["DOCSendingPreferences"]);
                                objEntity.IsUnScheduledServiceIncluded = string.IsNullOrEmpty(Convert.ToString(reader["IsUnScheduledServiceIncluded"])) ? false : Convert.ToBoolean(reader["IsUnScheduledServiceIncluded"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstAccountInfos = lstEntity;
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

        public AccountInfo CreateUpdateAccountsData(AccountInfo accountInfo)
        {
            AccountInfo objAccountInfo = new AccountInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_InsertUpdateAccountsData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", accountInfo.CustomerId);
                        cmd.Parameters.AddWithValue("@AccountId", accountInfo.AccountId);
                        cmd.Parameters.AddWithValue("@AccountName", accountInfo.AccountName);
                        cmd.Parameters.AddWithValue("@AccountNumber", accountInfo.AccountNumber);
                        cmd.Parameters.AddWithValue("@AccountDescription", accountInfo.AccountDescription);
                        cmd.Parameters.AddWithValue("@PaymentType", accountInfo.PaymentType);
                        cmd.Parameters.AddWithValue("@DOCSendingPreferences", accountInfo.DOCSendingPreferences);
                        cmd.Parameters.AddWithValue("@IsUnScheduledServiceIncluded", accountInfo.IsUnScheduledServiceIncluded);
                        cmd.Parameters.AddWithValue("@CreatedBy", accountInfo.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", accountInfo.IsActive);
                        cmd.ExecuteNonQuery();
                        objAccountInfo.CustomerId = accountInfo.CustomerId;
                    }
                }
                objAccountInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objAccountInfo.Status = Status.Failed;
                objAccountInfo.Message = ex.Message;
                throw ex;
            }
            return objAccountInfo;
        }
        public AccountInfo DeleteAccountsInfo(AccountInfo accountInfo)
        {
            AccountInfo objAccountInfo = new AccountInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Customer_DeleteAccountsinfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", accountInfo.CustomerId);
                        cmd.Parameters.AddWithValue("@AccountIds", accountInfo.AccountIds);
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objAccountInfo.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                objAccountInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                }
                objAccountInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objAccountInfo.Status = Status.Failed;
                objAccountInfo.Message = ex.Message;
                throw ex;
            }
            return objAccountInfo;
        }

        public CustomerInfo GetAllSitesByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerSite> lstEntity = new List<CustomerSite>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetAllSitesByCustomer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerBasicInfo.CustomerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSite objEntity = new CustomerSite();
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.AccountId = string.IsNullOrEmpty(Convert.ToString(reader["AccountId"])) ? 0 : Convert.ToInt32(reader["AccountId"]);
                                objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                                objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                                objEntity.GroupIds = Convert.ToString(reader["GroupIds"]);
                                objEntity.GroupName = Convert.ToString(reader["GroupName"]);
                                objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objEntity.Town = Convert.ToString(reader["Town"]);
                                objEntity.County = Convert.ToString(reader["County"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.AccessComments = Convert.ToString(reader["AccessComments"]);
                                objEntity.Site_SicCode = Convert.ToString(reader["Site_SicCode"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerSites = lstEntity;
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

        public CustomerSite CreateUpdateSiteInfo(CustomerSite customerSite)
        {
            CustomerSite objCustomerSite = new CustomerSite();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_InsertUpdateSiteInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Customer_SiteId", customerSite.Customer_SiteId);
                        cmd.Parameters.AddWithValue("@AccountId", customerSite.AccountId);
                        cmd.Parameters.AddWithValue("@GroupIds", customerSite.GroupIds);
                        cmd.Parameters.AddWithValue("@SiteCode", customerSite.SiteCode);
                        cmd.Parameters.AddWithValue("@SiteName", customerSite.SiteName);
                        cmd.Parameters.AddWithValue("@AddressLine1", customerSite.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", customerSite.AddressLine2);
                        cmd.Parameters.AddWithValue("@County", customerSite.County);
                        cmd.Parameters.AddWithValue("@Town", customerSite.Town);
                        cmd.Parameters.AddWithValue("@Postcode", customerSite.Postcode);
                        //cmd.Parameters.AddWithValue("@Region", customerSite.Region);
                        //cmd.Parameters.AddWithValue("@RegionId", customerSite.RegionId);
                        //cmd.Parameters.AddWithValue("@Country", customerSite.Country);
                        cmd.Parameters.AddWithValue("@AccessComments", customerSite.AccessComments);
                        cmd.Parameters.AddWithValue("@Site_SicCode", customerSite.Site_SicCode);
                        cmd.Parameters.AddWithValue("@CreatedBy", customerSite.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", customerSite.IsActive);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomerSite.Customer_SiteId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objCustomerSite.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomerSite.Status = Status.Failed;
                objCustomerSite.Message = ex.Message;
                throw ex;
            }
            return objCustomerSite;
        }

        public CustomerInfo GetAllGroupsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerGroupInfo> lstEntity = new List<CustomerGroupInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetAllGroupsByCustomer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerBasicInfo.CustomerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerGroupInfo objEntity = new CustomerGroupInfo();
                                objEntity.Customer_GroupId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_GroupId"])) ? 0 : Convert.ToInt32(reader["Customer_GroupId"]);
                                objEntity.GroupTypeIds = Convert.ToString(reader["GroupTypeId"]);
                                objEntity.GroupTypeName = Convert.ToString(reader["GroupTypeName"]);
                                objEntity.AccountIds = Convert.ToString(reader["AccountIds"]);
                                objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                                objEntity.GroupName = Convert.ToString(reader["GroupName"]);
                                objEntity.InvoiceStartDate = string.IsNullOrEmpty(Convert.ToString(reader["InvoiceStartDate"])) ? new DateTime() : Convert.ToDateTime(reader["InvoiceStartDate"]);
                                objEntity.MonthlyPaymentId = string.IsNullOrEmpty(Convert.ToString(reader["MonthlyPaymentId"])) ? 0 : Convert.ToInt32(reader["MonthlyPaymentId"]);
                                objEntity.MonthlyPaymentTypeName = Convert.ToString(reader["MonthlyPaymentTypeName"]);
                                objEntity.GroupNotes = Convert.ToString(reader["GroupNotes"]);
                                objEntity.InvoicingNotes = Convert.ToString(reader["InvoicingNotes"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerGroupInfos = lstEntity;
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

        public CustomerGroupInfo CreateUpdateGroupInfo(CustomerGroupInfo customerGroupInfo)
        {
            CustomerGroupInfo objCustomerGroupInfo = new CustomerGroupInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_InsertUpdateGroupInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Customer_GroupId", customerGroupInfo.Customer_GroupId);
                        cmd.Parameters.AddWithValue("@CustomerId", customerGroupInfo.CustomerId);
                        cmd.Parameters.AddWithValue("@AccountIds", customerGroupInfo.AccountIds);
                        cmd.Parameters.AddWithValue("@GroupTypeIds", customerGroupInfo.GroupTypeIds);
                        cmd.Parameters.AddWithValue("@GroupName", customerGroupInfo.GroupName);
                        cmd.Parameters.AddWithValue("@InvoiceStartDate", (customerGroupInfo.InvoiceStartDate == null || customerGroupInfo.InvoiceStartDate == new DateTime()) ? SqlDateTime.MaxValue.Value.AddDays(-1) : customerGroupInfo.InvoiceStartDate);
                        cmd.Parameters.AddWithValue("@MonthlyPaymentId", customerGroupInfo.MonthlyPaymentId);
                        cmd.Parameters.AddWithValue("@GroupNotes", customerGroupInfo.GroupNotes);
                        cmd.Parameters.AddWithValue("@InvoicingNotes", customerGroupInfo.InvoicingNotes);
                        cmd.Parameters.AddWithValue("@CreatedBy", customerGroupInfo.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", customerGroupInfo.IsActive);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomerGroupInfo.Customer_GroupId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objCustomerGroupInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomerGroupInfo.Status = Status.Failed;
                objCustomerGroupInfo.Message = ex.Message;
                throw ex;
            }
            return objCustomerGroupInfo;
        }

        public CustomerInfo GetCustomerGroupType()
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<GroupType> lstEntity = new List<GroupType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetCustomerGroupType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GroupType objEntity = new GroupType();
                                objEntity.GroupTypeId = string.IsNullOrEmpty(Convert.ToString(reader["GroupTypeId"])) ? 0 : Convert.ToInt32(reader["GroupTypeId"]);
                                objEntity.GroupTypeName = Convert.ToString(reader["GroupTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstGroupType = lstEntity;
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

        public CustomerInfo GetMonthlyPaymentType()
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<MonthlyPaymentType> lstEntity = new List<MonthlyPaymentType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetMonthlyPaymentType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MonthlyPaymentType objEntity = new MonthlyPaymentType();
                                objEntity.MonthlyPaymentTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MonthlyPaymentTypeId"])) ? 0 : Convert.ToInt32(reader["MonthlyPaymentTypeId"]);
                                objEntity.MonthlyPaymentTypeName = Convert.ToString(reader["MonthlyPaymentTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstMonthlyPaymentType = lstEntity;
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

        public CustomerInfo GetSitesByAccounts(AccountInfo accountInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerSite> lstEntity = new List<CustomerSite>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetSitesByAccounts]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountId", accountInfo.AccountId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSite objEntity = new CustomerSite();
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerSites = lstEntity;
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

        public CustomerInfo GetSitesByGroups(CustomerGroupInfo customerGroupInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerSite> lstEntity = new List<CustomerSite>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetSitesByGroups]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GroupId", customerGroupInfo.Customer_GroupId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSite objEntity = new CustomerSite();
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerSites = lstEntity;
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

        public CustomerInfo DeleteGroupByGroupId(CustomerGroupInfo customerGroupInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_DeleteGroupByGroupId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GroupId", customerGroupInfo.Customer_GroupId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerInfo.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                customerInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                }
                customerInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                customerInfo.Status = Status.Failed;
                customerInfo.Message = ex.Message;
                throw ex;
            }
            return customerInfo;
        }

        public CustomerInfo BulkDeleteGroup(CustomerGroupInfo customerGroupInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            int IsDeleted = 1;
            try
            {
                foreach (var GroupId in customerGroupInfo.GroupIds.Split(','))
                {
                    using (var conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SP_Customer_DeleteGroupByGroupId";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@GroupId", GroupId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    IsDeleted = Convert.ToInt32(reader["ReturnId"])==0?0: IsDeleted;
                                }
                            }
                        }
                    }
                }
                customerInfo.ReturnId = IsDeleted;
                if (IsDeleted == 1)
                {
                    customerInfo.Message = "Success! Groups are deleted and cannot be recovered";
                }
                else
                {
                    customerInfo.Message = "Warning! Some groups cannot be deleted. ";
                }
                customerInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                customerInfo.Status = Status.Failed;
                customerInfo.Message = ex.Message;
                throw ex;
            }
            return customerInfo;
        }
        public CustomerGroupInfo DeleteSiteMappingByGroup(CustomerGroupInfo customerGroupInfo)
        {
            CustomerGroupInfo objCustomerGroupInfo = new CustomerGroupInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_DeleteSiteMappingByGroup";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GroupId", customerGroupInfo.Customer_GroupId);
                        cmd.Parameters.AddWithValue("@SiteIds", customerGroupInfo.SiteIds);
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objCustomerGroupInfo.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                objCustomerGroupInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                }
                objCustomerGroupInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomerGroupInfo.Status = Status.Failed;
                objCustomerGroupInfo.Message = ex.Message;
                throw ex;
            }
            return objCustomerGroupInfo;
        }
        public CustomerInfo DeleteSiteBySiteId(CustomerSite customerSite)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_DeleteSiteBySiteId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SiteId", customerSite.Customer_SiteId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerInfo.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                customerInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                }
                customerInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                customerInfo.Status = Status.Failed;
                customerInfo.Message = ex.Message;
                throw ex;
            }
            return customerInfo;
        }

        public CustomerInfo BulkDeleteSite(CustomerSite customerSite)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            int IsDeleted = 1;
            try
            {
                foreach (var Customer_SiteId in customerSite.SiteIds.Split(','))
                {
                    using (var conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SP_Customer_DeleteSiteBySiteId";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SiteId", Customer_SiteId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    IsDeleted = Convert.ToInt32(reader["ReturnId"]) == 0 ? 0 : IsDeleted;
                                }
                            }
                        }
                    }
                }
                customerInfo.ReturnId = IsDeleted;
                if (IsDeleted == 1)
                {
                    customerInfo.Message = "Success! Sites are deleted and cannot be recovered";
                }
                else
                {
                    customerInfo.Message = "Warning! Some sites cannot be deleted. ";
                }

                customerInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                customerInfo.Status = Status.Failed;
                customerInfo.Message = ex.Message;
                throw ex;
            }
            return customerInfo;
        }

        public CustomerInfo GetDocumentTypes()
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<DocumentType> lstEntity = new List<DocumentType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetCustomerDocumentType]";
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

        public CustomerInfo GetAllDocumentsByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<DocumentInfo> lstEntity = new List<DocumentInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetAllDocumentsByCustomer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", customerBasicInfo.CustomerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DocumentInfo objEntity = new DocumentInfo();
                                objEntity.Customer_DocumentId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_DocumentId"])) ? 0 : Convert.ToInt32(reader["Customer_DocumentId"]);
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
                    customerInfo.lstDocumentInfos = lstEntity;
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
                        cmd.CommandText = "SP_Customer_InsertUpdateDocumentInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", documentInfo.CustomerId);
                        cmd.Parameters.AddWithValue("@Customer_DocumentId", documentInfo.Customer_DocumentId);
                        cmd.Parameters.AddWithValue("@SharePointId", documentInfo.SharePointId);
                        cmd.Parameters.AddWithValue("@DocumentTypeId", documentInfo.DocumentTypeId);
                        cmd.Parameters.AddWithValue("@DocumentName", documentInfo.DocumentName);
                        cmd.Parameters.AddWithValue("@DocDescription", documentInfo.DocDescription);
                        cmd.Parameters.AddWithValue("@ExpiryDate", documentInfo.ExpiryDate);
                        cmd.Parameters.AddWithValue("@FileReference", documentInfo.FileReference);
                        cmd.Parameters.AddWithValue("@CreatedBy", documentInfo.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", documentInfo.IsActive);
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

        public CustomerGroupInfo CreateUpdateSiteMappingByGroup(CustomerGroupInfo customerGroupInfo)
        {
            CustomerGroupInfo objCustomerGroupInfo = new CustomerGroupInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_InsertUpdateSiteMappingByGroup";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GroupId", customerGroupInfo.Customer_GroupId);
                        cmd.Parameters.AddWithValue("@SiteIds", customerGroupInfo.SiteIds);
                        cmd.Parameters.AddWithValue("@CreatedBy", customerGroupInfo.CreatedBy);
                        cmd.ExecuteNonQuery();
                        objCustomerGroupInfo.Customer_GroupId = customerGroupInfo.Customer_GroupId;
                    }
                }
                objCustomerGroupInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomerGroupInfo.Status = Status.Failed;
                objCustomerGroupInfo.Message = ex.Message;
                throw ex;
            }
            return objCustomerGroupInfo;
        }

        /// <summary>
        /// Database layer method to get pricing matrix list by CustomerId
        /// </summary>
        /// Delivery Point: DP4.8
        public CustomerInfo GetPricingMatrixListByCustomerId(CustomerBasicInfo customer)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<PricingMatrixSetup> lstEntity = new List<PricingMatrixSetup>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetPricingMatrixListByCustomerId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", Convert.ToString(customer.CustomerId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PricingMatrixSetup objEntity = new PricingMatrixSetup();
                                objEntity.MatrixId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixId"])) ? 0 : Convert.ToInt32(reader["MatrixId"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                                objEntity.StartDate = string.IsNullOrEmpty(Convert.ToString(reader["StartDate"])) ? new DateTime() : Convert.ToDateTime(reader["StartDate"]);
                                objEntity.EndDate = string.IsNullOrEmpty(Convert.ToString(reader["EndDate"])) ? new DateTime() : Convert.ToDateTime(reader["EndDate"]);
                                objEntity.CanDelete = string.IsNullOrEmpty(Convert.ToString(reader["CanDelete"])) ? 0 : Convert.ToInt32(reader["CanDelete"]);
                                objEntity.ActionHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["ActionHeaderId"])) ? 0 : Convert.ToInt32(reader["ActionHeaderId"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstpricingMatrices = lstEntity;
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

        public CustomerServiceComments UpdateServiceCommentStatus(CustomerServiceComments customerServiceComments)
        {
            CustomerServiceComments objCustomerServiceComments = new CustomerServiceComments();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Customer_UpdateServiceCommentStatus";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CusServiceCommentIds", customerServiceComments.CusServiceCommentIds);
                        cmd.Parameters.AddWithValue("@CreatedBy", customerServiceComments.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", customerServiceComments.IsActive);
                        cmd.ExecuteNonQuery();
                        objCustomerServiceComments.CusServiceCommentIds = customerServiceComments.CusServiceCommentIds;
                    }
                }
                objCustomerServiceComments.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomerServiceComments.Status = Status.Failed;
                objCustomerServiceComments.Message = ex.Message;
                throw ex;
            }
            return objCustomerServiceComments;
        }
        public CustomerInfo GetServiceCommentsData(CustomerServiceComments customerServiceComments)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerServiceComments> lstEntity = new List<CustomerServiceComments>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Customer_GetServiceCommentsData]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", Convert.ToString(customerServiceComments.CustomerId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerServiceComments objEntity = new CustomerServiceComments();
                                objEntity.CusServiceCommentId = string.IsNullOrEmpty(Convert.ToString(reader["CusServiceCommentId"])) ? 0 : Convert.ToInt32(reader["CusServiceCommentId"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.Comment = Convert.ToString(reader["Comment"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.CommentedOn = string.IsNullOrEmpty(Convert.ToString(reader["CommentedOn"])) ? (DateTime?)null : Convert.ToDateTime(reader["CommentedOn"]);
                                objEntity.ArchivedOn = string.IsNullOrEmpty(Convert.ToString(reader["ArchivedOn"])) ? (DateTime?)null : Convert.ToDateTime(reader["ArchivedOn"]);
                                objEntity.CommentedBy = Convert.ToString(reader["CommentedBy"]);
                                objEntity.ArchivedBy = Convert.ToString(reader["ArchivedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    customerInfo.lstCustomerServiceComments = lstEntity;
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
    }
}
