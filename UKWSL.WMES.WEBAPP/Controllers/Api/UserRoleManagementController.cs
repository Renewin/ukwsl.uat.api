using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.UserRoleMangement;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class UserRoleManagementController : ApiController
    {
        private IUserRoleManagementManager userRoleMangementManager;

        public UserRoleManagementController(IUserRoleManagementManager manager)
        {
            userRoleMangementManager = manager;
        }

        [HttpPost]
        [ActionName("GetUserRoles")]
        public IHttpActionResult GetUserRoles()
        {
            var result = userRoleMangementManager.GetUserRoles();
            return Ok(result);
        }

        [HttpPost]
        [ActionName("GetModuleAccessByRoleId")]
        public IHttpActionResult GetModuleAccessByRole(Roles roles)
        {
            var result = userRoleMangementManager.GetModuleAccessByRole(roles);
            return Ok(result);
        }

        [HttpPost]
        [ActionName("InsertUpdateFunctionPermission")]
        public IHttpActionResult InsertUpdateFunctionPermission(RoleFunctionPermission roleFunctionPermission)
        {
            if (roleFunctionPermission != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(roleFunctionPermission.RoleId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(roleFunctionPermission.CreatedBy)))
                {
                    return Ok(new RoleFunctionPermission
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(userRoleMangementManager.InsertUpdateFunctionPermission(roleFunctionPermission));
                }
            }
            else
            {
                return Ok(new RoleFunctionPermission
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        [HttpPost]
        [ActionName("GetFunctionAccessibleByRole")]
        public IHttpActionResult GetFunctionAccessibleByRolse(Roles roles)
        {
            if (roles != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(roles.RoleId)))
                {
                    return Ok(new UserInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    return Ok(userRoleMangementManager.GetFunctionAccessibleByRole(roles));
                }
            }
            else
            {
                return Ok(new UserInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetAllUserDetails")]
        public IHttpActionResult GetAllUserDetails()
        {
            var result = userRoleMangementManager.GetAllUserDetails();
            return Ok(result);
        }

        [HttpPost]
        [ActionName("CheckUserEmail")]
        public IHttpActionResult CheckUserEmail(User user)
        {
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.EmailAddress))
                {
                    return Ok(new User
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = userRoleMangementManager.CheckUserEmail(user);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new User
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("CreateUser")]
        public IHttpActionResult CreateUser(User user)
        {
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.FirstName)
                    || string.IsNullOrEmpty(user.LastName)
                    || string.IsNullOrEmpty(user.EmailAddress)
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(user.DepartmentId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(user.FunctionId))
                    || string.IsNullOrEmpty(user.Roles))
                {
                    return Ok(new User
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = userRoleMangementManager.CreateUser(user);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new User
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("UpdateUser")]
        public IHttpActionResult UpdateUser(User user)
        {
            if (user != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(user.Id))
                    || string.IsNullOrEmpty(user.FirstName)
                    || string.IsNullOrEmpty(user.LastName)
                    || string.IsNullOrEmpty(user.EmailAddress)
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(user.DepartmentId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(user.FunctionId))
                    || string.IsNullOrEmpty(user.Roles))
                {
                    return Ok(new User
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = userRoleMangementManager.UpdateUser(user);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new User
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("BulkUpdateUserInformation")]
        public IHttpActionResult BulkUpdateUserInformation(User user)
        {
            if (user != null)
            {
                if (string.IsNullOrEmpty(Convert.ToString(user.Ids))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(user.DepartmentId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(user.FunctionId))
                )
                {
                    return Ok(new User
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = userRoleMangementManager.UpdateBulkUserInformation(user);
                   return Ok(result);
                }
            }
            else
            {
                return Ok(new User
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetUserRolesWithActiveUsers")]
        public IHttpActionResult GetUserRolesWithActiveUsers()
        {
            var result = userRoleMangementManager.GetUserRolesWithActiveUsers();
            return Ok(result);
        }

        [HttpPost]
        [ActionName("GetAllActiveUsersByRole")]
        public IHttpActionResult GetAllActiveUsersByRole(Roles roles)
        {
            var result = userRoleMangementManager.GetAllActiveUsersByRole(roles);
            return Ok(result);
        }
        [HttpPost]
        [ActionName("ChangePassword")]
        public IHttpActionResult ChangePassword(User user)
        {
            if (user != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(user.Id))
                    || string.IsNullOrEmpty(user.NewPassword)
                    || string.IsNullOrEmpty(user.OldPassword))
                {
                    return Ok(new User
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = userRoleMangementManager.UpdateUserPassword(user);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new User
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetAllUserDetailsView")]
        public IHttpActionResult GetAllUserDetailsView()
        {
            var result = userRoleMangementManager.GetAllUserDetailsView();
            return Ok(result);
        }

        [HttpPost]
        [ActionName("GetUserFuntions")]
        public IHttpActionResult GetUserFuntions(User user)
        {
            var result = userRoleMangementManager.GetUserFuntions(user);
            return Ok(result);
        }

        [HttpPost]
        [ActionName("GetDepartments")]
        public IHttpActionResult GetDepartments()
        {
            var result = userRoleMangementManager.GetDepartments();
            return Ok(result);
        }

        [HttpPost]
        [ActionName("GetAllRolesByUser")]
        public IHttpActionResult GetAllRolesByUser(User user)
        {
            var result = userRoleMangementManager.GetAllRolesByUser(user);
            return Ok(result);
        }
    }
}
