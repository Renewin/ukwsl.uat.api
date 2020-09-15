using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.UserRoleMangement;

namespace UKWSL.WMES.Business.UserRoleMangement
{
    public class UserRoleManagementManager : IUserRoleManagementManager
    {
        private IUserRoleManagementRepository _userRoleManagementManager;
        public UserRoleManagementManager(IUserRoleManagementRepository userRoleMangementRepository)
        {
            _userRoleManagementManager = userRoleMangementRepository;
        }

        public UserInfo GetFunctionAccessibleByRole(Roles roles)
        {
            return _userRoleManagementManager.GetFunctionAccessibleByRole(roles);
        }

        public UserInfo GetModuleAccessByRole(Roles roles)
        {
            return _userRoleManagementManager.GetModuleAccessByRole(roles);
        }

        public UserInfo GetUserRoles()
        {
            return _userRoleManagementManager.GetUserRoles();
        }

        public RoleFunctionPermission InsertUpdateFunctionPermission(RoleFunctionPermission roleFunctionPermission)
        {
            return _userRoleManagementManager.InsertUpdateRoleFunctionPermission(roleFunctionPermission);
        }
        public UserInfo GetAllUserDetails()
        {
            return _userRoleManagementManager.GetAllUserDetails();
        }

        public User CheckUserEmail(User user)
        {
            return _userRoleManagementManager.CheckUserEmail(user);
        }

        public User CreateUser(User user)
        {
            return _userRoleManagementManager.CreateUser(user);
        }

        public User UpdateUser(User user)
        {
            return _userRoleManagementManager.UpdateUser(user);
        }

        public UserInfo GetUserRolesWithActiveUsers()
        {
            return _userRoleManagementManager.GetUserRolesWithActiveUsers();
        }

        public UserInfo GetAllActiveUsersByRole(Roles roles)
        {
            return _userRoleManagementManager.GetAllActiveUsersByRole(roles);
        }

        public User UpdateUserPassword(User user)
        {
            return _userRoleManagementManager.UpdateUserPassword(user);
        }

        public UserInfo GetAllUserDetailsView()
        {
            return _userRoleManagementManager.GetAllUserDetailsView();
        }
        public UserInfo GetUserFuntions(User user)
        {
            return _userRoleManagementManager.GetUserFuntions(user);
        }
        public UserInfo GetDepartments()
        {
            return _userRoleManagementManager.GetDepartments();
        }

        public User UpdateBulkUserInformation(User user)
        {
            return _userRoleManagementManager.UpdateBulkUserInformation(user);
        }

        public UserInfo GetAllRolesByUser(User user)
        {
            return _userRoleManagementManager.GetAllRolesByUser(user);
        }
    }
}
