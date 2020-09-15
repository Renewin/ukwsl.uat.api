using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Repositories.Pricing
{
    public class PricingOptimizationRepository : IPricingOptimizationRepository
    {

        private string _connectionString;
        public PricingOptimizationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public PricingInfo GetContractorPrice(PricingInfo pricingInfo)
        {
            PricingInfo objEntities = new PricingInfo();
            List<ContractorPrice> lstEntity = new List<ContractorPrice>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Pricing_GetSOSPricing_HeaderId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", Convert.ToString(pricingInfo.DealId));
                        cmd.Parameters.AddWithValue("@SOSHeaderId", Convert.ToString(pricingInfo.SOSHeaderId));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ContractorPrice objEntity = new ContractorPrice();
                            objEntity.SOSId = string.IsNullOrEmpty(Convert.ToString(reader["SOSId"])) ? 0 : Convert.ToInt32(reader["SOSId"]);
                            objEntity.PCId = FieldValidation.ToInteger(reader["PcId"]);
                            objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                            objEntity.SiteName = Convert.ToString(reader["SiteName"]);
                            objEntity.PostCode = Convert.ToString(reader["PostCode"]);
                            objEntity.Address = Convert.ToString(reader["Address"]);
                            objEntity.Region = Convert.ToString(reader["Region"]);
                            objEntity.WasteTypeName = Convert.ToString(reader["WasteType_Name"]);
                            objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                            objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                            objEntity.ContainerTypeName = Convert.ToString(reader["ContainerType_Name"]);
                            objEntity.ContainerSizeName = Convert.ToString(reader["ContainerSize_Name"]);
                            objEntity.QuantityTypeName = Convert.ToString(reader["QuantityTypeName"]);
                            objEntity.AssumedContainerWeight = FieldValidation.ToDecimal(reader["AssumedContainerWeight"]);
                            objEntity.Quantity = FieldValidation.ToDecimal(reader["Quantity"]);
                            objEntity.FrequencyTypeName = Convert.ToString(reader["FrequencyType_Name"]);
                            objEntity.FrequencyName = Convert.ToString(reader["Frequency_Name"]);
                            objEntity.Comments = Convert.ToString(reader["Comments"]);

                            objEntity.ContractorId = FieldValidation.ToInteger(reader["ContractorId"]);
                            objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                            objEntity.CostPerLift = FieldValidation.ToDecimal(reader["CostPerLift"]);
                            objEntity.QuantityTypeId = FieldValidation.ToInteger(reader["QuantityTypeId"]);
                            objEntity.PreferredQuantityType = Convert.ToString(reader["PreferredQuantityType"]);
                            objEntity.CostQuantity = FieldValidation.ToDecimal(reader["Cost_Quantity"]);
                            objEntity.MinQuantity = FieldValidation.ToInteger(reader["MinQuantity"]);
                            objEntity.MaxQuantity = FieldValidation.ToInteger(reader["MaxQuantity"]);
                            objEntity.ExcessCharge = FieldValidation.ToDecimal(reader["ExcessCharge"]);

                            objEntity.RentalUnitDay = FieldValidation.ToDecimal(reader["RentalUnit_Day"]);
                            objEntity.ConsignmentNoteVisit = FieldValidation.ToDecimal(reader["ConsignmentNote_Visit"]);
                            objEntity.Demurragehour = FieldValidation.ToInteger(reader["Demurrage_hour"]);
                            objEntity.TransportCost = FieldValidation.ToDecimal(reader["Transport_Cost"]);
                            objEntity.EndDestinationTypeId = FieldValidation.ToInteger(reader["EndDestinationTypeId"]);
                            objEntity.EndDestinationTypeName = Convert.ToString(reader["EndDestinationType_Name"]);
                            objEntity.FacilityName1 = Convert.ToString(reader["FacilityName1"]);
                            objEntity.FacilityName2 = Convert.ToString(reader["FacilityName2"]);
                            objEntity.PricingComments = Convert.ToString(reader["PricingComments"]);
                            lstEntity.Add(objEntity);
                        }
                        reader.Close();


                    }
                    objEntities.lstContractorPrice = lstEntity;
                }
                objEntities.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntities.Status = Status.Failed;
                objEntities.Message = ex.Message;
            }

            return objEntities;
        }
        public PricingInfo GetPricingDeals(CompanyInfo companyInfo)
        {

            PricingInfo pricingInfo = new PricingInfo();
            try
            {
                List<Deal> lstEntity = new List<Deal>();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Pricing_Deals]";
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
                                objEntity.SalesOwnerName = Convert.ToString(reader["SalesOwnerName"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }

                }
                pricingInfo.lstdeals = lstEntity;
                pricingInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                pricingInfo.Status = Status.Failed;
                pricingInfo.Message = ex.Message;
            }

            return pricingInfo;
        }

        public PricingInfo UploadPricingCsv(PricingInfo pricingInfo, Filedetails filedetails, DataTable dataTable)
        {
            PricingInfo pricingInfo1 = new PricingInfo();
            int _upooadedId = 0;
            List<ScheduleService> lstScheduleService = new List<ScheduleService>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_PricingUpload_InsertCSVRawData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@PricingCSVData", SqlDbType.Structured)
                        {
                            TypeName = "dbo.UDT_PricingSolutionUpload",
                            Value = dataTable
                        };
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@PricingUploadFileName", filedetails.FileName);
                        cmd.Parameters.AddWithValue("@PricingUpload_FileLocation", filedetails.FileLocation);
                        cmd.Parameters.AddWithValue("@SOS_Headerid", pricingInfo.SOSHeaderId);
                        cmd.Parameters.AddWithValue("@CreatedBy", pricingInfo.CreatedBy);
                        cmd.Parameters.Add("@SUploadId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        _upooadedId = Convert.ToInt32(cmd.Parameters["@SUploadId"].Value);
                        pricingInfo1.SUploadId = _upooadedId;
                        pricingInfo1.Status = Status.Success;
                    }

                    using (var cmd1 = conn.CreateCommand())
                    {
                        cmd1.CommandText = "sp_PricingUpload_ProcessCSVData";
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@SUploadId", _upooadedId);
                        cmd1.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd1.ExecuteNonQuery();
                        pricingInfo1.IsUploadSuccess = Convert.ToInt32(cmd1.Parameters["@Result"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                pricingInfo1.Status = Status.Failed;
                pricingInfo1.Message = ex.Message;
            }

            return pricingInfo1;
        }

        public PricingInfo GetPreferredContractorPrice(PricingInfo pricingInfo)
        {
            PricingInfo objEntities = new PricingInfo();
            List<PreferredContractorPrice> objEntityList = new List<PreferredContractorPrice>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Pricing_GetPotentialContractors_SOSId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SOSId", Convert.ToString(pricingInfo.SOSId));
                        cmd.Parameters.AddWithValue("@SOS_HeaderId", Convert.ToString(pricingInfo.SOSHeaderId));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            PreferredContractorPrice objEntity = new PreferredContractorPrice();
                            objEntity.PCId = FieldValidation.ToInteger(reader["PcId"]);
                            objEntity.ContractorId = FieldValidation.ToInteger(reader["ContractorId"]);
                            objEntity.ContractorName = Convert.ToString(reader["ContractorName"]);
                            objEntity.CostPerLift = FieldValidation.ToDecimal(reader["CostPerLift"]);
                            objEntity.QuantityTypeId = FieldValidation.ToInteger(reader["QuantityTypeId"]);
                            objEntity.QuantityTypeName = Convert.ToString(reader["QuantityTypeName"]);
                            //  objEntity.PreferredQuantityType = Convert.ToString(reader["PreferredQuantityType"]);
                            objEntity.CostQuantity = FieldValidation.ToDecimal(reader["Cost_Quantity"]);
                            objEntity.MinQuantity = FieldValidation.ToInteger(reader["MinQuantity"]);
                            objEntity.MaxQuantity = FieldValidation.ToInteger(reader["MaxQuantity"]);
                            objEntity.ExcessCharge = FieldValidation.ToDecimal(reader["ExcessCharge"]);
                            objEntity.TransportCost = FieldValidation.ToDecimal(reader["Transport_Cost"]);
                            objEntity.RentalUnitDay = FieldValidation.ToDecimal(reader["RentalUnit_Day"]);
                            objEntity.ConsignmentNoteVisit = FieldValidation.ToDecimal(reader["ConsignmentNote_Visit"]);
                            objEntity.Demurragehour = FieldValidation.ToInteger(reader["Demurrage_hour"]);
                            objEntity.CostWeek = FieldValidation.ToDecimal(reader["Cost_Week"]);
                            objEntity.EndDestinationTypeId = FieldValidation.ToInteger(reader["EndDestinationTypeId"]);
                            objEntity.EndDestinationTypeName = Convert.ToString(reader["EndDestinationType_Name"]);
                            objEntity.FacilityName1 = Convert.ToString(reader["FacilityName1"]);
                            objEntity.FacilityName2 = Convert.ToString(reader["FacilityName2"]);
                            objEntity.PricingComments = Convert.ToString(reader["Comments"]);
                            objEntity.IsPreferred = string.IsNullOrEmpty(Convert.ToString(reader["IsPreferred"])) ? false : Convert.ToBoolean(reader["IsPreferred"]);
                            objEntityList.Add(objEntity);
                        }
                        reader.Close();


                    }
                    objEntities.lstPreferredContractorPrice = objEntityList;
                }
                objEntities.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objEntities.Status = Status.Failed;
                objEntities.Message = ex.Message;
            }

            return objEntities;
        }

        public PricingInfo UpdateContractorPrice(PreferredContractorPrice contractorPrice)
        {
            PricingInfo pricingInfo = new PricingInfo();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_Pricing_UpdatePrefContractorPrice";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SOSid", contractorPrice.SOSId);
                        cmd.Parameters.AddWithValue("@SOS_HeaderId", contractorPrice.SOSHeaderId);
                        cmd.Parameters.AddWithValue("@PcId", contractorPrice.PCId);
                        cmd.Parameters.AddWithValue("@ContractorId", contractorPrice.ContractorId);
                        cmd.Parameters.AddWithValue("@ContractorName", contractorPrice.ContractorName);
                        cmd.Parameters.AddWithValue("@CostPerLift", contractorPrice.CostPerLift);
                        cmd.Parameters.AddWithValue("@QuantityTypeId", contractorPrice.QuantityTypeId);
                        cmd.Parameters.AddWithValue("@Cost_Quantity", contractorPrice.CostQuantity);
                        cmd.Parameters.AddWithValue("@MinQuantity", contractorPrice.MinQuantity);
                        cmd.Parameters.AddWithValue("@MaxQuantity", contractorPrice.MaxQuantity);
                        cmd.Parameters.AddWithValue("@ExcessCharge", contractorPrice.ExcessCharge);
                        cmd.Parameters.AddWithValue("@Transport_Cost", contractorPrice.TransportCost);
                        cmd.Parameters.AddWithValue("@RentalUnit_Day", contractorPrice.RentalUnitDay);
                        cmd.Parameters.AddWithValue("@ConsignmentNote_Visit", contractorPrice.ConsignmentNoteVisit);
                        cmd.Parameters.AddWithValue("@Demurrage_hour", contractorPrice.Demurragehour);
                        cmd.Parameters.AddWithValue("@Cost_Week", contractorPrice.CostWeek);
                        cmd.Parameters.AddWithValue("@EndDestinationTypeId", contractorPrice.EndDestinationTypeId);
                        cmd.Parameters.AddWithValue("@FacilityName1", contractorPrice.FacilityName1);
                        cmd.Parameters.AddWithValue("@FacilityName2", contractorPrice.FacilityName2);
                        cmd.Parameters.AddWithValue("@Comments", contractorPrice.Comments);
                        cmd.Parameters.AddWithValue("@CreatedBy", contractorPrice.CreatedBy);

                        cmd.ExecuteNonQuery();

                        pricingInfo.Status = Status.Success;
                    }

                }
            }
            catch (Exception ex)
            {
                pricingInfo.Status = Status.Failed;
                pricingInfo.Message = ex.Message;
            }

            return pricingInfo;
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
                        cmd1.CommandText = "sp_OptimalSOSUpload_ProcessCSVData";
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
                        reader.NextResult();
                        while (reader.Read())
                        {
                            sOSInfo.ReturnValue = string.IsNullOrEmpty(Convert.ToString(reader["ReturnValue"])) ? 0 : Convert.ToInt32(reader["ReturnValue"]);
                        }
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
                    cmd.CommandText = "[dbo].[sp_OptimalSOSUpload_InsertProcessedData]";
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

    }
}
