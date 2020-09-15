using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Repositories.Exports
{
   public class ExportRepository :IExportRepository
    {
        private string _connectionString;
        public ExportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ExportInfo GetSOSExportDetails(ExportInfo exportInfo)
        {
            ExportInfo objEntities = new ExportInfo();
            List<SOSExports> lstEntity = new List<SOSExports>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_SOSExport_GetAllDetails]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", Convert.ToString(exportInfo.DealId));
                        cmd.Parameters.AddWithValue("@SOSHeaderId", Convert.ToString(exportInfo.SOSHeaderId));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            SOSExports objEntity = new SOSExports();
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
                            objEntity.Quantity = FieldValidation.ToInteger(reader["Quantity"]);
                            objEntity.FrequencyTypeName = Convert.ToString(reader["FrequencyType_Name"]);
                            objEntity.FrequencyName = Convert.ToString(reader["Frequency_Name"]);
                            objEntity.Visits = Convert.ToString(reader["Visits"]);
                            objEntity.Comments = Convert.ToString(reader["Comments"]);
                            lstEntity.Add(objEntity);
                        }
                        reader.Close();


                    }
                    objEntities.lstSOSExports = lstEntity;
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

    }
}
