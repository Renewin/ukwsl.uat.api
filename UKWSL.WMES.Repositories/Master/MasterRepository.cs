using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Repositories.Master
{
    public class MasterRepository : IMasterRepository
    {
        private string _connectionString;
        public MasterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region GetMethods
        public MasterInfo GetPriceInflation()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<PriceInflation> lstEntity = new List<PriceInflation>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetPriceInflation]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PriceInflation objEntity = new PriceInflation();
                                objEntity.PriceInflationId = string.IsNullOrEmpty(Convert.ToString(reader["PriceInflationId"])) ? 0 : Convert.ToInt32(reader["PriceInflationId"]);
                                objEntity.PriceInflation_Name = Convert.ToString(reader["PriceInflation_Name"]);
                                objEntity.PriceInflation_Desc = Convert.ToString(reader["PriceInflation_Desc"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstPriceInflation = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetMaterialType()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<MaterialType> lstEntity = new List<MaterialType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetMaterialType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MaterialType objEntity = new MaterialType();
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.MaterialTypeDesc = Convert.ToString(reader["MaterialType_Desc"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstMaterialType = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetContainerType()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContainerType> lstEntity = new List<ContainerType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetContainerType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContainerType objEntity = new ContainerType();
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerTypeName = Convert.ToString(reader["ContainerType_Name"]);
                                objEntity.ContainerTypeDesc = Convert.ToString(reader["ContainerType_Desc"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstContainerType = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetContainerSize()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContainerSize> lstEntity = new List<ContainerSize>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetContainerSize]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContainerSize objEntity = new ContainerSize();
                                objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objEntity.ContainerSizeName = Convert.ToString(reader["ContainerSize_Name"]);
                                objEntity.ContainerSizeDesc = Convert.ToString(reader["ContainerSize_Desc"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstContainerSize = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetPricingMethod()
        {

            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<PricingMethod> lstEntity = new List<PricingMethod>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetPricingMethod]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PricingMethod objEntity = new PricingMethod();
                                objEntity.PricingMethodId = string.IsNullOrEmpty(Convert.ToString(reader["PricingMethodId"])) ? 0 : Convert.ToInt32(reader["PricingMethodId"]);
                                objEntity.PricingMethodName = Convert.ToString(reader["PricingMethod_Name"]);
                                objEntity.PricingMethodDesc = Convert.ToString(reader["PricingMethod_Desc"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstPricingMethod = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }
        public MasterInfo GetFrequencySize()
        {

            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FrequencySize> lstEntity = new List<FrequencySize>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetAllFrequencySize]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FrequencySize objEntity = new FrequencySize();
                                objEntity.FrequencyId = string.IsNullOrEmpty(Convert.ToString(reader["FrequencyId"])) ? 0 : Convert.ToInt32(reader["FrequencyId"]);
                                objEntity.FrequencyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["FrequencyTypeId"])) ? 0 : Convert.ToInt32(reader["FrequencyTypeId"]);
                                objEntity.FrequencyName = Convert.ToString(reader["Frequency_Name"]);
                                objEntity.FrequencyType_Name = Convert.ToString(reader["FrequencyType_Name"]);
                                objEntity.FrequencyDesc = Convert.ToString(reader["Frequency_Desc"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstFrequencySize = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }



        public MasterInfo GetFrequencySizeById(FrequencyType frequencyType)
        {

            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FrequencySize> lstEntity = new List<FrequencySize>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetFrequencySizeById]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FrequencyTypeId", frequencyType.FrequencyTypeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FrequencySize objEntity = new FrequencySize();
                                objEntity.FrequencyId = string.IsNullOrEmpty(Convert.ToString(reader["FrequencyId"])) ? 0 : Convert.ToInt32(reader["FrequencyId"]);
                                objEntity.FrequencyName = Convert.ToString(reader["Frequency_Name"]);
                                objEntity.FrequencyDesc = Convert.ToString(reader["Frequency_Desc"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstFrequencySize = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }


        public MasterInfo GetFrequencyType()
        {

            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<FrequencyType> lstEntity = new List<FrequencyType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetFrequencyType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FrequencyType objEntity = new FrequencyType();
                                objEntity.FrequencyTypeId = string.IsNullOrEmpty(Convert.ToString(reader["FrequencyTypeId"])) ? 0 : Convert.ToInt32(reader["FrequencyTypeId"]);
                                objEntity.FrequencyTypeName = Convert.ToString(reader["FrequencyType_Name"]);
                                objEntity.FrequencyTypeDesc = Convert.ToString(reader["FrequencyType_Desc"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstFrequencyType = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetWasteType()
        {

            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<WasteType> lstEntity = new List<WasteType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetWasteType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WasteType objEntity = new WasteType();
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.WasteTypeName = Convert.ToString(reader["WasteType_Name"]);
                                objEntity.WasteTypeDesc = Convert.ToString(reader["WasteType_Desc"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstWasteTypes = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }
        public MasterInfo GetAllSalesUser()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<User> lstEntity = new List<User>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetAllSalesUser]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User objEntity = new User();
                                objEntity.Id = string.IsNullOrEmpty(Convert.ToString(reader["UserId"])) ? 0 : Convert.ToInt32(reader["UserId"]);
                                objEntity.FirstName = Convert.ToString(reader["FirstName"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstUser = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }
        public MasterInfo GetAllSHEQDocumentTypes()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<SHEQDocumentTypes> lstEntity = new List<SHEQDocumentTypes>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetAllSHEQDocumentTypes]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SHEQDocumentTypes objEntity = new SHEQDocumentTypes();
                                objEntity.SHEQDocument_TypeId = string.IsNullOrEmpty(Convert.ToString(reader["SHEQDocument_TypeId"])) ? 0 : Convert.ToInt32(reader["SHEQDocument_TypeId"]);
                                objEntity.SHEQDocument_TypeName = Convert.ToString(reader["SHEQDocument_TypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstSHEQDocumentTypes = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo GetMaterialTypeByContainer(Container model)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<MaterialType> lstEntity = new List<MaterialType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetMaterialTypeByContainer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WasteTypeId", model.WasteTypeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MaterialType objEntity = new MaterialType();
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.MaterialTypeDesc = Convert.ToString(reader["MaterialType_Desc"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstMaterialType = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo GetContainerTypeByContainer(Container model)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContainerType> lstEntity = new List<ContainerType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetContainerTypeByContainer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WasteTypeId", model.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", model.MaterialTypeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContainerType objEntity = new ContainerType();
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerTypeName = Convert.ToString(reader["ContainerType_Name"]);
                                objEntity.ContainerTypeDesc = Convert.ToString(reader["ContainerType_Desc"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstContainerType = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo GetContainerSizeByContainer(Container model)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContainerSize> lstEntity = new List<ContainerSize>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetContainerSizeByContainer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WasteTypeId", model.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", model.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", model.ContainerTypeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContainerSize objEntity = new ContainerSize();
                                objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objEntity.ContainerSizeName = Convert.ToString(reader["ContainerSize_Name"]);
                                objEntity.ContainerSizeDesc = Convert.ToString(reader["ContainerSize_Desc"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstContainerSize = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo GetContainerAvgWeightByContainer(Container model)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Container> lstEntity = new List<Container>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetAvgWeightByContainer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WasteTypeId", model.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", model.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", model.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", model.ContainerSizeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Container objEntity = new Container();
                                objEntity.AverageContainerWeightTonnes = Convert.ToString(reader["AverageContainerWeight_Tonnes"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstContainer = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo GetAllContainerConfigurations()
        {

            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ContainerConfigurations> lstEntity = new List<ContainerConfigurations>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetAllContainerConfigurations]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContainerConfigurations objEntity = new ContainerConfigurations();
                                objEntity.CMpapingId = string.IsNullOrEmpty(Convert.ToString(reader["CMappingId"])) ? 0 : Convert.ToInt32(reader["CMappingId"]);
                                objEntity.WasteTypeId = string.IsNullOrEmpty(Convert.ToString(reader["WasteTypeId"])) ? 0 : Convert.ToInt32(reader["WasteTypeId"]);
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.ContainerTypeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerTypeId"])) ? 0 : Convert.ToInt32(reader["ContainerTypeId"]);
                                objEntity.ContainerSizeId = string.IsNullOrEmpty(Convert.ToString(reader["ContainerSizeId"])) ? 0 : Convert.ToInt32(reader["ContainerSizeId"]);
                                objEntity.WasteTypeName = Convert.ToString(reader["WasteType_Name"]);
                                objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.ContainerTypeName = Convert.ToString(reader["ContainerType_Name"]);
                                objEntity.ContainerSizeName = Convert.ToString(reader["ContainerSize_Name"]);
                                objEntity.AverageContainerWeightTonnes = Convert.ToDecimal(reader["AverageContainerWeight_Tonnes"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModfiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstContainerConfigurations = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetCustomerQuantityType()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CustomerQuantityType> lstEntity = new List<CustomerQuantityType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetCustomerQtyType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerQuantityType objEntity = new CustomerQuantityType();
                                objEntity.QuantityTypeId = string.IsNullOrEmpty(Convert.ToString(reader["QtyTypeId"])) ? 0 : Convert.ToInt32(reader["QtyTypeId"]);
                                objEntity.QuantityTypeName = Convert.ToString(reader["QuantityTypeName"]);
                                objEntity.Minvalue = Convert.ToDecimal(reader["Minvalue"]);
                                objEntity.MaxValue = Convert.ToDecimal(reader["MaxValue"]);
                                objEntity.Units = Convert.ToString(reader["Units"]);
                                objEntity.IsDefault = string.IsNullOrEmpty(Convert.ToString(reader["IsDefault"])) ? 0 : Convert.ToInt32(reader["IsDefault"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstCustomerQuantityType = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetContractor()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Contractor> lstEntity = new List<Contractor>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Contractor_GetAllContractorInfo]";
                        cmd.CommandType = CommandType.StoredProcedure;

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
                    masterInfo.lstContractor = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetEndDestinationType()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<EndDestinationType> lstEntity = new List<EndDestinationType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetEndDestinationType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EndDestinationType objEntity = new EndDestinationType();
                                objEntity.EdTypeId = string.IsNullOrEmpty(Convert.ToString(reader["EdTypeId"])) ? 0 : Convert.ToInt32(reader["EdTypeId"]);
                                objEntity.EndDestinationTypeName = Convert.ToString(reader["EndDestinationType_Name"]);
                                objEntity.EndDestinationTypeDesc = Convert.ToString(reader["EndDestinationType_Desc"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                                objEntity.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstEndDestinationTypes = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }
        public MasterInfo GetAvailableContractor(PricingInfo pricingInfo)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Contractor> lstEntity = new List<Contractor>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_Pricing_GetAvailableContractors]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SOSid", pricingInfo.SOSId);
                        cmd.Parameters.AddWithValue("@SOS_HeaderId", pricingInfo.SOSHeaderId);
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
                    masterInfo.lstAvailableContractor = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetBagType()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<BagType> lstEntity = new List<BagType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_Master_GetBagType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BagType objEntity = new BagType();
                                objEntity.BagTypeId = string.IsNullOrEmpty(Convert.ToString(reader["BagTypeId"])) ? 0 : Convert.ToInt32(reader["BagTypeId"]);
                                objEntity.BagTypeName = Convert.ToString(reader["BagTypeName"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstBagType = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }

        public MasterInfo GetApprovedPricingSites(SOSInfo sOSInfo)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<Sites> lstEntity = new List<Sites>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ApprovedPricing_GetAllSites]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ApprovedPricingId", Convert.ToString(sOSInfo.ApprovedPricingId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Sites objEntity = new Sites();
                                objEntity.Site = Convert.ToString(reader["Site"]);
                                objEntity.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objEntity.SiteName = Convert.ToString(reader["Sitename"]);
                                objEntity.AddressLine1 = Convert.ToString(reader["Site_Addressline1"]);
                                objEntity.AddressLine2 = Convert.ToString(reader["Site_Addressline2"]);
                                objEntity.PostCode = Convert.ToString(reader["Site_Postcode"]);
                                objEntity.Town = Convert.ToString(reader["Site_Town"]);
                                objEntity.County = Convert.ToString(reader["Site_county"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstApprovedPricingSites = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }

            return masterInfo;
        }







        public MasterInfo GetServiceJobType()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<JobType> lstEntity = new List<JobType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetServiceJobType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                JobType objEntity = new JobType();
                                objEntity.JobTypeId = string.IsNullOrEmpty(Convert.ToString(reader["JobTypeId"])) ? 0 : Convert.ToInt32(reader["JobTypeId"]);
                                objEntity.JobTypeName = Convert.ToString(reader["JobTypeName"]);
                                objEntity.JobType_Desc = Convert.ToString(reader["JobType_Desc"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                                objEntity.CreatedBy = string.IsNullOrEmpty(Convert.ToString(reader["CreatedBy"])) ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstServiceJobType = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }

        public MasterInfo GetServiceDeliveryFailureType()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<ServiceDeliveryFailureType> lstEntity = new List<ServiceDeliveryFailureType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetServiceDeliveryFailureType]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceDeliveryFailureType objEntity = new ServiceDeliveryFailureType();
                                objEntity.DeliveryFailureTypeId = string.IsNullOrEmpty(Convert.ToString(reader["DeliveryFailureTypeId"])) ? 0 : Convert.ToInt32(reader["DeliveryFailureTypeId"]);
                                objEntity.DeliveryFailureType_Name = Convert.ToString(reader["DeliveryFailureType_Name"]);
                                objEntity.DeliveryFailureType_Desc = Convert.ToString(reader["DeliveryFailureType_Desc"]);
                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstServiceDeliveryFailureType = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }

        public MasterInfo GetPriceUpdateStatus()
        {

            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<PricingUpdateStatus> lstEntity = new List<PricingUpdateStatus>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetAllPriceUpdateStatus]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PricingUpdateStatus objEntity = new PricingUpdateStatus();
                                objEntity.PriceUpdateStatusId = string.IsNullOrEmpty(Convert.ToString(reader["PriceUpdateStatusId"])) ? 0 : Convert.ToInt32(reader["PriceUpdateStatusId"]);
                                objEntity.PriceUpdateStatus = Convert.ToString(reader["PriceUpdateStatus"]);
                                objEntity.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                objEntity.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                                objEntity.CreatedBy = string.IsNullOrEmpty(Convert.ToString(reader["CreatedBy"])) ? 0 : Convert.ToInt32(reader["CreatedBy"]);

                                lstEntity.Add(objEntity);
                            }
                        }


                    }
                    masterInfo.lstPricingUpdateStatus = lstEntity;
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }


            return masterInfo;
        }

        public MasterInfo GetCountyDetails()
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<CountyInfo> lstEntity = new List<CountyInfo>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetCountyDetails]";
                        cmd.CommandType = CommandType.StoredProcedure;
                           using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                              CountyInfo objEntity = new CountyInfo();
                                objEntity.CountyidId = string.IsNullOrEmpty(Convert.ToString(reader["CountyidId"])) ? 0 : Convert.ToInt32(reader["CountyidId"]);
                                objEntity.CountyName = Convert.ToString(reader["CountyName"]);
                                 lstEntity.Add(objEntity);
                            }
                        }
                    }
                      masterInfo.lstCountyInfo = lstEntity;
 }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }

        public MasterInfo GetMultipleMaterialTypeByContainer(Container model)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    List<MaterialType> lstEntity = new List<MaterialType>();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_GetMultipleMaterialTypeByContainer]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WasteTypeIds", model.WasteTypeIds);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                MaterialType objEntity = new MaterialType();
                                objEntity.MaterialTypeId = string.IsNullOrEmpty(Convert.ToString(reader["MaterialTypeId"])) ? 0 : Convert.ToInt32(reader["MaterialTypeId"]);
                                objEntity.MaterialTypeName = Convert.ToString(reader["MaterialType_Name"]);
                                objEntity.MaterialTypeDesc = Convert.ToString(reader["MaterialType_Desc"]);
                                objEntity.EWCCode = Convert.ToString(reader["EWCCode"]);

                                lstEntity.Add(objEntity);
                            }
                        }
                    }
                    masterInfo.lstMaterialType = lstEntity;

                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }

        #endregion

        #region CheckIfExists
        public MasterInfo CheckWasteTypeExist(WasteType wasteType)
        {
            MasterInfo objMasterInfo = new MasterInfo();
            try
            {
                objMasterInfo.IsWasteTypeExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Master_CheckWasteTypeExist";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WasteTypeName", wasteType.WasteTypeName);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objMasterInfo.IsWasteTypeExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objMasterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objMasterInfo.Status = Status.Failed;
                objMasterInfo.Message = ex.Message;
                throw ex;
            }
            return objMasterInfo;
        }

        public MasterInfo CheckMaterialTypeExist(MaterialType materialType)
        {
            MasterInfo objMasterInfo = new MasterInfo();
            try
            {
                objMasterInfo.IsMaterialTypeExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Master_CheckMaterialTypeExist";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaterialTypeName", materialType.MaterialTypeName);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objMasterInfo.IsMaterialTypeExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objMasterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objMasterInfo.Status = Status.Failed;
                objMasterInfo.Message = ex.Message;
                throw ex;
            }
            return objMasterInfo;
        }

        public MasterInfo CheckContainerTypeExist(ContainerType containerType)
        {
            MasterInfo objMasterInfo = new MasterInfo();
            try
            {
                objMasterInfo.IsContainerTypeExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Master_CheckContainerTypeExist";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContainerTypeName", containerType.ContainerTypeName);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objMasterInfo.IsContainerTypeExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objMasterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objMasterInfo.Status = Status.Failed;
                objMasterInfo.Message = ex.Message;
                throw ex;
            }
            return objMasterInfo;
        }

        public MasterInfo CheckContainerSizeExist(ContainerSize containerSize)
        {
            MasterInfo objMasterInfo = new MasterInfo();
            try
            {
                objMasterInfo.IsContainerSizeExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Master_CheckContainerSizeExist";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContainerSizeName", containerSize.ContainerSizeName);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objMasterInfo.IsContainerSizeExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objMasterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objMasterInfo.Status = Status.Failed;
                objMasterInfo.Message = ex.Message;
                throw ex;
            }
            return objMasterInfo;
        }

        public MasterInfo CheckContainerConfigExist(ContainerConfigurations containerConfigurations)
        {
            MasterInfo objMasterInfo = new MasterInfo();
            try
            {
                objMasterInfo.IsContainerConfigExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Master_CheckContainerConfigExist";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WasteTypeId", containerConfigurations.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", containerConfigurations.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", containerConfigurations.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", containerConfigurations.ContainerSizeId);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objMasterInfo.IsContainerConfigExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objMasterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objMasterInfo.Status = Status.Failed;
                objMasterInfo.Message = ex.Message;
                throw ex;
            }
            return objMasterInfo;
        }

        public MasterInfo CheckFrequencyExist(FrequencySize frequencySize)
        {
            MasterInfo objMasterInfo = new MasterInfo();
            try
            {
                objMasterInfo.IsFrequencyExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Master_CheckFrequencyExist";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FrequencyName", frequencySize.FrequencyName);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objMasterInfo.IsFrequencyExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objMasterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objMasterInfo.Status = Status.Failed;
                objMasterInfo.Message = ex.Message;
                throw ex;
            }
            return objMasterInfo;
        }

        public MasterInfo CheckQuantityTypeExist(CustomerQuantityType customerQuantityType)
        {
            MasterInfo objMasterInfo = new MasterInfo();
            try
            {
                objMasterInfo.IsQuantityTypeExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Master_CheckQuantityTypeExist";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@QuantityTypeName", customerQuantityType.QuantityTypeName);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objMasterInfo.IsQuantityTypeExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objMasterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objMasterInfo.Status = Status.Failed;
                objMasterInfo.Message = ex.Message;
                throw ex;
            }
            return objMasterInfo;
        }

        #endregion

        /// <summary>
        /// Section for Insert of Master Date
        /// </summary>
        #region InsertMethod
        public MasterInfo InsertUpdateWasteType(WasteType wasteType)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_InsertUpdateWasteType]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WasteTypeId", wasteType.WasteTypeId);
                        cmd.Parameters.AddWithValue("@WasteTypeName", wasteType.WasteTypeName);
                        cmd.Parameters.AddWithValue("@IsActive", wasteType.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", wasteType.CreatedBy);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        masterInfo.MasterId = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo InsertUpdateMaterialType(MaterialType materialType)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_InsertUpdateMaterialType]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaterialTypeId", materialType.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeName", materialType.MaterialTypeName);
                        cmd.Parameters.AddWithValue("@EWCCode", materialType.EWCCode);
                        cmd.Parameters.AddWithValue("@IsActive", materialType.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", materialType.CreatedBy);
                        cmd.Parameters.Add("@ResultID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        masterInfo.MasterId = Convert.ToInt32(cmd.Parameters["@ResultID"].Value);
                    }
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo InsertUpdateContainerType(ContainerType containerType)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_InsertUpdateContainerType]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContainerTypeId", containerType.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerTypeName", containerType.ContainerTypeName);
                        cmd.Parameters.AddWithValue("@IsActive", containerType.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", containerType.CreatedBy);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        masterInfo.MasterId = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo InsertUpdateContainerSize(ContainerSize containerSize)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_InsertUpdateContainerSize]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ContainerSizeId", containerSize.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeName", containerSize.ContainerSizeName);
                        cmd.Parameters.AddWithValue("@IsActive", containerSize.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", containerSize.CreatedBy);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        masterInfo.MasterId = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo InsertUpdateFrequency(FrequencySize frequencySize)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_InsertUpdateFrequency]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FrequencyId", frequencySize.FrequencyId);
                        cmd.Parameters.AddWithValue("@FrequencyTypeId", frequencySize.FrequencyTypeId);
                        cmd.Parameters.AddWithValue("@FrequencyName", frequencySize.FrequencyName);
                        cmd.Parameters.AddWithValue("@VisitsPerWeek", frequencySize.VisitsPerWeek);
                        cmd.Parameters.AddWithValue("@IsActive", frequencySize.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", frequencySize.CreatedBy);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        masterInfo.MasterId = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo InsertUpdateQuantityType(CustomerQuantityType customerQuantityType)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_InsertUpdateQuantityType]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@QuantityTypeId", customerQuantityType.QuantityTypeId);
                        cmd.Parameters.AddWithValue("@QuantityTypeName", customerQuantityType.QuantityTypeName);
                        cmd.Parameters.AddWithValue("@Minvalue", customerQuantityType.Minvalue);
                        cmd.Parameters.AddWithValue("@MaxValue", customerQuantityType.MaxValue);
                        cmd.Parameters.AddWithValue("@Units", customerQuantityType.Units);
                        cmd.Parameters.AddWithValue("@IsActive", customerQuantityType.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", customerQuantityType.CreatedBy);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        masterInfo.MasterId = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }
        public MasterInfo InsertUpdateContainerConfiguration(ContainerConfigurations containerConfigurations)
        {
            MasterInfo masterInfo = new MasterInfo();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[Master_InsertUpdateContainerConfiguration]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CMappingId", containerConfigurations.CMpapingId);
                        cmd.Parameters.AddWithValue("@WasteTypeId", containerConfigurations.WasteTypeId);
                        cmd.Parameters.AddWithValue("@MaterialTypeId", containerConfigurations.MaterialTypeId);
                        cmd.Parameters.AddWithValue("@ContainerTypeId", containerConfigurations.ContainerTypeId);
                        cmd.Parameters.AddWithValue("@ContainerSizeId", containerConfigurations.ContainerSizeId);
                        cmd.Parameters.AddWithValue("@AverageContainerWeight_Tonnes", containerConfigurations.AverageContainerWeightTonnes);
                        cmd.Parameters.AddWithValue("@IsActive", containerConfigurations.IsActive);
                        cmd.Parameters.AddWithValue("@CreatedBy", containerConfigurations.CreatedBy);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        masterInfo.MasterId = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                masterInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                masterInfo.Status = Status.Failed;
                masterInfo.Message = ex.Message;
            }
            return masterInfo;
        }


        #endregion
    }
}
