using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class UserInfo : Result
    {
        public User user { get; set; }
        public List<Roles> lstRoles {get;set;}
        public List<User> lstUsers { get; set; }
        public List<Modules> lstModules { get; set; }
        public List<RoleFunctionPermission> lstRoleFunctionPermission { get; set; }
        public int UserRoles { get; set; }
        public int InActiveUsers { get; set; }
        public int ActiveUsers { get; set; }
        public List<Department> lstDepartments { get; set; }
        public List<UserFunction> lstUserFunctions { get; set; }
    }
}
