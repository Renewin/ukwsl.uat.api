using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.ScheduleofServices
{
    public class ScheduleOfServiceRepository : IScheduleOfServiceRepository
    {

        private string _connectionString;
        public ScheduleOfServiceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SOSInfo CreateScheduleofService(ScheduleofService scheduleofServices)
        {

            SOSInfo sOSInfo = new SOSInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_InsertScheduleofServices";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", scheduleofServices.DealId);
                        cmd.Parameters.AddWithValue("@SiteId", scheduleofServices.SiteId);
                        cmd.Parameters.AddWithValue("@WasteTypeId", scheduleofServices.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", scheduleofServices.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@EWCCode", scheduleofServices.EWCCode);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", scheduleofServices.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", scheduleofServices.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@QtyTypeId", scheduleofServices.QuantityTypeId);
                        cmd.Parameters.AddWithValue("@AssumedContainerWeight", scheduleofServices.AverageContainerWeightTonnes);
                        cmd.Parameters.AddWithValue("@Quantity", scheduleofServices.Quantity);
                        cmd.Parameters.AddWithValue("@FrequencyTypeId", scheduleofServices.FrequencyTypeId);
                        cmd.Parameters.AddWithValue("@EstimatedFrequency", scheduleofServices.FrequencyId);
                        cmd.Parameters.AddWithValue("@Comments", scheduleofServices.Comments == null ? "" : scheduleofServices.Comments);
                        cmd.Parameters.AddWithValue("@CreatedBy", scheduleofServices.CreatedBy);
                        cmd.Parameters.Add("@ResultHeaderID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        ScheduleofService objscheduleofService = new ScheduleofService();
                        objscheduleofService.SOSHeaderId = Convert.ToInt32(cmd.Parameters["@ResultHeaderID"].Value);
                        sOSInfo.scheduleofServices = objscheduleofService;
                    }
                }
                sOSInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                sOSInfo.Status = Status.Failed;
                sOSInfo.Message = ex.Message;
                throw ex;
            }

            return sOSInfo;
        }


        public SOSInfo UpdateScheduleofService(ScheduleofService scheduleofServices)
        {
            SOSInfo sOSInfo = new SOSInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_UpdateScheduleofServices";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SOSId", scheduleofServices.SOSId);
                        cmd.Parameters.AddWithValue("@DealId", scheduleofServices.DealId);
                        cmd.Parameters.AddWithValue("@SiteId", scheduleofServices.SiteId);
                        cmd.Parameters.AddWithValue("@WasteTypeId", scheduleofServices.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", scheduleofServices.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@EWCCode", scheduleofServices.EWCCode);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", scheduleofServices.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", scheduleofServices.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@QtyTypeId", scheduleofServices.QuantityTypeId);
                        cmd.Parameters.AddWithValue("@AssumedContainerWeight", scheduleofServices.AverageContainerWeightTonnes);
                        cmd.Parameters.AddWithValue("@Quantity", scheduleofServices.Quantity);
                        cmd.Parameters.AddWithValue("@FrequencyTypeId", scheduleofServices.FrequencyTypeId);
                        cmd.Parameters.AddWithValue("@EstimatedFrequency", scheduleofServices.FrequencyId);
                        cmd.Parameters.AddWithValue("@Comments", scheduleofServices.Comments == null ? "" : scheduleofServices.Comments);
                        cmd.Parameters.AddWithValue("@CreatedBy", scheduleofServices.CreatedBy);
                        cmd.ExecuteNonQuery();
                        ScheduleofService objscheduleofService = new ScheduleofService();
                        sOSInfo.scheduleofServices = objscheduleofService;
                    }
                }
                sOSInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                sOSInfo.Status = Status.Failed;
                sOSInfo.Message = ex.Message;
                throw ex;
            }

            return sOSInfo;
        }

        public SOSInfo GetScheduleofService(ScheduleofService scheduleofServices)
        {
            SOSInfo sOSInfo = new SOSInfo();
            List<ScheduleService> lstEntity = new List<ScheduleService>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetSOSByDeal_HeaderId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", Convert.ToString(scheduleofServices.DealId));
                        cmd.Parameters.AddWithValue("@SOSHeaderId", Convert.ToString(scheduleofServices.SOSHeaderId));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ScheduleService objEntity = new ScheduleService();
                            objEntity.SOSId = string.IsNullOrEmpty(Convert.ToString(reader["SOSId"])) ? 0 : Convert.ToInt32(reader["SOSId"]);
                            objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                            objEntity.Address_line1 = Convert.ToString(reader["Address_line1"]);
                            objEntity.Address_line2 = Convert.ToString(reader["Address_line2"]);
                            objEntity.Town = Convert.ToString(reader["Town"]);
                            objEntity.County = Convert.ToString(reader["County"]);
                            objEntity.Region = Convert.ToString(reader["Region"]);
                            objEntity.Country = Convert.ToString(reader["Country"]);
                            objEntity.WasteTypeName = Convert.ToString(reader["WasteType_Name"]);
                            objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                            objEntity.ContainerTypeName = Convert.ToString(reader["ContainerType_Name"]);
                            objEntity.ContainerSizeName = Convert.ToString(reader["ContainerSize_Name"]);
                            objEntity.QuantityTypeName = Convert.ToString(reader["QuantityTypeName"]);
                            objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                            objEntity.Quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.FrequencyTypeName = Convert.ToString(reader["FrequencyType_Name"]);
                            objEntity.FrequencyName = Convert.ToString(reader["Frequency_Name"]);
                            objEntity.AverageContainerWeightTonnes = Convert.ToString(reader["AssumedContainerWeight"]);
                            objEntity.Comment = Convert.ToString(reader["Comments"]);
                            lstEntity.Add(objEntity);
                        }
                        reader.Close();


                    }
                    sOSInfo.lstScheduleService = lstEntity;
                }
                sOSInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                sOSInfo.Status = Status.Failed;
                sOSInfo.Message = ex.Message;
            }

            return sOSInfo;


        }

        public SOSInfo GetSOSHeaderByDeal(ScheduleofService scheduleofService)
        {
            SOSInfo sOSInfo = new SOSInfo();
            List<SOSHeader> lstEntity = new List<SOSHeader>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetSOSHeaderByDeal]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", Convert.ToString(scheduleofService.DealId));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            SOSHeader objEntity = new SOSHeader();
                            objEntity.SOSHeaderId = string.IsNullOrEmpty(Convert.ToString(reader["SOS_HeaderId"])) ? 0 : Convert.ToInt32(reader["SOS_HeaderId"]);
                            objEntity.SOSHeaderName = Convert.ToString(reader["SOSHeader_Name"]);
                            lstEntity.Add(objEntity);
                        }
                        reader.Close();


                    }
                    sOSInfo.lstSOSHeader = lstEntity;
                }
                sOSInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                sOSInfo.Status = Status.Failed;
                sOSInfo.Message = ex.Message;
            }

            return sOSInfo;
        }

        public SOSInfo CheckScheduleofServices(ScheduleofService scheduleofServices)
        {
            SOSInfo sOSInfo = new SOSInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_CheckScheduleofServices";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", scheduleofServices.DealId);
                        cmd.Parameters.AddWithValue("@SiteId", scheduleofServices.SiteId);
                        cmd.Parameters.AddWithValue("@WasteTypeId", scheduleofServices.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", scheduleofServices.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", scheduleofServices.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", scheduleofServices.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@Quantity", scheduleofServices.Quantity);
                        cmd.Parameters.AddWithValue("@FrequencyId", scheduleofServices.FrequencyId);
                        cmd.Parameters.AddWithValue("@PricingMethodId", scheduleofServices.PricingMethodId);
                        cmd.Parameters.AddWithValue("@CreatedBy", scheduleofServices.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        ScheduleofService objscheduleofService = new ScheduleofService();
                        objscheduleofService.IsSOSExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                        sOSInfo.scheduleofServices = objscheduleofService;
                    }
                }
                sOSInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                sOSInfo.Status = Status.Failed;
                sOSInfo.Message = ex.Message;
                throw ex;
            }

            return sOSInfo;
        }

        public SOSInfo UploadCSVRawData(ScheduleofService scheduleofService, SOSFileDetails sOSFileDetails, DataTable dataTable)
        {
            SOSInfo sOSInfo = new SOSInfo();
            int _upooadedId = 0;
            List<ScheduleService> lstScheduleService = new List<ScheduleService>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOSUpload_InsertCSVRawData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@CSVData", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_SOSUplaod",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@SOSUploadFileName", sOSFileDetails.FileName);
                        cmd.Parameters.AddWithValue("@SOSUpload_FileLocation", sOSFileDetails.FileLocation);
                        cmd.Parameters.AddWithValue("@SOS_Headerid", scheduleofService.SOSHeaderId);
                        cmd.Parameters.AddWithValue("@CreatedBy", scheduleofService.CreatedBy);
                        cmd.Parameters.Add("@SOS_UploadId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        _upooadedId = Convert.ToInt32(cmd.Parameters["@SOS_UploadId"].Value);
                        sOSInfo.SOSUploadId = _upooadedId;
                        sOSInfo.Status = Status.Success;
                    }

                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "sp_SOSUpload_ProcessCSVData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@SOS_UploadId", _upooadedId);
                        cmd1.Parameters.AddWithValue("@SOS_HeaderId", scheduleofService.SOSHeaderId);
                        cmd1.CommandTimeout = 600;
                        SqlDataReader reader = cmd1.ExecuteReader();

                        while (reader.Read())
                        {
                            sOSInfo.Message = Convert.ToString(reader["ReturnMsg"]);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ScheduleService objEntity = new ScheduleService();
                            //objEntity.TempSOSId = Convert.ToInt32(reader["TempSOSId"]);
                            objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.Address_line1 = Convert.ToString(reader["Address_line1"]);
                            objEntity.Address_line2 = Convert.ToString(reader["Address_line2"]);
                            objEntity.Town = Convert.ToString(reader["Town"]);
                            objEntity.County = Convert.ToString(reader["County"]);
                            objEntity.Region = Convert.ToString(reader["Region"]);
                            objEntity.PostCode = Convert.ToString(reader["Postcode"]);
                            objEntity.WasteTypeName = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerTypeName = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSizeName = Convert.ToString(reader["ContainerSize"]);
                            objEntity.QuantityTypeName = Convert.ToString(reader["CustomerQuantityType"]);
                            objEntity.AverageContainerWeightTonnes = Convert.ToString(reader["AssumedContainerWeight"]);
                            objEntity.Quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.FrequencyTypeName = Convert.ToString(reader["FrequencyType"]);
                            objEntity.FrequencyName = Convert.ToString(reader["EstimatedFrequency"]);
                            objEntity.Comment = Convert.ToString(reader["Comments"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            lstScheduleService.Add(objEntity);
                        }
                        sOSInfo.lstPassedScheduleService = lstScheduleService;
                        lstScheduleService = new List<ScheduleService>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ScheduleService objEntity = new ScheduleService();
                            //objEntity.TempSOSId = Convert.ToInt32(reader["TempSOSId"]);
                            objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.Address_line1 = Convert.ToString(reader["Address_line1"]);
                            objEntity.Address_line2 = Convert.ToString(reader["Address_line2"]);
                            objEntity.Town = Convert.ToString(reader["Town"]);
                            objEntity.County = Convert.ToString(reader["County"]);
                            objEntity.Region = Convert.ToString(reader["Region"]);
                            objEntity.PostCode = Convert.ToString(reader["Postcode"]);
                            objEntity.WasteTypeName = Convert.ToString(reader["WasteType"]);
                            objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType"]);
                            objEntity.ContainerTypeName = Convert.ToString(reader["ContainerType"]);
                            objEntity.ContainerSizeName = Convert.ToString(reader["ContainerSize"]);
                            objEntity.QuantityTypeName = Convert.ToString(reader["CustomerQuantityType"]);
                            objEntity.AverageContainerWeightTonnes = Convert.ToString(reader["AssumedContainerWeight"]);
                            objEntity.Quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.FrequencyTypeName = Convert.ToString(reader["FrequencyType"]);
                            objEntity.FrequencyName = Convert.ToString(reader["EstimatedFrequency"]);
                            objEntity.Comment = Convert.ToString(reader["Comments"]);
                            objEntity.UploadComment = Convert.ToString(reader["UploadComment"]);
                            lstScheduleService.Add(objEntity);
                        }
                        sOSInfo.lstFailedScheduleService = lstScheduleService;
                    }


                }

            }
            catch (Exception ex)
            {
                sOSInfo.Status = Status.Failed;
                sOSInfo.Message = ex.Message;
            }

            return sOSInfo;
        }


        public SOSInfo InsertUploadedData(SOSInfo sOSInfo)
        {
            SOSInfo objEntity = new SOSInfo();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "sp_SOSUpload_InsertProcessedData";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SOS_UploadId", sOSInfo.SOSUploadId);
                    cmd.Parameters.AddWithValue("@SOS_HeaderId", sOSInfo.SOSHeaderId);
                    cmd.Parameters.AddWithValue("@CreatedBy", sOSInfo.CreatedBy);
                    cmd.ExecuteNonQuery();
                    sOSInfo.Status = Status.Success;
                }
            }
            return objEntity;

        }

        public SOSInfo GetScheduleofServiceBySosId(ScheduleofService scheduleofServices)
        {
            SOSInfo sOSInfo = new SOSInfo();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    ScheduleofService objEntity = new ScheduleofService();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetSOSByDeal_SOSId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SOSId", Convert.ToString(scheduleofServices.SOSId));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            objEntity.SOSId = string.IsNullOrEmpty(Convert.ToString(reader["SOSId"])) ? 0 : Convert.ToInt32(reader["SOSId"]);
                            objEntity.SiteId = string.IsNullOrEmpty(Convert.ToString(reader["SiteId"])) ? 0 : Convert.ToInt32(reader["SiteId"]);
                            objEntity.DealId = string.IsNullOrEmpty(Convert.ToString(reader["DealId"])) ? 0 : Convert.ToInt32(reader["DealId"]);
                            objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                            objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                            objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                            objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                            objEntity.QuantityTypeId = string.IsNullOrEmpty(Convert.ToString(reader["QtyTypeId"])) ? 0 : Convert.ToInt32(reader["QtyTypeId"]);
                            objEntity.FrequencyId = string.IsNullOrEmpty(Convert.ToString(reader["FrequencyId"])) ? 0 : Convert.ToInt32(reader["FrequencyId"]);
                            objEntity.FrequencyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["FrequencyTypeId"])) ? 0 : Convert.ToInt32(reader["FrequencyTypeId"]);
                            objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                            objEntity.Quantity = Convert.ToString(reader["Quantity"]);
                            objEntity.AverageContainerWeightTonnes = Convert.ToDecimal(reader["AssumedContainerWeight"]);
                            objEntity.Comments = Convert.ToString(reader["Comments"]);
                        }
                        reader.Close();


                    }
                    sOSInfo.scheduleofServices = objEntity;
                }
                sOSInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                sOSInfo.Status = Status.Failed;
                sOSInfo.Message = ex.Message;
            }

            return sOSInfo;
        }

        public SOSInfo DeleteSOSInfo(ScheduleofService scheduleofServices)
        {
            SOSInfo sOSInfo = new SOSInfo();
            var results = 0;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_PCustomer_DeleteSOSInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SOSId", scheduleofServices.SOSIds);
                        cmd.Parameters.AddWithValue("@SOS_HeaderId", scheduleofServices.SOSHeaderId);
                        cmd.Parameters.AddWithValue("@CreatedBy", scheduleofServices.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ResultMessage", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        results = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                        sOSInfo.Message = Convert.ToString(cmd.Parameters["@ResultMessage"].Value);
                    }
                }
                if (results == 0)
                {
                    sOSInfo.Status = Status.Failed;
                }
                else if (results == 1)
                {
                    sOSInfo.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                sOSInfo.Status = Status.Failed;
                sOSInfo.Message = ex.Message;
                throw ex;
            }

            return sOSInfo;
        }
    }
}
