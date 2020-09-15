using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.Customer
{
    public class SiteRepository : ISiteRepository
    {

        private string _connectionString;
        public SiteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Changes as per story Euw-727
        /// </summary>
        /// <param name="sites"></param>
        /// <returns>Sites</returns>
        public Sites CreateUpdateSite(Sites sites)
        {

            Sites objSites = new Sites();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_InsertUpdateCompanySites";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SiteId", sites.SiteId);
                        cmd.Parameters.AddWithValue("@SiteCode", sites.SiteCode);
                        cmd.Parameters.AddWithValue("@CompanyId", sites.CompanyId);
                        cmd.Parameters.AddWithValue("@SiteName", sites.SiteName);
                        cmd.Parameters.AddWithValue("@Address1", sites.AddressLine1);
                        cmd.Parameters.AddWithValue("@Address2", sites.AddressLine2);
                        cmd.Parameters.AddWithValue("@Town", sites.Town);
                        cmd.Parameters.AddWithValue("@County", sites.County);
                        cmd.Parameters.AddWithValue("@PostCode", sites.PostCode);
                        cmd.Parameters.AddWithValue("@Region", sites.Region);
                        cmd.Parameters.AddWithValue("@RegionId", sites.RegionId);
                        cmd.Parameters.AddWithValue("@Country", sites.Country);
                        cmd.Parameters.AddWithValue("@CreatedBy", sites.CreatedBy);
                        cmd.ExecuteNonQuery();
                    }
                }
                objSites.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objSites.Status = Status.Failed;
                objSites.Message = ex.Message;
                throw ex;
            }
            return objSites;
        }


        public Sites CheckSiteName(Sites sites)
        {
            Sites objSites = new Sites();
            try
            {
                objSites.IsSiteExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_CheckCompanySiteName";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sitename", sites.SiteName);
                        cmd.Parameters.AddWithValue("@CompanyId", sites.CompanyId);
                        cmd.Parameters.AddWithValue("@ActionType", sites.ActionType);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objSites.IsSiteExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objSites.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objSites.Status = Status.Failed;
                objSites.Message = ex.Message;
                throw ex;
            }
            return objSites;
        }

        public Sites CheckSiteCode(Sites sites)
        {

            Sites objSites = new Sites();
            try
            {
                objSites.IsSiteExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_SOS_CheckCompanySiteCode";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SiteCode", sites.SiteCode);
                        cmd.Parameters.AddWithValue("@CompanyId", sites.CompanyId);
                        cmd.Parameters.AddWithValue("@ActionType", sites.ActionType);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objSites.IsSiteExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objSites.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objSites.Status = Status.Failed;
                objSites.Message = ex.Message;
                throw ex;
            }
            return objSites;
        }

        /// <summary>
        /// Changes as per story Euw-727
        /// </summary>
        /// <param name="sites"></param>
        /// <returns>Sites</returns>
        public Sites GetSite(Sites sites)
        {
            Sites objSite = new Sites();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_PCustomer_GetSitesBySiteId]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CompanyId", Convert.ToString(sites.CompanyId));
                        cmd.Parameters.AddWithValue("@SiteId", Convert.ToString(sites.SiteId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                objSite.SiteId = string.IsNullOrEmpty(Convert.ToString(reader["SiteId"])) ? 0 : Convert.ToInt32(reader["SiteId"]);
                                objSite.SiteCode = Convert.ToString(reader["SiteCode"]);
                                objSite.SiteName = Convert.ToString(reader["SiteName"]);
                                objSite.Address = Convert.ToString(reader["Address_line1"]) + " " + Convert.ToString(reader["Address_line2"]);
                                objSite.AddressLine1 = Convert.ToString(reader["Address_line1"]);
                                objSite.AddressLine2 = Convert.ToString(reader["Address_line2"]);
                                objSite.PostCode = Convert.ToString(reader["PostCode"]);
                                objSite.Town = Convert.ToString(reader["Town"]);
                                objSite.County = Convert.ToString(reader["County"]);
                                objSite.CompanyId = string.IsNullOrEmpty(Convert.ToString(reader["CompanyId"])) ? 0 : Convert.ToInt32(reader["CompanyId"]);
                                objSite.RegionId = string.IsNullOrEmpty(Convert.ToString(reader["RegionId"])) ? 0 : Convert.ToInt32(reader["RegionId"]);
                                objSite.Region = Convert.ToString(reader["Region"]);
                                objSite.Country = Convert.ToString(reader["Country"]); 
                            }

                        }
                    }

                }
                objSite.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objSite.Status = Status.Failed;
                objSite.Message = ex.Message;
            }

            return objSite;

        }


        public Sites DeleteSiteInfo(Sites sites)
        {
            Sites objSite = new Sites();
            var results = 0;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "sp_PCustomer_DeleteSiteInfo";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@SiteId", sites.SiteIds);
                        cmd.Parameters.AddWithValue("@CreatedBy", sites.CreatedBy);
                        cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ResultMessage", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        results = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                        objSite.Message = Convert.ToString(cmd.Parameters["@ResultMessage"].Value);
                    }
                }
                if (results == 0)
                {
                    objSite.Status = Status.Failed;
                }
                else if (results == 1)
                {
                    objSite.Status = Status.Success;
                }
                
            }
            catch (Exception ex)
            {
                objSite.Status = Status.Failed;
                objSite.Message = ex.Message;
                throw ex;
            }
            return objSite;
        }
    }
}
