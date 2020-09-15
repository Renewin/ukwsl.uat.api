using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.UserRoleMangement
{
    public class UserRoleManagementRepository : IUserRoleManagementRepository
    {
        private string _connectionString;

        public UserRoleManagementRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserInfo GetFunctionAccessibleByRole(Roles roles)
        {
            UserInfo userInfo = new UserInfo();
            List<RoleFunctionPermission> lstRoleFunctionEntity = new List<RoleFunctionPermission>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Role_GetFunctionAccessibleByRole";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleId", roles.RoleId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RoleFunctionPermission roleFunctionPermission = new RoleFunctionPermission();
                                roleFunctionPermission.ModuleId = string.IsNullOrEmpty(Convert.ToString(reader["ModuleId"])) ? 0 : Convert.ToInt32(reader["ModuleId"]);
                                roleFunctionPermission.MainModuleName = Convert.ToString(reader["MainModule_Name"]);
                                roleFunctionPermission.MFunctionId = string.IsNullOrEmpty(Convert.ToString(reader["MFunctionId"])) ? 0 : Convert.ToInt32(reader["MFunctionId"]);
                                roleFunctionPermission.PageName = Convert.ToString(reader["Page_Name"]);
                                roleFunctionPermission.IsGranted = string.IsNullOrEmpty(Convert.ToString(reader["IsGranted"])) ? false : Convert.ToBoolean(reader["IsGranted"]);
                                lstRoleFunctionEntity.Add(roleFunctionPermission);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstRoleFunctionPermission = lstRoleFunctionEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }

        public UserInfo GetModuleAccessByRole(Roles roles)
        {
            UserInfo userInfo = new UserInfo();
            List<Modules> lstEntity = new List<Modules>();

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Module_GetModuleAccessByRole";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleId", roles.RoleId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Modules modules = new Modules();
                                modules.ModuleId = string.IsNullOrEmpty(Convert.ToString(reader["ModuleId"])) ? 0 : Convert.ToInt32(reader["ModuleId"]);
                                modules.MFunctionId = string.IsNullOrEmpty(Convert.ToString(reader["MFunctionId"])) ? 0 : Convert.ToInt32(reader["MFunctionId"]);
                                modules.MainModuleName = Convert.ToString(reader["MainModule_Name"]);
                                modules.PageName = Convert.ToString(reader["Page_Name"]);
                                lstEntity.Add(modules);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstModules = lstEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }
        public UserInfo GetUserRoles()
        {
            UserInfo userInfo = new UserInfo();
            List<Roles> lstEntity = new List<Roles>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Role_GetAllRoleDetails";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Roles UserRoles = new Roles();
                                UserRoles.RoleId = string.IsNullOrEmpty(Convert.ToString(reader["RoleId"])) ? 0 : Convert.ToInt32(reader["RoleId"]);
                                UserRoles.RoleName = Convert.ToString(reader["RoleName"]);
                                UserRoles.RoleDesc = Convert.ToString(reader["RoleDesc"]);
                                UserRoles.RoleCode = Convert.ToString(reader["RoleCode"]);
                                lstEntity.Add(UserRoles);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstRoles = lstEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }

        public RoleFunctionPermission InsertUpdateRoleFunctionPermission(RoleFunctionPermission roleFunctionPermission)
        {
            int result = 0;
            RoleFunctionPermission entity = new RoleFunctionPermission();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Role_InsertUpdateRoleFunctionPermission";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleId", roleFunctionPermission.RoleId);
                        cmd.Parameters.AddWithValue("@FunctionId", roleFunctionPermission.FunctionId);
                        cmd.Parameters.AddWithValue("@CreatedBy", roleFunctionPermission.CreatedBy);
                        result = cmd.ExecuteNonQuery();


                    }
                }
                if (result > 0)
                    entity.Status = Status.Success;
                else
                    entity.Status = Status.Failed;
            }
            catch (Exception ex)
            {
                entity.Status = Status.Failed;
                entity.Message = ex.Message;
                throw ex;
            }
            return entity;
        }

        public UserInfo GetAllUserDetails()
        {
            UserInfo userInfo = new UserInfo();
            List<User> lstEntity = new List<User>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_Getalluserdetails";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User();
                                user.Id = string.IsNullOrEmpty(Convert.ToString(reader["UserId"])) ? 0 : Convert.ToInt32(reader["UserId"]);
                                user.RoleName = Convert.ToString(reader["RoleName"]);
                                user.FirstName = Convert.ToString(reader["firstName"]);
                                user.LastName = Convert.ToString(reader["lastName"]);
                                user.EmailAddress = Convert.ToString(reader["Email"]);
                                user.MobileNumber = Convert.ToString(reader["MobileNo"]);
                                user.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                lstEntity.Add(user);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstUsers = lstEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }

        public User CheckUserEmail(User user)
        {
            User objUser = new User();
            try
            {
                objUser.IsUserEmailExist = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_CheckUserEmailExist";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserEmail", user.EmailAddress);
                        cmd.Parameters.Add("@Result", SqlDbType.Int);
                        cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objUser.IsUserEmailExist = Convert.ToInt32(cmd.Parameters["@Result"].Value);
                    }
                }
                objUser.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objUser.Status = Status.Failed;
                objUser.Message = ex.Message;
                throw ex;
            }
            return objUser;
        }

        public User CreateUser(User user)
        {
            User objUser = new User();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_InsertUserInformation";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Email", user.EmailAddress);
                        cmd.Parameters.AddWithValue("@MobileNo", user.MobileNumber);
                        cmd.Parameters.AddWithValue("@PhoneNo", user.LandlineNo);
                        cmd.Parameters.AddWithValue("@Roles", user.Roles);
                        cmd.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                        cmd.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                        cmd.Parameters.AddWithValue("@FunctionId", user.FunctionId);
                        cmd.Parameters.AddWithValue("@JobTitle", user.JobTitle);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int);
                        cmd.Parameters["@ResultId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objUser.Id = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                objUser.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objUser.Status = Status.Failed;
                objUser.Message = ex.Message;
                throw ex;
            }
            return objUser;
        }

        public User UpdateUser(User user)
        {
            User objUser = new User();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_UpdateUserInformation";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", user.Id);
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Email", user.EmailAddress);
                        cmd.Parameters.AddWithValue("@MobileNo", user.MobileNumber);
                        cmd.Parameters.AddWithValue("@PhoneNo", user.LandlineNo);
                        cmd.Parameters.AddWithValue("@Roles", user.Roles);
                        cmd.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                        cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                        cmd.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                        cmd.Parameters.AddWithValue("@FunctionId", user.FunctionId);
                        cmd.Parameters.AddWithValue("@JobTitle", user.JobTitle);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int);
                        cmd.Parameters["@ResultId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objUser.Id = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                objUser.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objUser.Status = Status.Failed;
                objUser.Message = ex.Message;
                throw ex;
            }
            return objUser;
        }
        public User UpdateBulkUserInformation(User user)
        {
            User objUser = new User();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_BulkUpdateUserInformation";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", user.Ids);
                        cmd.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                        cmd.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                        cmd.Parameters.AddWithValue("@FunctionId", user.FunctionId);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int);
                        cmd.Parameters["@ResultId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objUser.Id = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                if (objUser.Id > 0)
                    objUser.Status = Status.Success;
            }
            catch (Exception ex)
            {
                objUser.Status = Status.Failed;
                objUser.Message = ex.Message;
                throw ex;
            }
            return objUser;
        }
        public UserInfo GetUserRolesWithActiveUsers()
        {
            UserInfo userInfo = new UserInfo();
            List<Roles> lstEntity = new List<Roles>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Role_GetallrolewithActiveusers";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Roles UserRoles = new Roles();
                                UserRoles.RoleId = string.IsNullOrEmpty(Convert.ToString(reader["RoleId"])) ? 0 : Convert.ToInt32(reader["RoleId"]);
                                UserRoles.RoleName = Convert.ToString(reader["RoleName"]);
                                UserRoles.TotalUsers = string.IsNullOrEmpty(Convert.ToString(reader["TotalUsers"])) ? 0 : Convert.ToInt32(reader["TotalUsers"]);
                                lstEntity.Add(UserRoles);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstRoles = lstEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }

        public UserInfo GetAllActiveUsersByRole(Roles roles)
        {
            UserInfo userInfo = new UserInfo();
            List<User> lstEntity = new List<User>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_GetAllactiveusersbyRole";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleId", roles.RoleId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User();
                                user.Id = string.IsNullOrEmpty(Convert.ToString(reader["UserId"])) ? 0 : Convert.ToInt32(reader["UserId"]);
                                user.UserName = Convert.ToString(reader["UserName"]);
                                user.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                                user.FunctionName = Convert.ToString(reader["FunctionName"]);
                                lstEntity.Add(user);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstUsers = lstEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }

        public User UpdateUserPassword(User user)
        {
            User objUser = new User();
            int result = 0;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_ChangeUserPassword";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", user.Id);
                        cmd.Parameters.AddWithValue("@NewPassword", user.NewPassword);
                        cmd.Parameters.AddWithValue("@OldPassword", user.OldPassword);
                        cmd.Parameters.Add("@ResultId", SqlDbType.Int);
                        cmd.Parameters["@ResultId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@ResultId"].Value);
                    }
                }
                if (result != 1)
                {
                    objUser.Status = Status.Failed;
                }
            }
            catch (Exception ex)
            {
                objUser.Status = Status.Failed;
                objUser.Message = ex.Message;
                throw ex;
            }
            return objUser;
        }

        public UserInfo GetAllUserDetailsView()
        {
            UserInfo userInfo = new UserInfo();
            List<User> lstEntity = new List<User>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_Getalluserdetails";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userInfo.ActiveUsers = string.IsNullOrEmpty(Convert.ToString(reader["ActiveUsers"])) ? 0 : Convert.ToInt32(reader["ActiveUsers"]);
                                userInfo.InActiveUsers = string.IsNullOrEmpty(Convert.ToString(reader["InActiveUsers"])) ? 0 : Convert.ToInt32(reader["InActiveUsers"]);
                                userInfo.UserRoles = string.IsNullOrEmpty(Convert.ToString(reader["UserRoles"])) ? 0 : Convert.ToInt32(reader["UserRoles"]);
                            }
                            reader.NextResult();
                            while (reader.Read())
                            {
                                User user = new User();
                                user.Id = string.IsNullOrEmpty(Convert.ToString(reader["UserId"])) ? 0 : Convert.ToInt32(reader["UserId"]);
                                user.FirstName = Convert.ToString(reader["firstName"]);
                                user.LastName = Convert.ToString(reader["lastname"]);
                                user.EmailAddress = Convert.ToString(reader["Email"]);
                                user.MobileNumber = Convert.ToString(reader["MobileNo"]);
                                user.LandlineNo = Convert.ToString(reader["LandlineNo"]);
                                user.RoleName = Convert.ToString(reader["RoleName"]);
                                user.IsActive = string.IsNullOrEmpty(Convert.ToString(reader["IsActive"])) ? false : Convert.ToBoolean(reader["IsActive"]);
                                user.DepartmentId = string.IsNullOrEmpty(Convert.ToString(reader["DepartmentId"])) ? 0 : Convert.ToInt32(reader["DepartmentId"]);
                                user.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                                user.FunctionId = string.IsNullOrEmpty(Convert.ToString(reader["FunctionId"])) ? 0 : Convert.ToInt32(reader["FunctionId"]);
                                user.FunctionName = Convert.ToString(reader["FunctionName"]);
                                user.JobTitle = Convert.ToString(reader["JobTitle"]);
                                lstEntity.Add(user);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstUsers = lstEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }

        public UserInfo GetDepartments()
        {
            UserInfo userInfo = new UserInfo();
            List<Department> lstEntity = new List<Department>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_GetDepartment";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Department department = new Department();
                                department.DepartmentId = string.IsNullOrEmpty(Convert.ToString(reader["DepartmentId"])) ? 0 : Convert.ToInt32(reader["DepartmentId"]);
                                department.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                                lstEntity.Add(department);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstDepartments = lstEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }

        public UserInfo GetUserFuntions(User user)
        {
            UserInfo userInfo = new UserInfo();
            List<UserFunction> lstEntity = new List<UserFunction>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_GetFunction";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserFunction userFunction = new UserFunction();
                                userFunction.FunctionId = string.IsNullOrEmpty(Convert.ToString(reader["FunctionId"])) ? 0 : Convert.ToInt32(reader["FunctionId"]);
                                userFunction.FunctionName = Convert.ToString(reader["FunctionName"]);
                                lstEntity.Add(userFunction);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstUserFunctions = lstEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }

        public UserInfo GetAllRolesByUser(User user)
        {
            UserInfo userInfo = new UserInfo();
            List<Roles> lstEntity = new List<Roles>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "User_GetAllRolesbyUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", user.Id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Roles role = new Roles();
                                role.RoleId = string.IsNullOrEmpty(Convert.ToString(reader["RoleId"])) ? 0 : Convert.ToInt32(reader["RoleId"]);
                                role.RoleName = Convert.ToString(reader["RoleName"]);
                                role.RoleDesc = Convert.ToString(reader["RoleDesc"]);
                                lstEntity.Add(role);
                            }
                        }

                    }
                }
                userInfo.Status = Status.Success;
                userInfo.lstRoles = lstEntity;
            }
            catch (Exception ex)
            {
                userInfo.Status = Status.Failed;
                userInfo.Message = ex.Message;
                throw ex;
            }
            return userInfo;
        }
    }
}
