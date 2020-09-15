using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.PricingMatrix
{
    public class PricingMatrixRepository : IPricingMatrixRepository
    {
        private string _connectionString;
        public PricingMatrixRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Area of Coverage
        /// <summary>
        /// Database layer method to get postcode list by contractorId
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetPostCodeListByContractorId(ContractorBasicInfo contractor)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Contractor_Config_AreaofCoverage> lstEntity = new List<Contractor_Config_AreaofCoverage>();
                    ContractorAdminSetting objContractorAdminSettingInfo = new ContractorAdminSetting();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetPostCodeListByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorAdminSetting objEntity = new ContractorAdminSetting();
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.IsNationalSupplier = string.IsNullOrEmpty(Convert.ToString(reader["IsNationalSupplier"])) ? false : Convert.ToBoolean(reader["IsNationalSupplier"]);
                                objContractorAdminSettingInfo = objEntity;

                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                Contractor_Config_AreaofCoverage objEntity = new Contractor_Config_AreaofCoverage();
                                objEntity.AOCId = string.IsNullOrEmpty(Convert.ToString(reader["AOCId"])) ? 0 : Convert.ToInt32(reader["AOCId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstareaofCoverages = lstEntity;
                    pricingMatrixInfo.ContractorAdminSetting = objContractorAdminSettingInfo;
                }

                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Insert and Update Coverage
        /// </summary>
        /// Delivery Point: DP4.8

        public PricingMatrixInfo InsertandUpdateAreaofCoverage(Contractor_Config_AreaofCoverage areaofCoverage)
        {
            PricingMatrixInfo objPricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_InsertUpdateAreaofCoverage]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AOCId", areaofCoverage.AOCId);
                        cmd.Parameters.AddWithValue("@ContractorId", areaofCoverage.ContractorId);
                        cmd.Parameters.AddWithValue("@PostCode", areaofCoverage.PostCode);
                        cmd.Parameters.AddWithValue("@CreatedBy", areaofCoverage.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", areaofCoverage.IsActive);
                        cmd.ExecuteNonQuery();
                    }
                }
                objPricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrixInfo.Status = Status.Failed;
                objPricingMatrixInfo.Message = ex.Message;
                throw ex;
            }
            return objPricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Check Area of Coverage Exists
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo CheckAreaofCoverageExists(Contractor_Config_AreaofCoverage areaofCoverage)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    Contractor_Config_AreaofCoverage objEntity = new Contractor_Config_AreaofCoverage();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_CheckAreaofCoverageExists]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(areaofCoverage.ContractorId));
                        cmd.Parameters.AddWithValue("@PostCode", Convert.ToString(areaofCoverage.PostCode));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objEntity.AOCId = string.IsNullOrEmpty(Convert.ToString(reader["AOCId"])) ? 0 : Convert.ToInt32(reader["AOCId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                    pricingMatrixInfo.areaofCoverage = objEntity;
                }

                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Delete Area of Coverage
        /// </summary>
        /// Delivery Point: DP4.8
        public Contractor_Config_AreaofCoverage DeleteAreaofCoverage(Contractor_Config_AreaofCoverage areaofCoverage)
        {
            Contractor_Config_AreaofCoverage objAreaofCoverage = new Contractor_Config_AreaofCoverage();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Contractor_DeleteAreaofCoverage";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", areaofCoverage.ContractorId);
                        cmd.Parameters.AddWithValue("@AOCIds", areaofCoverage.AOCIds);
                        cmd.ExecuteNonQuery();
                        objAreaofCoverage.AOCIds = areaofCoverage.AOCIds;
                    }
                }
                objAreaofCoverage.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objAreaofCoverage.Status = Status.Failed;
                objAreaofCoverage.Message = ex.Message;
                throw ex;
            }
            return objAreaofCoverage;
        }

        /// <summary>
        /// Database layer method to Update IsNational Supplier
        /// </summary>
        /// Delivery Point: DP4.8
        public ContractorAdminSetting UpdateIsNationalSupplier(ContractorAdminSetting contractorAdminSetting)
        {
            ContractorAdminSetting objContractorAdminSettingInfo = new ContractorAdminSetting();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_UpdateIsNationalSupplier]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", contractorAdminSetting.ContractorId);
                        cmd.Parameters.AddWithValue("@IsNationalSupplier", contractorAdminSetting.IsNationalSupplier);

                        cmd.ExecuteNonQuery();
                        objContractorAdminSettingInfo.ContractorId = contractorAdminSetting.ContractorId;
                    }
                }
                objContractorAdminSettingInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objContractorAdminSettingInfo.Status = Status.Failed;
                objContractorAdminSettingInfo.Message = ex.Message;
                throw ex;
            }
            return objContractorAdminSettingInfo;

        }

        #endregion

        #region Potential Service
        /// <summary>
        /// Database layer method to Get Potential Service List By ContractorId
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetPotentialServiceListByContractorId(ContractorBasicInfo contractor)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Contractor_Config_PotentialService> lstEntity = new List<Contractor_Config_PotentialService>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetPotentialServicesListByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractor.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contractor_Config_PotentialService objEntity = new Contractor_Config_PotentialService();
                                objEntity.PSId = string.IsNullOrEmpty(Convert.ToString(reader["PSId"])) ? 0 : Convert.ToInt32(reader["PSId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.WasteType.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.WasteType.WasteTypeName = Convert.ToString(reader["WasteType_Name"]);
                                objEntity.MaterialType.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialType.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.MaterialType.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.ContainerType.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerType.ContainerTypeName = Convert.ToString(reader["ContainerType_Name"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstpotentialServices = lstEntity;
                }

                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Get Potential ServiceInfo
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetPotentialServiceInfo(Contractor_Config_PotentialService potentialService)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    Contractor_Config_PotentialService objEntity = new Contractor_Config_PotentialService();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_GetPotentialServiceInfo]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(potentialService.ContractorId));
                        cmd.Parameters.AddWithValue("@PSId", Convert.ToString(potentialService.PSId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objEntity.PSId = string.IsNullOrEmpty(Convert.ToString(reader["PSId"])) ? 0 : Convert.ToInt32(reader["PSId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.WasteType.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialType.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialType.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.ContainerType.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                    pricingMatrixInfo.potentialService = objEntity;
                }

                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Insert and Update Potential Service
        /// </summary>
        /// Delivery Point: DP4.8

        public PricingMatrixInfo InsertandUpdatePotentialService(Contractor_Config_PotentialService potentialService)
        {
            PricingMatrixInfo objPricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_InsertUpdatePotentialService]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PSId", potentialService.PSId);
                        cmd.Parameters.AddWithValue("@ContractorId", potentialService.ContractorId);
                        cmd.Parameters.AddWithValue("@WasteTypeId", potentialService.WasteType.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", potentialService.MaterialType.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@EWCCode", potentialService.MaterialType.EWCCode);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", potentialService.ContainerType.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@PostCode", potentialService.PostCode);
                        cmd.Parameters.AddWithValue("@IsActive", potentialService.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", potentialService.CreatedBy);

                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objPricingMatrixInfo.potentialService.PSId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objPricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrixInfo.Status = Status.Failed;
                objPricingMatrixInfo.Message = ex.Message;
                throw ex;
            }
            return objPricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Check Potential Service Exists
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo CheckPotentialServiceExists(Contractor_Config_PotentialService potentialService)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                   List< Contractor_Config_PotentialService> lstPotentialService = new List<Contractor_Config_PotentialService>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Contractor_CheckPotentialServiceExists]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(potentialService.ContractorId));
                        cmd.Parameters.AddWithValue("@WasteTypeId", Convert.ToString(potentialService.WasteType.WasteTypeId));
                        cmd.Parameters.AddWithValue("@MaterialTypeId", Convert.ToString(potentialService.MaterialType.MaterialTypeId));
                        cmd.Parameters.AddWithValue("@ContainerTypeId", Convert.ToString(potentialService.ContainerType.ContainerTypeId));
                        cmd.Parameters.AddWithValue("@PostCode", Convert.ToString(potentialService.PostCode));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contractor_Config_PotentialService objEntity = new Contractor_Config_PotentialService();
                                objEntity.PSId = string.IsNullOrEmpty(Convert.ToString(reader["PSId"])) ? 0 : Convert.ToInt32(reader["PSId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.WasteType.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialType.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialType.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.ContainerType.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                                lstPotentialService.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstpotentialServices = lstPotentialService;
                }

                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Delete Potential Service
        /// </summary>
        /// Delivery Point: DP4.8
        public Contractor_Config_PotentialService DeletePotentialService(Contractor_Config_PotentialService potentialService)
        {
            Contractor_Config_PotentialService objPotentialService = new Contractor_Config_PotentialService();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Contractor_DeletePotentialService";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", potentialService.ContractorId);
                        cmd.Parameters.AddWithValue("@PSIds", potentialService.PSIds);
                        cmd.ExecuteNonQuery();
                        objPotentialService.PSIds = potentialService.PSIds;
                    }
                }
                objPotentialService.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPotentialService.Status = Status.Failed;
                objPotentialService.Message = ex.Message;
                throw ex;
            }
            return objPotentialService;
        }

        /// Database layer method to Get WasteTypes By PotentialService
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetWasteTypeByPotentialService(Contractor_Config_PotentialService potentialService)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<WasteType> lstEntity = new List<WasteType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetWasteTypeByPotentialService]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(potentialService.ContractorId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WasteType objEntity = new WasteType();
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.WasteTypeName = Convert.ToString(reader["WasteType_Name"]);
                             lstEntity.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstWasteTypes = lstEntity;
                }

                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// Database layer method to Get MaterialTypes By Potential Service
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetMaterialTypeByPotentialService(Contractor_Config_PotentialService potentialService)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<MaterialType> lstEntity = new List<MaterialType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetMaterialTypeByPotentialService]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(potentialService.ContractorId));
                        cmd.Parameters.AddWithValue("@WasteTypeId", Convert.ToString(potentialService.WasteType.WasteTypeId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MaterialType objEntity = new MaterialType();
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstMaterialTypes = lstEntity;
                }

                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// Database layer method to Get Container Types By Potential Service
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetContainerTypeByPotentialService(Contractor_Config_PotentialService potentialService)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContainerType> lstEntity = new List<ContainerType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetContainerTypeByPotentialService]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(potentialService.ContractorId));
                        cmd.Parameters.AddWithValue("@WasteTypeId", Convert.ToString(potentialService.WasteType.WasteTypeId));
                        cmd.Parameters.AddWithValue("@MaterialTypeId", Convert.ToString(potentialService.MaterialType.MaterialTypeId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContainerType objEntity = new ContainerType();
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerTypeName = Convert.ToString(reader["ContainerType_Name"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstContainerTypes = lstEntity;
                }

                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        #endregion

        #region Pricing Matrix Contractor / Customer
        /// <summary>
        /// Database layer method to Get Customer List
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetCustomerList()
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerBasicInfo> lstEntity = new List<CustomerBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetCustomerList]";
                        cmd.CommandType = CommandType.StoredProcedure;
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
                    pricingMatrixInfo.lstCustomers = lstEntity;
                }
                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Get Contractor List
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetContractorList()
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorBasicInfo> lstEntity = new List<ContractorBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetContractorList]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorBasicInfo objEntity = new ContractorBasicInfo();
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.CompanyName = Convert.ToString(reader["CompanyName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstContractors = lstEntity;
                }
                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Get PostCodes By Area of Coverage
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetPostCodesByAreaofCoverage(Contractor_Config_PotentialService potentialService)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Contractor_Config_AreaofCoverage> lstEntity = new List<Contractor_Config_AreaofCoverage>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_ContractorPostCodeList]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(potentialService.ContractorId));
                        cmd.Parameters.AddWithValue("@WasteTypeId", potentialService.WasteType.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", potentialService.MaterialType.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", potentialService.ContainerType.ContainerTypeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contractor_Config_AreaofCoverage objEntity = new Contractor_Config_AreaofCoverage();
                                objEntity.AOCId = string.IsNullOrEmpty(Convert.ToString(reader["AOCId"])) ? 0 : Convert.ToInt32(reader["AOCId"]);
                                objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstPostCodes = lstEntity;
                }
                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Insert and Update Pricing Matrix
        /// </summary>
        /// Delivery Point: DP4.8

        public PricingMatrixInfo InsertandUpdatePricingMatrixSetup(PricingMatrixSetup pricingMatrixSetup)
        {
            PricingMatrixInfo objPricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_InsertUpdatePricingMatrix_SetupHeader]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixId", pricingMatrixSetup.MatrixId);
                        cmd.Parameters.AddWithValue("@MatrixTypeId", pricingMatrixSetup.MatrixTypeId);
                        cmd.Parameters.AddWithValue("@ContractorId", pricingMatrixSetup.ContractorId);
                        cmd.Parameters.AddWithValue("@CustomerId", pricingMatrixSetup.CustomerId);
                        cmd.Parameters.AddWithValue("@StartDate", (pricingMatrixSetup.StartDate == null || pricingMatrixSetup.StartDate == new DateTime()) ? SqlDateTime.MinValue.Value : pricingMatrixSetup.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", (pricingMatrixSetup.EndDate == null || pricingMatrixSetup.EndDate == new DateTime()) ? SqlDateTime.MinValue.Value : pricingMatrixSetup.EndDate);
                        cmd.Parameters.AddWithValue("@IsSpecific", pricingMatrixSetup.IsSpecific);
                        cmd.Parameters.AddWithValue("@Specific_CustomerId", pricingMatrixSetup.Specific_CustomerId);
                        cmd.Parameters.AddWithValue("@Specific_ContractorId", pricingMatrixSetup.Specific_ContractorId);
                        cmd.Parameters.AddWithValue("@IsActive", pricingMatrixSetup.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", pricingMatrixSetup.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objPricingMatrixInfo.PricingMatrixSetup.MatrixId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objPricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrixInfo.Status = Status.Failed;
                objPricingMatrixInfo.Message = ex.Message;
                throw ex;
            }
            return objPricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to UpdateEndDatePricingMatrix
        /// </summary>
        /// Delivery Point: DP4.8

        public PricingMatrixSetup UpdateEndDatePricingMatrix(PricingMatrixSetup pricingMatrixSetup)
        {
            PricingMatrixSetup objPricingMatrixSetup = new PricingMatrixSetup();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_UpdateEndDatePricingMatrix]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixId", pricingMatrixSetup.MatrixId);
                        cmd.Parameters.AddWithValue("@EndDate", (pricingMatrixSetup.EndDate == null || pricingMatrixSetup.EndDate == new DateTime()) ? SqlDateTime.MinValue.Value : pricingMatrixSetup.EndDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", pricingMatrixSetup.CreatedBy);
                        cmd.ExecuteNonQuery();
                        objPricingMatrixSetup.MatrixId = pricingMatrixSetup.MatrixId;
                    }
                }
                objPricingMatrixSetup.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrixSetup.Status = Status.Failed;
                objPricingMatrixSetup.Message = ex.Message;
                throw ex;
            }
            return objPricingMatrixSetup;
        }

        /// <summary>
        /// Database layer method to Insert and Update Pricing Matrix Detail
        /// </summary>
        /// Delivery Point: DP4.8

        public PricingMatrixInfo InsertandUpdatePricingMatrixDetail(PricingMatrixDetail pricingMatrixDetail)
        {
            PricingMatrixInfo objPricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_InsertUpdatePricingMatrix_Details]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PMId", pricingMatrixDetail.PMId);
                        cmd.Parameters.AddWithValue("@MatrixId", pricingMatrixDetail.MatrixId);

                        cmd.Parameters.AddWithValue("@WasteTypeId", pricingMatrixDetail.WasteType.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", pricingMatrixDetail.MaterialType.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@EWCCode", pricingMatrixDetail.MaterialType.EWCCode);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", pricingMatrixDetail.ContainerType.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", pricingMatrixDetail.ContainerSize.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@IsPostCodeSpecific", pricingMatrixDetail.IsPostCodeSpecific);
                        cmd.Parameters.AddWithValue("@Postcode", pricingMatrixDetail.Postcode);
                        cmd.Parameters.AddWithValue("@IsTiredRate", pricingMatrixDetail.IsTiredRate);
                        cmd.Parameters.AddWithValue("@QuantityFrom", pricingMatrixDetail.QuantityFrom);
                        cmd.Parameters.AddWithValue("@QuantityTo", pricingMatrixDetail.QuantityTo);

                        cmd.Parameters.AddWithValue("@CustPrice_PricePerlift", pricingMatrixDetail.CustPricePerlift);
                        cmd.Parameters.AddWithValue("@CustPrice_TransportCost", pricingMatrixDetail.CustTransportCost);
                        cmd.Parameters.AddWithValue("@CustPrice_TransportPerQuantity", pricingMatrixDetail.CustTransportPerQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_MinimumTransportCharge", pricingMatrixDetail.CustMinimumTransportCharge);
                        cmd.Parameters.AddWithValue("@CustPrice_PricePerQuantity", pricingMatrixDetail.CustPricePerQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_QtyTypeId", pricingMatrixDetail.CustQtyTypeId);
                        cmd.Parameters.AddWithValue("@CustPrice_MinimumQuantity", pricingMatrixDetail.CustMinimumQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_MaxQuantity", pricingMatrixDetail.CustMaxQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_ExcessWeightCharge", pricingMatrixDetail.CustExcessWeightCharge);
                        cmd.Parameters.AddWithValue("@CustPrice_RentalPerUnit_PerDay", pricingMatrixDetail.CustRentalPerUnit_PerDay);
                        cmd.Parameters.AddWithValue("@CustPrice_DemurragePerHour", pricingMatrixDetail.CustDemurragePerHour);
                        cmd.Parameters.AddWithValue("@CustPrice_ConsignmentNoteCharge_PerVisit", pricingMatrixDetail.CustConsignmentNoteCharge_PerVisit);
                                                
                        cmd.Parameters.AddWithValue("@ContPrice_CostPerlift", pricingMatrixDetail.ContrPricePerlift);
                        cmd.Parameters.AddWithValue("@ContrPrice_TransportCost", pricingMatrixDetail.ContrTransportCost);
                        cmd.Parameters.AddWithValue("@ContrPrice_TransportPerQuantity", pricingMatrixDetail.ContrTransportPerQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_MinimumTransportCharge", pricingMatrixDetail.ContrMinimumTransportCharge);
                        cmd.Parameters.AddWithValue("@ContrPrice_CostPerQuantity", pricingMatrixDetail.ContrPricePerQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_QtyTypeId", pricingMatrixDetail.ContrQtyTypeId);
                        cmd.Parameters.AddWithValue("@ContrPrice_MinimumQuantity", pricingMatrixDetail.ContrMinimumQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_MaxQuantity", pricingMatrixDetail.ContrMaxQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_ExcessWeightCharge", pricingMatrixDetail.ContrExcessWeightCharge);
                        cmd.Parameters.AddWithValue("@ContrPrice_RentalPerUnit_PerDay", pricingMatrixDetail.ContrRentalPerUnit_PerDay);
                        cmd.Parameters.AddWithValue("@ContrPrice_DemurragePerHour", pricingMatrixDetail.ContrDemurragePerHour);
                        cmd.Parameters.AddWithValue("@ContrPrice_ConsignmentNoteCharge_PerVisit", pricingMatrixDetail.ContrConsignmentNoteCharge_PerVisit);
                                               
                        cmd.Parameters.AddWithValue("@IsPriceUpdated", pricingMatrixDetail.IsPriceUpdated);
                        cmd.Parameters.AddWithValue("@IsActive", pricingMatrixDetail.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", pricingMatrixDetail.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objPricingMatrixInfo.PricingMatrixDetail.PMId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objPricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrixInfo.Status = Status.Failed;
                objPricingMatrixInfo.Message = ex.Message;
                throw ex;
            }
            return objPricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Get Pricing Matrix By MatrixId
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetPricingMatrixByMatrixId(PricingMatrixSetup pricingMatrixSetup)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PricingMatrixSetup objPricingMatrixSetup = new PricingMatrixSetup();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetPricingMatrixByMatrixId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixId", Convert.ToString(pricingMatrixSetup.MatrixId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objPricingMatrixSetup.MatrixId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixId"])) ? 0 : Convert.ToInt32(reader["MatrixId"]);
                                objPricingMatrixSetup.MatrixTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixTypeId"])) ? 0 : Convert.ToInt32(reader["MatrixTypeId"]);
                                objPricingMatrixSetup.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objPricingMatrixSetup.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objPricingMatrixSetup.StartDate = string.IsNullOrEmpty(Convert.ToString(reader["StartDate"])) ? new DateTime() : Convert.ToDateTime(reader["StartDate"]);
                                objPricingMatrixSetup.EndDate = string.IsNullOrEmpty(Convert.ToString(reader["EndDate"])) ? new DateTime() : Convert.ToDateTime(reader["EndDate"]);
                                objPricingMatrixSetup.IsSpecific = string.IsNullOrEmpty(Convert.ToString(reader["IsSpecific"])) ? false : Convert.ToBoolean(reader["IsSpecific"]);
                                objPricingMatrixSetup.Specific_ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["Specific_ContractorId"])) ? 0 : Convert.ToInt32(reader["Specific_ContractorId"]);
                                objPricingMatrixSetup.Specific_CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["Specific_CustomerId"])) ? 0 : Convert.ToInt32(reader["Specific_CustomerId"]);
                                objPricingMatrixSetup.CustomerName = Convert.ToString(reader["CustomerName"]);
                                objPricingMatrixSetup.ContractorName = Convert.ToString(reader["ContractorName"]);
                                objPricingMatrixSetup.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objPricingMatrixSetup.ActionHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["ActionHeaderId"])) ? 0 : Convert.ToInt32(reader["ActionHeaderId"]);
                            }
                        }
                    }
                    pricingMatrixInfo.PricingMatrixSetup = objPricingMatrixSetup;
                }
                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Get Pricing Details By MatrixId
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetPricingMatrixDetailsByMatrixId(PricingMatrixSetup pricingMatrixSetup)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<PricingMatrixDetail> lstEntity = new List<PricingMatrixDetail>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetPricingMatrixDetailsByMatrixId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixId", Convert.ToString(pricingMatrixSetup.MatrixId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PricingMatrixDetail objEntity = new PricingMatrixDetail();

                                objEntity.PMId = string.IsNullOrEmpty(Convert.ToString(reader["PMId"])) ? 0 : Convert.ToInt32(reader["PMId"]);
                                objEntity.MatrixId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixId"])) ? 0 : Convert.ToInt32(reader["MatrixId"]);
                                objEntity.WasteType.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.WasteType.WasteTypeName = Convert.ToString(reader["WasteType_Name"]);
                                objEntity.MaterialType.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialType.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.MaterialType.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.ContainerType.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerType.ContainerTypeName = Convert.ToString(reader["ContainerType_Name"]);
                                objEntity.ContainerSize.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objEntity.ContainerSize.ContainerSizeName = Convert.ToString(reader["ContainerSize_Name"]);
                                objEntity.IsTiredRate = string.IsNullOrEmpty(Convert.ToString(reader["IsTiredRate"])) ? false : Convert.ToBoolean(reader["IsTiredRate"]);
                                objEntity.QuantityFrom = string.IsNullOrEmpty(Convert.ToString(reader["QuantityFrom"])) ? 0 : Convert.ToInt32(reader["QuantityFrom"]);
                                objEntity.QuantityTo = string.IsNullOrEmpty(Convert.ToString(reader["QuantityTo"])) ? 0 : Convert.ToInt32(reader["QuantityTo"]);
                                objEntity.IsPostCodeSpecific = string.IsNullOrEmpty(Convert.ToString(reader["IsPostCodeSpecific"])) ? false : Convert.ToBoolean(reader["IsPostCodeSpecific"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.IsPriceUpdated = string.IsNullOrEmpty(Convert.ToString(reader["IsPriceUpdated"])) ? false : Convert.ToBoolean(reader["IsPriceUpdated"]);
                                objEntity.CanDelete = string.IsNullOrEmpty(Convert.ToString(reader["CanDelete"])) ? 0 : Convert.ToInt32(reader["CanDelete"]);

                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstPricingMatrixDetails = lstEntity;
                }
                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Get Pricing Detail Info By PMId
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetPricingMatrixDetailInfoByPMId(PricingMatrixDetail pricingMatrixDetail)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PricingMatrixDetail objPricingMatrixDetail = new PricingMatrixDetail();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetPricingMatrixDetailInfoByPMId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PMId", Convert.ToString(pricingMatrixDetail.PMId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objPricingMatrixDetail.PMId = string.IsNullOrEmpty(Convert.ToString(reader["PMId"])) ? 0 : Convert.ToInt32(reader["PMId"]);
                                objPricingMatrixDetail.MatrixId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixId"])) ? 0 : Convert.ToInt32(reader["MatrixId"]);
                                objPricingMatrixDetail.WasteType.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objPricingMatrixDetail.MaterialType.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objPricingMatrixDetail.MaterialType.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objPricingMatrixDetail.ContainerType.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objPricingMatrixDetail.ContainerSize.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objPricingMatrixDetail.IsPostCodeSpecific = string.IsNullOrEmpty(Convert.ToString(reader["IsPostCodeSpecific"])) ? false : Convert.ToBoolean(reader["IsPostCodeSpecific"]);
                                objPricingMatrixDetail.Postcode = Convert.ToString(reader["Postcode"]);
                                objPricingMatrixDetail.IsTiredRate = string.IsNullOrEmpty(Convert.ToString(reader["IsTiredRate"])) ? false : Convert.ToBoolean(reader["IsTiredRate"]);
                                objPricingMatrixDetail.QuantityFrom = string.IsNullOrEmpty(Convert.ToString(reader["QuantityFrom"])) ? 0 : Convert.ToInt32(reader["QuantityFrom"]);
                                objPricingMatrixDetail.QuantityTo = string.IsNullOrEmpty(Convert.ToString(reader["QuantityTo"])) ? 0 : Convert.ToInt32(reader["QuantityTo"]);
                                objPricingMatrixDetail.CustPricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                                objPricingMatrixDetail.CustTransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                                objPricingMatrixDetail.CustTransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                                objPricingMatrixDetail.CustMinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                                objPricingMatrixDetail.CustPricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                                objPricingMatrixDetail.CustQtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["CustPrice_QtyTypeId"]);
                                objPricingMatrixDetail.CustMinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                                objPricingMatrixDetail.CustMaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                                objPricingMatrixDetail.CustExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                                objPricingMatrixDetail.CustRentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                                objPricingMatrixDetail.CustDemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                                objPricingMatrixDetail.CustConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                                objPricingMatrixDetail.ContrPricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContPrice_CostPerlift"]);
                                objPricingMatrixDetail.ContrTransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                                objPricingMatrixDetail.ContrTransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                                objPricingMatrixDetail.ContrMinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                                objPricingMatrixDetail.ContrPricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                                objPricingMatrixDetail.ContrQtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["ContrPrice_QtyTypeId"]);
                                objPricingMatrixDetail.ContrMinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                                objPricingMatrixDetail.ContrMaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                                objPricingMatrixDetail.ContrExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                                objPricingMatrixDetail.ContrRentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                                objPricingMatrixDetail.ContrDemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                                objPricingMatrixDetail.ContrConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);
                                objPricingMatrixDetail.IsPriceUpdated = string.IsNullOrEmpty(Convert.ToString(reader["IsPriceUpdated"])) ? false : Convert.ToBoolean(reader["IsPriceUpdated"]);
                                objPricingMatrixDetail.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                    pricingMatrixInfo.PricingMatrixDetail = objPricingMatrixDetail;
                }
                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to Delete Pricing Matrixo By MatrixId
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixSetup DeletePricingMatrixByMatrixId(PricingMatrixSetup pricingMatrix)
        {
            PricingMatrixSetup objPricingMatrixSetup = new PricingMatrixSetup();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_DeletePricingMatrixByMatrixId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixIds", pricingMatrix.MatrixIds);
                        cmd.ExecuteNonQuery();
                        objPricingMatrixSetup.MatrixIds = pricingMatrix.MatrixIds;
                    }
                }
                objPricingMatrixSetup.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrixSetup.Status = Status.Failed;
                objPricingMatrixSetup.Message = ex.Message;
                throw ex;
            }
            return objPricingMatrixSetup;
        }

        /// <summary>
        /// Database layer method to Delete Pricing Detail By PMId
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixDetail DeleteMatrixDetailsByPMId(PricingMatrixDetail pricingMatrixDetail)
        {
            PricingMatrixDetail objPricingMatrixDetail = new PricingMatrixDetail();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_DeleteMatrixDetailsByPMId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PMIds", pricingMatrixDetail.PMIds);
                        cmd.ExecuteNonQuery();
                        objPricingMatrixDetail.PMIds = pricingMatrixDetail.PMIds;
                    }
                }
                objPricingMatrixDetail.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrixDetail.Status = Status.Failed;
                objPricingMatrixDetail.Message = ex.Message;
                throw ex;
            }
            return objPricingMatrixDetail;
        }

        /// <summary>
        /// Database layer method to Validate Contractor Price Exist Date Overlap
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixSetup ValidateContractorPriceExist(PricingMatrixSetup matrixSetup)
        {
            PricingMatrixSetup objPricingMatrixSetup = new PricingMatrixSetup();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PricingMatrixSetup PricingMatrixSetup = new PricingMatrixSetup();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_ValidateContractorPriceExist]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContractorId", matrixSetup.ContractorId);
                        cmd.Parameters.AddWithValue("@StartDate",matrixSetup.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate",matrixSetup.EndDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PricingMatrixSetup.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                PricingMatrixSetup.MatrixId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixId"])) ? 0 : Convert.ToInt32(reader["MatrixId"]);
                                //PricingMatrixSetup.StartDate = string.IsNullOrEmpty(Convert.ToString(reader["StartDate"])) ? new DateTime() : Convert.ToDateTime(reader["StartDate"]);
                                //PricingMatrixSetup.EndDate = string.IsNullOrEmpty(Convert.ToString(reader["EndDate"])) ? new DateTime() : Convert.ToDateTime(reader["EndDate"]);

                            }
                        }
                    }
                    objPricingMatrixSetup = PricingMatrixSetup;
                }
                objPricingMatrixSetup.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrixSetup.Status = Status.Failed;
                objPricingMatrixSetup.Message = ex.Message;
            }
            return objPricingMatrixSetup;
        }

        /// <summary>
        /// Database layer method to Validate Customer Price Exist Date Overlap
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixSetup ValidateCustomerPriceExist(PricingMatrixSetup matrixSetup)
        {
            PricingMatrixSetup objPricingMatrixSetup = new PricingMatrixSetup();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PricingMatrixSetup PricingMatrixSetup = new PricingMatrixSetup();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_ValidateCustomerPriceExist]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", matrixSetup.CustomerId);
                        cmd.Parameters.AddWithValue("@StartDate", matrixSetup.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", matrixSetup.EndDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PricingMatrixSetup.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                PricingMatrixSetup.MatrixId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixId"])) ? 0 : Convert.ToInt32(reader["MatrixId"]);
                                //PricingMatrixSetup.StartDate = string.IsNullOrEmpty(Convert.ToString(reader["StartDate"])) ? new DateTime() : Convert.ToDateTime(reader["StartDate"]);
                                //PricingMatrixSetup.EndDate = string.IsNullOrEmpty(Convert.ToString(reader["EndDate"])) ? new DateTime() : Convert.ToDateTime(reader["EndDate"]);

                            }
                        }
                    }
                    objPricingMatrixSetup = PricingMatrixSetup;
                }
                objPricingMatrixSetup.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrixSetup.Status = Status.Failed;
                objPricingMatrixSetup.Message = ex.Message;
            }
            return objPricingMatrixSetup;
        }

        /// <summary>
        /// Database layer method to MatrixDetailsExistsornot
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo MatrixDetailsExistsornot(PricingMatrixDetail pricingMatrixDetail)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PricingMatrixDetail objpricingMatrixDetail = new PricingMatrixDetail();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_ServiceExistByID]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixId", pricingMatrixDetail.MatrixId);
                        cmd.Parameters.AddWithValue("@WasteTypeId", pricingMatrixDetail.WasteType.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", pricingMatrixDetail.MaterialType.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", pricingMatrixDetail.ContainerType.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", pricingMatrixDetail.ContainerSize.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@IsTiredRate", Convert.ToBoolean(pricingMatrixDetail.IsTiredRate));
                        cmd.Parameters.AddWithValue("@QuantityFrom", pricingMatrixDetail.QuantityFrom);
                        cmd.Parameters.AddWithValue("@QuantityTo", pricingMatrixDetail.QuantityTo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objpricingMatrixDetail.PMId = string.IsNullOrEmpty(Convert.ToString(reader["PMId"])) ? 0 : Convert.ToInt32(reader["PMId"]);
                                //objEntity.MatrixId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixId"])) ? 0 : Convert.ToInt32(reader["MatrixId"]);
                                //objEntity.WasteType.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                //objEntity.MaterialType.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                //objEntity.MaterialType.EWCCode = Convert.ToString(reader["EWCCode"]);
                                //objEntity.ContainerType.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                //objEntity.ContainerSize.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                //objEntity.IsTiredRate = string.IsNullOrEmpty(Convert.ToString(reader["IsTiredRate"])) ? false : Convert.ToBoolean(reader["IsTiredRate"]);
                                //objEntity.QuantityFrom = string.IsNullOrEmpty(Convert.ToString(reader["QuantityFrom"])) ? 0 : Convert.ToInt32(reader["QuantityFrom"]);
                                //objEntity.QuantityTo = string.IsNullOrEmpty(Convert.ToString(reader["QuantityTo"])) ? 0 : Convert.ToInt32(reader["QuantityTo"]);
                               
                            }
                        }
                    }
                    pricingMatrixInfo.PricingMatrixDetail = objpricingMatrixDetail;
                }
                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }



        #endregion

        #region Customer Price Update Restriction

        /// <summary>
        /// Database layer method to Get Customer Price Update Restriction List
        /// </summary>
        /// Delivery Point: DP4.8
        public CustomerPriceUpdateRestrictionInfo GetCustomerPriceUpdateRestrictionList()
        {
            CustomerPriceUpdateRestrictionInfo priceUpdateRestrictionInfo = new CustomerPriceUpdateRestrictionInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerPriceUpdateRestriction> lstEntity = new List<CustomerPriceUpdateRestriction>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetCustomerPriceUpdateRestrictionList]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerPriceUpdateRestriction objEntity = new CustomerPriceUpdateRestriction();
                                objEntity.RestrictionId = string.IsNullOrEmpty(Convert.ToString(reader["RestrictionId"])) ? 0 : Convert.ToInt32(reader["RestrictionId"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                                objEntity.StartDate = string.IsNullOrEmpty(Convert.ToString(reader["StartDate"])) ? new DateTime() : Convert.ToDateTime(reader["StartDate"]);
                                //objEntity.EndDate = reader["EndDate"] == DBNull.Value ? null : (DateTime?)reader["EndDate"];
                                objEntity.EndDate = string.IsNullOrEmpty(Convert.ToString(reader["EndDate"])) ? new DateTime() : Convert.ToDateTime(reader["EndDate"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    priceUpdateRestrictionInfo.lstCustomerPriceUpdateRestriction = lstEntity;
                }
                priceUpdateRestrictionInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                priceUpdateRestrictionInfo.Status = Status.Failed;
                priceUpdateRestrictionInfo.Message = ex.Message;
            }
            return priceUpdateRestrictionInfo;
        }

        /// <summary>
        /// Database layer method to Get Customer Price Update Restriction History List
        /// </summary>
        /// Delivery Point: DP4.8
        public CustomerPriceUpdateRestrictionInfo GetCustomerPriceUpdateRestrictionHistoryList(CustomerBasicInfo customerBasicInfo)
        {
            CustomerPriceUpdateRestrictionInfo priceUpdateRestrictionInfo = new CustomerPriceUpdateRestrictionInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetCustomerPriceUpdateRestrictionHistoryList]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerId", Convert.ToString(customerBasicInfo.CustomerId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerPriceUpdateRestrictionHistory objEntity = new CustomerPriceUpdateRestrictionHistory();
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.CustomerName  = Convert.ToString(reader["CustomerName"]);
                                priceUpdateRestrictionInfo.CustomerPriceUpdateRestrictionHistory = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                CustomerPriceUpdateRestrictionHistory objEntity = new CustomerPriceUpdateRestrictionHistory();
                                objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.StartDate = string.IsNullOrEmpty(Convert.ToString(reader["StartDate"])) ? new DateTime() : Convert.ToDateTime(reader["StartDate"]);
                                objEntity.EndDate = string.IsNullOrEmpty(Convert.ToString(reader["EndDate"])) ? new DateTime() : Convert.ToDateTime(reader["EndDate"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["UpdatedBy"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["UpdatedOn"]);
                                priceUpdateRestrictionInfo.lstCustomerPriceUpdateRestrictionHistory.Add(objEntity);
                            }
                          
                        }
                    }
                }
                priceUpdateRestrictionInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                priceUpdateRestrictionInfo.Status = Status.Failed;
                priceUpdateRestrictionInfo.Message = ex.Message;
            }
            return priceUpdateRestrictionInfo;
        }

        /// <summary>
        /// Database layer method to Get Customer Price Update Restriction By Id
        /// </summary>
        /// Delivery Point: DP4.8
        public CustomerPriceUpdateRestrictionInfo GetCustomerPriceUpdateRestrictionById(CustomerPriceUpdateRestriction customerPriceUpdateRestriction)
        {
            CustomerPriceUpdateRestrictionInfo priceUpdateRestrictionInfo = new CustomerPriceUpdateRestrictionInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    CustomerPriceUpdateRestriction objEntity = new CustomerPriceUpdateRestriction();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetCustomerPriceUpdateRestrictionInfobyId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RestrictionId", Convert.ToString(customerPriceUpdateRestriction.RestrictionId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                objEntity.RestrictionId = string.IsNullOrEmpty(Convert.ToString(reader["RestrictionId"])) ? 0 : Convert.ToInt32(reader["RestrictionId"]);
                                objEntity.CustomerId = string.IsNullOrEmpty(Convert.ToString(reader["CustomerId"])) ? 0 : Convert.ToInt32(reader["CustomerId"]);
                                objEntity.StartDate = string.IsNullOrEmpty(Convert.ToString(reader["StartDate"])) ? new DateTime() : Convert.ToDateTime(reader["StartDate"]);
                                //objEntity.EndDate = reader["EndDate"] == DBNull.Value ? null : (DateTime?)reader["EndDate"];
                                objEntity.EndDate = string.IsNullOrEmpty(Convert.ToString(reader["EndDate"])) ? new DateTime() : Convert.ToDateTime(reader["EndDate"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                                           }
                        }
                    }
                    priceUpdateRestrictionInfo.CustomerPriceUpdateRestriction = objEntity;
                }
                priceUpdateRestrictionInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                priceUpdateRestrictionInfo.Status = Status.Failed;
                priceUpdateRestrictionInfo.Message = ex.Message;
            }
            return priceUpdateRestrictionInfo;
        }

        /// <summary>
        /// Database layer method to Insert and Update Customer Price Update Restriction
        /// </summary>
        /// Delivery Point: DP4.8
        public CustomerPriceUpdateRestrictionInfo InsertandUpdateCustomerPriceUpdateRestriction(CustomerPriceUpdateRestriction customerPriceUpdateRestriction)
        {
            CustomerPriceUpdateRestrictionInfo objCustomerPriceUpdateRestrictionInfo = new CustomerPriceUpdateRestrictionInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_InsertUpdateCustomerPriceUpdateRestriction]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RestrictionId", customerPriceUpdateRestriction.RestrictionId);
                        cmd.Parameters.AddWithValue("@CustomerId", customerPriceUpdateRestriction.CustomerId);
                        cmd.Parameters.AddWithValue("@StartDate", customerPriceUpdateRestriction.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", customerPriceUpdateRestriction.EndDate);
                        cmd.Parameters.AddWithValue("@ActionDate", customerPriceUpdateRestriction.ActionDate);
                        cmd.Parameters.AddWithValue("@IsActive", customerPriceUpdateRestriction.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", customerPriceUpdateRestriction.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objCustomerPriceUpdateRestrictionInfo.CustomerPriceUpdateRestriction.RestrictionId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objCustomerPriceUpdateRestrictionInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomerPriceUpdateRestrictionInfo.Status = Status.Failed;
                objCustomerPriceUpdateRestrictionInfo.Message = ex.Message;
                throw ex;
            }
            return objCustomerPriceUpdateRestrictionInfo;

        }

        /// <summary>
        /// Database layer method to Delete Customer Price Update Restriction
        /// </summary>
        /// Delivery Point: DP4.8
        public CustomerPriceUpdateRestrictionInfo DeleteCustomerPriceUpdateRestriction(CustomerPriceUpdateRestriction customerPriceUpdateRestriction)
        {
            CustomerPriceUpdateRestrictionInfo objCustomerPriceUpdateRestrictionInfo = new CustomerPriceUpdateRestrictionInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_DeleteCustomerPriceUpdateRestriction]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RestrictionIds", customerPriceUpdateRestriction.RestrictionIds);
                        cmd.ExecuteNonQuery();
                    }
                }
                objCustomerPriceUpdateRestrictionInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objCustomerPriceUpdateRestrictionInfo.Status = Status.Failed;
                objCustomerPriceUpdateRestrictionInfo.Message = ex.Message;
                throw ex;
            }
            return objCustomerPriceUpdateRestrictionInfo;
        }

        #endregion

        #region Pricing Matrix Upload
        /// <summary>
        /// Database layer method to Upload Pricing Matrix Detail RawData
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixUploadInfo UploadPricingMatrixDetailRawData(PricingMatrixUploadInfo matrixUploadInfo, DataTable dataTable)
        {
            PricingMatrixUploadInfo objPricingMatrixUploadInfo = new PricingMatrixUploadInfo();
            List<PricingMatrix_MatrixDetails> lstPricingMatrixDetails = new List<PricingMatrix_MatrixDetails>();
            int _upooadedId = 0;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_PricingMatrix_Upload_InsertRawData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@PricingMatrixDetails", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_PricingMatrix_UploadMatrixDetails",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@MatrixId", matrixUploadInfo.MatrixSetup.MatrixId);
                        cmd.Parameters.AddWithValue("@MatrixTypeId", matrixUploadInfo.MatrixSetup.MatrixTypeId);
                        cmd.Parameters.AddWithValue("@ContractorId", matrixUploadInfo.MatrixSetup.ContractorId);
                        cmd.Parameters.AddWithValue("@CustomerId", matrixUploadInfo.MatrixSetup.CustomerId);
                        cmd.Parameters.AddWithValue("@StartDate", matrixUploadInfo.MatrixSetup.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", matrixUploadInfo.MatrixSetup.EndDate);
                        cmd.Parameters.AddWithValue("@IsSpecific", matrixUploadInfo.MatrixSetup.IsSpecific);
                        cmd.Parameters.AddWithValue("@Specific_CustomerId", matrixUploadInfo.MatrixSetup.Specific_CustomerId);
                        cmd.Parameters.AddWithValue("@Specific_ContractorId", matrixUploadInfo.MatrixSetup.Specific_ContractorId);
                        cmd.Parameters.AddWithValue("@FileLocation", matrixUploadInfo.FileLocation);
                        cmd.Parameters.AddWithValue("@CreatedBy", matrixUploadInfo.CreatedBy);
                        cmd.Parameters.Add("@MatrixHeaderId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        _upooadedId = Convert.ToInt32(cmd.Parameters["@MatrixHeaderId"].Value);
                        objPricingMatrixUploadInfo.MatrixHeaderId = _upooadedId;
                        objPricingMatrixUploadInfo.Status = Status.Success;
                    }
                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "SP_PricingMatrixUpload_ProcessData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@MatrixHeaderId", objPricingMatrixUploadInfo.MatrixHeaderId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        while (reader.Read())
                        {
                            objPricingMatrixUploadInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            PricingMatrix_MatrixDetails objEntity = new PricingMatrix_MatrixDetails();
                            objEntity.MDId = string.IsNullOrEmpty(Convert.ToString(reader["MDId"])) ? 0 : Convert.ToInt32(reader["MDId"]);
                            objEntity.UploadComment = Convert.ToString(reader["ReasonForError"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCOde"]);

                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);

                            objEntity.QuantityFrom = string.IsNullOrEmpty(Convert.ToString(reader["QuantityFrom"])) ? 0 : Convert.ToInt32(reader["QuantityFrom"]);
                            objEntity.QuantityTo = string.IsNullOrEmpty(Convert.ToString(reader["QuantityTo"])) ? 0 : Convert.ToInt32(reader["QuantityTo"]);

                            objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                            objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                            objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                            objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                            objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                            objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                            objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                            objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                            objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                            objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.ContPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContPrice_CostPerlift"]);
                            objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                            objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                            objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                            objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                            objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                            objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                            objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                            objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                            objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);

                            lstPricingMatrixDetails.Add(objEntity);
                        }
                        objPricingMatrixUploadInfo.lstPassedMatrixDetail = lstPricingMatrixDetails;
                        lstPricingMatrixDetails = new List<PricingMatrix_MatrixDetails>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            PricingMatrix_MatrixDetails objEntity = new PricingMatrix_MatrixDetails();
                            objEntity.MDId = string.IsNullOrEmpty(Convert.ToString(reader["MDId"])) ? 0 : Convert.ToInt32(reader["MDId"]);
                            objEntity.UploadComment = Convert.ToString(reader["ReasonForError"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCOde"]);

                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);

                            objEntity.QuantityFrom = string.IsNullOrEmpty(Convert.ToString(reader["QuantityFrom"])) ? 0 : Convert.ToInt32(reader["QuantityFrom"]);
                            objEntity.QuantityTo = string.IsNullOrEmpty(Convert.ToString(reader["QuantityTo"])) ? 0 : Convert.ToInt32(reader["QuantityTo"]);

                            objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                            objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                            objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                            objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                            objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                            objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                            objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                            objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                            objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                            objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.ContPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContPrice_CostPerlift"]);
                            objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                            objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                            objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                            objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                            objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                            objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                            objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                            objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                            objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);

                            lstPricingMatrixDetails.Add(objEntity);
                        }
                        objPricingMatrixUploadInfo.lstFailedMatrixDetail = lstPricingMatrixDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                objPricingMatrixUploadInfo.Status = Status.Failed;
                objPricingMatrixUploadInfo.Message = ex.Message;
            }
            return objPricingMatrixUploadInfo;
        }

        /// <summary>
        /// Database layer method to Pricing Matrix Upload Create Matrix
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixUploadInfo PricingMatrixUploadCreateMatrix(PricingMatrixUploadInfo matrixUploadInfo)
        {
            PricingMatrixUploadInfo objMatrixUploadInfo = new PricingMatrixUploadInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PricingMatrixUploadInfo objEntity = new PricingMatrixUploadInfo();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrixUpload_CreateMatrix]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixHeaderId", Convert.ToString(matrixUploadInfo.MatrixHeaderId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objEntity.MatrixHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixId"])) ? 0 : Convert.ToInt32(reader["MatrixId"]);
                                objEntity.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                objEntity.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                    objMatrixUploadInfo = objEntity;
                }

                objMatrixUploadInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objMatrixUploadInfo.Status = Status.Failed;
                objMatrixUploadInfo.Message = ex.Message;
            }
            return objMatrixUploadInfo;
        }

        /// <summary>
        /// Database layer method to Pricing Matrix Upload Cancel Upload Process
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixUploadInfo PricingMatrixUploadCancelUploadProcess(PricingMatrixUploadInfo matrixUploadInfo)
        {
            PricingMatrixUploadInfo objMatrixUploadInfo = new PricingMatrixUploadInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PricingMatrixUploadInfo objEntity = new PricingMatrixUploadInfo();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrixUpload_CancelUploadProcess]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixHeaderId", Convert.ToString(matrixUploadInfo.MatrixHeaderId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objEntity.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                objEntity.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                    objMatrixUploadInfo = objEntity;
                }

                objMatrixUploadInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objMatrixUploadInfo.Status = Status.Failed;
                objMatrixUploadInfo.Message = ex.Message;
            }
            return objMatrixUploadInfo;
        }

        /// <summary>
        /// Database layer method to Get Matrix Detail By MDid
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrix_MatrixDetails GetMatrixDetailByMDid(PricingMatrix_MatrixDetails pricingMatrix_MatrixDetails)
        {
            PricingMatrix_MatrixDetails pricingMatrixInfo = new PricingMatrix_MatrixDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PricingMatrix_MatrixDetails objEntity = new PricingMatrix_MatrixDetails();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_Upload_GetMatrixDetailByMDid]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MDid", Convert.ToString(pricingMatrix_MatrixDetails.MDId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objEntity.MDId = string.IsNullOrEmpty(Convert.ToString(reader["MDid"])) ? 0 : Convert.ToInt32(reader["MDid"]);
                                objEntity.MatrixHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["MatrixHeaderId"])) ? 0 : Convert.ToInt32(reader["MatrixHeaderId"]);
                                objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                                objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialType= Convert.ToString(reader["MaterialType"]);
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                objEntity.QuantityFrom = string.IsNullOrEmpty(Convert.ToString(reader["QuantityFrom"])) ? 0 : Convert.ToInt32(reader["QuantityFrom"]);
                                objEntity.QuantityTo = string.IsNullOrEmpty(Convert.ToString(reader["QuantityTo"])) ? 0 : Convert.ToInt32(reader["QuantityTo"]);
                                objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                                objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                                objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                                objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                                objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                                objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                                objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                                objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                                objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                                objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                                objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                                objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);
                                objEntity.ContPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContPrice_CostPerlift"]);
                                objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                                objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                                objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                                objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                                objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                                objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                                objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                                objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                                objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                                objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                                objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);

                            }
                        }
                    }
                    pricingMatrixInfo = objEntity;
                }

                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary> 
        /// Database layer method to Update Imported Matrix Prices By Id
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrix_MatrixDetails UpdateImportedMatrixPricesById(PricingMatrix_MatrixDetails pricingMatrix_MatrixDetails)
        {
            PricingMatrix_MatrixDetails objPricingMatrix_MatrixDetails = new PricingMatrix_MatrixDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_Upload_UpdateImportedMatrixPricesById]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MDid", pricingMatrix_MatrixDetails.MDId);
                        cmd.Parameters.AddWithValue("@PostCode", pricingMatrix_MatrixDetails.PostCode);
                        cmd.Parameters.AddWithValue("@WasteType", pricingMatrix_MatrixDetails.WasteType);
                        cmd.Parameters.AddWithValue("@WasteTypeId", pricingMatrix_MatrixDetails.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialType", pricingMatrix_MatrixDetails.MaterialType);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", pricingMatrix_MatrixDetails.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@EWCCode", pricingMatrix_MatrixDetails.EWCCode);
                        cmd.Parameters.AddWithValue("@ContainerType", pricingMatrix_MatrixDetails.ContainerType);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", pricingMatrix_MatrixDetails.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSize", pricingMatrix_MatrixDetails.ContainerSize);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", pricingMatrix_MatrixDetails.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@QuantityFrom", pricingMatrix_MatrixDetails.QuantityFrom);
                        cmd.Parameters.AddWithValue("@QuantityTo", pricingMatrix_MatrixDetails.QuantityTo);
                        cmd.Parameters.AddWithValue("@CustPrice_PricePerlift", pricingMatrix_MatrixDetails.CustPrice_PricePerlift);
                        cmd.Parameters.AddWithValue("@CustPrice_TransportCost", pricingMatrix_MatrixDetails.CustPrice_TransportCost);
                        cmd.Parameters.AddWithValue("@CustPrice_TransportPerQuantity", pricingMatrix_MatrixDetails.CustPrice_TransportPerQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_MinimumTransportCharge", pricingMatrix_MatrixDetails.CustPrice_MinimumTransportCharge);
                        cmd.Parameters.AddWithValue("@CustPrice_PricePerQuantity", pricingMatrix_MatrixDetails.CustPrice_PricePerQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_QuantityType", pricingMatrix_MatrixDetails.CustPrice_QuantityType);
                        cmd.Parameters.AddWithValue("@CustPrice_QtyTypeId", pricingMatrix_MatrixDetails.CustPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@CustPrice_MinimumQuantity", pricingMatrix_MatrixDetails.CustPrice_MinimumQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_MaxQuantity", pricingMatrix_MatrixDetails.CustPrice_MaxQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_ExcessWeightCharge", pricingMatrix_MatrixDetails.CustPrice_ExcessWeightCharge);
                        cmd.Parameters.AddWithValue("@CustPrice_RentalPerUnit_PerDay", pricingMatrix_MatrixDetails.CustPrice_RentalPerUnit_PerDay);
                        cmd.Parameters.AddWithValue("@CustPrice_DemurragePerHour", pricingMatrix_MatrixDetails.CustPrice_DemurragePerHour);
                        cmd.Parameters.AddWithValue("@CustPrice_ConsignmentNoteCharge_PerVisit", pricingMatrix_MatrixDetails.CustPrice_ConsignmentNoteCharge_PerVisit);
                        cmd.Parameters.AddWithValue("@ContPrice_CostPerlift", pricingMatrix_MatrixDetails.ContPrice_CostPerlift);
                        cmd.Parameters.AddWithValue("@ContrPrice_TransportCost", pricingMatrix_MatrixDetails.ContrPrice_TransportCost);
                        cmd.Parameters.AddWithValue("@ContrPrice_TransportPerQuantity", pricingMatrix_MatrixDetails.ContrPrice_TransportPerQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_MinimumTransportCharge", pricingMatrix_MatrixDetails.ContrPrice_MinimumTransportCharge);
                        cmd.Parameters.AddWithValue("@ContrPrice_CostPerQuantity", pricingMatrix_MatrixDetails.ContrPrice_CostPerQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_QuantityType", pricingMatrix_MatrixDetails.ContrPrice_QuantityType);
                        cmd.Parameters.AddWithValue("@ContrPrice_QtyTypeId", pricingMatrix_MatrixDetails.ContrPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@ContrPrice_MaxQuantity", pricingMatrix_MatrixDetails.ContrPrice_MaxQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_ExcessWeightCharge", pricingMatrix_MatrixDetails.ContrPrice_ExcessWeightCharge);
                        cmd.Parameters.AddWithValue("@ContrPrice_RentalPerUnit_PerDay", pricingMatrix_MatrixDetails.ContrPrice_RentalPerUnit_PerDay);
                        cmd.Parameters.AddWithValue("@ContrPrice_DemurragePerHour", pricingMatrix_MatrixDetails.ContrPrice_DemurragePerHour);
                        cmd.Parameters.AddWithValue("@ContrPrice_ConsignmentNoteCharge_PerVisit", pricingMatrix_MatrixDetails.ContrPrice_ConsignmentNoteCharge_PerVisit);
                        cmd.Parameters.AddWithValue("@CreatedBy", pricingMatrix_MatrixDetails.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objPricingMatrix_MatrixDetails.MDId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objPricingMatrix_MatrixDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingMatrix_MatrixDetails.Status = Status.Failed;
                objPricingMatrix_MatrixDetails.Message = ex.Message;
                throw ex;
            }
            return objPricingMatrix_MatrixDetails;

        }


        /// <summary>
        /// Database layer method to Process Data Pricing Matrix Detail
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixUploadInfo ProcessDataPricingMatrixDetail(PricingMatrixUploadInfo matrixUploadInfo)
        {
            PricingMatrixUploadInfo objPricingMatrixUploadInfo = new PricingMatrixUploadInfo();
            List<PricingMatrix_MatrixDetails> lstPricingMatrixDetails = new List<PricingMatrix_MatrixDetails>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                   
                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "SP_PricingMatrixUpload_ProcessData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@MatrixHeaderId", matrixUploadInfo.MatrixHeaderId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        while (reader.Read())
                        {
                            objPricingMatrixUploadInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            PricingMatrix_MatrixDetails objEntity = new PricingMatrix_MatrixDetails();
                            objEntity.MDId = string.IsNullOrEmpty(Convert.ToString(reader["MDId"])) ? 0 : Convert.ToInt32(reader["MDId"]);
                            objEntity.UploadComment = Convert.ToString(reader["ReasonForError"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCOde"]);

                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);

                            objEntity.QuantityFrom = string.IsNullOrEmpty(Convert.ToString(reader["QuantityFrom"])) ? 0 : Convert.ToInt32(reader["QuantityFrom"]);
                            objEntity.QuantityTo = string.IsNullOrEmpty(Convert.ToString(reader["QuantityTo"])) ? 0 : Convert.ToInt32(reader["QuantityTo"]);

                            objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                            objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                            objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                            objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                            objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                            objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                            objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                            objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                            objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                            objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.ContPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContPrice_CostPerlift"]);
                            objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                            objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                            objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                            objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                            objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                            objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                            objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                            objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                            objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);

                            lstPricingMatrixDetails.Add(objEntity);
                        }
                        objPricingMatrixUploadInfo.lstPassedMatrixDetail = lstPricingMatrixDetails;
                        lstPricingMatrixDetails = new List<PricingMatrix_MatrixDetails>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            PricingMatrix_MatrixDetails objEntity = new PricingMatrix_MatrixDetails();
                            objEntity.MDId = string.IsNullOrEmpty(Convert.ToString(reader["MDId"])) ? 0 : Convert.ToInt32(reader["MDId"]);
                            objEntity.UploadComment = Convert.ToString(reader["ReasonForError"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCOde"]);

                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);

                            objEntity.QuantityFrom = string.IsNullOrEmpty(Convert.ToString(reader["QuantityFrom"])) ? 0 : Convert.ToInt32(reader["QuantityFrom"]);
                            objEntity.QuantityTo = string.IsNullOrEmpty(Convert.ToString(reader["QuantityTo"])) ? 0 : Convert.ToInt32(reader["QuantityTo"]);

                            objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                            objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                            objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                            objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                            objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                            objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                            objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                            objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                            objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                            objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.ContPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContPrice_CostPerlift"]);
                            objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                            objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                            objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                            objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                            objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                            objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                            objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                            objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                            objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);

                            lstPricingMatrixDetails.Add(objEntity);
                        }
                        objPricingMatrixUploadInfo.lstFailedMatrixDetail = lstPricingMatrixDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                objPricingMatrixUploadInfo.Status = Status.Failed;
                objPricingMatrixUploadInfo.Message = ex.Message;
            }
            return objPricingMatrixUploadInfo;
        }
        #endregion

        #region Pricing Update Upload
        /// <summary>
        /// Database layer method to Pricing Update Upload Insert Raw Data
        /// </summary>
        /// Delivery Point: DP4.8
        public PriceUpdateUploadInfo PricingUpdateUploadInsertRawData(PriceUpdateUploadInfo pricingUpdateUploadInfo , DataTable dataTable)
        {
            PriceUpdateUploadInfo objPricingUpdateUploadInfo = new PriceUpdateUploadInfo();
            List<PriceUpdateUploadDetails> lstPricingUpdateUploadDetails = new List<PriceUpdateUploadDetails>();
            int _upooadedId = 0;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {   
                        cmd.CommandText = "SP_PricingUpdate_Upload_InsertRawData";
                        cmd.CommandType = CommandType.StoredProcedure;
                      
                        cmd.Parameters.AddWithValue("@CreatedBy", pricingUpdateUploadInfo.CreatedBy);
                        cmd.Parameters.AddWithValue("@FileLocation", pricingUpdateUploadInfo.FileLocation);
                        SqlParameter param = new SqlParameter("@PricingUploadDetails", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_PricingUpdate_UploadDetails",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.Add("@UploadHeaderId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        _upooadedId = Convert.ToInt32(cmd.Parameters["@UploadHeaderId"].Value);
                        objPricingUpdateUploadInfo.UploadHeaderId = _upooadedId;
                        objPricingUpdateUploadInfo.Status = Status.Success;
                    }
                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "SP_PricingUpdate_Upload_ProcessData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@UploadHeaderId", objPricingUpdateUploadInfo.UploadHeaderId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        while (reader.Read())
                        {
                            objPricingUpdateUploadInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            PriceUpdateUploadDetails objEntity = new PriceUpdateUploadDetails();
                            objEntity.Udid = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                            objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                            objEntity.SalesContact = Convert.ToString(reader["SalesContact"]);
                            objEntity.ServiceComments = Convert.ToString(reader["ServiceComments"]);
                            objEntity.InternalComments = Convert.ToString(reader["InternalComments"]);
                            objEntity.CustomerPONumber = Convert.ToString(reader["CustomerPONumber"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.SitePostCode = Convert.ToString(reader["SitePostCode"]);
                            objEntity.SiteAccessComments = Convert.ToString(reader["SiteAccessComments"]);
                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.Quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.EstimatedFrequency = Convert.ToString(reader["EstimatedFrequency"]);
                            objEntity.WeightUsage = Convert.ToString(reader["WeightUsage"]);
                            objEntity.PriceUpdateStatus = Convert.ToString(reader["PriceUpdateStatus"]);

                            objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                            objEntity.CustPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalCharge"]);
                            objEntity.CustPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalChargeFrequency"]);
                            objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                            objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                            objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                            objEntity.CustPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["CustPrice_QtyTypeId"]);
                            objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                            objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                            objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                            objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                            objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                            objEntity.CustPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ActualDemurrage"]);
                            objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                            objEntity.ContrPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerlift"]);
                            objEntity.ContrPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalCharge"]);
                            objEntity.ContrPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalChargeFrequency"]);
                            objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                            objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                            objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                            objEntity.ContrPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["ContrPrice_QtyTypeId"]);
                            objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                            objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                            objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                            objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                            objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                            objEntity.ContrPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ActualDemurrage"]);
                            objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.PlannedCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["PlannedCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["PlannedCollectionDate"]);
                            objEntity.PeriodofCollection = Convert.ToString(reader["PeriodofCollection"]);
                            objEntity.ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["ActualCollectionDate"]);

                            lstPricingUpdateUploadDetails.Add(objEntity);
                        }
                        objPricingUpdateUploadInfo.lstPassedPricingUpdateDetail = lstPricingUpdateUploadDetails;
                        lstPricingUpdateUploadDetails = new List<PriceUpdateUploadDetails>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            PriceUpdateUploadDetails objEntity = new PriceUpdateUploadDetails();
                            objEntity.Udid = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                            objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                            objEntity.SalesContact = Convert.ToString(reader["SalesContact"]);
                            objEntity.ServiceComments = Convert.ToString(reader["ServiceComments"]);
                            objEntity.InternalComments = Convert.ToString(reader["InternalComments"]);
                            objEntity.CustomerPONumber = Convert.ToString(reader["CustomerPONumber"]);

                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.SitePostCode = Convert.ToString(reader["SitePostCode"]);
                            objEntity.SiteAccessComments = Convert.ToString(reader["SiteAccessComments"]);
                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.Quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.EstimatedFrequency = Convert.ToString(reader["EstimatedFrequency"]);
                            objEntity.WeightUsage = Convert.ToString(reader["WeightUsage"]);
                            objEntity.PriceUpdateStatus = Convert.ToString(reader["PriceUpdateStatus"]);

                            objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                            objEntity.CustPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalCharge"]);
                            objEntity.CustPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalChargeFrequency"]);
                            objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                            objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                            objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                            objEntity.CustPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["CustPrice_QtyTypeId"]);
                            objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                            objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                            objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                            objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                            objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                            objEntity.CustPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ActualDemurrage"]);
                            objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                            objEntity.ContrPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerlift"]);
                            objEntity.ContrPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalCharge"]);
                            objEntity.ContrPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalChargeFrequency"]);
                            objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                            objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                            objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                            objEntity.ContrPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["ContrPrice_QtyTypeId"]);
                            objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                            objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                            objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                            objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                            objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                            objEntity.ContrPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ActualDemurrage"]);
                            objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.PlannedCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["PlannedCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["PlannedCollectionDate"]);
                            objEntity.PeriodofCollection = Convert.ToString(reader["PeriodofCollection"]);
                            objEntity.ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["ActualCollectionDate"]);

                            lstPricingUpdateUploadDetails.Add(objEntity);
                        }
                        objPricingUpdateUploadInfo.lstFailedPricingUpdateDetail = lstPricingUpdateUploadDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                objPricingUpdateUploadInfo.Status = Status.Failed;
                objPricingUpdateUploadInfo.Message = ex.Message;
            }
            return objPricingUpdateUploadInfo;
        }

        /// <summary>
        /// Database layer method to Pricing Update Upload Update Prices
        /// </summary>
        /// Delivery Point: DP4.8
        public PriceUpdateUploadInfo PricingUpdateUploadUpdatePrices(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            PriceUpdateUploadInfo objPricingUpdateUploadInfo = new PriceUpdateUploadInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PriceUpdateUploadInfo objEntity = new PriceUpdateUploadInfo();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingUpdate_Upload_UpdatePrices]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UploadHeaderId", Convert.ToString(pricingUpdateUploadInfo.UploadHeaderId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objEntity.ActionHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["ActionHeaderId"])) ? 0 : Convert.ToInt32(reader["ActionHeaderId"]);
                                objEntity.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                objEntity.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                    objPricingUpdateUploadInfo = objEntity;
                }

                objPricingUpdateUploadInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingUpdateUploadInfo.Status = Status.Failed;
                objPricingUpdateUploadInfo.Message = ex.Message;
            }
            return objPricingUpdateUploadInfo;
        }

        /// <summary>
        /// Database layer method to Pricing Update Upload Cancel Upload Process
        /// </summary>
        /// Delivery Point: DP4.8
        public PriceUpdateUploadInfo PricingUpdateUploadCancelUploadProcess(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            PriceUpdateUploadInfo objPricingUpdateUploadInfo = new PriceUpdateUploadInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PriceUpdateUploadInfo objEntity = new PriceUpdateUploadInfo();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingUpdate_Upload_CancelUploadProcess]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UploadHeaderId", Convert.ToString(pricingUpdateUploadInfo.UploadHeaderId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objEntity.ReturnId = string.IsNullOrEmpty(Convert.ToString(reader["ReturnId"])) ? 0 : Convert.ToInt32(reader["ReturnId"]);
                                objEntity.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }
                    }
                    objPricingUpdateUploadInfo = objEntity;
                }

                objPricingUpdateUploadInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingUpdateUploadInfo.Status = Status.Failed;
                objPricingUpdateUploadInfo.Message = ex.Message;
            }
            return objPricingUpdateUploadInfo;
        }

        /// <summary>
        /// Database layer method to get all price update action list
        /// </summary>
        /// Delivery Point: DP4.8
        public PriceUpdateUploadInfo GetAllPriceUpdateAction()
        {
            PriceUpdateUploadInfo objPricingUpdateUploadInfo = new PriceUpdateUploadInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<PriceUpdate_ActionHeader> lstEntity = new List<PriceUpdate_ActionHeader>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingUpdate_GetAllPriceUpdateAction]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                PriceUpdate_ActionHeader objEntity = new PriceUpdate_ActionHeader();
                                objEntity.ActionHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["ActionHeaderId"])) ? 0 : Convert.ToInt32(reader["ActionHeaderId"]);
                                objEntity.PriceUpdateActionId = string.IsNullOrEmpty(Convert.ToString(reader["PriceUpdateActionId"])) ? 0 : Convert.ToInt32(reader["PriceUpdateActionId"]);
                                objEntity.ProcessedBy = Convert.ToString(reader["ProcessedBy"]);
                                objEntity.ProcessedOn = string.IsNullOrEmpty(Convert.ToString(reader["ProcessedOn"])) ? new DateTime() : Convert.ToDateTime(reader["ProcessedOn"]);
                                objEntity.PriceUpdateAction = Convert.ToString(reader["PriceUpdateAction"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    objPricingUpdateUploadInfo.lstPriceUpdate_Action = lstEntity;
                }

                objPricingUpdateUploadInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingUpdateUploadInfo.Status = Status.Failed;
                objPricingUpdateUploadInfo.Message = ex.Message;
            }
            return objPricingUpdateUploadInfo;
        }   
        
        /// <summary>
        /// Database layer method to get uploaded by udid
        /// </summary>
        /// Delivery Point: DP4.8
        public PriceUpdateUploadDetails GetUploadedDataByUdid(PriceUpdateUploadDetails priceUpdateUploadDetails)
        {
            PriceUpdateUploadDetails objPricingUpdateUploadInfo = new PriceUpdateUploadDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    PriceUpdateUploadDetails objEntity = new PriceUpdateUploadDetails();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingUpdate_GetUploadedDataByUdid]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Udid", Convert.ToString(priceUpdateUploadDetails.Udid));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                objEntity.Udid = string.IsNullOrEmpty(Convert.ToString(reader["Udid"])) ? 0 : Convert.ToInt32(reader["Udid"]);
                                objEntity.UploadHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["UploadHeaderId"])) ? 0 : Convert.ToInt32(reader["UploadHeaderId"]);
                                objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                                objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                                objEntity.SalesContact = Convert.ToString(reader["SalesContact"]);
                                objEntity.ServiceComments = Convert.ToString(reader["ServiceComments"]);
                                objEntity.InternalComments = Convert.ToString(reader["InternalComments"]);
                                objEntity.CustomerPONumber = Convert.ToString(reader["CustomerPONumber"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.SitePostCode = Convert.ToString(reader["SitePostCode"]);
                                objEntity.SiteAccessComments = Convert.ToString(reader["SiteAccessComments"]);
                                objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objEntity.Quantity = Convert.ToString(reader["Quantity"]);
                                objEntity.EstimatedFrequency = Convert.ToString(reader["EstimatedFrequency"]);
                                objEntity.FrequencyId = string.IsNullOrEmpty(Convert.ToString(reader["FrequencyId"])) ? 0 : Convert.ToInt32(reader["FrequencyId"]);
                                objEntity.WeightUsage = Convert.ToString(reader["WeightUsage"]);
                                objEntity.PriceUpdateStatus = Convert.ToString(reader["PriceUpdateStatus"]);

                                objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                                objEntity.CustPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalCharge"]);
                                objEntity.CustPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalChargeFrequency"]);
                                objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                                objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                                objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                                objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                                objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                                objEntity.CustPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["CustPrice_QtyTypeId"]);
                                objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                                objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                                objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                                objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                                objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                                objEntity.CustPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ActualDemurrage"]);
                                objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                                objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                                objEntity.ContrPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerlift"]);
                                objEntity.ContrPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalCharge"]);
                                objEntity.ContrPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalChargeFrequency"]);
                                objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                                objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                                objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                                objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                                objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                                objEntity.ContrPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["ContrPrice_QtyTypeId"]);
                                objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                                objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                                objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                                objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                                objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                                objEntity.ContrPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ActualDemurrage"]);
                                objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);
                                objEntity.PlannedCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["PlannedCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["PlannedCollectionDate"]);
                                objEntity.PeriodofCollection = Convert.ToString(reader["PeriodofCollection"]);
                                objEntity.ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["ActualCollectionDate"]);
                              

                            }
                        }
                    }
                    objPricingUpdateUploadInfo = objEntity;
                }

                objPricingUpdateUploadInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPricingUpdateUploadInfo.Status = Status.Failed;
                objPricingUpdateUploadInfo.Message = ex.Message;
            }
            return objPricingUpdateUploadInfo;
        }

        /// <summary> 
        /// Database layer method to Update Imported Matrix Prices By Id
        /// </summary>
        /// Delivery Point: DP4.8
        public PriceUpdateUploadDetails UpdateImportedPriceUpdateById(PriceUpdateUploadDetails priceUpdateUploadDetails)
        {
            PriceUpdateUploadDetails objPriceUpdateUploadDetails = new PriceUpdateUploadDetails();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingUpdate_Upload_UpdateImportedPriceUpdateById]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Udid", priceUpdateUploadDetails.Udid);
                        cmd.Parameters.AddWithValue("@ContractorPONumber", priceUpdateUploadDetails.ContractorPONumber);
                        cmd.Parameters.AddWithValue("@CustomerName", priceUpdateUploadDetails.CustomerName);
                        cmd.Parameters.AddWithValue("@SalesContact", priceUpdateUploadDetails.SalesContact);
                        cmd.Parameters.AddWithValue("@ServiceComments", priceUpdateUploadDetails.ServiceComments);
                        cmd.Parameters.AddWithValue("@InternalComments", priceUpdateUploadDetails.InternalComments);
                        cmd.Parameters.AddWithValue("@CustomerPONumber", priceUpdateUploadDetails.CustomerPONumber);
                        cmd.Parameters.AddWithValue("@SiteName", priceUpdateUploadDetails.SiteName);
                        cmd.Parameters.AddWithValue("@SitePostCode", priceUpdateUploadDetails.SitePostCode);
                        cmd.Parameters.AddWithValue("@SiteAccessComments", priceUpdateUploadDetails.SiteAccessComments);
                        cmd.Parameters.AddWithValue("@WasteType", priceUpdateUploadDetails.WasteType);
                        cmd.Parameters.AddWithValue("@WasteTypeId", priceUpdateUploadDetails.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialType", priceUpdateUploadDetails.MaterialType);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", priceUpdateUploadDetails.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@EWCCode", priceUpdateUploadDetails.EWCCode);
                        cmd.Parameters.AddWithValue("@ContainerType", priceUpdateUploadDetails.ContainerType);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", priceUpdateUploadDetails.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSize", priceUpdateUploadDetails.ContainerSize);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", priceUpdateUploadDetails.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@Quantity", priceUpdateUploadDetails.Quantity);
                        cmd.Parameters.AddWithValue("@EstimatedFrequency", priceUpdateUploadDetails.EstimatedFrequency);
                        cmd.Parameters.AddWithValue("@FrequencyId", priceUpdateUploadDetails.FrequencyId);
                        cmd.Parameters.AddWithValue("@WeightUsage", priceUpdateUploadDetails.WeightUsage);
                        cmd.Parameters.AddWithValue("@PriceUpdateStatus", priceUpdateUploadDetails.PriceUpdateStatus);
                        cmd.Parameters.AddWithValue("@CustPrice_PricePerlift", priceUpdateUploadDetails.CustPrice_PricePerlift);
                        cmd.Parameters.AddWithValue("@CustPrice_AdditionalCharge", priceUpdateUploadDetails.CustPrice_AdditionalCharge);
                        cmd.Parameters.AddWithValue("@CustPrice_AdditionalChargeFrequency", priceUpdateUploadDetails.CustPrice_AdditionalChargeFrequency);
                        cmd.Parameters.AddWithValue("@CustPrice_TransportCost", priceUpdateUploadDetails.CustPrice_TransportCost);
                        cmd.Parameters.AddWithValue("@CustPrice_TransportPerQuantity", priceUpdateUploadDetails.CustPrice_TransportPerQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_MinimumTransportCharge", priceUpdateUploadDetails.CustPrice_MinimumTransportCharge);
                        cmd.Parameters.AddWithValue("@CustPrice_PricePerQuantity", priceUpdateUploadDetails.CustPrice_PricePerQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_QuantityType", priceUpdateUploadDetails.CustPrice_QuantityType);
                        cmd.Parameters.AddWithValue("@CustPrice_QtyTypeId", priceUpdateUploadDetails.CustPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@CustPrice_MinimumQuantity", priceUpdateUploadDetails.CustPrice_MinimumQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_MaxQuantity", priceUpdateUploadDetails.CustPrice_MaxQuantity);
                        cmd.Parameters.AddWithValue("@CustPrice_ExcessWeightCharge", priceUpdateUploadDetails.CustPrice_ExcessWeightCharge);
                        cmd.Parameters.AddWithValue("@CustPrice_RentalPerUnit_PerDay", priceUpdateUploadDetails.CustPrice_RentalPerUnit_PerDay);
                        cmd.Parameters.AddWithValue("@CustPrice_DemurragePerHour", priceUpdateUploadDetails.CustPrice_DemurragePerHour);
                        cmd.Parameters.AddWithValue("@CustPrice_ConsignmentNoteCharge_PerVisit", priceUpdateUploadDetails.CustPrice_ConsignmentNoteCharge_PerVisit);
                        cmd.Parameters.AddWithValue("@ContractorName", priceUpdateUploadDetails.ContractorName);
                        cmd.Parameters.AddWithValue("@ContrPrice_CostPerlift", priceUpdateUploadDetails.ContrPrice_CostPerlift);
                        cmd.Parameters.AddWithValue("@ContrPrice_TransportCost", priceUpdateUploadDetails.ContrPrice_TransportCost);
                        cmd.Parameters.AddWithValue("@ContrPrice_TransportPerQuantity", priceUpdateUploadDetails.ContrPrice_TransportPerQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_MinimumTransportCharge", priceUpdateUploadDetails.ContrPrice_MinimumTransportCharge);
                        cmd.Parameters.AddWithValue("@ContrPrice_CostPerQuantity", priceUpdateUploadDetails.ContrPrice_CostPerQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_QuantityType", priceUpdateUploadDetails.ContrPrice_QuantityType);
                        cmd.Parameters.AddWithValue("@ContrPrice_QtyTypeId", priceUpdateUploadDetails.ContrPrice_QtyTypeId);
                        cmd.Parameters.AddWithValue("@ContrPrice_MaxQuantity", priceUpdateUploadDetails.ContrPrice_MaxQuantity);
                        cmd.Parameters.AddWithValue("@ContrPrice_ExcessWeightCharge", priceUpdateUploadDetails.ContrPrice_ExcessWeightCharge);
                        cmd.Parameters.AddWithValue("@ContrPrice_RentalPerUnit_PerDay", priceUpdateUploadDetails.ContrPrice_RentalPerUnit_PerDay);
                        cmd.Parameters.AddWithValue("@ContrPrice_DemurragePerHour", priceUpdateUploadDetails.ContrPrice_DemurragePerHour);
                        cmd.Parameters.AddWithValue("@ContrPrice_ConsignmentNoteCharge_PerVisit", priceUpdateUploadDetails.ContrPrice_ConsignmentNoteCharge_PerVisit);
                        cmd.Parameters.AddWithValue("@PlannedCollectionDate", priceUpdateUploadDetails.PlannedCollectionDate);
                        cmd.Parameters.AddWithValue("@PeriodofCollection", priceUpdateUploadDetails.PeriodofCollection);
                        cmd.Parameters.AddWithValue("@ActualCollectionDate", priceUpdateUploadDetails.ActualCollectionDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", priceUpdateUploadDetails.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objPriceUpdateUploadDetails.Udid = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objPriceUpdateUploadDetails.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objPriceUpdateUploadDetails.Status = Status.Failed;
                objPriceUpdateUploadDetails.Message = ex.Message;
                throw ex;
            }
            return objPriceUpdateUploadDetails;

        }


        /// <summary>
        /// Database layer method to Pricing Update Process Data
        /// </summary>
        /// Delivery Point: DP4.8
        public PriceUpdateUploadInfo PricingUpdateProcessData(PriceUpdateUploadInfo pricingUpdateUploadInfo)
        {
            PriceUpdateUploadInfo objPricingUpdateUploadInfo = new PriceUpdateUploadInfo();
            List<PriceUpdateUploadDetails> lstPricingUpdateUploadDetails = new List<PriceUpdateUploadDetails>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                   
                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "SP_PricingUpdate_Upload_ProcessData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@UploadHeaderId", pricingUpdateUploadInfo.UploadHeaderId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        while (reader.Read())
                        {
                            objPricingUpdateUploadInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            PriceUpdateUploadDetails objEntity = new PriceUpdateUploadDetails();
                            objEntity.Udid = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                            objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                            objEntity.SalesContact = Convert.ToString(reader["SalesContact"]);
                            objEntity.ServiceComments = Convert.ToString(reader["ServiceComments"]);
                            objEntity.InternalComments = Convert.ToString(reader["InternalComments"]);
                            objEntity.CustomerPONumber = Convert.ToString(reader["CustomerPONumber"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.SitePostCode = Convert.ToString(reader["SitePostCode"]);
                            objEntity.SiteAccessComments = Convert.ToString(reader["SiteAccessComments"]);
                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.Quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.EstimatedFrequency = Convert.ToString(reader["EstimatedFrequency"]);
                            objEntity.WeightUsage = Convert.ToString(reader["WeightUsage"]);
                            objEntity.PriceUpdateStatus = Convert.ToString(reader["PriceUpdateStatus"]);

                            objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                            objEntity.CustPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalCharge"]);
                            objEntity.CustPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalChargeFrequency"]);
                            objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                            objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                            objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                            objEntity.CustPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["CustPrice_QtyTypeId"]);
                            objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                            objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                            objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                            objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                            objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                            objEntity.CustPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ActualDemurrage"]);
                            objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                            objEntity.ContrPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerlift"]);
                            objEntity.ContrPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalCharge"]);
                            objEntity.ContrPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalChargeFrequency"]);
                            objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                            objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                            objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                            objEntity.ContrPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["ContrPrice_QtyTypeId"]);
                            objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                            objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                            objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                            objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                            objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                            objEntity.ContrPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ActualDemurrage"]);
                            objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.PlannedCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["PlannedCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["PlannedCollectionDate"]);
                            objEntity.PeriodofCollection = Convert.ToString(reader["PeriodofCollection"]);
                            objEntity.ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["ActualCollectionDate"]);

                            lstPricingUpdateUploadDetails.Add(objEntity);
                        }
                        objPricingUpdateUploadInfo.lstPassedPricingUpdateDetail = lstPricingUpdateUploadDetails;
                        lstPricingUpdateUploadDetails = new List<PriceUpdateUploadDetails>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            PriceUpdateUploadDetails objEntity = new PriceUpdateUploadDetails();
                            objEntity.Udid = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                            objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                            objEntity.SalesContact = Convert.ToString(reader["SalesContact"]);
                            objEntity.ServiceComments = Convert.ToString(reader["ServiceComments"]);
                            objEntity.InternalComments = Convert.ToString(reader["InternalComments"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.SitePostCode = Convert.ToString(reader["SitePostCode"]);
                            objEntity.SiteAccessComments = Convert.ToString(reader["SiteAccessComments"]);
                            objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                            objEntity.Quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.EstimatedFrequency = Convert.ToString(reader["EstimatedFrequency"]);
                            objEntity.WeightUsage = Convert.ToString(reader["WeightUsage"]);
                            objEntity.PriceUpdateStatus = Convert.ToString(reader["PriceUpdateStatus"]);

                            objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                            objEntity.CustPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalCharge"]);
                            objEntity.CustPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalChargeFrequency"]);
                            objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                            objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                            objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                            objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                            objEntity.CustPrice_QuantityType = Convert.ToString(reader["CustPrice_QuantityType"]);
                            objEntity.CustPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["CustPrice_QtyTypeId"]);
                            objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                            objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                            objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                            objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                            objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                            objEntity.CustPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ActualDemurrage"]);
                            objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                            objEntity.ContrPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerlift"]);
                            objEntity.ContrPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalCharge"]);
                            objEntity.ContrPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_AdditionalChargeFrequency"]);
                            objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                            objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                            objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                            objEntity.ContrPrice_QuantityType = Convert.ToString(reader["ContrPrice_QuantityType"]);
                            objEntity.ContrPrice_QtyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_QtyTypeId"])) ? 0 : Convert.ToInt32(reader["ContrPrice_QtyTypeId"]);
                            objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                            objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                            objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                            objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                            objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                            objEntity.ContrPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ActualDemurrage"]);
                            objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);

                            objEntity.PlannedCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["PlannedCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["PlannedCollectionDate"]);
                            objEntity.PeriodofCollection = Convert.ToString(reader["PeriodofCollection"]);
                            objEntity.ActualCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["ActualCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["ActualCollectionDate"]);

                            lstPricingUpdateUploadDetails.Add(objEntity);
                        }
                        objPricingUpdateUploadInfo.lstFailedPricingUpdateDetail = lstPricingUpdateUploadDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                objPricingUpdateUploadInfo.Status = Status.Failed;
                objPricingUpdateUploadInfo.Message = ex.Message;
            }
            return objPricingUpdateUploadInfo;
        }


        #endregion
        #region Update Price Contractor/Customer 
        /// <summary>
        /// Database layer method to Update Price By MatrixId
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixSetup UpdatePrice(PricingMatrixSetup pricingMatrixSetup)
        {
            PricingMatrixSetup pricingInfo = new PricingMatrixSetup();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("[dbo].[SP_PricingMatrix_UpdateMatrixPrices]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixId", pricingMatrixSetup.MatrixId);
                        cmd.Parameters.AddWithValue("@CreatedBy", pricingMatrixSetup.CreatedBy);
                        cmd.Parameters.AddWithValue("@Actiondate", pricingMatrixSetup.EndDate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pricingInfo.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                pricingInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                                pricingInfo.ActionHeaderId= string.IsNullOrEmpty(Convert.ToString(reader["ActionHeaderId"])) ? 0 : Convert.ToInt32(reader["ActionHeaderId"]);

                            }
                        }

                    };
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                pricingInfo.Status = Status.Failed;
                pricingInfo.Message = ex.Message;
                throw ex;
            }
            return pricingInfo;
        }
        /// <summary>
        /// Database layer method to Update Price By MatrixId
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixSetup CheckMatrixHeaderForPriceUpdate(PricingMatrixSetup pricingMatrixSetup)
        {
            PricingMatrixSetup pricingInfo = new PricingMatrixSetup();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("[dbo].[SP_PriceUpdate_CheckMatrixHeaderForPriceUpdate]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MatrixId", pricingMatrixSetup.MatrixId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pricingInfo.ReturnId = Convert.ToInt32(reader["ReturnId"]);
                                pricingInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                            }
                        }

                    };
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                pricingInfo.Status = Status.Failed;
                pricingInfo.Message = ex.Message;
                throw ex;
            }
            return pricingInfo;
        }
        /// <summary>
        /// Database layer method to get price update report
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetPriceUpdate_UpdateReport(PricingMatrixSetup pricingMatrixSetup)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<PriceUpdate_UpdateReport> lstEntity = new List<PriceUpdate_UpdateReport>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetPriceUpdate_UpdateReport]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ActionHeaderId", Convert.ToString(pricingMatrixSetup.ActionHeaderId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PriceUpdate_UpdateReport objEntity = new PriceUpdate_UpdateReport();

                                objEntity.ActionHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["ActionHeaderId"])) ? 0 : Convert.ToInt32(reader["ActionHeaderId"]);
                                objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                                objEntity.JobType = Convert.ToString(reader["JobType"]);
                                objEntity.PriceUpdateStatus = Convert.ToString(reader["PriceUpdateStatus"]);
                                objEntity.ActionDate = string.IsNullOrEmpty(Convert.ToString(reader["ActionDate"])) ? new DateTime() : Convert.ToDateTime(reader["ActionDate"]);
                                objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                                objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                                objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                objEntity.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                objEntity.EstimatedFrequency = Convert.ToString(reader["EstimatedFrequency"]);
                                objEntity.WeightUsage = Convert.ToString(reader["WeightUsage"]);
                                objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                                objEntity.CustPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalCharge"]);
                                objEntity.CustPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalChargeFrequency"]);
                                objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                                objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                                objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                                objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                                objEntity.CustPrice_QtyType = Convert.ToString(reader["CustPrice_QtyType"]);
                                objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                                objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                                objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                                objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                                objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                                objEntity.CustPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ActualDemurrage"]);
                                objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);
                                //objEntity.ContractorName=Convert.ToString(reader["ContractorName"]);
                                objEntity.ContPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContPrice_CostPerlift"]);
                                objEntity.ContPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["ContPrice_AdditionalCharge"]);
                                objEntity.ContPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["ContPrice_AdditionalChargeFrequency"]);
                                objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                                objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                                objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                                objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                                objEntity.ContrPrice_QtyType = Convert.ToString(reader["ContrPrice_QtyType"]);
                                objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                                objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                                objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                                objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                                objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                                objEntity.ContrPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ActualDemurrage"]);
                                objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);
                                objEntity.PlannedCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["PlannedCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["PlannedCollectionDate"]);

                                lstEntity.Add(objEntity);

                            }
                        }
                    }
                    pricingMatrixInfo.lstpriceUpdateReports = lstEntity;
                }
                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }

        /// <summary>
        /// Database layer method to get price update exception report
        /// </summary>
        /// Delivery Point: DP4.8
        public PricingMatrixInfo GetPriceUpdate_ExceptionReport(PricingMatrixSetup pricingMatrixSetup)
        {
            PricingMatrixInfo pricingMatrixInfo = new PricingMatrixInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<PriceUpdate_ExceptionReport> lstEntity = new List<PriceUpdate_ExceptionReport>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_PricingMatrix_GetPriceUpdate_ExceptionReport]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ActionHeaderId", Convert.ToString(pricingMatrixSetup.ActionHeaderId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PriceUpdate_ExceptionReport objEntity = new PriceUpdate_ExceptionReport();

                                objEntity.ActionHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["ActionHeaderId"])) ? 0 : Convert.ToInt32(reader["ActionHeaderId"]);
                                objEntity.ContractorPONumber = Convert.ToString(reader["ContractorPONumber"]);
                                objEntity.JobType = Convert.ToString(reader["JobType"]);
                                objEntity.PriceUpdateStatus = Convert.ToString(reader["PriceUpdateStatus"]);
                                objEntity.ReasonforRejection = Convert.ToString(reader["ReasonforRejection"]);
                                objEntity.CustomerName = Convert.ToString(reader["CustomerName"]);
                                objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.WasteType = Convert.ToString(reader["WasteType"]);
                                objEntity.MaterialType = Convert.ToString(reader["MaterialType"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.ContainerType = Convert.ToString(reader["ContainerType"]);
                                objEntity.ContainerSize = Convert.ToString(reader["ContainerSize"]);
                                objEntity.Quantity = string.IsNullOrEmpty(Convert.ToString(reader["Quantity"])) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                objEntity.EstimatedFrequency = Convert.ToString(reader["EstimatedFrequency"]);
                                objEntity.WeightUsage = Convert.ToString(reader["WeightUsage"]);
                                objEntity.CustPrice_PricePerlift = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerlift"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerlift"]);
                                objEntity.CustPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalCharge"]);
                                objEntity.CustPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["CustPrice_AdditionalChargeFrequency"]);
                                objEntity.CustPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportCost"]);
                                objEntity.CustPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_TransportPerQuantity"]);
                                objEntity.CustPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_MinimumTransportCharge"]);
                                objEntity.CustPrice_PricePerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_PricePerQuantity"])) ? 0 : Convert.ToDecimal(reader["CustPrice_PricePerQuantity"]);
                                objEntity.CustPrice_QtyType = Convert.ToString(reader["CustPrice_QtyType"]);
                                objEntity.CustPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MinimumQuantity"]);
                                objEntity.CustPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["CustPrice_MaxQuantity"]);
                                objEntity.CustPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ExcessWeightCharge"]);
                                objEntity.CustPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["CustPrice_RentalPerUnit_PerDay"]);
                                objEntity.CustPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["CustPrice_DemurragePerHour"]);
                                objEntity.CustPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ActualDemurrage"]);
                                objEntity.CustPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["CustPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["CustPrice_ConsignmentNoteCharge_PerVisit"]);
                                //objEntity.ContractorName=Convert.ToString(reader["ContractorName"]);
                                objEntity.ContPrice_CostPerlift = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_CostPerlift"])) ? 0 : Convert.ToDecimal(reader["ContPrice_CostPerlift"]);
                                objEntity.ContPrice_AdditionalCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_AdditionalCharge"])) ? 0 : Convert.ToDecimal(reader["ContPrice_AdditionalCharge"]);
                                objEntity.ContPrice_AdditionalChargeFrequency = string.IsNullOrEmpty(Convert.ToString(reader["ContPrice_AdditionalChargeFrequency"])) ? 0 : Convert.ToDecimal(reader["ContPrice_AdditionalChargeFrequency"]);
                                objEntity.ContrPrice_TransportCost = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportCost"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportCost"]);
                                objEntity.ContrPrice_TransportPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_TransportPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_TransportPerQuantity"]);
                                objEntity.ContrPrice_MinimumTransportCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumTransportCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_MinimumTransportCharge"]);
                                objEntity.ContrPrice_CostPerQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_CostPerQuantity"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_CostPerQuantity"]);
                                objEntity.ContrPrice_QtyType = Convert.ToString(reader["ContrPrice_QtyType"]);
                                objEntity.ContrPrice_MinimumQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MinimumQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MinimumQuantity"]);
                                objEntity.ContrPrice_MaxQuantity = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_MaxQuantity"])) ? 0 : Convert.ToInt32(reader["ContrPrice_MaxQuantity"]);
                                objEntity.ContrPrice_ExcessWeightCharge = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ExcessWeightCharge"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ExcessWeightCharge"]);
                                objEntity.ContrPrice_RentalPerUnit_PerDay = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_RentalPerUnit_PerDay"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_RentalPerUnit_PerDay"]);
                                objEntity.ContrPrice_DemurragePerHour = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_DemurragePerHour"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_DemurragePerHour"]);
                                objEntity.ContrPrice_ActualDemurrage = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ActualDemurrage"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ActualDemurrage"]);
                                objEntity.ContrPrice_ConsignmentNoteCharge_PerVisit = string.IsNullOrEmpty(Convert.ToString(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"])) ? 0 : Convert.ToDecimal(reader["ContrPrice_ConsignmentNoteCharge_PerVisit"]);
                                objEntity.PlannedCollectionDate = string.IsNullOrEmpty(Convert.ToString(reader["PlannedCollectionDate"])) ? new DateTime() : Convert.ToDateTime(reader["PlannedCollectionDate"]);
                                objEntity.PeriodofCollection= Convert.ToString(reader["PeriodofCollection"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    pricingMatrixInfo.lstPriceUpdateExceptionReport = lstEntity;
                }
                pricingMatrixInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingMatrixInfo.Status = Status.Failed;
                pricingMatrixInfo.Message = ex.Message;
            }
            return pricingMatrixInfo;
        }
       
        #endregion
    }

}
