using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Authentication;

namespace UKWSL.WMES.Business.Authentication
{
    public  interface IAuthenticationManager
    {
        User GetLoggedInUser(string userName, string password);
        UserInfo GetUserRolesByUserId(User user);
    }
}
