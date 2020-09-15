using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;


namespace UKWSL.WMES.Repositories.ContractorWeight
{
    public class ContractorWeightRepository : IContractorWeightRepository
    {
        private string _connectionString;
        public ContractorWeightRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// Database layer method to Get All Service Weights by ContractorId
        /// </summary>
        /// Delivery Point: DP4.9
        public ContractorWeightInfo GetAllServiceWeightsbyContractorId(ServiceJobDetails serviceJobDetails)
        {
            ContractorWeightInfo contractorInfo = new ContractorWeightInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceJobDetails> lstEntity = new List<ServiceJobDetails>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_ContractorWeight_GetAllServiceWeightsbyContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(serviceJobDetails.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceJobDetails objEntity = new ServiceJobDetails();
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objEntity.ServiceStatusName = Convert.ToString(reader["ServiceStatusName"]);
                                objEntity.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                                objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                                objEntity.ActualWeight = string.IsNullOrEmpty(Convert.ToString(reader["ActualWeight"])) ? 0 : Convert.ToInt32(reader["ActualWeight"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.WasteType_Name = Convert.ToString(reader["WasteType_Name"]);
                                objEntity.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.ContainerType_Name = Convert.ToString(reader["ContainerType_Name"]);
                                objEntity.ContainerSize_Name = Convert.ToString(reader["ContainerSize_Name"]);
                                objEntity.AWCount = string.IsNullOrEmpty(Convert.ToString(reader["AWCount"])) ? 0 : Convert.ToInt32(reader["AWCount"]);
                                objEntity.Confirmation_ActualDateofDelivery = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualDateofDelivery"])) ? new DateTime() : Convert.ToDateTime(reader["Confirmation_ActualDateofDelivery"]);
                                objEntity.Confirmation_ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["Confirmation_ActualCollectionDate"]);
                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstServiceJobDetails = lstEntity;

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
        /// Database layer method to Get All Service Weights by ContractorId
        /// </summary>
        /// Delivery Point: DP4.9
        public ContractorWeightInfo GetAllCustomersbyContractorId(CustomerBasicInfo customerBasicInfo)
        {
            ContractorWeightInfo contractorInfo = new ContractorWeightInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerBasicInfo> lstEntity = new List<CustomerBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_ContractorWeight_GetAllCustomersbyContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(customerBasicInfo.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerBasicInfo objEntity = new CustomerBasicInfo();
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstCustomerBasicInfos = lstEntity;

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
        /// Database layer method to Get All Service Sites by ContractorId
        /// </summary>
        /// Delivery Point: DP4.9
        public ContractorWeightInfo GetAllServiceSitesbyContractorId(ServiceSite serviceSite)
        {
            ContractorWeightInfo contractorInfo = new ContractorWeightInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceSite> lstEntity = new List<ServiceSite>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_ContractorWeight_GetAllServiceSitessbyContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(serviceSite.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceSite objEntity = new ServiceSite();
                                //objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.Customer_SiteId = string.IsNullOrEmpty(Convert.ToString(reader["Customer_SiteId"])) ? 0 : Convert.ToInt32(reader["Customer_SiteId"]);
                                objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.Address = Convert.ToString(reader["Address"]);
                                objEntity.TotalServices = string.IsNullOrEmpty(Convert.ToString(reader["TotalServices"])) ? 0 : Convert.ToInt32(reader["TotalServices"]);
                                objEntity.ActiveServices = string.IsNullOrEmpty(Convert.ToString(reader["ActiveServices"])) ? 0 : Convert.ToInt32(reader["ActiveServices"]);
                                lstEntity.Add(objEntity);
                            }

                        }
                    }
                    contractorInfo.lstServiceSite = lstEntity;

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
        /// Database layer method to get all Actual Weights by Job Id and ServiceType Id
        /// </summary>
        /// Delivery Point: DP4.9
        public ContractorWeightInfo GetActualWeightDetailsByJobId(ServiceBasicInfo serviceBasicInfo)
        {
            ContractorWeightInfo contractorWeightInfo = new ContractorWeightInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceJobDetails> lstEntity = new List<ServiceJobDetails>();
                    ServiceJobDetails serviceJob = new ServiceJobDetails();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Service_GetActualWeightDetailsByJobId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JobId", Convert.ToString(serviceBasicInfo.JobId));
                        cmd.Parameters.AddWithValue("@ServiceTypeId", Convert.ToString(serviceBasicInfo.ServiceTypeId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                serviceJob.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                serviceJob.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                serviceJob.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);

                                serviceJob.CustomerName = Convert.ToString(reader["CustomerName"]);
                                serviceJob.SiteName = Convert.ToString(reader["SiteName"]);
                                serviceJob.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                serviceJob.AccountName = Convert.ToString(reader["AccountName"]);
                                serviceJob.Postcode = Convert.ToString(reader["Postcode"]);
                                serviceJob.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]); 
                                serviceJob.ServiceStatusName = Convert.ToString(reader["ServiceStatusName"]);
                                serviceJob.WasteType_Name = Convert.ToString(reader["WasteType_Name"]);
                                serviceJob.MaterialType_Name = Convert.ToString(reader["MaterialType_Name"]);
                                serviceJob.ContainerSize_Name = Convert.ToString(reader["ContainerSize_Name"]);
                                serviceJob.ContainerType_Name = Convert.ToString(reader["ContainerType_Name"]);
                                serviceJob.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? (int?)null : Convert.ToInt32(reader["Quantity"]); 
                                serviceJob.FrequencyTypeId = Convert.ToInt32(reader["FrequencyTypeId"]);
                                serviceJob.FrequencyType_Name = Convert.ToString(reader["FrequencyType_Name"]);
                                serviceJob.WeightType = Convert.ToString(reader["WeightType"]);
                                serviceJob.WeightUsage = Convert.ToString(reader["WeightUsage"]);
                                serviceJob.AssumedContainerWeight = string.IsNullOrEmpty(Convert.ToString(reader["AssumedContainerWeight"])) ? 0 : Convert.ToDecimal(reader["AssumedContainerWeight"]);
                                serviceJob.Confirmation_ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["Confirmation_ActualCollectionDate"]);


                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                ServiceJobDetails objEntity = new ServiceJobDetails();
                                objEntity.CollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["CollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["CollectionDate"]);
                                objEntity.Confirmation_ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["Confirmation_ActualCollectionDate"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objEntity.AWId = string.IsNullOrEmpty(Convert.ToString(reader["AWId"])) ? 0 : Convert.ToInt32(reader["AWId"]);
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                objEntity.ActualWeight = string.IsNullOrEmpty(Convert.ToString(reader["ActualWeight"])) ? 0 : Convert.ToDecimal(reader["ActualWeight"]);
                                objEntity.Comment = Convert.ToString(reader["Comment"]);
                                objEntity.ConfirmationName = Convert.ToString(reader["ConfirmationName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorWeightInfo.lstServiceJobDetails = lstEntity;
                    contractorWeightInfo.serviceJobDetails = serviceJob;
                }
                contractorWeightInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorWeightInfo.Status = Status.Failed;
                contractorWeightInfo.Message = ex.Message;
            }
            return contractorWeightInfo;
        }

        /// <summary>
        /// Database layer method to create and update ServiceActualWeight
        /// </summary>
        /// Delivery Point: DP4.9
        public ServiceJobDetails CreateUpdateServiceActualWeight(ServiceJobDetails serviceJobDetails)
        {
            ServiceJobDetails objService = new ServiceJobDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[SP_Service_InsertUpdateServiceActualWeight]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", serviceJobDetails.ContractorId);
                        cmd.Parameters.AddWithValue("@JobId", serviceJobDetails.JobId);
                        cmd.Parameters.AddWithValue("@AWId", serviceJobDetails.AWId);
                        cmd.Parameters.AddWithValue("@CollectionDate", serviceJobDetails.Confirmation_ActualCollectionDate);
                        cmd.Parameters.AddWithValue("@ActualWeight", serviceJobDetails.ActualWeight);
                        cmd.Parameters.AddWithValue("@Comment", serviceJobDetails.Comment);
                        cmd.Parameters.AddWithValue("@ConfirmationName", serviceJobDetails.ConfirmationName);
                        cmd.Parameters.AddWithValue("@CreatedBy", serviceJobDetails.CreatedBy);
                        cmd.Parameters.Add("@ReturnId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objService.AWId = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                    }
                }
                objService.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objService.Status = Status.Failed;
                objService.Message = ex.Message;
                throw ex;
            }
            return objService;
        }

        /// <summary>
        /// Database layer method to Upload Import Actual weight CSV Raw data
        /// </summary>
        /// Delivery Point: DP4.9
        public ContractorWeightInfo UploadImportActualWeightCSVRawData(ContractorWeightInfo contractorWeightInfo, DataTable dataTable)
        {
            ContractorWeightInfo objIAWInfo = new ContractorWeightInfo();
            int _upooadedId = 0;
            List<ImportActualWeight> lstImportActualWeight = new List<ImportActualWeight>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ImportActualWeight_InsertRawData]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@ImportActualWeightData", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_ImportActualWeight",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@ContractorId", contractorWeightInfo.ContractorId);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractorWeightInfo.CreatedBy);
                        cmd.Parameters.Add("@IWId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        _upooadedId = Convert.ToInt32(cmd.Parameters["@IWId"].Value);
                        objIAWInfo.IWId = _upooadedId;
                        objIAWInfo.Status = Status.Success;
                    }

                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "SP_ImportActualWeight_ProcessData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@IWId", objIAWInfo.IWId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        while (reader.Read())
                        {
                            objIAWInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ImportActualWeight objEntity = new ImportActualWeight();
                            objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.SiteAddress = Convert.ToString(reader["SiteAddress"]);
                            objEntity.SiteTown = Convert.ToString(reader["SiteTown"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.ActualWeight = Convert.ToDecimal(reader["ActualWeight"]);
                            objEntity.ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["ActualCollectionDate"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.ContractorQuantityType = Convert.ToString(reader["ContractorQuantityType"]);
                            lstImportActualWeight.Add(objEntity);

                        }
                        objIAWInfo.lstPassedImportActualWeight = lstImportActualWeight;
                        lstImportActualWeight = new List<ImportActualWeight>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ImportActualWeight objEntity = new ImportActualWeight();
                            objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.SiteAddress = Convert.ToString(reader["SiteAddress"]);
                            objEntity.SiteTown = Convert.ToString(reader["SiteTown"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.ActualWeight = Convert.ToDecimal(reader["ActualWeight"]);
                            objEntity.ActualCollectionDate = Convert.ToDateTime(reader["ActualCollectionDate"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.ContractorQuantityType = Convert.ToString(reader["ContractorQuantityType"]);

                            lstImportActualWeight.Add(objEntity);
                        }
                        objIAWInfo.lstFailedImportActualWeight = lstImportActualWeight;
                    }
                }
            }
            catch (Exception ex)
            {
                objIAWInfo.Status = Status.Failed;
                objIAWInfo.Message = ex.Message;
            }
            return objIAWInfo;
        }

        /// <summary>
        /// Database layer to get all Import Actual Weights list
        /// </summary>
        /// Delivery Point: Dp4.19
        public ContractorWeightInfo GetAllImportActualWeights(ImportActualWeight importActualWeight)
        {
            ContractorWeightInfo contractorInfo = new ContractorWeightInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ImportActualWeight> lstEntity = new List<ImportActualWeight>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_ContractorWeight_GetAllImportActualWeights]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ImportActualWeight objEntity = new ImportActualWeight();
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.IWID = string.IsNullOrEmpty(Convert.ToString(reader["IWID"])) ? 0 : Convert.ToInt32(reader["IWID"]);
                                objEntity.CreatedByName = Convert.ToString(reader["CreatedBy"]);
                                objEntity.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                objEntity.UploadStatus = Convert.ToString(reader["UploadStatus"]);
                                objEntity.ReportStatus = Convert.ToString(reader["ReportStatus"]);
                                objEntity.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstImportActualWeight = lstEntity;
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
        /// Database layer method to create and update ImportActualWeight
        /// </summary>
        /// Delivery Point: DP4.9
        public ContractorWeightInfo InsertUploadedImportActualWeightData(ContractorWeightInfo contractorWeightInfo)
        {
            ContractorWeightInfo objEntity = new ContractorWeightInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_ImportActualWeight_BulkUpdateWeights";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IWId", contractorWeightInfo.IWId);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractorWeightInfo.CreatedBy);
                        cmd.ExecuteNonQuery();
                        contractorWeightInfo.ReturnValue = contractorWeightInfo.IWId;
                        contractorWeightInfo.Status = Status.Success;
                    }

                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "SP_ImportActualWeight_ProcessData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@IWId", contractorWeightInfo.IWId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();
                    }
                }
                objEntity.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
            }

            return objEntity;
        }

        /// <summary>
        /// Database layer method to Cancel uploading ImportActualWeight
        /// </summary>
        /// Delivery Point: DP4.9
        public ContractorWeightInfo CancelInsertUploadedImportActualWeightData(ContractorWeightInfo contractorWeightInfo)
        {
            ContractorWeightInfo objEntity = new ContractorWeightInfo();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "[SP_ImportActualWeight_CancelProcess]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IWId", contractorWeightInfo.IWId);
                    cmd.ExecuteNonQuery();
                    contractorWeightInfo.ReturnValue = contractorWeightInfo.IWId;
                    contractorWeightInfo.Status = Status.Success;
                }
            }
            return objEntity;
        }

        /// <summary>
        /// Database layer to get all service Pending Report
        /// </summary>
        /// Delivery Point: Dp4.19
        public ContractorWeightInfo GetAllServicePendingReport(ImportActualWeight importActualWeight)
        {
            ContractorWeightInfo contractorInfo = new ContractorWeightInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ImportActualWeight> lstEntity = new List<ImportActualWeight>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_ContractorWeight_GetAllServicePendingReportbyContractorId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(importActualWeight.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ImportActualWeight objEntity = new ImportActualWeight();
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.IWID = string.IsNullOrEmpty(Convert.ToString(reader["IWID"])) ? 0 : Convert.ToInt32(reader["IWID"]);
                                objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                                objEntity.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                objEntity.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objEntity.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                objEntity.ServiceStatusName = Convert.ToString(reader["ServiceStatusName"]);
                                objEntity.CompanyName = Convert.ToString(reader["CustomerName"]);
                                objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.PostCode = Convert.ToString(reader["Postcode"]);
                                objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.AssumedContainerWeight = string.IsNullOrEmpty(Convert.ToString(reader["AssumedContainerWeight"])) ? 0 : Convert.ToDecimal(reader["AssumedContainerWeight"]);
                                objEntity.ActualWeight = string.IsNullOrEmpty(Convert.ToString(reader["ActualWeight"])) ? 0 : Convert.ToDecimal(reader["ActualWeight"]);
                                objEntity.ContractorQuantityType = Convert.ToString(reader["ContractorQuantityType"]);
                                objEntity.ContrPrice_cost_per_lift = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_cost_per_lift"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_cost_per_lift"]);
                                objEntity.CustPrice_price_per_lift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_price_per_lift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_price_per_lift"]);
                                objEntity.Confirmation_ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["Confirmation_ActualCollectionDate"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstImportActualWeight = lstEntity;
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
        /// Database layer to get all service affected Report
        /// </summary>
        /// Delivery Point: Dp4.19
        public ContractorWeightInfo GetAllServiceAffectedFromImport(ImportActualWeight importActualWeight)
        {
            ContractorWeightInfo contractorInfo = new ContractorWeightInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ImportActualWeight> lstEntity = new List<ImportActualWeight>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[sp_ContractorWeight_GetAllServiceAffectedfromImportbyContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(importActualWeight.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ImportActualWeight objEntity = new ImportActualWeight();
                                objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.IWID = string.IsNullOrEmpty(Convert.ToString(reader["IWID"])) ? 0 : Convert.ToInt32(reader["IWID"]);
                                objEntity.ServiceStatusId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceStatusId"])) ? 0 : Convert.ToInt32(reader["ServiceStatusId"]);
                                objEntity.ServiceTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ServiceTypeId"])) ? 0 : Convert.ToInt32(reader["ServiceTypeId"]);
                                objEntity.ServiceTypeName = Convert.ToString(reader["ServiceTypeName"]);
                                objEntity.CompanyName = Convert.ToString(reader["CustomerName"]);
                                objEntity.AccountName = Convert.ToString(reader["AccountName"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.PostCode = Convert.ToString(reader["Postcode"]);
                                objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objEntity.Confirmation_ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["Confirmation_ActualCollectionDate"]);
                                objEntity.Confirmation_ActualDateofDelivery = string.IsNullOrEmpty(Convert.ToString(reader["Confirmation_ActualDateofDelivery"])) ? new DateTime() : Convert.ToDateTime(reader["Confirmation_ActualDateofDelivery"]);
                                objEntity.AccountNumber = Convert.ToString(reader["AccountNumber"]);
                                objEntity.Address = Convert.ToString(reader["Address"]);
                                objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                                objEntity.VisitsPerWeek = Convert.ToString(reader["VisitsPerWeek"]);
                                objEntity.ActualWeight = string.IsNullOrEmpty(Convert.ToString(reader["ActualWeight"])) ? 0 : Convert.ToDecimal(reader["ActualWeight"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorInfo.lstImportActualWeight = lstEntity;
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
        /// Database layer to get imported weight by Id
        /// </summary>
        /// Delivery Point: Dp4.19
        public ImportActualWeight GetImportedWeightById(ImportActualWeight importActualWeight)
        {
            ImportActualWeight objEntity = new ImportActualWeight();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[sp_ContractorWeight_GetImportedWeightById]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Convert.ToString(importActualWeight.Id));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                                objEntity.JobId = string.IsNullOrEmpty(Convert.ToString(reader["JobId"])) ? 0 : Convert.ToInt32(reader["JobId"]);
                                objEntity.IWID = string.IsNullOrEmpty(Convert.ToString(reader["IWId"])) ? 0 : Convert.ToInt32(reader["IWId"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                                objEntity.SiteAddress = Convert.ToString(reader["SiteAddress"]);
                                objEntity.SiteTown = Convert.ToString(reader["SiteTown"]);
                                objEntity.PostCode = Convert.ToString(reader["Postcode"]);
                                objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objEntity.ContractorQuantityType = Convert.ToString(reader["ContractorQuantityType"]);
                                objEntity.QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["QtyTypeId"])) ? 0 : Convert.ToInt32(reader["QtyTypeId"]);
                                objEntity.ActualCollectionDate = Convert.ToDateTime(reader["ActualCollectionDate"]);
                                objEntity.ActualWeight = string.IsNullOrEmpty(Convert.ToString(reader["ActualWeight"])) ? 0 : Convert.ToDecimal(reader["ActualWeight"]);
                            }
                        }
                    }
                }
                objEntity.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntity.Status = Status.Failed;
                objEntity.Message = ex.Message;
            }
            return objEntity;
        }

        /// <summary>
        /// Database layer method to  update ImportActualWeight by Id
        /// </summary>
        /// Delivery Point: DP4.9
        public ImportActualWeight UpdateImportedWeightById(ImportActualWeight importActualWeight)
        {
            ImportActualWeight objImportActual = new ImportActualWeight();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[sp_ContractorWeight_UpdateImportedWeightById]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IW_DetailsId", importActualWeight.Id);
                        cmd.Parameters.AddWithValue("@IWID", importActualWeight.IWID);
                        cmd.Parameters.AddWithValue("@ContractorPONumber", importActualWeight.ContractorPONumber);
                        cmd.Parameters.AddWithValue("@SiteName", importActualWeight.SiteName);
                        cmd.Parameters.AddWithValue("@SiteAddress", importActualWeight.SiteAddress);
                        cmd.Parameters.AddWithValue("@SiteTown", importActualWeight.SiteTown);
                        cmd.Parameters.AddWithValue("@PostCode", importActualWeight.PostCode);
                       //cmd.Parameters.AddWithValue("@Customer_SiteId", importActualWeight.Customer_SiteId);
                        cmd.Parameters.AddWithValue("@WasteType", importActualWeight.WasteType);
                        cmd.Parameters.AddWithValue("@WasteTypeId", importActualWeight.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialType", importActualWeight.MaterialType);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", importActualWeight.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerType", importActualWeight.ContainerType);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", importActualWeight.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSize", importActualWeight.ContainerSize);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", importActualWeight.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@ActualWeight", importActualWeight.ActualWeight);
                        cmd.Parameters.AddWithValue("@ContractorQuantityType", importActualWeight.ContractorQuantityType);
                        cmd.Parameters.AddWithValue("@QtyTypeId", importActualWeight.QtyTypeId);
                        cmd.Parameters.AddWithValue("@ActualCollectionDate", importActualWeight.ActualCollectionDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", importActualWeight.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objImportActual.Id = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objImportActual.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objImportActual.Status = Status.Failed;
                objImportActual.Message = ex.Message;
                throw ex;
            }
            return objImportActual;
        }

        /// <summary>
        /// Database layer method to Process ImportActualWeight
        /// </summary>
        /// Delivery Point: DP4.9
        public ContractorWeightInfo ProcessImportActualWeight(ContractorWeightInfo contractorWeightInfo)
        {
            ContractorWeightInfo objIAWInfo = new ContractorWeightInfo();
            List<ImportActualWeight> lstImportActualWeight = new List<ImportActualWeight>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "SP_ImportActualWeight_ProcessData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@IWId", contractorWeightInfo.IWId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        while (reader.Read())
                        {
                            objIAWInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ImportActualWeight objEntity = new ImportActualWeight();
                            objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.SiteAddress = Convert.ToString(reader["SiteAddress"]);
                            objEntity.SiteTown = Convert.ToString(reader["SiteTown"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.ActualWeight = Convert.ToDecimal(reader["ActualWeight"]);
                            objEntity.ActualCollectionDate = Convert.ToDateTime(reader["ActualCollectionDate"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.ContractorQuantityType = Convert.ToString(reader["ContractorQuantityType"]);
                            lstImportActualWeight.Add(objEntity);

                        }
                        objIAWInfo.lstPassedImportActualWeight = lstImportActualWeight;
                        lstImportActualWeight = new List<ImportActualWeight>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ImportActualWeight objEntity = new ImportActualWeight();
                            objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.SiteAddress = Convert.ToString(reader["SiteAddress"]);
                            objEntity.SiteTown = Convert.ToString(reader["SiteTown"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.ActualWeight = Convert.ToDecimal(reader["ActualWeight"]);
                            objEntity.ActualCollectionDate = Convert.ToDateTime(reader["ActualCollectionDate"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.ContractorQuantityType = Convert.ToString(reader["ContractorQuantityType"]);

                            lstImportActualWeight.Add(objEntity);
                        }
                        objIAWInfo.lstFailedImportActualWeight = lstImportActualWeight;
                    }
                }
            }
            catch (Exception ex)
            {
                objIAWInfo.Status = Status.Failed;
                objIAWInfo.Message = ex.Message;
            }
            return objIAWInfo;
        }

        /// <summary>
        /// Database layer method to Confirm Pending  Services
        /// </summary>
        /// Delivery Point: DP4.9
        public ImportActualWeight PendingServiceConfirmed(ImportActualWeight importActualWeight)
        {
            ImportActualWeight objImportActualWeight = new ImportActualWeight();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[SP_ImportActualWeight_IsConfirmed]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JobIds", importActualWeight.JobIds);
                        cmd.ExecuteNonQuery();
                        objImportActualWeight.JobIds = importActualWeight.JobIds;
                    }
                }
                objImportActualWeight.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objImportActualWeight.Status = Status.Failed;
                objImportActualWeight.Message = ex.Message;
                throw ex;
            }
            return objImportActualWeight;
        }

        /// <summary>
        /// Database layer method to get Contractor Office Contact
        /// </summary>
        /// Delivery Point: DP4.1
        public ContractorWeightInfo GetContractorOfficeContact(ContractorContact contractorContact)
        {
            ContractorWeightInfo contractorWeightInfo = new ContractorWeightInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorContact> lstEntity = new List<ContractorContact>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_ContractorWeight_GetOfficeContact]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorContact objEntity = new ContractorContact();
                                objEntity.MainEmailAddress = Convert.ToString(reader["MainEmailAddress"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    contractorWeightInfo.lstContractorContacts = lstEntity;
                }

                contractorWeightInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                contractorWeightInfo.Status = Status.Failed;
                contractorWeightInfo.Message = ex.Message;
            }
            return contractorWeightInfo;
        }
    }
}

