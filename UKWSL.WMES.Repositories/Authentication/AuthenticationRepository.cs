using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.DbContext;

namespace UKWSL.WMES.Repositories.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private string _connectionString;

        public AuthenticationRepository()
        {
             _connectionString = ConfigurationManager.ConnectionStrings["Hub2Connection"].ConnectionString;
        }
        public User Login(string userName, string password)
        {
            User loggedInUser = new User();
            
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "sp_UserLogin_Authentication";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", userName);
                    cmd.Parameters.AddWithValue("@UserPass", password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            loggedInUser.Id = string.IsNullOrEmpty(Convert.ToString(reader["UserId"])) ? 0 : Convert.ToInt32(reader["UserId"]);
                            loggedInUser.FirstName = Convert.ToString(reader["FirstName"]);
                            loggedInUser.UserName = Convert.ToString(reader["FirstName"]);
                            loggedInUser.LastName = Convert.ToString(reader["Surname"]);
                            loggedInUser.EmailAddress = Convert.ToString(reader["Email"]);
                        }
                    }
                    
                }
            }
            return loggedInUser;
        }

        public User GetUserdetails(string userName)
        {
            User loggedInUser = new User();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Sp_UserLogin_GetUserDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", userName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            loggedInUser.Id = string.IsNullOrEmpty(Convert.ToString(reader["UserId"])) ? 0 : Convert.ToInt32(reader["UserId"]);
                            loggedInUser.FirstName = Convert.ToString(reader["FirstName"]);
                            loggedInUser.UserName = Convert.ToString(reader["Email"]);
                            loggedInUser.LastName = Convert.ToString(reader["Surname"]);
                            loggedInUser.EmailAddress = Convert.ToString(reader["Email"]);
                            loggedInUser.MobileNumber = Convert.ToString(reader["MobileNo"]);
                            
                        }
                    }

                }
            }
            return loggedInUser;
        }
        public UserInfo GetUserRolesByUserId(User user)
        {

            UserInfo userInfo = new UserInfo();
            List<Roles> lstEntity = new List<Roles>();
            List<RoleFunctionPermission> lstRoleFunctionEntity = new List<RoleFunctionPermission>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Sp_Authentication_GetUserRolesByUserId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", user.Id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Roles UserRoles = new Roles();
                            UserRoles.RoleId = string.IsNullOrEmpty(Convert.ToString(reader["RoleId"])) ? 0 : Convert.ToInt32(reader["RoleId"]);
                            UserRoles.RoleName = Convert.ToString(reader["RoleName"]);
                            UserRoles.RoleDesc = Convert.ToString(reader["RoleDesc"]);
                            UserRoles.RoleCode = Convert.ToString(reader["RoleCode"]);
                            UserRoles.IsPrimary = string.IsNullOrEmpty(Convert.ToString(reader["IsPrimary"])) ? false : Convert.ToBoolean(reader["IsPrimary"]);
                            lstEntity.Add(UserRoles);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            RoleFunctionPermission roleFunctionPermission = new RoleFunctionPermission();
                            roleFunctionPermission.ModuleId =  string.IsNullOrEmpty(Convert.ToString(reader["ModuleId"])) ? 0 : Convert.ToInt32(reader["ModuleId"]);
                            roleFunctionPermission.MainModuleName = Convert.ToString(reader["MainModule_Name"]);
                            roleFunctionPermission.MFunctionId =  string.IsNullOrEmpty(Convert.ToString(reader["MFunctionId"])) ? 0 : Convert.ToInt32(reader["MFunctionId"]);
                            roleFunctionPermission.PageName = Convert.ToString(reader["Page_Name"]);
                            roleFunctionPermission.FunctionName = Convert.ToString(reader["Function_Name"]);
                            lstRoleFunctionEntity.Add(roleFunctionPermission);
                        }
                    }

                }
            }
            userInfo.lstRoleFunctionPermission = lstRoleFunctionEntity;
            userInfo.lstRoles = lstEntity;
            return userInfo;
        }

    }
}
