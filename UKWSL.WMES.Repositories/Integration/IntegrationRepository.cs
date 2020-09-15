using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Integration
{
    public class IntegrationRepository :IIntegrationRepository
    {
        private string _connectionString;
        public IntegrationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public APIConfiguration GetAPIKey(APIConfiguration aPIConfiguration)
        {

            APIConfiguration objAPIConfiguration = new APIConfiguration();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Master_GetAPIConfigHeader";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AppName", aPIConfiguration.AppName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objAPIConfiguration.AppId = string.IsNullOrEmpty(Convert.ToString(reader["API_AppId"])) ? 0 : Convert.ToInt32(reader["API_AppId"]);
                                objAPIConfiguration.AppName = Convert.ToString(reader["API_AppName"]);
                                objAPIConfiguration.AppKey = Convert.ToString(reader["API_AppKey"]);
                                objAPIConfiguration.AppEnvironment = Convert.ToString(reader["API_AppEnvironment"]);
                                objAPIConfiguration.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                }
                objAPIConfiguration.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objAPIConfiguration.Status = Status.Failed;
                objAPIConfiguration.Message = ex.Message;
                throw ex;
            }
            return objAPIConfiguration;
        }

        public APIConfigFunctions GETAPIFunctions(APIConfigFunctions aPIConfigFunctions)
        {
            APIConfigFunctions objAPIConfigFunctions = new APIConfigFunctions();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Master_GetAPIConfigFunctions";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FunctionsName", aPIConfigFunctions.FunctionName); 
                        cmd.Parameters.AddWithValue("@AppId", aPIConfigFunctions.AppId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objAPIConfigFunctions.FunctionId = string.IsNullOrEmpty(Convert.ToString(reader["API_FunctionId"])) ? 0 : Convert.ToInt32(reader["API_FunctionId"]);
                                objAPIConfigFunctions.AppId = string.IsNullOrEmpty(Convert.ToString(reader["API_AppId"])) ? 0 : Convert.ToInt32(reader["API_AppId"]);
                                objAPIConfigFunctions.FunctionName = Convert.ToString(reader["API_FunctionName"]);
                                objAPIConfigFunctions.FunctionURL = Convert.ToString(reader["API_FunctionURL"]);
                                objAPIConfigFunctions.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                }
                objAPIConfigFunctions.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objAPIConfigFunctions.Status = Status.Failed;
                objAPIConfigFunctions.Message = ex.Message;
                throw ex;
            }
            return objAPIConfigFunctions;
        }
    }
}
