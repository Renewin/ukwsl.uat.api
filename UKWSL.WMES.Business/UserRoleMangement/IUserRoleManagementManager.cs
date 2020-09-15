using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.UserRoleMangement
{
    public interface IUserRoleManagementManager
    {       
        UserInfo GetUserRoles();
        UserInfo GetModuleAccessByRole(Roles roles);
        RoleFunctionPermission InsertUpdateFunctionPermission(RoleFunctionPermission roleFunctionPermission);
        UserInfo GetFunctionAccessibleByRole(Roles roles);
        UserInfo GetAllUserDetails();
        User CheckUserEmail(User user);
        User CreateUser(User user);
        User UpdateUser(User user);
        UserInfo GetUserRolesWithActiveUsers();
        UserInfo GetAllActiveUsersByRole(Roles roles);
        User UpdateUserPassword(User user);
        UserInfo GetAllUserDetailsView();
        UserInfo GetUserFuntions(User user);
        UserInfo GetDepartments();
        User UpdateBulkUserInformation(User user);
        UserInfo GetAllRolesByUser(User user);
    }
}
