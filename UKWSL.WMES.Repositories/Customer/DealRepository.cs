using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Customer
{
    public class DealRepository : IDealRepository
    {

        private string _connectionString;
        public DealRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Deal UpdateDeal(Deal deal)
        {

            Deal objDeal = new Deal();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_UpdateCompanyDeal";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DId", deal.Did);
                        cmd.Parameters.AddWithValue("@DealId", deal.DealId);
                        cmd.Parameters.AddWithValue("@CompanyId", deal.CompanyId);
                        cmd.Parameters.AddWithValue("@SalesOwnerId", deal.SalesOwnerId);
                        cmd.Parameters.AddWithValue("@ContractStartDate", deal.ContractStartDate);
                        cmd.Parameters.AddWithValue("@ContractEndDate", deal.ContractEndDate);
                        cmd.Parameters.AddWithValue("@DealAmount", deal.DealAmount);
                        cmd.Parameters.AddWithValue("@CreatedBy", deal.CreatedBy);
                        cmd.Parameters.AddWithValue("@CompanyName", deal.CompanyName);
                        cmd.Parameters.AddWithValue("@ContractDuration", deal.ContractDuration);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objDeal.Did = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objDeal.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objDeal.Status = Status.Failed;
                objDeal.Message = ex.Message;
                throw ex;
            }
            return objDeal;
        }
        public Deal CreateUpdateDeal(Deal deal)
        {

            Deal objDeal = new Deal();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_InsertCompanyDeal";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", deal.DealId);
                        cmd.Parameters.AddWithValue("@CompanyId", deal.CompanyId);
                        cmd.Parameters.AddWithValue("@SalesOwnerId", deal.SalesOwnerId);
                        cmd.Parameters.AddWithValue("@ContractStartDate", deal.ContractStartDate);
                        cmd.Parameters.AddWithValue("@ContractEndDate", deal.ContractEndDate);
                        cmd.Parameters.AddWithValue("@DealAmount", deal.DealAmount);
                        cmd.Parameters.AddWithValue("@ContractDuration", deal.ContractDuration);
                        cmd.Parameters.AddWithValue("@CompanyName", deal.CompanyName);
                        cmd.Parameters.AddWithValue("@CreatedBy", deal.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objDeal.Did = string.IsNullOrEmpty(Convert.ToString(cmd.Parameters["@Result"].Value)) ? 0 : Convert.ToInt32(cmd.Parameters["@Result"].Value); 
                    }
                }
                objDeal.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objDeal.Status = Status.Failed;
                objDeal.Message = ex.Message;
                throw ex;
            }
            return objDeal;
        }



        public Deal DeleteDealInfo(Deal deal)
        {
            Deal objDeal = new Deal();
            var results = 0;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_PCustomer_DeleteDealInfo";
                        cmd.CommandType = CommandType.StoredProcedure;
                    
                        cmd.Parameters.AddWithValue("@DId", deal.Did);
                        cmd.Parameters.AddWithValue("@CreatedBy", deal.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ResultMessage", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        results = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                        objDeal.Message = Convert.ToString(cmd.Parameters["@ResultMessage"].Value);
                    }
                }
                if (results == 0)
                {
                    objDeal.Status = Status.Failed;
                }
                else if (results == 1)
                {
                    objDeal.Status = Status.Success;
                }
            }
            catch (Exception ex)
            {
                objDeal.Status = Status.Failed;
                objDeal.Message = ex.Message;
                throw ex;
            }
            return objDeal;
        }
        public Deal CheckDeal(Deal deal)
        {

            Deal objDeal = new Deal();
            try
            {
                objDeal.IsDealExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_CheckCompanyDeal";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", deal.DealId);
                        cmd.Parameters.AddWithValue("@CompanyId", deal.CompanyId);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objDeal.IsDealExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objDeal.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objDeal.Status = Status.Failed;
                objDeal.Message = ex.Message;
                throw ex;
            }
            return objDeal;
        }

        /// <summary>
        /// Changes as per EUE-727
        /// </summary>

        public Deal GetDeal(Deal deal)
        {
            Deal objDeal = new Deal();
            try
            {
                objDeal.IsDealExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_PCustomer_GetDealDetailsByDealId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", deal.Did);
                        cmd.Parameters.AddWithValue("@CompanyId", deal.CompanyId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            objDeal.Did = string.IsNullOrEmpty(Convert.ToString(reader["DId"])) ? 0 : Convert.ToInt32(reader["DId"]);
                            objDeal.DealId = Convert.ToString(reader["DealId"]);
                            objDeal.ContractDuration = string.IsNullOrEmpty(Convert.ToString(reader["ContractDuration"])) ? 0 : Convert.ToInt32(reader["ContractDuration"]);
                            objDeal.ContractStartDate = Convert.ToDateTime(reader["ContractStartDate"]);
                            objDeal.ContractEndDate = Convert.ToDateTime(reader["ContractEndDate"]);
                            objDeal.DealAmount = Convert.ToDecimal(reader["DealAmount"]);
                            objDeal.SalesOwnerId = string.IsNullOrEmpty(Convert.ToString(reader["SalesOwnerId"])) ? 0 : Convert.ToInt32(reader["SalesOwnerId"]);
                            objDeal.CompanyId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyId"])) ? 0 : Convert.ToInt32(reader["CompanyId"]);
                            objDeal.SOSStatus = string.IsNullOrEmpty(Convert.ToString(reader["Status"])) ? 0 : Convert.ToInt32(reader["Status"]);
                            objDeal.DealStatusId = string.IsNullOrEmpty(Convert.ToString(reader["DealStatusId"])) ? 0 : Convert.ToInt32(reader["DealStatusId"]);
                            objDeal.DealStatusName = Convert.ToString(reader["DealStatusName"]);
                            objDeal.CompanyName = Convert.ToString(reader["CompanyName"]);
                            objDeal.SalesOwnerName = Convert.ToString(reader["SalesOwnerName"]);
                            objDeal.ModifiedOn = Convert.ToDateTime(reader["LastModifiedOn"]);
                            objDeal.ModifiedByName = Convert.ToString(reader["LastModifiedBy"]);
                        }

                    }
                }
                objDeal.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objDeal.Status = Status.Failed;
                objDeal.Message = ex.Message;
                throw ex;
            }
            return objDeal;
        }

        public Deal UpdateDealOwner(Deal deal, DataTable dtDeals)
        {
            Deal objDeal = new Deal();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "sp_PCustomer_UpdateDealOwner";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter("@CompanyDeal", SqlDbType.Structured)
                    {
                        TypeName = "dbo.UDT_CompanyDealIds",
                        Value = dtDeals
                    };
                    cmd.Parameters.Add(param);
                    cmd.Parameters.AddWithValue("@SalesOwnerId", deal.SalesOwnerId);
                    cmd.Parameters.AddWithValue("@CreatedBy", deal.CreatedBy);
                    cmd.ExecuteNonQuery();
                    objDeal.Status = Status.Success;
                }
            }

            return objDeal;
        }


        public DealInfo GetDealOwnerHistory(Deal deal)
        {
            DealInfo dealInfo = new DealInfo();
            List<DealHistory> lstEntity = new List<DealHistory>();
            Deal objdeal = new Deal(); 
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetDealOwnerHistory]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", deal.CompanyId);
                        cmd.Parameters.AddWithValue("@DealId", deal.Did);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            objdeal.CompanyName = Convert.ToString(reader["CompanyName"]);
                            objdeal.DealId = Convert.ToString(reader["DealId"]);
                            objdeal.ContractDuration = string.IsNullOrEmpty(Convert.ToString(reader["ContractDuration"])) ? 0 : Convert.ToInt32(reader["ContractDuration"]);
                            objdeal.ContractStartDate = Convert.ToDateTime(reader["ContractStartDate"]);
                            objdeal.ContractEndDate = Convert.ToDateTime(reader["ContractEndDate"]);
                            objdeal.DealAmount = Convert.ToDecimal(reader["DealAmount"]);
                            objdeal.SalesOwnerName = Convert.ToString(reader["SalesOwnerName"]); 
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            DealHistory objEntity = new DealHistory();
                            objEntity.SalesOwner = Convert.ToString(reader["Owner"]);
                            objEntity.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            objEntity.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            lstEntity.Add(objEntity);
                        }
                        reader.Close();


                    }
                    dealInfo.lstdealHistories = lstEntity;
                }
                dealInfo.Status = Status.Success;
            }
            catch (Exception ex)
            {
                dealInfo.Status = Status.Failed;
                dealInfo.Message = ex.Message;
            }

            return dealInfo;
        }

        public Deal UpdateDealStatus(Deal deal)
        {

            Deal objDeal = new Deal();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_PCustomer_UpdateDealStatus";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DealId", deal.DealId);
                        cmd.Parameters.AddWithValue("@DealPipeline", deal.DealPipeline);                        
                        cmd.Parameters.AddWithValue("@CreatedBy", deal.CreatedBy);                        
                        cmd.ExecuteNonQuery();
                    }
                }
                objDeal.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objDeal.Status = Status.Failed;
                objDeal.Message = ex.Message;
                throw ex;
            }
            return objDeal;
        }
    }
}
