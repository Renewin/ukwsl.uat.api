using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Facility
{
    public class FacilityRepository : IFacilityRepository
    {
        private string _connectionString;
        public FacilityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #region APIs For Add and Edit Facility Page APIs
        public FacilityBasicInfo CheckFacilityName(FacilityBasicInfo facilityBasicInfo)
        {
            FacilityBasicInfo objFacility = new FacilityBasicInfo();
            try
            {
                objFacility.IsFacilityExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Facility_CheckFacilityName";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityName", facilityBasicInfo.FacilityName);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objFacility.IsFacilityExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objFacility.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacility.Status = Status.Failed;
                objFacility.Message = ex.Message;
                throw ex;
            }
            return objFacility;
        }

        public FacilityInfo GetFacilityType()
        {
            FacilityInfo FacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FacilityType> lstEntity = new List<FacilityType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetFacilityType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FacilityType objEntity = new FacilityType();
                                objEntity.FacilityTypeId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityTypeId"])) ? 0 : Convert.ToInt32(reader["FacilityTypeId"]);
                                objEntity.FacilityType_Name = Convert.ToString(reader["FacilityType_Name"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    FacilityInfo.lstFacilityType = lstEntity;
                }
                FacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                FacilityInfo.Status = Status.Failed;
                FacilityInfo.Message = ex.Message;
            }
            return FacilityInfo;
        }

        public FacilityInfo GetFacilityInfobyFacilityId(FacilityBasicInfo facilityBasicInfo)
        {
            FacilityInfo facilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetFacilityInfobyFacilityId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(facilityBasicInfo.FacilityId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FacilityBasicInfo objEntity = new FacilityBasicInfo();
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.FacilityName = Convert.ToString(reader["FacilityName"]);
                                objEntity.FacilityTypeId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityTypeId"])) ? 0 : Convert.ToInt32(reader["FacilityTypeId"]);
                                objEntity.FacilityOperator = Convert.ToString(reader["FacilityOperator"]);
                                objEntity.PermitNumber = Convert.ToString(reader["PermitNumber"]);
                                objEntity.WasteManagementLicenceNumber = Convert.ToString(reader["WasteManagementLicenceNumber"]);
                                objEntity.ExemptionNumber = Convert.ToString(reader["ExemptionNumber"]);
                                objEntity.ScrapMetalLicenceNumber = Convert.ToString(reader["ScrapMetalLicenceNumber"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objEntity.Town = Convert.ToString(reader["Town"]);
                                objEntity.County = Convert.ToString(reader["County"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.RegionId = string.IsNullOrEmpty(Convert.ToString(reader["RegionId"])) ? 0 : Convert.ToInt32(reader["RegionId"]);
                                objEntity.Country = Convert.ToString(reader["Country"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.Longitude = string.IsNullOrEmpty(Convert.ToString(reader["Longitude"])) ? 0 : Convert.ToDecimal(reader["Longitude"]);
                                objEntity.Latitude = string.IsNullOrEmpty(Convert.ToString(reader["Latitude"])) ? 0 : Convert.ToDecimal(reader["Latitude"]);
                                facilityInfo.facilityBasicInfo = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                FacilityWasteTypePercentage objEntity = new FacilityWasteTypePercentage();
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.WasteTypeName = Convert.ToString(reader["WasteType_Name"]);
                                objEntity.LandfillPercentage = string.IsNullOrEmpty(Convert.ToString(reader["LandfillPercentage"])) ? 0 : Convert.ToDecimal(reader["LandfillPercentage"]);
                                objEntity.RecoveredPercentage = string.IsNullOrEmpty(Convert.ToString(reader["RecoveredPercentage"])) ? 0 : Convert.ToDecimal(reader["RecoveredPercentage"]);
                                objEntity.RecycledPercentage = string.IsNullOrEmpty(Convert.ToString(reader["RecycledPercentage"])) ? 0 : Convert.ToDecimal(reader["RecycledPercentage"]);
                                objEntity.TotalPercentage = string.IsNullOrEmpty(Convert.ToString(reader["TotalPercentage"])) ? 0 : Convert.ToDecimal(reader["TotalPercentage"]);
                                objEntity.FromDate = Convert.ToDateTime(reader["FromDate"]);
                                objEntity.ToDate = reader["ToDate"] == DBNull.Value ? null : (DateTime?)reader["ToDate"];

                                facilityInfo.lstWasteTypePercentage.Add(objEntity);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                FacilityMaterialTypePercentage objEntity = new FacilityMaterialTypePercentage();
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.LandfillPercentage = string.IsNullOrEmpty(Convert.ToString(reader["LandfillPercentage"])) ? 0 : Convert.ToDecimal(reader["LandfillPercentage"]);
                                objEntity.RecoveredPercentage = string.IsNullOrEmpty(Convert.ToString(reader["RecoveredPercentage"])) ? 0 : Convert.ToDecimal(reader["RecoveredPercentage"]);
                                objEntity.RecycledPercentage = string.IsNullOrEmpty(Convert.ToString(reader["RecycledPercentage"])) ? 0 : Convert.ToDecimal(reader["RecycledPercentage"]);
                                objEntity.TotalPercentage = string.IsNullOrEmpty(Convert.ToString(reader["TotalPercentage"])) ? 0 : Convert.ToDecimal(reader["TotalPercentage"]);
                                objEntity.FromDate = Convert.ToDateTime(reader["FromDate"]);
                                objEntity.ToDate = reader["ToDate"] == DBNull.Value ? null : (DateTime?)reader["ToDate"];
                                facilityInfo.lstMaterialTypePercentage.Add(objEntity);
                            }
                        }
                    }
                }
                facilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                facilityInfo.Status = Status.Failed;
                facilityInfo.Message = ex.Message;
            }
            return facilityInfo;
        }

        public FacilityWasteTypeHistory GetWasteTypeHistorybyWasteTypeId(FacilityWasteTypeHistory facilityWasteTypeHistory)
        {
            FacilityWasteTypeHistory ObjFacilityWasteTypeHistory = new FacilityWasteTypeHistory();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetWasteTypeHistorybyWasteTypeId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WasteTypeId", Convert.ToString(facilityWasteTypeHistory.WasteTypeInfo.WasteTypeId));
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(facilityWasteTypeHistory.FacilityBasicInfo.FacilityId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FacilityBasicInfo objEntity = new FacilityBasicInfo();
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.FacilityName = Convert.ToString(reader["FacilityName"]);
                                ObjFacilityWasteTypeHistory.FacilityBasicInfo = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                WasteType objEntity = new WasteType();
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.WasteTypeName = Convert.ToString(reader["WasteType_Name"]);
                                ObjFacilityWasteTypeHistory.WasteTypeInfo = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                FacilityPercentage objEntity = new FacilityPercentage();
                                objEntity.LandfillPercentage = string.IsNullOrEmpty(Convert.ToString(reader["LandfillPercentage"])) ? 0 : Convert.ToDecimal(reader["LandfillPercentage"]);
                                objEntity.RecoveredPercentage = string.IsNullOrEmpty(Convert.ToString(reader["RecoveredPercentage"])) ? 0 : Convert.ToDecimal(reader["RecoveredPercentage"]);
                                objEntity.RecycledPercentage = string.IsNullOrEmpty(Convert.ToString(reader["RecycledPercentage"])) ? 0 : Convert.ToDecimal(reader["RecycledPercentage"]);
                                objEntity.FromDate = Convert.ToDateTime(reader["FromDate"]);
                                objEntity.ToDate = reader["ToDate"] == DBNull.Value ? null : (DateTime?)reader["ToDate"];
                                objEntity.ModifiedByName = Convert.ToString(reader["UpdatedBy"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["UpdatedOn"]);
                                ObjFacilityWasteTypeHistory.lstWasteTypePercentages.Add(objEntity);
                            }
                        }
                    }
                }
                ObjFacilityWasteTypeHistory.Status = Status.Success;
            }
            catch (Exception ex)
            {
                ObjFacilityWasteTypeHistory.Status = Status.Failed;
                ObjFacilityWasteTypeHistory.Message = ex.Message;
            }
            return ObjFacilityWasteTypeHistory;
        }

        public FacilityMaterialTypeHistory GetMaterialTypeHistorybyMaterialTypeId(FacilityMaterialTypeHistory facilityMaterialTypeHistory)
        {
            FacilityMaterialTypeHistory ObjFacilityMaterialTypeHistory = new FacilityMaterialTypeHistory();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetMaterialTypeHistorybyMaterialTypeId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaterialTypeId", Convert.ToString(facilityMaterialTypeHistory.MaterialTypeInfo.MaterialTypeId));
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(facilityMaterialTypeHistory.FacilityBasicInfo.FacilityId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FacilityBasicInfo objEntity = new FacilityBasicInfo();
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.FacilityName = Convert.ToString(reader["FacilityName"]);
                                ObjFacilityMaterialTypeHistory.FacilityBasicInfo = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                MaterialType objEntity = new MaterialType();
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                                ObjFacilityMaterialTypeHistory.MaterialTypeInfo = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                FacilityPercentage objEntity = new FacilityPercentage();
                                objEntity.LandfillPercentage = string.IsNullOrEmpty(Convert.ToString(reader["LandfillPercentage"])) ? 0 : Convert.ToDecimal(reader["LandfillPercentage"]);
                                objEntity.RecoveredPercentage = string.IsNullOrEmpty(Convert.ToString(reader["RecoveredPercentage"])) ? 0 : Convert.ToDecimal(reader["RecoveredPercentage"]);
                                objEntity.RecycledPercentage = string.IsNullOrEmpty(Convert.ToString(reader["RecycledPercentage"])) ? 0 : Convert.ToDecimal(reader["RecycledPercentage"]);
                                objEntity.FromDate = Convert.ToDateTime(reader["FromDate"]);
                                objEntity.ToDate = reader["ToDate"] == DBNull.Value ? null : (DateTime?)reader["ToDate"];
                                objEntity.ModifiedByName = Convert.ToString(reader["UpdatedBy"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["UpdatedOn"]);
                                ObjFacilityMaterialTypeHistory.lstMaterialTypePercentages.Add(objEntity);
                            }
                        }
                    }

                }

                ObjFacilityMaterialTypeHistory.Status = Status.Success;
            }
            catch (Exception ex)
            {
                ObjFacilityMaterialTypeHistory.Status = Status.Failed;
                ObjFacilityMaterialTypeHistory.Message = ex.Message;
            }
            return ObjFacilityMaterialTypeHistory;
        }

        public FacilityBasicInfo AddFacilityInfo(FacilityBasicInfo facility)
        {
            FacilityBasicInfo objFacility = new FacilityBasicInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Facility_InsertFacilityBasicInfo]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", facility.FacilityId);
                        cmd.Parameters.AddWithValue("@FacilityName", facility.FacilityName);
                        cmd.Parameters.AddWithValue("@FacilityTypeId", facility.FacilityTypeId);
                        cmd.Parameters.AddWithValue("@FacilityOperator", facility.FacilityOperator);
                        cmd.Parameters.AddWithValue("@IsActive", facility.IsActive);
                        cmd.Parameters.AddWithValue("@PermitNumber", facility.PermitNumber);
                        cmd.Parameters.AddWithValue("@WasteManagementLicenceNumber", facility.WasteManagementLicenceNumber);
                        cmd.Parameters.AddWithValue("@ExemptionNumber", facility.ExemptionNumber);
                        cmd.Parameters.AddWithValue("@ScrapMetalLicenceNumber", facility.ScrapMetalLicenceNumber);
                        cmd.Parameters.AddWithValue("@AddressLine1", facility.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", facility.AddressLine2);
                        cmd.Parameters.AddWithValue("@Town", facility.Town);
                        cmd.Parameters.AddWithValue("@County", facility.County);
                        cmd.Parameters.AddWithValue("@Postcode", facility.Postcode);
                        cmd.Parameters.AddWithValue("@RegionId", facility.RegionId);
                        cmd.Parameters.AddWithValue("@Country", facility.Country);
                        cmd.Parameters.AddWithValue("@CreatedBy", facility.CreatedBy);
                        cmd.Parameters.AddWithValue("@Longitude", facility.Longitude);
                        cmd.Parameters.AddWithValue("@Latitude", facility.Latitude);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objFacility.FacilityId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objFacility.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacility.Status = Status.Failed;
                objFacility.Message = ex.Message;
                throw ex;
            }
            return objFacility;
        }

        public FacilityInfo AddUpdateWasteTypePercentage(FacilityInfo facilityInfo, DataTable dataTable)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_InsertUpdateWasteTypePercentage]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@FacilityWasteTypePer", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_Facility_WasteTypePercentage",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@CreatedBy", facilityInfo.facilityBasicInfo.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
            }
            return objFacilityInfo;
        }

        public FacilityInfo InsertUpdateMaterialTypePercentage(FacilityInfo facilityInfo, DataTable dataTable)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_InsertUpdateMaterialTypePercentage]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@FacilityMaterialTypePer", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_Facility_MaterialTypePercentage",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@CreatedBy", facilityInfo.facilityBasicInfo.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
            }
            return objFacilityInfo;
        }
        #endregion

        #region Facility Dashboard
        public FacilityInfo GetAllFacilityList()
        {
            FacilityInfo facilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FacilityBasicInfo> lstEntity = new List<FacilityBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetAllFacilityList]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FacilityBasicInfo objEntity = new FacilityBasicInfo();
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.FacilityStatus = Convert.ToString(reader["Status"]);
                                objEntity.FacilityName = Convert.ToString(reader["FacilityName"]);
                                objEntity.FacilityType_Name = Convert.ToString(reader["FacilityType_Name"]);
                                objEntity.FacilityOperator = Convert.ToString(reader["FacilityOperator"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.NoofContractor = string.IsNullOrEmpty(Convert.ToString(reader["NoofContractor"])) ? 0 : Convert.ToInt32(reader["NoofContractor"]);
                                objEntity.WasteManagementLicenceNumber = Convert.ToString(reader["WasteManagementLicenceNumber"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objEntity.Town = Convert.ToString(reader["Town"]);
                                objEntity.County = Convert.ToString(reader["County"]);
                                objEntity.Country = Convert.ToString(reader["Country"]);                                
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.Longitude = string.IsNullOrEmpty(Convert.ToString(reader["Longitude"])) ? 0 : Convert.ToDecimal(reader["Longitude"]);
                                objEntity.Latitude = string.IsNullOrEmpty(Convert.ToString(reader["Latitude"])) ? 0 : Convert.ToDecimal(reader["Latitude"]);

                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    facilityInfo.lstFacilityBasicInfo = lstEntity;
                }
                facilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                facilityInfo.Status = Status.Failed;
                facilityInfo.Message = ex.Message;
            }
            return facilityInfo;
        }

        public FacilityInfo GetCountbyFacilityType()
        {
            FacilityInfo facilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FacilityBasicInfo> lstEntity = new List<FacilityBasicInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetCountbyFacilityType]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FacilityBasicInfo objEntity = new FacilityBasicInfo();
                                objEntity.FacilityTypeId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityTypeId"])) ? 0 : Convert.ToInt32(reader["FacilityTypeId"]);
                                objEntity.FacilityType_Name = Convert.ToString(reader["FacilityType_Name"]);
                                objEntity.TotalFacilities = string.IsNullOrEmpty(Convert.ToString(reader["TotalFacilities"])) ? 0 : Convert.ToInt32(reader["TotalFacilities"]);
                                objEntity.Percentage = string.IsNullOrEmpty(Convert.ToString(reader["Percentage"])) ? 0 : Convert.ToDecimal(reader["Percentage"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    facilityInfo.lstFacilityTypeCount = lstEntity;
                }
                facilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                facilityInfo.Status = Status.Failed;
                facilityInfo.Message = ex.Message;
            }
            return facilityInfo;
        }

        public FacilityInfo GetOverviewDetails()
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetOverviewDetails]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objFacilityInfo.TotalFacility = string.IsNullOrEmpty(Convert.ToString(reader["TotalFacility"])) ? 0 : Convert.ToInt32(reader["TotalFacility"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                objFacilityInfo.ContractorWithoutFacilities = string.IsNullOrEmpty(Convert.ToString(reader["ContractorWithoutFacilities"])) ? 0 : Convert.ToInt32(reader["ContractorWithoutFacilities"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                objFacilityInfo.FacilitiesWithoutContractor = string.IsNullOrEmpty(Convert.ToString(reader["FacilitiesWithoutContractor"])) ? 0 : Convert.ToInt32(reader["FacilitiesWithoutContractor"]); Convert.ToString(reader["FacilitiesWithoutContractor"]);
                            }
                        }

                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
            }
            return objFacilityInfo;
        }

        #endregion

        #region Facility Contractor Allocation
        public FacilityInfo GetNonAllocatedContractorsByFacilityId(FacilityAllocatedContractors allocatedContractors)
        {
            FacilityInfo facilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Contractor> lstEntity = new List<Contractor>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetNonAllocatedContractorsByFacilityId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(allocatedContractors.FacilityId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contractor objEntity = new Contractor();
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    facilityInfo.lstContractors = lstEntity;
                }
                facilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                facilityInfo.Status = Status.Failed;
                facilityInfo.Message = ex.Message;
            }
            return facilityInfo;
        }

        public FacilityInfo GetAllocatedContractorsByFacilityId(FacilityAllocatedContractors allocatedContractors)
        {
            FacilityInfo facilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FacilityAllocatedContractors> lstEntity = new List<FacilityAllocatedContractors>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetAllocatedContractorsByFacilityId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(allocatedContractors.FacilityId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FacilityAllocatedContractors objEntity = new FacilityAllocatedContractors();
                                objEntity.ContractorAllocationId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorAllocationId"])) ? 0 : Convert.ToInt32(reader["ContractorAllocationId"]);
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                                objEntity.Address = Convert.ToString(reader["Address"]);
                                objEntity.ActiveDepots = string.IsNullOrEmpty(Convert.ToString(reader["ActiveDepots"])) ? 0 : Convert.ToInt32(reader["ActiveDepots"]);
                                objEntity.Warning = string.IsNullOrEmpty(Convert.ToString(reader["Warning"])) ? 0 : Convert.ToInt32(reader["Warning"]);
                                objEntity.CanDelete = string.IsNullOrEmpty(Convert.ToString(reader["CanDelete"])) ? 0 : Convert.ToInt32(reader["CanDelete"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    facilityInfo.lstAllocatedContractors = lstEntity;
                }
                facilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                facilityInfo.Status = Status.Failed;
                facilityInfo.Message = ex.Message;
            }
            return facilityInfo;
        }

        public FacilityInfo InsertContractorAllocation(FacilityAllocatedContractors allocatedContractors)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Facility_InsertContractorAllocation]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", allocatedContractors.FacilityId);
                        cmd.Parameters.AddWithValue("@Contractors", allocatedContractors.ContractorIds);
                        cmd.Parameters.AddWithValue("@CreatedBy", allocatedContractors.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
                throw ex;
            }
            return objFacilityInfo;
        }

        public FacilityInfo RemoveContractorAllocation(FacilityAllocatedContractors allocatedContractors)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Facility_RemoveContractorAllocation]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", allocatedContractors.FacilityId);
                        cmd.Parameters.AddWithValue("@Contractors", allocatedContractors.ContractorIds);
                        cmd.ExecuteNonQuery();
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
                throw ex;
            }
            return objFacilityInfo;
        }
        #endregion

        #region Facility Depot Allocation
        public FacilityInfo GetNonAllocatedDepotsByContractorId(ContractorDepots contractorDepots)
        {
            FacilityInfo facilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorDepots> lstEntity = new List<ContractorDepots>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetNonAllocatedDepotsByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(contractorDepots.FacilityId));
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractorDepots.ContractorId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorDepots objEntity = new ContractorDepots();
                                objEntity.Contractor_DepotID = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_DepotID"])) ? 0 : Convert.ToInt32(reader["Contractor_DepotID"]);
                                objEntity.DepotName = Convert.ToString(reader["DepotName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    facilityInfo.lstContractorDepots = lstEntity;
                }
                facilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                facilityInfo.Status = Status.Failed;
                facilityInfo.Message = ex.Message;
            }
            return facilityInfo;
        }

        public FacilityInfo GetAllocatedDepotsByContractorId(ContractorDepots contractorDepots)
        {
            FacilityInfo facilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContractorDepots> lstEntity = new List<ContractorDepots>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetAllocatedDepotsByContractorId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(contractorDepots.FacilityId));
                        cmd.Parameters.AddWithValue("@ContractorId", Convert.ToString(contractorDepots.ContractorId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContractorDepots objEntity = new ContractorDepots();
                                objEntity.ContractorDepotAllocationId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorDepotAllocationId"])) ? 0 : Convert.ToInt32(reader["ContractorDepotAllocationId"]);
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.ContractorId = string.IsNullOrEmpty(Convert.ToString(reader["ContractorId"])) ? 0 : Convert.ToInt32(reader["ContractorId"]);
                                objEntity.Contractor_DepotID = string.IsNullOrEmpty(Convert.ToString(reader["Contractor_DepotID"])) ? 0 : Convert.ToInt32(reader["Contractor_DepotID"]);
                                objEntity.DepotName = Convert.ToString(reader["DepotName"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                                objEntity.Town = Convert.ToString(reader["Town"]);
                                objEntity.County = Convert.ToString(reader["County"]);
                                objEntity.Postcode = Convert.ToString(reader["Postcode"]);
                                objEntity.Country = Convert.ToString(reader["Country"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.CanDelete = string.IsNullOrEmpty(Convert.ToString(reader["CanDelete"])) ? 0 : Convert.ToInt32(reader["CanDelete"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    facilityInfo.lstAllocatedContractorDepots = lstEntity;
                }
                facilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                facilityInfo.Status = Status.Failed;
                facilityInfo.Message = ex.Message;
            }
            return facilityInfo;
        }

        public FacilityInfo InsertDepotAllocation(ContractorDepots contractorDepots)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Facility_InsertDepotAllocation]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", contractorDepots.FacilityId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractorDepots.ContractorId);
                        cmd.Parameters.AddWithValue("@Depots", contractorDepots.Contractor_DepotIDs);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractorDepots.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
                throw ex;
            }
            return objFacilityInfo;
        }

        public FacilityInfo RemoveDepotAllocation(ContractorDepots contractorDepots)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Facility_RemoveDepotAllocation]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", contractorDepots.FacilityId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractorDepots.ContractorId);
                        cmd.Parameters.AddWithValue("@Depots", contractorDepots.Contractor_DepotIDs);
                        cmd.ExecuteNonQuery();
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
                throw ex;
            }
            return objFacilityInfo;
        }
        #endregion

        #region Facility Licence Documents
        public FacilityInfo GetDocumentTypesByFacilityId(DocumentInfo documentInfo)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetDocumentTypesByFacility]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(documentInfo.FacilityId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DocumentInfo objEntity = new DocumentInfo();
                                objEntity.DocumentTypeId = string.IsNullOrEmpty(Convert.ToString(reader["LicenceDocumentTypeId"])) ? 0 : Convert.ToInt32(reader["LicenceDocumentTypeId"]);
                                objEntity.DocumentTypeName = Convert.ToString(reader["LicenceDocumentType"]);
                                objEntity.NoofDocuments = string.IsNullOrEmpty(Convert.ToString(reader["TotalDocuments"])) ? 0 : Convert.ToInt32(reader["TotalDocuments"]);
                                objEntity.FacilityDocumentStatus = Convert.ToString(reader["Status"]);
                                objFacilityInfo.lstFacilityDocumentTypes.Add(objEntity);
                            }
                        }
                    }

                }

                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
            }
            return objFacilityInfo;
        }

        public FacilityInfo GetLicenceDocumentsByDocumentTypeId(DocumentInfo documentInfo)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetLicenceDocumentsByDocumentTypeId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LicenceDocumentTypeId", Convert.ToString(documentInfo.DocumentTypeId));
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(documentInfo.FacilityId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DocumentType objEntity = new DocumentType();
                                objEntity.DocumentTypeId = string.IsNullOrEmpty(Convert.ToString(reader["LicenceDocumentTypeId"])) ? 0 : Convert.ToInt32(reader["LicenceDocumentTypeId"]);
                                objEntity.DocumentTypeName = Convert.ToString(reader["LicenceDocumentType"]);
                                objFacilityInfo.FacilityDocumentType = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                DocumentInfo objEntity = new DocumentInfo();
                                objEntity.Facility_LicenceDocumentId = string.IsNullOrEmpty(Convert.ToString(reader["Facility_LicenceDocumentId"])) ? 0 : Convert.ToInt32(reader["Facility_LicenceDocumentId"]);
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.DocumentTypeId = string.IsNullOrEmpty(Convert.ToString(reader["LicenceDocumentTypeId"])) ? 0 : Convert.ToInt32(reader["LicenceDocumentTypeId"]);
                                objEntity.LicenceNo = Convert.ToString(reader["LicenceNo"]);
                                objEntity.DocDescription = Convert.ToString(reader["LicenceDocDescription"]);
                                objEntity.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);
                                objEntity.WebSiteURL = Convert.ToString(reader["WebSiteURL"]);
                                objEntity.SharePointId = string.IsNullOrEmpty(Convert.ToString(reader["SharePointId"])) ? 0 : Convert.ToInt32(reader["SharePointId"]);
                                objEntity.FileReference = Convert.ToString(reader["FileReference"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.FacilityDocumentStatus = Convert.ToString(reader["Status"]);
                                objEntity.CreatedByName = Convert.ToString(reader["UploadedBy"]);
                                objEntity.CreatedOn = Convert.ToDateTime(reader["UploadedOn"]);
                                objFacilityInfo.lstFacilityDocuments.Add(objEntity);
                            }
                        }
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
            }
            return objFacilityInfo;
        }

        public FacilityInfo GetLicenceDocumentsArchivedByDocumentTypeId(DocumentInfo documentInfo)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_GetLicenceDocumentsArchivedByDocumentTypeId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LicenceDocumentTypeId", Convert.ToString(documentInfo.DocumentTypeId));
                        cmd.Parameters.AddWithValue("@FacilityId", Convert.ToString(documentInfo.FacilityId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DocumentType objEntity = new DocumentType();
                                objEntity.DocumentTypeId = string.IsNullOrEmpty(Convert.ToString(reader["LicenceDocumentTypeId"])) ? 0 : Convert.ToInt32(reader["LicenceDocumentTypeId"]);
                                objEntity.DocumentTypeName = Convert.ToString(reader["LicenceDocumentType"]);
                                objFacilityInfo.FacilityDocumentType = objEntity;
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                DocumentInfo objEntity = new DocumentInfo();
                                objEntity.Facility_LicenceDocumentId = string.IsNullOrEmpty(Convert.ToString(reader["Id"])) ? 0 : Convert.ToInt32(reader["Id"]);
                                objEntity.FacilityId = string.IsNullOrEmpty(Convert.ToString(reader["FacilityId"])) ? 0 : Convert.ToInt32(reader["FacilityId"]);
                                objEntity.DocumentTypeId = string.IsNullOrEmpty(Convert.ToString(reader["LicenceDocumentTypeId"])) ? 0 : Convert.ToInt32(reader["LicenceDocumentTypeId"]);
                                objEntity.LicenceNo = Convert.ToString(reader["LicenceNo"]);
                                objEntity.DocDescription = Convert.ToString(reader["LicenceDocDescription"]);
                                objEntity.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);
                                objEntity.SharePointId = string.IsNullOrEmpty(Convert.ToString(reader["SharePointId"])) ? 0 : Convert.ToInt32(reader["SharePointId"]);
                                objEntity.FileReference = Convert.ToString(reader["FileReference"]);
                                objEntity.CreatedByName = Convert.ToString(reader["UploadedBy"]);
                                objEntity.CreatedOn = Convert.ToDateTime(reader["UploadedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["ArchivedBy"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["ArchivedOn"]);
                                objFacilityInfo.lstFacilityArchivedDocuments.Add(objEntity);
                            }
                        }
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
            }
            return objFacilityInfo;
        }

        public FacilityInfo InsertFacilityDocument(DocumentInfo documentInfo)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_InsertFacilityDocument]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", documentInfo.FacilityId);
                        cmd.Parameters.AddWithValue("@LicenceDocumentTypeId", documentInfo.DocumentTypeId);
                        cmd.Parameters.AddWithValue("@LicenceNo", documentInfo.LicenceNo);
                        cmd.Parameters.AddWithValue("@LicenceDocDescription", documentInfo.DocDescription);
                        cmd.Parameters.AddWithValue("@ExpiryDate", (documentInfo.ExpiryDate == null || documentInfo.ExpiryDate == new DateTime()) ? SqlDateTime.MinValue.Value : documentInfo.ExpiryDate);
                        cmd.Parameters.AddWithValue("@WebSiteURL", documentInfo.WebSiteURL);
                        cmd.Parameters.AddWithValue("@SharePointId", documentInfo.SharePointId);
                        cmd.Parameters.AddWithValue("@FileReference", documentInfo.FileReference);
                        cmd.Parameters.AddWithValue("@CreatedBy", documentInfo.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objFacilityInfo.FacilityDocumentInfo.Facility_LicenceDocumentId = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
                throw ex;
            }
            return objFacilityInfo;
        }

        public FacilityInfo DeleteLicenceDocumentById(DocumentInfo documentInfo)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_DeleteLicenceDocumentById]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Facility_LicenceDocumentId", documentInfo.Facility_LicenceDocumentId);
                        cmd.Parameters.AddWithValue("@FacilityId", documentInfo.FacilityId);
                        cmd.Parameters.AddWithValue("@CreatedBy", documentInfo.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
                throw ex;
            }
            return objFacilityInfo;
        }

        public FacilityInfo DeleteLicenceDocumentsByDocumentTypeId(DocumentInfo documentInfo)
        {
            FacilityInfo objFacilityInfo = new FacilityInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_Facility_DeleteLicenceDocumentsByDocumentTypeId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LicenceDocumentTypeId", documentInfo.DocumentTypeId);
                        cmd.Parameters.AddWithValue("@FacilityId", documentInfo.FacilityId);
                        cmd.Parameters.AddWithValue("@CreatedBy", documentInfo.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                objFacilityInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objFacilityInfo.Status = Status.Failed;
                objFacilityInfo.Message = ex.Message;
                throw ex;
            }
            return objFacilityInfo;
        }

        #endregion
    }

}